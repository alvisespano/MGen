(*
 * Caffettiera
 * MGen
 * gen.fs: general-purpose generation facilities
 * (C) 2008 Alvise Spano' @ Netical
 *)
 
#light "off" 

namespace Caffettiera.FSharp.Generator

module Gen =
  struct
  
    type 'a compilation_unit = Package of string * 'a compilation_unit list
							 | Code of string * bool * 'a
    
    let generate_compilation_unit limit (ow : Caffettiera.CSharp.Common.IO.ChapterWriter) path generate cu =
        let cnt = ref limit in
        let rec f fullname (di : System.IO.DirectoryInfo) = function
            Package (name, cus) ->
                let subdir = di.CreateSubdirectory name in
                ow.WriteLine (sprintf "creating package directory '%s':" (if fullname then subdir.FullName else name));
                ow.BeginChapter ();
                List.iter (f false subdir) cus;
                ow.EndChapter ()
            
          | Code (name, overwrite, x) ->
                decr cnt;                   
                let filename = sprintf "%s\\%s" di.FullName name in
                if Ver.demo_mode && !cnt < 0 then
                  begin
                        ow.WriteLine (sprintf "demo version limit exceeded: generation of code file '%s' skipped" (if fullname then filename else name));
                        ow.Flush ();
                  end
                else
                  begin
                    ow.Write (sprintf "generating code file '%s'..." (if fullname then filename else name));
                    ow.Flush ();
                    let exists = System.IO.File.Exists filename in
                    if not exists || overwrite then
                      begin
	                    use sw = System.IO.File.CreateText filename
		                in
			                sw.WriteLine (generate x : string);
				            ow.WriteLine (if exists then "overwritten" else "done")
				      end
				    else ow.WriteLine "skipped"
		          end
        in
            f true (System.IO.DirectoryInfo path) cu
            
    
    type template =
        Template of string list * string
      | TemplateMap of string list * (string * string) list * template
    
    type subst = (string * string) list
    
    let rec apply_subst_to_template subst = function
        Template (vars, t) ->
            let f (t : string) v =
                match List.try_assoc v subst with
                    Some x -> t.Replace (sprintf "$%s$" v, x)
                  | None   -> raise (System.ArgumentException (sprintf "apply_subst_to_template: unbound variable %s in substitution" v))
            in        
                List.fold_left f t vars 
       
      | TemplateMap (vars, maps, t) ->
            let subst' = List.map (fun (v, t) -> (v, apply_subst_to_template subst (Template (vars, t)))) maps
            in
                apply_subst_to_template (subst' @ subst) t
        
        
    let capitalize (s : string) =
        if s.Length > 0 then
            let head = (s.Substring (0, 1)).ToUpper ()
            in
                if s.Length > 1 then head ^ (s.Substring 1)
                else head
        else s
        
    let is_stereotype (st : string option) (s : string) =
		match st with
			None
		  | Some "" -> false
		  | Some s' -> s'.ToLower () = s.ToLower ()
        
	let on_stereotype (st : string option) (s : string) on_none on_equal on_different =
		match st with
			None
		  | Some ""									  -> on_none ()
		  | Some s' when s'.ToLower () = s.ToLower () -> on_equal s'
		  | s'										  -> on_different s'
    
  end