(*
 * Caffettiera
 * MGen
 * ddl.fs: DDL generator
 * (C) 2008 Alvise Spano' @ Netical
 *)
 
#light "off" 

namespace Caffettiera.FSharp.Generator

module DDL =
  struct
    open Caffettiera.FSharp.Generator
    open Caffettiera.FSharp.Generator.Gen
    open Caffettiera.FSharp.Common.Prelude
    open Caffettiera.FSharp.Common
  
    type compilation_item =
        { name			 : string;
          drops			 : string list;
          tables		 : string list;
          pk_constraints : string list;
          fk_constraints : string list;
        }
  
	let pretty_ty = function
		Tyabsyn.String (Some n)	-> sprintf "nvarchar(%d)" n
	  | Tyabsyn.String None		-> "ntext"
      | Tyabsyn.Float			-> "float"
      | Tyabsyn.Datetime		-> "datetime"
      | Tyabsyn.Binary  		-> "binary"
      | Tyabsyn.Bool			-> "bit"
      | Tyabsyn.Char			-> "nchar"
      | Tyabsyn.Int				-> "int"
      | Tyabsyn.Verbatim s		-> s
      
      | Tyabsyn.Decimal o ->
            let (a, b) = match o with
                            None -> Config.default_ddl_decimal_bounds
                          | Some (a, b) -> (a, b)
            in
                sprintf "decimal(%d, %d)" a b
  
  
    (* generators *)
    
    let generate_compilation_item ci =
        apply_subst_to_template
            [("NAME", ci.name);
             ("DROPS", flatten_strings "\n" ci.drops);
             ("TABLES", flatten_strings "\n" ci.tables);
             ("PKCONSTRAINTS", flatten_strings "\n" ci.pk_constraints);
             ("FKCONSTRAINTS", flatten_strings "\n" ci.fk_constraints);
             ]
             DDLTemplates.compilation_item
    
    let generate_create_table pk name fields fks =
        apply_subst_to_template
            [("NAME", capitalize name);
             ("FIELDS", flatten_strings ",\n" (fields @ [pk] @ fks));
             ]
             DDLTemplates.create_table
    
    let generate_root_create_table name =
        let pk = apply_subst_to_template [("NAME", capitalize name); ("IDENTITY", "IDENTITY(1,1)")] DDLTemplates.pk
        in
            generate_create_table pk name

    let generate_specialized_create_table name =
        let pk = apply_subst_to_template [("NAME", capitalize name); ("IDENTITY", "")] DDLTemplates.pk
        in
            generate_create_table pk name
    
    let generate_field name ty =
        apply_subst_to_template [("NAME", capitalize name); ("TYPE", pretty_ty ty)] DDLTemplates.field
 
    let generate_relation_fk conntype name ty target template =
        apply_subst_to_template
            [("NAME", capitalize (something "" name));
             ("TYPE", if conntype then ty else "");
             ("TARGET", capitalize target);
            ]
            template
    
    let generate_composition_fk conntype name target =
        generate_relation_fk conntype name Config.composition_connector_type_sourceside target DDLTemplates.composition_fk

    let generate_aggregation_fk conntype name target =
        generate_relation_fk conntype name Config.aggregation_connector_type_sourceside target DDLTemplates.aggregation_fk

    let generate_association_fk conntype name target =
        generate_relation_fk conntype name Config.association_connector_type_sourceside target DDLTemplates.association_fk

    let generate_alter_table_relation conntype name ty source target =
        apply_subst_to_template
            [("NAME", capitalize (something "" name));
             ("TYPE", if conntype then ty else "");
             ("SOURCE", capitalize source);
             ("TARGET", capitalize target);
             ]
             DDLTemplates.alter_table_relation

    let generate_alter_table_pk name =
        apply_subst_to_template [("NAME", capitalize name)] DDLTemplates.alter_table_pk
    
    let generate_alter_table_composition conntype name source target =
        generate_alter_table_relation conntype name Config.composition_connector_type_sourceside source target
        
    let generate_alter_table_aggregation conntype name source target =
        generate_alter_table_relation conntype name Config.aggregation_connector_type_sourceside source target
        
    let generate_alter_table_association conntype name source target =
        generate_alter_table_relation conntype name Config.association_connector_type_sourceside source target
     
    let generate_alter_table_subtype name supertype =
        apply_subst_to_template [("NAME", capitalize name); ("SUPERTYPE", capitalize supertype)] DDLTemplates.alter_table_subtype

    let generate_drop_relation_constraint conntype name ty source target =
        apply_subst_to_template
            [("NAME", capitalize (something "" name));
             ("TYPE", if conntype then ty else "");
             ("SOURCE", capitalize source);
             ("TARGET", capitalize target);
             ]
             DDLTemplates.drop_relation_constraint

    let generate_drop_composition_constraint conntype name source target =
        generate_drop_relation_constraint conntype name Config.composition_connector_type_sourceside source target

    let generate_drop_aggregation_constraint conntype name source target =
        generate_drop_relation_constraint conntype name Config.aggregation_connector_type_sourceside source target

    let generate_drop_association_constraint conntype name source target =
        generate_drop_relation_constraint conntype name Config.association_connector_type_sourceside source target

    let generate_drop_subtype_constraint name supertype =
        apply_subst_to_template [("NAME", capitalize name); ("SUPERTYPE", capitalize supertype)] DDLTemplates.drop_subtype_constraint

    let generate_drop_table name =
        apply_subst_to_template [("NAME", capitalize name)] DDLTemplates.drop_table

    
    
    (* main generator *)
               
    let generate genbase conntype dbname drops (g : ClassModel.bom) =
        let (constraintdrops, tabledrops, tables, pkconstraints, fkconstraints) =
            let f ((constraintdrops, tabledrops, tables, pkconstraints, fkconstraints) as z) = function
                ClassModel.Class cl as node ->
                    
                    let isbase = match cl.stereotype with None -> false | Some s -> s.ToLower () = Config.base_class_stereotype.ToLower () in

					if isbase && not genbase then z
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
								
						and (onesidecomps, manysidecomps) = ClassModel.get_compositions g node
						and (onesideaggrs, manysideaggrs) = ClassModel.get_aggregations g node
						and (holdersideassocs, sourcesideassocs) = ClassModel.get_associations g node
						in
	                    
						// generate table
						let table =
							let fields = List.map (fun (a : ClassModel.attribute) -> generate_field a.name a.ty) c.attributes
							and compfks = List.map (fun (e : ClassModel.edge, c' : ClassModel.classs) -> generate_composition_fk conntype e.name c'.name) onesidecomps
							and aggrfks = List.map (fun (e : ClassModel.edge, c' : ClassModel.classs) -> generate_aggregation_fk conntype e.name c'.name) onesideaggrs
							and assocfks = List.map (fun (e : ClassModel.edge, c' : ClassModel.classs) -> generate_association_fk conntype e.name c'.name) sourcesideassocs
							and g =
								match supertype with
									Some _ -> generate_specialized_create_table c.name
								  | None   -> generate_root_create_table c.name
							in
								g fields (compfks @ aggrfks @ assocfks)
	                    
						// generate pk constraint
						and pkconstraint = generate_alter_table_pk c.name
	                       
						// generate constraints
						and fkconstraints' =
							let compalters = List.map (fun (e : ClassModel.edge, c' : ClassModel.classs) -> generate_alter_table_composition conntype e.name c.name c'.name) onesidecomps
							and aggralters = List.map (fun (e : ClassModel.edge, c' : ClassModel.classs) -> generate_alter_table_aggregation conntype e.name c.name c'.name) onesideaggrs
							and assocalters = List.map (fun (e : ClassModel.edge, c' : ClassModel.classs) -> generate_alter_table_association conntype e.name c.name c'.name) sourcesideassocs
							and superalter =
								match supertype with
									Some c' -> [generate_alter_table_subtype c.name c'.name]
								  | None    -> []
							in
								superalter @ compalters @ aggralters @ assocalters
	                    
						// generate drops
						and tabledrop = generate_drop_table c.name
						and constraintdrops' =
							let compdrops = List.map (fun (e : ClassModel.edge, c' : ClassModel.classs) -> generate_drop_composition_constraint conntype e.name c.name c'.name) onesidecomps
							and aggrdrops = List.map (fun (e : ClassModel.edge, c' : ClassModel.classs) -> generate_drop_aggregation_constraint conntype e.name c.name c'.name) onesideaggrs
							and assocdrops = List.map (fun (e : ClassModel.edge, c' : ClassModel.classs) -> generate_drop_association_constraint conntype e.name c.name c'.name) sourcesideassocs
							and superdrop =
								match supertype with
									Some c' -> [generate_drop_subtype_constraint c.name c'.name]
								  | None    -> []
							in
								superdrop @ compdrops @ aggrdrops @ assocdrops
						in
							(constraintdrops @ constraintdrops',
							tabledrops @ [tabledrop],
							tables @ [table],
							pkconstraints @ [pkconstraint],
							fkconstraints @ fkconstraints')
            in
                g.FoldNodes f ([], [], [], [], [])
        in
            Code (sprintf "%s.sql" dbname, true,
				  { name = dbname;
					drops = if drops then constraintdrops @ tabledrops else [];
					tables = tables;
					pk_constraints = pkconstraints;
					fk_constraints = fkconstraints;
				  }) 
  end