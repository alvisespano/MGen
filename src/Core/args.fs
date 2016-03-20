(*
 * Caffettiera
 * MGen
 * args.fs: command line argument specification
 * (C) 2008 Alvise Spano' @ Netical
 *)
   
#light "off" 

namespace Caffettiera.FSharp.Generator

module Args =
  struct
  
    open Caffettiera.FSharp.Generator
    open Caffettiera.FSharp.Common
  
    let wucoutpath = ref None
    let blloutpath = ref None
    let bomoutpath = ref None
    let boamoutpath = ref None
    let ddloutpath = ref None
    let outpath = ref None
    let generate_all = ref true
    let generate_ddl = ref false
    let generate_bom = ref false
    let generate_boam = ref false
    let generate_bll = ref false
    let generate_wuc = ref false
    let overwritebomext = ref false
    let overwriteboamext = ref false
    let overwritewucext = ref false
    let overwritebllext = ref false
    let genbase = ref false
    let nodrops = ref false
    let noconntype = ref false
    let modelfilename = ref ""
    let nettiersname = ref None
    let namespacename = ref None
    let dbname = ref None
    let bomdiagrampath = ref Config.default_bom_class_diagram_path
    let blldiagrampath = ref Config.default_bll_component_diagram_path
    let wucpackagepath = ref Config.default_wuc_package_path
    let wucdiagramname = ref None
    

    let specl = [
        "-wuc",
            XArg.Unit (fun () -> generate_all := false; generate_wuc := true),
            ["turn off generate-all mode and activate WUC generation";
             "(default = generate all)"];
        
        "-bll",
            XArg.Unit (fun () -> generate_all := false; generate_bll := true),
            ["turn off generate-all mode and activate BLL generation";
             "(default = generate all)"];     
             
        "-bom",
            XArg.Unit (fun () -> generate_all := false; generate_bom := true),
            ["turn off generate-all mode and activate BOM generation";
             "(default = generate all)"];
        
        "-boam",
            XArg.Unit (fun () -> generate_all := false; generate_boam := true),
            ["turn off generate-all mode and activate BOAM generation";
             "(default = generate all)"];
        
        "-ddl",
            XArg.Unit (fun () -> generate_all := false; generate_ddl := true),
            ["turn off generate-all mode and activate DDL generation";
             "(default = generate all)"];
             
        "-generate-bases",
            XArg.Unit (fun () -> genbase := true),
            [sprintf "generate superclasses tagged with the '%s' stereotype" Config.base_class_stereotype;
             "(default = false)"];
             
        "-out",
            XArg.String ("PATH", fun s -> outpath := Some s),
	        ["put all generated code into path PATH";
	         "(default = ./)"];

        "-bom-diagram",
	        XArg.String ("PATH", fun s -> bomdiagrampath := s),
	        ["retrieve BOM class diagram from PATH in model repository";
	         sprintf "(default = \"%s\")" Config.default_bom_class_diagram_path];
        
        "-bll-diagram",
	        XArg.String ("PATH", fun s -> blldiagrampath := s),
	        ["retrieve BLL component diagram from PATH in model repository";
	         sprintf "(default = \"%s\")" Config.default_bll_component_diagram_path];
          
        "-wuc-package",
	        XArg.String ("PATH", fun s -> wucpackagepath := s),
	        ["retrieve WUC packages from PATH in model repository";
	         sprintf "(default = \"%s\")" Config.default_wuc_package_path];
        
        "-wuc-diagram",
            XArg.String ("NAME", fun s -> wucdiagramname := Some s),
	        ["assume NAME as the WUC class diagram name into each WUC package";
	         "(default = package name)"];
        
        "-db",
	        XArg.String ("NAME", fun s -> dbname := Some s),
	        ["assume NAME as the DataBase name for DDL generation";
	         "(default = NetTiers base namespace or MODEL basename)"];  
          
        "-nettiers",
	        XArg.String ("NAMESPACE", fun s -> nettiersname := Some s),
	        ["assume NAMESPACE as NetTiers base namespace";
	         "(default = namespace specified by -namespace or DB name or MODEL basename)"];

        "-namespace",
	        XArg.String ("NAME", fun s -> namespacename := Some s),
	        ["put generated code into namespace NAME";
	         "(default = MODEL basename)"];

        "-no-connector-types",
            XArg.Set noconntype,
            ["do not generate connector type in identifier names of relation properties"];

        "-no-drops",
            XArg.Set nodrops,
            ["don't generate drop statements in DDL code"];
        
        "-overwrite-bom-ext",
            XArg.Set overwritebomext,
            ["overwrite BOM extension source files"];
        
        "-overwrite-boam-ext",
            XArg.Set overwriteboamext,
            ["overwrite BOAM extension source files"];
        
        "-overwrite-bll-ext",
            XArg.Set overwritebllext,
            ["overwrite BLL extension source files"];
        
        "-overwrite-wuc-ext",
            XArg.Set overwritewucext,
            ["overwrite WUCs extension source files"];
        
        "-wuc-out",
	        XArg.String ("PATH", fun s -> generate_wuc := true; wucoutpath := Some s),
	        ["turn on WUC generation and override WUC output path into PATH";
	         "(dafault = ./ or PATH specified by the -out option)"];
	   
	    "-bll-out",
	        XArg.String ("PATH", fun s -> generate_bll := true; blloutpath := Some s),
	        ["turn on BLL generation and override BLL output path into PATH";
	         "(dafault = ./ or PATH specified by the -out option)"];
	   
	    "-bom-out",
	        XArg.String ("PATH", fun s -> generate_bom := true; bomoutpath := Some s),
	        ["turn on BOM generation and override BOM output path into PATH";
	         "(dafault = ./ or PATH specified by the -out option)"];
	         
	    "-boam-out",
	        XArg.String ("PATH", fun s -> generate_boam := true; boamoutpath := Some s),
	        ["turn on BOAM generation and override BOAM output path into PATH";
	         "(dafault = ./ or PATH specified by the -out option)"];
	     
	    "-ddl-out",
	        XArg.String ("PATH", fun s -> generate_ddl := true; ddloutpath := Some s),
	        ["turn on DDL generation and override DDL output path into PATH";
	         "(dafault = ./ or PATH specified by the -out option)"];
    ] 
      
    let usage = "usage: mgen [OPTION].. <MODEL>\n\n MODEL  EAP model repository input file\n\n OPTION"

    let error msg =
        printf "error: %s\n\n" msg;
        XArg.usage usage specl 3 2;
        exit 1
        
    ;;
    
    if (Array.length Sys.argv) < 2 then begin
        printf "MGen v%s\nWritten by Alvise Spano'\n(C) 2008-09 Netical - Simplicy into complexity [http://www.netical.it]\n\n" Ver.pretty;
        XArg.usage usage specl 3 2;
        exit 0
      end;
    let anon s =
        if !modelfilename <> "" then error "more than one MODEL input file specified"
        else modelfilename := s
    in
    XArg.parse usage specl anon;
    if !modelfilename = "" then error "no MODEL input file specified"
 
  end


