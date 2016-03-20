(*
 * Caffettiera
 * MGen
 * bom.fs: BOM generator
 * (C) 2008 Alvise Spano' @ Netical
 *)
 
#light "off" 

namespace Caffettiera.FSharp.Generator

module BOAM =
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
        
    let pretty_simple_ty = WUC.pretty_simple_ty
        
	let rec pretty_complex_ty namespacename = function 
		Tyabsyn.Special (sp, id) -> sprintf (match sp with Tyabsyn.Bo -> "%s.BOM.%s" | Tyabsyn.Boa -> "%s.BOAM.%s") namespacename id
      | Tyabsyn.App (id, ty)	 -> sprintf "%s<%s>" id (pretty_complex_ty namespacename ty)
      | Tyabsyn.Simple si		 -> pretty_simple_ty si
            
    let pretty_ret_ty namespacename = function
		Tyabsyn.Void	  -> "void"
	  | Tyabsyn.Complex c -> pretty_complex_ty namespacename c
	  
    let pretty_attribute_ty = pretty_simple_ty
	let pretty_method_arg_ty = pretty_complex_ty
    let pretty_method_ret_ty = pretty_ret_ty
            
    
    (* generators *)
    
    let generate_compilation_item ci =
        apply_subst_to_template
            [("NAME", ci.name);
             ("USINGS", ci.usings);
             ("NAMESPACE", capitalize ci.namespacename);
             ("BODY", flatten_strings "\n" ci.body);
             ]
             BOAMTemplates.compilation_item
    
    (* top level stuff *)
    
    let generate_usings () =
        apply_subst_to_template [] BOAMTemplates.usings
             
  
    (* business object avatars *)
  
    let generate_root_business_object_avatar name isabstract isvalidexpr body =
        apply_subst_to_template
            [("NAME", capitalize name);
             ("BASE", "");
             ("NEW", "");
             ("ABSTRACT", if isabstract then "abstract" else "");
             ("VIRTUAL", "virtual");
             ("BODY", body);
             ("ISVALIDEXPR", isvalidexpr);
             ]
             BOAMTemplates.business_object_avatar
             
    let generate_specialized_business_object_avatar basename name isabstract isvalidexpr body =
        apply_subst_to_template
            [("NAME", capitalize name);
             ("BASE", sprintf ": %s" (capitalize basename));
             ("NEW", "new");
             ("ABSTRACT", if isabstract then "abstract" else "");
             ("VIRTUAL", "override");
             ("BODY", body);
             ("ISVALIDEXPR", apply_subst_to_template ["EXPR", isvalidexpr] BOAMTemplates.specialized_isvalidexpr);
             ]
             BOAMTemplates.business_object_avatar
             
    (* relation properties *)
    
    let generate_simple_property name ty =
        apply_subst_to_template [("NAME", capitalize name); ("TYPE", pretty_attribute_ty ty)] BOAMTemplates.simple_property

    let generate_relation conntype name ty revtype source target template =
        apply_subst_to_template
            [("NAME", capitalize (something "" name));
             ("TYPE",  if conntype then ty else "");
             ("REVTYPE", if conntype then revtype else "");
             ("TARGET", capitalize target);
             ("SOURCE", capitalize source);
             ]
             template
    
    let generate_composition_or_aggregation conntype name ty revtype source target bodytemplate regiontemplate =
        let body = generate_relation conntype name ty revtype source target bodytemplate
        in
            apply_subst_to_template
                [("TARGET", capitalize target);
                 ("SOURCE", capitalize source);
                 ("BODY", body)
                 ]
                 regiontemplate

    let generate_composition_sourceside conntype name source target =
        generate_composition_or_aggregation conntype name
            Config.composition_connector_type_sourceside Config.composition_connector_type_targetside
            source target
            BOAMTemplates.aggregation_and_composition_body_sourceside
            BOAMTemplates.composition_region

    let generate_composition_targetside conntype name source target =
        generate_composition_or_aggregation conntype name
            Config.composition_connector_type_targetside Config.composition_connector_type_sourceside
            source target
            BOAMTemplates.aggregation_and_composition_body_targetside
            BOAMTemplates.composition_region
    
    let generate_aggregation_sourceside conntype name source target =
        generate_composition_or_aggregation conntype name
            Config.aggregation_connector_type_sourceside Config.aggregation_connector_type_targetside
            source target
            BOAMTemplates.aggregation_and_composition_body_sourceside
            BOAMTemplates.aggregation_region

    let generate_aggregation_targetside conntype name source target =
        generate_composition_or_aggregation conntype name
            Config.aggregation_connector_type_targetside Config.aggregation_connector_type_sourceside
            source target
            BOAMTemplates.aggregation_and_composition_body_targetside BOAMTemplates.aggregation_region
 
    let generate_association_sourceside conntype name source target =
        generate_relation conntype name
            Config.association_connector_type_sourceside Config.association_connector_type_targetside
            source target
            BOAMTemplates.association
            
    let generate_association_targetside conntype name source target =
        generate_relation conntype name
            Config.association_connector_type_targetside Config.association_connector_type_sourceside
            target source
            BOAMTemplates.association
 
 
	(* isvalid *)
  
    let generate_isvalidexpr attrs =
        match List.filter (function ({ name = _; stereotype = Some s; ty = _ } : ClassModel.attribute) -> (String.lowercase s) = Config.validable_attribute_stereotype | _ -> false) attrs with
            []    -> "true"
          | attrs -> mappen_strings (fun (a : ClassModel.attribute) -> apply_subst_to_template [("NAME", capitalize a.name)] BOAMTemplates.isvalidexpr_term) " && " attrs


	(* actions *)
	
	let generate_method_args namespacename args =
		mappen_strings (fun (ty, id) -> apply_subst_to_template [("TYPE", pretty_method_arg_ty namespacename ty); ("NAME", id)] BOAMTemplates.method_arg) ", " args

	let generate_ext_action_method namespacename name rty args =
		apply_subst_to_template [("NAME", capitalize name); ("RTYPE", pretty_method_ret_ty namespacename rty); ("ARGS", generate_method_args namespacename args)] BOAMTemplates.ext_action_method

	let generate_method_signature namespacename name rty args =
		apply_subst_to_template [("NAME", capitalize name); ("RTYPE", pretty_method_ret_ty namespacename rty); ("ARGS", generate_method_args namespacename args)] BOAMTemplates.method_signature

	let generate_ext main_template generate_method name methods =
		let actions = mappen_strings (fun (m : ClassModel.methodd) -> generate_method m.name m.return_ty m.args) "\n" methods
		in
			apply_subst_to_template [("NAME", name); ("ACTIONS", actions)] main_template

	let generate_ext_business_object_avatar_interface namespacename =
		generate_ext BOAMTemplates.ext_business_object_avatar_interface (generate_method_signature namespacename)

	let generate_ext_business_object_avatar namespacename =
		generate_ext BOAMTemplates.ext_business_object_avatar (generate_ext_action_method namespacename)

   
    
    (* main generator *)
        
    let generate genbase overwriteext conntype namespacename (g : ClassModel.bom) =
        let usings = generate_usings () in
        //let namespacename = sprintf "%s.BOAM" (capitalize namespacename) in
        let items =
            let f items = function
                ClassModel.Class cl as node ->
                    let mappen (f : ClassModel.edge * ClassModel.classs -> string) l = mappen_strings f "\n" l in
                
					let isbase = match cl.stereotype with None -> false | Some s -> s.ToLower () = Config.base_class_stereotype.ToLower () in

					if isbase && not genbase then items
					else
					  
						// get relations
						
						let (c, supertype) =
							let supertype = ClassModel.has_supertype g node in
							let (c, supertype) =
								match supertype with
									Some ({ name = _; stereotype = Some s; isabstract = _; attributes = _; methods = _ } as super)
										when s.ToLower () = Config.base_class_stereotype.ToLower () -> (ClassModel.merge_base_class super cl, None)
										
								  | _ -> (cl, supertype)
							in
								(c, supertype)
								
						and (targetsideaggrs, sourcesideaggrs) = ClassModel.get_aggregations g node
						and (targetsidecomps, sourcesidecomps) = ClassModel.get_compositions g node
						and (targetsideassocs, sourcesideassocs) = ClassModel.get_associations g node
						in
	                    
						// generate compositions
						let sourcesidecompsbody = mappen (fun (e, c') -> generate_composition_sourceside conntype e.name c'.name c.name) sourcesidecomps
						and targetsidecompsbody = mappen (fun (e, c') -> generate_composition_targetside conntype e.name c.name c'.name) targetsidecomps
	                    
						// generate aggregations
						and sourcesideaggrsbody = mappen (fun (e, c') -> generate_aggregation_sourceside conntype e.name c'.name c.name) sourcesideaggrs
						and targetsideaggrsbody = mappen (fun (e, c') -> generate_aggregation_targetside conntype e.name c.name c'.name) targetsideaggrs
	                    
						// generate associations
						and sourcesideassocsbody = mappen (fun (e, c') -> generate_association_sourceside conntype e.name c'.name c.name) sourcesideassocs
						and targetsideassocsbody = mappen (fun (e, c') -> generate_association_targetside conntype e.name c.name c'.name) targetsideassocs
	                   
						// generate attribute properties
						and simpleprops = mappen_strings (fun (a : ClassModel.attribute) -> generate_simple_property a.name a.ty) "\n" c.attributes
	                    
						// generate IsValid() expression
						and isvalidexpr = generate_isvalidexpr c.attributes

						in
	                    
						let body =
							simpleprops
							^ targetsidecompsbody ^ sourcesidecompsbody
							^ targetsideaggrsbody ^ sourcesideaggrsbody
							^ sourcesideassocsbody ^ targetsideassocsbody
						in
	                    
						let boa =
							let f =
								match supertype with
									Some c' -> generate_specialized_business_object_avatar c'.name
								  | None    -> generate_root_business_object_avatar
							in
								f c.name c.isabstract isvalidexpr body
						in        
	                      
						let methods =
							let f = function
								Some ""
							  | None    -> true
							  |	Some s  -> s.ToLower () = Config.boam_action_stereotype.ToLower ()
							in
								List.filter (fun (m : ClassModel.methodd) -> f m.stereotype) c.methods
						in
						let iextboa = generate_ext_business_object_avatar_interface namespacename c.name methods
						and extboa = generate_ext_business_object_avatar namespacename c.name methods
						in
							[
							Code (sprintf "%s.cs" (capitalize c.name), true,
								  { name = sprintf "Business Object Avatar %s" (capitalize c.name);
									usings = usings;
									namespacename = namespacename;
									body = [iextboa; boa] });
							 
							Code (sprintf "%s.ext.cs" (capitalize c.name), overwriteext,
								  { name = sprintf "Business Object Avatar %s Extension" (capitalize c.name);
									usings = usings;
									namespacename = namespacename;
									body = [extboa] })
							]
							@ items
            in
                g.FoldNodes f []
        in
            Package ("BOAM", items)
  
  end