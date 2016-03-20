(*
 * Caffettiera
 * MGen
 * classmodel.fs: class model abstract representation
 * (C) 2008 Netical
 *)
 
#light "off" 

namespace Caffettiera.FSharp.Generator

module ClassModel =
  struct
  
    open Caffettiera.FSharp.Common
    open Caffettiera.FSharp.Common.Prelude    
    open Caffettiera.FSharp.Generator.Tyabsyn
      
    type id = string
    
    type simple_ty = Caffettiera.FSharp.Generator.Tyabsyn.simple
    type complex_ty = Caffettiera.FSharp.Generator.Tyabsyn.complex
    type ret_ty = Caffettiera.FSharp.Generator.Tyabsyn.ret
    
    //type visibility = Private | Protected | Public | Package
    
    type attribute =
      { ty          : simple_ty;
        name        : id;
        //visibility  : visibility;
        stereotype  : string option;
      }
      
    type methodd =
      { return_ty   : ret_ty;
        name        : id;
        args        : (complex_ty * id) list;
        stereotype  : string option;
        //visibility  : visibility;
      }
    
    type classs =
      { name         : string;
        stereotype   : string option;
        isabstract   : bool;
        attributes   : attribute list;
        methods      : methodd list;
        //visibility  : visibility;
      }
      
    type connector = Specializes | Associates | Composes | Aggregates
    
    type node = Class of classs  
    
    type edge =
        { name       : string option;
          stereotype : string option;
          connector  : connector;
        }
      
    type bom = Graph.t<node, edge>
      
    exception IllFormed of string  
      
   
    (*
     * high-level interface
     *)  
        
    let __parse_ty parser where s = 
    	let lexbuf = Lexing.from_string s in
        let err header =
            let pos = lexbuf.EndPos.Column - 1 in
            let msg = if pos < s.Length then sprintf "at character '%c' at position %d in type '%s'" s.[pos] (pos + 1) s
					  else sprintf "past end of type '%s'" s
		    in
			    raise (ParseError (sprintf "syntax error in '%s' item: %s: %s" where header msg))
        in
            try parser Tylexer.token lexbuf
            with Parsing.Parse_error -> err "parse error"
               | Failure s           -> err s
	
    let parse_complex_ty item s = __parse_ty Typarser.complex item s
					
    let parse_simple_ty item s =
        try __parse_ty Typarser.simple item s
        with ParseError msg as e ->
            (try ignore (parse_complex_ty item s)
            with _ -> raise e);
            raise (ParseError (sprintf "%s. Hint: complex types are not allowed in this context" msg))
    
    let parse_ret_ty item s = __parse_ty Typarser.ret item s
     
    let has_supertype (g : bom) (Class c as n : node) =
        let p = function ({ connector = Specializes; name = _; stereotype = _ }, Graph.Outgoing, Class _) -> true | _ -> false
        in
            match List.filter p (g.GetEdges n) with
                [] -> None
                
              | [({ connector = Specializes; name = _; stereotype = _ }, Graph.Outgoing, Class c')] -> Some c'
              
              | l -> raise (IllFormed (sprintf "class '%s' has more than one supertype: %s"
                        c.name (mappen_strings (fun (_, _, Class c') -> c'.name) ", " l)))

    let get_relations conn (g : bom) (n : node) =
        let p = function ({ connector = conn'; name = _; stereotype = _ }, _, Class _) when conn = conn' -> true | _ -> false in
        let conns = List.filter p (g.GetEdges n) in
        let (inc, out) = List.partition (function (_, Graph.Incoming, _) -> true | (_, Graph.Outgoing, _) -> false) conns
        in
            (List.map (fun (e, _, Class c) -> (e, c)) inc,
            List.map (fun (e, _, Class c) -> (e, c)) out)

    let get_compositions g n = get_relations Composes g n
    
    let get_aggregations g n = get_relations Aggregates g n
    
    let get_associations g n = get_relations Associates g n
    
	let merge_base_class (super : classs) (sub : classs) =
	  { name		= sub.name;
        stereotype  = sub.stereotype;
        isabstract  = sub.isabstract;
        attributes  = super.attributes @ sub.attributes;
        methods     = super.methods @ sub.methods;
      } : classs 
    
        
  end