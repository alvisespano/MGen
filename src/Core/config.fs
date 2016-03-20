(*
 * Caffettiera
 * MGen
 * config.fs: static configuration bindings
 * (C) 2008 Alvise Spano' @ Netical
 *)
 
#light "off" 

namespace Caffettiera.FSharp.Generator

module Config =
  struct

    (* demo restrictions *)
    
    module Demo =
      struct
        let bo_limit = 5
        let wuc_limit = 5
        let bll_limit = 5
        let ddl_limit = 5
      end

	(* WUCs *)
	
	let default_wuc_package_path = "Model/WebUserControls"
    let validable_attribute_stereotype = "validable"
    let required_attribute_stereotype = "required"
    let grid_component_stereotype = "grid"
    let form_component_stereotype = "form"
    let wuc_id_suffix = "Control"
    
    (* BLL *)
    
    let default_bll_component_diagram_path = "Model/BLL/BLL"
	
	(* BOM *)
	
	let default_bom_class_diagram_path = "Model/BOM/BOM"
    let bom_action_stereotype = "bo"
    let boam_action_stereotype = "boa"
    let base_class_stereotype = "base"
    let association_connector_type_sourceside = "Associated"
    let association_connector_type_targetside = "Association"
    let composition_connector_type_sourceside = "Composed"
    let composition_connector_type_targetside = "Composition"
    let aggregation_connector_type_sourceside = "Aggregated"
    let aggregation_connector_type_targetside = "Aggregation"

    (* DDL *)
    
    let default_ddl_decimal_bounds = (18, 0)
    
  end