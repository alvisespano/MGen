(*
 * Caffettiera
 * MGen
 * ddl.fs: DDL generator
 * (C) 2008 Alvise Spano' @ Netical
 *)
 
#light "off" 

namespace Caffettiera.FSharp.Generator

module BLL =
  struct
    open Caffettiera.FSharp.Generator
    open Caffettiera.FSharp.Generator.Gen
    open Caffettiera.FSharp.Common.Prelude
    open Caffettiera.FSharp.Common
  
    type compilation_item =
        { name			: string;
          usings		: string;
          namespacename : string;
	      body			: string list;
        }
        
    let pretty_attribute_ty = BOAM.pretty_attribute_ty
	let pretty_method_arg_ty = BOAM.pretty_method_arg_ty
	let pretty_method_ret_ty = BOAM.pretty_method_ret_ty
        
  
    (* generators *)
   
    let generate_compilation_item ci =
        apply_subst_to_template
            [("NAME", ci.name);
             ("USINGS", ci.usings);
             ("NAMESPACE", capitalize ci.namespacename);
             ("BODY", flatten_strings "\n" ci.body);
             ]
             BLLTemplates.compilation_item
    
    (* top level stuff *)
    
    let generate_usings () =
        apply_subst_to_template [] BLLTemplates.usings
        
    let generate_interface name props methods =
		apply_subst_to_template
			[("NAME", capitalize name);
			 ("PROPERTIES", flatten_strings "\n" props);
			 ("METHODS", flatten_strings "\n" methods)
			 ]
			 BLLTemplates.interfacee
			 
	let generate_stubbed_use (c : ComponentModel.componentt) =
        apply_subst_to_template ["NAME", capitalize c.name] BLLTemplates.stubbed_use
    
    let generate_stubbed_new (c : ComponentModel.componentt) =
        apply_subst_to_template ["NAME", capitalize c.name] BLLTemplates.stubbed_new      
		 
	let generate_class name uses news methods =
		apply_subst_to_template
			[("NAME", capitalize name);
			 ("METHODS", flatten_strings "\n" methods);
			 ("USES", flatten_strings ";\n" uses);
			 ("NEWS", flatten_strings ";\n" news);
			 ]
			 BLLTemplates.classs		 
			 
	let generate_ext_class name props methods =
		apply_subst_to_template
			[("NAME", capitalize name);
			 ("PROPERTIES", flatten_strings "\n" props);
			 ("METHODS", flatten_strings "\n" methods)
			 ]
			 BLLTemplates.ext_class
			 
	let generate_property_signature name ty =
		apply_subst_to_template [("NAME", capitalize name); ("TYPE", pretty_attribute_ty ty)] BLLTemplates.property_signature
			
	let generate_property_not_implemented name ty =
		apply_subst_to_template [("NAME", capitalize name); ("TYPE", pretty_attribute_ty ty)] BLLTemplates.property_not_implemented
			 
	let generate_method_arg namespacename (ty, id) =
		apply_subst_to_template [("NAME", id); ("TYPE", pretty_method_arg_ty namespacename ty)] BLLTemplates.method_arg
			 
	let generate_method subst template namespacename (m : ClassModel.methodd) =
		apply_subst_to_template
			([("NAME", capitalize m.name);
			 ("RTYPE", pretty_method_ret_ty namespacename m.return_ty);
			 ("ARGS", mappen_strings (generate_method_arg namespacename) ", " m.args)
			 ] @ subst)
			 template	 
			 
	let generate_method_signature = generate_method [] BLLTemplates.method_signature
	
	let generate_method_stub (c : ComponentModel.componentt) args r =
	    generate_method
	        ["APP", mappen_strings (fun (_, id) -> id) ", " args;
	         "BLL", capitalize c.name;
	         "RETURN", if r then "return" else "";
	        ]
	        BLLTemplates.method_stub
	
	let generate_method_not_implemented = generate_method [] BLLTemplates.method_not_implemented
	         

    
    (* main generator *)
    
    let is_arg_type_stubbable = function
        (Tyabsyn.Simple (Tyabsyn.String _), Tyabsyn.Simple (Tyabsyn.String _))  -> true
        
      | (Tyabsyn.Simple sty1, Tyabsyn.Simple sty2)                              -> sty1 = sty2
      
      | (Tyabsyn.Special (Tyabsyn.Bo, id1), Tyabsyn.Special (Tyabsyn.Bo, id2))    
      | (Tyabsyn.Special (Tyabsyn.Boa, id1), Tyabsyn.Special (Tyabsyn.Boa, id2))
      | (Tyabsyn.Special (Tyabsyn.Bo, id1), Tyabsyn.Special (Tyabsyn.Boa, id2))
      | (Tyabsyn.Special (Tyabsyn.Boa, id1), Tyabsyn.Special (Tyabsyn.Bo, id2)) -> id1 = id2
      
      | (Tyabsyn.App (id1, cty1), Tyabsyn.App (id2, cty2))                      -> id1 = id2 && cty1 = cty2
      
      | _                                                                       -> false
        
    let is_ret_type_stubbable = function
        (Tyabsyn.Void, Tyabsyn.Void)                 -> true
      | (Tyabsyn.Complex cty1, Tyabsyn.Complex cty2) -> is_arg_type_stubbable (cty1, cty2)
      | _                                            -> false
        
    let can_stub_method (m : ClassModel.methodd) (m' : ClassModel.methodd) =
        try
            if m.name = m'.name && is_ret_type_stubbable (m.return_ty, m'.return_ty) then
                let f (ty', id') = List.find (fun (ty, id) -> id = id' && is_arg_type_stubbable (ty, ty')) m.args
                in
                    Some (List.map f m'.args, m.return_ty <> Tyabsyn.Void)
            else None
        with :? System.Collections.Generic.KeyNotFoundException -> None   
    
    let can_stub_component m (c : ComponentModel.componentt) =
        match List.choose (can_stub_method m) c.methods with
            [args, r] -> Some (c, args, r)
          | _         -> None
               
    let generate overwriteext namespacename (g : ComponentModel.bllm) =
        let items =
            let f items (ComponentModel.Component c as n) =
                let uses = ComponentModel.get_uses g n in
                
                let stubbeduses = List.map generate_stubbed_use uses
                and stubbednews = List.map generate_stubbed_new uses
                
                and (stubbedmeths, notimplementedmeths) =
                    let f (stubbed, notimplemented) m =
                        match List.map (can_stub_component m) uses with
                            [Some (c, args, r)] -> (generate_method_stub c args r namespacename m :: stubbed, notimplemented)
                          | _                   -> (stubbed, generate_method_not_implemented namespacename m :: notimplemented)
                    in
                        List.fold_left f ([], []) c.methods
                
                and imeths = List.map (fun (m : ClassModel.methodd) -> generate_method_signature namespacename m) c.methods
                and iprops = List.map (fun (a : ClassModel.attribute) -> generate_property_signature a.name a.ty) c.attributes
                and notimplementedprops = List.map (fun (a : ClassModel.attribute) -> generate_property_not_implemented a.name a.ty) c.attributes
		        in
		        
		        let interf = generate_interface c.name iprops imeths
		        and cl = generate_class c.name stubbeduses stubbednews stubbedmeths
		        and extcl = generate_ext_class c.name notimplementedprops notimplementedmeths
		        in
    		        [Code (sprintf "%s.cs" (capitalize c.name), true,
				        { name = c.name;
				          usings = generate_usings ();
				          namespacename = namespacename;
				          body = [interf; cl] });
				          
				     Code (sprintf "%s.ext.cs" (capitalize c.name), overwriteext,
				        { name = c.name;
				          usings = generate_usings ();
				          namespacename = namespacename;
				          body = [extcl] })
				     ]
				     @ items
			in
			    g.FoldNodes f []
		in
            Package ("BLL", items)
      
      
  end