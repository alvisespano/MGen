(*
 * Caffettiera
 * MGen
 * wuc.fs: WebUserControl generator
 * (C) 2008 Alvise Spano' @ Netical
 *)
 
#light "off" 

namespace Caffettiera.FSharp.Generator

module WUC =
  struct
    open Caffettiera.FSharp.Common.Prelude  
    open Caffettiera.FSharp.Generator.Gen
  
    type ascx = string
    
    type cs =
      { name			: string;
        usings			: string;
        namespacename	: string;
        body			: string list;
      }    
  
    type compilation_item = Ascx of ascx | Cs of cs | Ext of cs
    
    let pretty_simple_ty = function
	    Tyabsyn.String _	-> "string"
      | Tyabsyn.Float		-> "double"
      | Tyabsyn.Bool		-> "bool"
      | Tyabsyn.Char		-> "char"
      | Tyabsyn.Int			-> "int"
      | Tyabsyn.Datetime	-> "DateTime"
      | Tyabsyn.Decimal _   -> "decimal"
      | Tyabsyn.Binary      -> "byte[]"
      | Tyabsyn.Verbatim id	-> id
   
    let pretty_attribute_ty = pretty_simple_ty

          
    (* top-level generators *)
       
    let generate_cs cs =
        apply_subst_to_template
            [("NAME", cs.name);
             ("USINGS", cs.usings);
             ("NAMESPACE", capitalize cs.namespacename);
             ("BODY", flatten_strings "\n" cs.body);
             ]
             WUCTemplates.cs
       
    let generate_ascx (ascx : ascx) = ascx   
       
    let generate_compilation_item = function
        Ascx ascx   -> generate_ascx ascx
      | Ext cs
      | Cs cs       -> generate_cs cs

    let generate_cs_usings () =
        apply_subst_to_template [] WUCTemplates.cs_usings
        
        
    (* dataobjects *)    
        
    let generate_cs_dataobject name bo namespacename properties =
        apply_subst_to_template
            [("DO", capitalize name);
             ("BO", capitalize bo);
             ("NAMESPACE", namespacename);
             ("PROPERTIES", properties);
            ]
            WUCTemplates.cs_dataobject
        
    let generate_cs_dataobject_property name ty =
        apply_subst_to_template [("NAME", capitalize name); ("TYPE", pretty_attribute_ty ty)] WUCTemplates.cs_dataobject_property
              
    let generate_ext_dataobject name properties =
        apply_subst_to_template
            [("DO", capitalize name);
             ("PROPERTIES", properties);
            ]
            WUCTemplates.ext_dataobject
        
    let generate_ext_dataobject_property name ty =
        apply_subst_to_template [("NAME", capitalize name); ("TYPE", pretty_attribute_ty ty)] WUCTemplates.ext_dataobject_property
    
              
    (* grid *)         
            
    let generate_cs_grid_view name namespacename dataobject bo columns =
        apply_subst_to_template
            ["NAME", capitalize name;
             "NAMESPACE", namespacename;
             "DO", capitalize dataobject;
             "BO", capitalize bo;
             "COLUMNS", columns;
            ]
            WUCTemplates.cs_grid_view 
            
    let generate_cs_grid_view_column name =
        apply_subst_to_template ["NAME", capitalize name] WUCTemplates.cs_grid_view_column
            
    let generate_cs_grid_presenter name namespacename dataobject bo =
		apply_subst_to_template
            ["NAME", capitalize name;
             "NAMESPACE", namespacename;
             "DO", capitalize dataobject;
             "BO", capitalize bo;
            ]
            WUCTemplates.cs_grid_presenter
            
    let generate_ext_grid_view name =
        apply_subst_to_template ["NAME", capitalize name] WUCTemplates.ext_grid_view         

    let generate_ext_grid_presenter name namespacename dataobject bo =
		apply_subst_to_template
            ["NAME", capitalize name;
             "NAMESPACE", namespacename;
             "DO", capitalize dataobject;
             "BO", capitalize bo;
            ]
            WUCTemplates.ext_grid_presenter
            
    let generate_ascx_grid namespacename filename wucname columns =
        apply_subst_to_template
            ["FILENAME", filename;
             "WUCNAME", capitalize wucname;
             "NAMESPACE", namespacename;
             "COLUMNS", columns;
            ]
            WUCTemplates.ascx_grid
 
	let generate_ascx_grid_column name =
		apply_subst_to_template ["NAME", capitalize name] WUCTemplates.ascx_grid_column
		
 
    (* form *)
             
    let generate_cs_form_view name namespacename dataobject bo =
        apply_subst_to_template
            ["NAME", capitalize name;
             "NAMESPACE", namespacename;
             "DO", capitalize dataobject;
             "BO", capitalize bo;
            ]
            WUCTemplates.cs_form_view
            
    let generate_ext_form_view name dataobject items =
        apply_subst_to_template
			["NAME", capitalize name;
			 "ITEMS", items;
			 "DO", capitalize dataobject;
			] WUCTemplates.ext_form_view         
            
    let generate_ext_form_view_item name =
        apply_subst_to_template ["NAME", capitalize name] WUCTemplates.ext_form_view_item
	
	let generate_cs_form_presenter name namespacename dataobject bo =
		apply_subst_to_template
            ["NAME", capitalize name;
             "NAMESPACE", namespacename;
             "DO", capitalize dataobject;
             "BO", capitalize bo;
            ]
            WUCTemplates.cs_form_presenter
            
    let generate_ext_form_presenter name namespacename dataobject bo =
		apply_subst_to_template
            ["NAME", capitalize name;
             "NAMESPACE", namespacename;
             "DO", capitalize dataobject;
             "BO", capitalize bo;
            ]
            WUCTemplates.ext_form_presenter 
	
	let generate_ascx_form_table_item name =
        apply_subst_to_template ["NAME", capitalize name] WUCTemplates.ascx_form_table_item

    let generate_ascx_form_table_insert_item required name ty =
		let (t, trq, subst) =
			match ty with
				Tyabsyn.String o ->
					let s = match o with None -> "" | Some n -> sprintf "%d" n
					in
						(WUCTemplates.ascx_form_table_insert_item_string,
						WUCTemplates.ascx_form_table_insert_item_string_required,
						["MAXLENGTH", s])
			
			  |	Tyabsyn.Int ->
						(WUCTemplates.ascx_form_table_insert_item_integer,
						WUCTemplates.ascx_form_table_insert_item_integer_required,
						[])

			  |	Tyabsyn.Datetime ->
						(WUCTemplates.ascx_form_table_insert_item_datetime,
						WUCTemplates.ascx_form_table_insert_item_datetime_required,
						[])
			
			  | _ -> raise (System.NotSupportedException (sprintf "simple type '%s' not supported as WUC field" (pretty_attribute_ty ty)))
		in
			apply_subst_to_template (["NAME", capitalize name] @ subst) (if required then trq else t)
			
    let generate_ascx_form namespacename filename wucname items insertitems =
        apply_subst_to_template
            ["FILENAME", filename;
             "WUCNAME", capitalize wucname;
             "NAMESPACE", namespacename;
             "ITEMS", items;
             "INSERTITEMS", insertitems;
            ]
            WUCTemplates.ascx_form
            
	(*
	 * generators
	 *)
 
    (* form *)         
            
    let generate_form namespacename packagename filenamebase (wuc : ComponentModel.wuc) =
        let usings = generate_cs_usings ()
        //and namespacename = sprintf "%s.%s" (capitalize namespacename) (capitalize packagename)
        and mappen_attrs (f : ClassModel.attribute -> string) = mappen_strings f "\n"
        and (simpleattrs, customattrs) = List.partition (fun (a : ClassModel.attribute) -> List.exists (fun (a' : ClassModel.attribute) -> a.name = a'.name) wuc.bo.attributes) wuc.dataobject.attributes
        in
        let ascx =
			let items = mappen_attrs (fun a -> generate_ascx_form_table_item a.name) wuc.dataobject.attributes
			and insertitems =
				let f (a : ClassModel.attribute) = generate_ascx_form_table_insert_item (is_stereotype a.stereotype Config.required_attribute_stereotype) a.name a.ty
				in
					mappen_attrs f wuc.dataobject.attributes
			in
				generate_ascx_form namespacename filenamebase wuc.view.name items insertitems
        and cs =
            let dataobject =
				let props = mappen_attrs (fun a -> generate_cs_dataobject_property a.name a.ty) simpleattrs
				in
					generate_cs_dataobject wuc.dataobject.name wuc.bo.name namespacename props
            and view = generate_cs_form_view wuc.view.name namespacename wuc.dataobject.name wuc.bo.name
			and presenter = generate_cs_form_presenter wuc.view.name namespacename wuc.dataobject.name wuc.bo.name
            in
                { name = capitalize wuc.view.name;
                  usings = usings;
                  namespacename = namespacename;
                  body = [dataobject; view; presenter];
                }
        and ext =
			let dataobject =
				let props = mappen_attrs (fun a -> generate_ext_dataobject_property a.name a.ty) customattrs
				in
					generate_ext_dataobject wuc.dataobject.name props
            and view =
				let items = mappen_attrs (fun a -> generate_ext_form_view_item a.name) wuc.dataobject.attributes
                in
                    generate_ext_form_view wuc.view.name wuc.dataobject.name items
            and presenter = generate_ext_form_presenter wuc.view.name namespacename wuc.dataobject.name wuc.bo.name
            in
                { name = capitalize wuc.view.name;
                  usings = usings;
                  namespacename = namespacename;
                  body = [dataobject; view; presenter];
                }
        in
            [filenamebase, Ascx ascx;
             filenamebase, Cs cs;
             filenamebase, Ext ext]            
        
   
 
    (* grid *)
     
    let generate_grid namespacename packagename filenamebase (wuc : ComponentModel.wuc) =
        let usings = generate_cs_usings ()
        and namespacename = sprintf "%s.%s" (capitalize namespacename) (capitalize packagename)
        and mappen_attrs (f : ClassModel.attribute -> string) = mappen_strings f "\n"
        and (simpleattrs, customattrs) = List.partition (fun (a : ClassModel.attribute) -> List.exists (fun (a' : ClassModel.attribute) -> a.name = a'.name) wuc.bo.attributes) wuc.dataobject.attributes
        in
        let ascx =
			let columns = mappen_attrs (fun a -> generate_ascx_grid_column a.name) wuc.dataobject.attributes
			in
				generate_ascx_grid namespacename filenamebase wuc.view.name columns
        and cs =
            let dataobject =
				let props = mappen_attrs (fun a -> generate_cs_dataobject_property a.name a.ty) simpleattrs
				in
					generate_cs_dataobject wuc.dataobject.name wuc.bo.name namespacename props
            and view =
				let columns = mappen_attrs (fun a -> generate_cs_grid_view_column a.name) wuc.dataobject.attributes
                in
                    generate_cs_grid_view wuc.view.name namespacename wuc.dataobject.name wuc.bo.name columns
            and presenter = generate_cs_grid_presenter wuc.view.name namespacename wuc.dataobject.name wuc.bo.name
            in
                { name = capitalize wuc.view.name;
                  usings = usings;
                  namespacename = namespacename;
                  body = [dataobject; view; presenter];
                }
        and ext =
			let dataobject =
				let props = mappen_attrs (fun a -> generate_ext_dataobject_property a.name a.ty) customattrs
				in
					generate_ext_dataobject wuc.dataobject.name props
            and view = generate_ext_grid_view wuc.view.name
            and presenter = generate_ext_grid_presenter wuc.view.name namespacename wuc.dataobject.name wuc.bo.name
            in
                { name = capitalize wuc.view.name;
                  usings = usings;
                  namespacename = namespacename;
                  body = [dataobject; view; presenter];
                }
        in
            [filenamebase, Ascx ascx;
             filenamebase, Cs cs;
             filenamebase, Ext ext]            
        
        
    (* main *)    
        
    let generate overwriteext namespacename packagename (wuc : ComponentModel.wuc) =
        let filenamebase = capitalize wuc.view.name in
        let items =
            let f =
                match wuc.view.stereotype with
                    None -> raise (ComponentModel.IllFormed (sprintf "WUC '%s' has no stereotype" wuc.view.name))
                  | Some s when s.ToLower () = Config.grid_component_stereotype -> generate_grid 
                  | Some s when s.ToLower () = Config.form_component_stereotype -> generate_form

                  | Some s -> raise (System.NotImplementedException (sprintf "WebUserControl <<%s>> not yet implemented" s))
            in
                f namespacename packagename filenamebase wuc
        in
        let f (filenamebase, ci) =
            match ci with
                Ascx _ -> Code (sprintf "%s.ascx" filenamebase, true, ci)
              | Cs _   -> Code (sprintf "%s.ascx.cs" filenamebase, true, ci)
              | Ext _  -> Code (sprintf "%s.ext.cs" filenamebase, overwriteext, ci)
        in
            Package (packagename, List.map f items)
  
  end