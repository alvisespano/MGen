(*
 * Caffettiera
 * MGen
 * bom.fs: BOM generator
 * (C) 2008 Alvise Spano' @ Netical
 *)
 
#light "off" 

namespace Caffettiera.FSharp.Generator

module BOM =
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
             BOMTemplates.compilation_item
    
    (* misc stuff *)
    
    let generate_usings () =
        apply_subst_to_template [] BOMTemplates.usings
            
    let generate_bo nettiersname =
        apply_subst_to_template [("NETTIERSNAME", nettiersname)] BOMTemplates.bo
    
    let generate_transaction nettiersname =
		apply_subst_to_template [("NETTIERSNAME", nettiersname)] BOMTemplates.transaction
    
	let generate_prop_assign name ty template =
		apply_subst_to_template [("NAME", capitalize name); ("TYPE", pretty_attribute_ty ty)] template

	let generate_prop_assigns template attrs =
		mappen_strings (fun (a : ClassModel.attribute) -> generate_prop_assign a.name a.ty template) "\n" attrs

	let generate_simple_property name ty =
        apply_subst_to_template [("NAME", capitalize name); ("TYPE", pretty_attribute_ty ty)] BOMTemplates.simple_property


    (* constructors *)
		
	let generate_constructors subst nettiersname namespacename name attrs =
		let subst' =
			[("NETTIERSNAME", nettiersname);
             ("NAMESPACE", namespacename);
             ("NAME", capitalize name);
            ]
		in
			apply_subst_to_template (subst' @ subst) BOMTemplates.constructors
			
    let generate_root_constructors =
        generate_constructors
            [("INTBASECONSTRUCTOR", "");
             ("EMPTYBASECONSTRUCTOR", "");
             ("ENTITYBASECONSTRUCTOR", "")
             ]
            
    let generate_specialized_constructors =
        generate_constructors
            [("INTBASECONSTRUCTOR", apply_subst_to_template [] BOMTemplates.specialized_intbaseconstructor);
             ("EMPTYBASECONSTRUCTOR", apply_subst_to_template [] BOMTemplates.specialized_emptybaseconstructor);
             ("ENTITYBASECONSTRUCTOR", apply_subst_to_template [] BOMTemplates.specialized_entitybaseconstructor);
             ]
            
            
    (* business objects *)
  
	let generate_business_object subst generate_constructors nettiersname namespacename name isabstract body attrs =
		let subst' =
			[("NETTIERSNAME", nettiersname);
			 ("NAMESPACE", namespacename);
             ("NAME", capitalize name);
             ("ABSTRACT", if isabstract then "abstract" else "");
             ("BODY", body);
             ("CONSTRUCTORS", generate_constructors nettiersname namespacename name attrs);
             ("PROPASSIGNS", generate_prop_assigns BOMTemplates.prop_assign_from_x_to_r attrs);
            ]
        in
			apply_subst_to_template (subst' @ subst) BOMTemplates.business_object
		
	let generate_root_business_object isvalidexpr =
        generate_business_object
            [("BASE", "");
             ("NEW", "");
             ("VIRTUAL", "virtual");
             ("ISVALIDEXPR", isvalidexpr);
             ]
            generate_root_constructors
             
    let generate_specialized_business_object basename isvalidexpr =
        generate_business_object
            [("BASE", sprintf "%s," (capitalize basename));
             ("NEW", "new");
             ("VIRTUAL", "override");
             ("ISVALIDEXPR", apply_subst_to_template ["EXPR", isvalidexpr] BOMTemplates.specialized_isvalidexpr);
             ]
             generate_specialized_constructors
             
    (* relation properties *)
    
    let generate_relation conntype name ty revtype nettiersname source target template =
        apply_subst_to_template
            [("NETTIERSNAME", nettiersname);
             ("NAME", capitalize (something "" name));
             ("TYPE",  if conntype then ty else "");
             ("REVTYPE", if conntype then revtype else "");
             ("TARGET", capitalize target);
             ("SOURCE", capitalize source);
             ]
             template
    
    let generate_composition_or_aggregation conntype name ty revtype nettiersname source target bodytemplate regiontemplate =
        let body = generate_relation conntype name ty revtype nettiersname source target bodytemplate
        in
            apply_subst_to_template
                [("TARGET", capitalize target);
                 ("SOURCE", capitalize source);
                 ("BODY", body)
                 ]
                 regiontemplate

    let generate_composition_sourceside conntype name nettiersname source target =
        generate_composition_or_aggregation conntype name
            Config.composition_connector_type_sourceside Config.composition_connector_type_targetside
            nettiersname source target
            BOMTemplates.aggregation_and_composition_body_sourceside
            BOMTemplates.composition_region

    let generate_composition_targetside conntype name nettiersname source target =
        generate_composition_or_aggregation conntype name
            Config.composition_connector_type_targetside Config.composition_connector_type_sourceside
            nettiersname source target
            BOMTemplates.aggregation_and_composition_body_targetside
            BOMTemplates.composition_region
    
    let generate_aggregation_sourceside conntype name nettiersname source target =
        generate_composition_or_aggregation conntype name
            Config.aggregation_connector_type_sourceside Config.aggregation_connector_type_targetside
            nettiersname source target
            BOMTemplates.aggregation_and_composition_body_sourceside
            BOMTemplates.aggregation_region

    let generate_aggregation_targetside conntype name nettiersname source target =
        generate_composition_or_aggregation conntype name
            Config.aggregation_connector_type_targetside Config.aggregation_connector_type_sourceside
            nettiersname source target
            BOMTemplates.aggregation_and_composition_body_targetside BOMTemplates.aggregation_region
 
    let generate_association_sourceside conntype name nettiersname source target =
        generate_relation conntype name
            Config.association_connector_type_sourceside Config.association_connector_type_targetside
            nettiersname source target
            BOMTemplates.association_sourceside
            
    let generate_association_targetside conntype name nettiersname source target =
        generate_relation conntype name
            Config.association_connector_type_targetside Config.association_connector_type_sourceside
            nettiersname source target
            BOMTemplates.association_targetside
 
 
    (* commits *)
  
    let generate_commit_relation conntype name ty revtype source target template =
        apply_subst_to_template
            [("SOURCE", capitalize source);
             ("TARGET", capitalize target);
             ("NAME", capitalize (something "" name));
             ("TYPE", if conntype then ty else "");
             ("REVTYPE", if conntype then revtype else "");
             ]
             template
             
    let generate_commit_composition_sourceside conntype name source target =
        generate_commit_relation conntype name
            Config.composition_connector_type_sourceside Config.composition_connector_type_targetside
            source target
            BOMTemplates.commit_composition_sourceside

    let generate_commit_composition_targetside conntype name source target =
        generate_commit_relation conntype name
            Config.composition_connector_type_targetside Config.composition_connector_type_sourceside
            source target
            BOMTemplates.commit_composition_targetside

    let generate_commit_composition_removal_sourceside conntype name source target =
        generate_commit_relation conntype name
            Config.composition_connector_type_sourceside Config.composition_connector_type_targetside
            source target
            BOMTemplates.commit_composition_removal_sourceside

    let generate_commit_aggregation_sourceside conntype name source target =
        generate_commit_relation conntype name
            Config.aggregation_connector_type_sourceside Config.aggregation_connector_type_targetside
            source target
            BOMTemplates.commit_aggregation_sourceside

    let generate_commit_aggregation_targetside conntype name source target =
        generate_commit_relation conntype name
            Config.aggregation_connector_type_targetside Config.aggregation_connector_type_sourceside
            source target
            BOMTemplates.commit_aggregation_targetside
      
    let generate_commit_association_sourceside conntype name source target =
         generate_commit_relation conntype name
            Config.association_connector_type_targetside Config.association_connector_type_sourceside
            source target
            BOMTemplates.commit_association_sourceside
            
    let generate_commit_association_targetside conntype name source target =
         generate_commit_relation conntype name
            Config.association_connector_type_sourceside Config.association_connector_type_targetside
            source target
            BOMTemplates.commit_association_targetside
            
    let generate_commit_supertype ty supertype =
        apply_subst_to_template [] BOMTemplates.commit_supertype

    let generate_commit_self () =
        apply_subst_to_template [] BOMTemplates.commit_self

    let generate_root_reccommit nettiersname body =
        apply_subst_to_template [("NETTIERSNAME", nettiersname); ("VIRTUAL", "virtual"); ("BODY", body)] BOMTemplates.reccommit

    let generate_specialized_reccommit nettiersname body =
        apply_subst_to_template [("NETTIERSNAME", nettiersname); ("VIRTUAL", "override"); ("BODY", body)] BOMTemplates.reccommit
    
    let generate_isvalidexpr attrs =
        match List.filter (function ({ name = _; stereotype = Some s; ty = _ } : ClassModel.attribute) -> (String.lowercase s) = Config.validable_attribute_stereotype | _ -> false) attrs with
            []    -> "true"
          | attrs -> mappen_strings (fun (a : ClassModel.attribute) -> apply_subst_to_template [("NAME", capitalize a.name)] BOMTemplates.isvalidexpr_term) " && " attrs


	(* actions *)
	
	let generate_method_args namespacename args =
		mappen_strings (fun (ty, id) -> apply_subst_to_template [("TYPE", pretty_method_arg_ty namespacename ty); ("NAME", id)] BOMTemplates.method_arg) ", " args

	let generate_ext_action_method namespacename name rty args =
		apply_subst_to_template [("NAME", capitalize name); ("RTYPE", pretty_method_ret_ty namespacename rty); ("ARGS", generate_method_args namespacename args)] BOMTemplates.ext_action_method

	let generate_method_signature namespacename name rty args =
		apply_subst_to_template [("NAME", capitalize name); ("RTYPE", pretty_method_ret_ty namespacename rty); ("ARGS", generate_method_args namespacename args)] BOMTemplates.method_signature

	let generate_ext main_template generate_method name methods =
		let actions = mappen_strings (fun (m : ClassModel.methodd) -> generate_method m.name m.return_ty m.args) "\n" methods
		in
			apply_subst_to_template [("NAME", name); ("ACTIONS", actions)] main_template

	let generate_ext_business_object_interface namespacename =
		generate_ext BOMTemplates.ext_business_object_interface (generate_method_signature namespacename)

	let generate_ext_business_object namespacename =
		generate_ext BOMTemplates.ext_business_object (generate_ext_action_method namespacename)

   
    
    (* main generator *)
        
    let generate genbase overwriteext conntype nettiersname namespacename (g : ClassModel.bom) =
        let usings = generate_usings () in
        //let namespacename = capitalize namespacename in
        //let namespacename = sprintf "%s.BOM" (capitalize namespacename) in
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
						let sourcesidecompsbody = mappen (fun (e, c') -> generate_composition_sourceside conntype e.name nettiersname c'.name c.name) sourcesidecomps
						and targetsidecompsbody = mappen (fun (e, c') -> generate_composition_targetside conntype e.name nettiersname c.name c'.name) targetsidecomps
	                    
						// generate aggregations
						and sourcesideaggrsbody = mappen (fun (e, c') -> generate_aggregation_sourceside conntype e.name nettiersname c'.name c.name) sourcesideaggrs
						and targetsideaggrsbody = mappen (fun (e, c') -> generate_aggregation_targetside conntype e.name nettiersname c.name c'.name) targetsideaggrs
	                    
						// generate associations
						and sourcesideassocsbody = mappen (fun (e, c') -> generate_association_sourceside conntype e.name nettiersname c'.name c.name) sourcesideassocs
						and targetsideassocsbody = mappen (fun (e, c') -> generate_association_targetside conntype e.name nettiersname c.name c'.name) targetsideassocs
	                    
						// generate commit
						and reccommit =
							let sourcesidecompcommits = mappen (fun (e, c') -> generate_commit_composition_sourceside conntype e.name c'.name c.name) sourcesidecomps
							and targetsidecompcommits = mappen (fun (e, c') -> generate_commit_composition_targetside conntype e.name c.name c'.name) targetsidecomps
							and sourcesidecompremovalcommits = mappen (fun (e, c') -> generate_commit_composition_removal_sourceside conntype e.name c'.name c.name) sourcesidecomps
							and sourcesideaggrcommits = mappen (fun (e, c') -> generate_commit_aggregation_sourceside conntype e.name c'.name c.name) sourcesideaggrs
							and targetsideaggrcommits = mappen (fun (e, c')  -> generate_commit_aggregation_targetside conntype e.name c.name c'.name) targetsideaggrs
							and sourcesideassoccommits = mappen (fun (e, c') -> generate_commit_association_sourceside conntype e.name c'.name c.name) sourcesideassocs
							and targetsideassoccommits = mappen (fun (e, c') -> generate_commit_association_targetside conntype e.name c.name c'.name) targetsideassocs
							and supercommit =
								match supertype with
									Some c' -> generate_commit_supertype c.name c'.name
								  | None    -> ""
							in
							let body =
								supercommit
								^ sourcesidecompcommits ^ sourcesideaggrcommits ^ sourcesideassoccommits
								^ sourcesidecompremovalcommits
								^ targetsidecompcommits ^ targetsideaggrcommits ^ targetsideassoccommits
								^ (generate_commit_self ())
							in
								match supertype with
									Some c' -> generate_specialized_reccommit nettiersname body
								  | None    -> generate_root_reccommit nettiersname body
	                        
						// generate attribute properties
						and simpleprops = mappen_strings (fun (a : ClassModel.attribute) -> generate_simple_property a.name a.ty) "\n" c.attributes
	                    
						// generate IsValid() expression
						and isvalidexpr = generate_isvalidexpr c.attributes

						in
	                    
						let body =
							simpleprops
							^ reccommit
							^ targetsidecompsbody ^ sourcesidecompsbody
							^ targetsideaggrsbody ^ sourcesideaggrsbody
							^ sourcesideassocsbody ^ targetsideassocsbody
						in
	                    
						let bo =
							let f =
								match supertype with
									Some c' -> generate_specialized_business_object c'.name
								  | None    -> generate_root_business_object
							in
								f isvalidexpr nettiersname namespacename c.name c.isabstract body c.attributes
						in        
	                    
						let methods =
							let f = function
								Some ""
							  | None    -> true
							  |	Some s  -> s.ToLower () = Config.bom_action_stereotype.ToLower ()
							in
								List.filter (fun (m : ClassModel.methodd) -> f m.stereotype) c.methods
						in
						let iextbo = generate_ext_business_object_interface namespacename c.name methods
						and extbo = generate_ext_business_object namespacename c.name methods
						in
							[
							Code (sprintf "%s.cs" (capitalize c.name), true,
								  { name = sprintf "Business Object %s" (capitalize c.name);
									usings = usings;
									namespacename = namespacename;
									body = [iextbo; bo] });
							 
							Code (sprintf "%s.ext.cs" (capitalize c.name), overwriteext,
								  { name = sprintf "Business Object %s Extension" (capitalize c.name);
									usings = usings;
									namespacename = namespacename;
									body = [extbo] })
							]
							@ items
					  
            in
                g.FoldNodes f []
        in
        let bo = Code ("BO.cs", true,
                       { name = "Generic Utils for Business Objects";
                         usings = usings;
                         namespacename = namespacename;
                         body = [generate_transaction nettiersname; generate_bo nettiersname];
                       })
        in
            Package ("BOM", bo :: items)
  
  end