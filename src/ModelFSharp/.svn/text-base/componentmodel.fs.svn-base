(*
 * Caffettiera
 * MGen
 * componentmodel.fs: component model abstract representation
 * (C) 2008 Netical
 *)

#light "off" 

namespace Caffettiera.FSharp.Generator

module ComponentModel =
  struct
  
    open Caffettiera.FSharp.Common
    open Caffettiera.FSharp.Common.Prelude
    open Caffettiera.FSharp.Generator
    
    type componentt =
      { name        : string;
        stereotype	: string option;
        requires    : string list;
        provides    : string list;
        attributes	: ClassModel.attribute list;
        methods		: ClassModel.methodd list
      }
    
    type wuc =
      { view        : componentt;
        bo          : ClassModel.classs;
        dataobject  : ClassModel.classs;
      }   
      	          
    type connector = Dependency  	          
      	          
	type node = Component of componentt
		
	type edge = 
	    { name       : string option;
          stereotype : string option;
          connector  : connector;
        }
	
	type bllm = Graph.t<node, edge>
      
    exception IllFormed of string  
  
  
    (* high-level interface *)
    
    let get_relations conn (g : bllm) (n : node) =
        let p = function ({ connector = conn'; name = _; stereotype = _ }, _, Component _) when conn = conn' -> true | _ -> false in
        let conns = List.filter p (g.GetEdges n) in
        let (inc, out) = List.partition (function (_, Graph.Incoming, _) -> true | (_, Graph.Outgoing, _) -> false) conns
        in
            (List.map (fun (e, _, Component c) -> (e, c)) inc,
            List.map (fun (e, _, Component c) -> (e, c)) out)

    let get_uses g n =
        List.choose (function ({ name = _; stereotype = Some "use"; connector = Dependency}, c) -> Some c | _ -> None) (snd (get_relations Dependency g n))
  
  end