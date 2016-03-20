(*
 * Caffettiera
 * MGen
 * main.fs: main code
 * (C) 2008 Alvise Spano' @ Netical
 *)
 
#light "off" 

open Caffettiera.FSharp.Generator.ClassModel
open Caffettiera.FSharp.Generator
open Caffettiera.FSharp.Common
open Caffettiera.FSharp.Common.Prelude

let ow = new Caffettiera.CSharp.Common.IO.ChapterWriter(System.Console.Out)

let modelbasename =
    let s = Filename.basename !Args.modelfilename
    in
        try Filename.chop_extension s
        with _ -> s

let generate_model limit modelname infos generate generate_compilation_item model outpath =
  begin
    let namespacename = something modelbasename !Args.namespacename in
    ow.WriteLine (sprintf "generating %s with" modelname);
    ow.BeginChapter ();
    ow.WriteLine (sprintf "Target Namespace = %s" namespacename);
    ow.WriteLine (sprintf "Output Path = %s" outpath);
    List.iter (fun (h, s) -> ow.WriteLine (sprintf "%s = %s" h s)) infos;
    ow.BeginChapter ();
    try
        let ci = generate namespacename model
        in
            Gen.generate_compilation_unit limit ow outpath generate_compilation_item ci
    finally
        ow.EndChapter ();
        ow.EndChapter ()
  end

let generate_wuc packagename (wuc : ComponentModel.wuc) =
    generate_model Config.Demo.wuc_limit (sprintf "WUC %s" wuc.view.name)
        [("Package Name", packagename)]
        (WUC.generate !Args.overwritewucext packagename)
        WUC.generate_compilation_item
        wuc
  
let generate_bll =
    generate_model Config.Demo.bll_limit "BLL" [] (BLL.generate !Args.overwritebllext) BLL.generate_compilation_item

let generate_bom =
    let nettiersname = somethings modelbasename [!Args.nettiersname; !Args.namespacename; !Args.dbname]
    and conntype = not !Args.noconntype
    in
        generate_model Config.Demo.bo_limit "BOM"
            ["NetTiers Namespace", nettiersname;
             "Generate Connector Types", conntype.ToString ();
             "Generate Bases", (!Args.genbase).ToString ()
             ]
            (BOM.generate !Args.genbase !Args.overwritebomext conntype nettiersname)
            BOM.generate_compilation_item
  
let generate_boam =
    let conntype = not !Args.noconntype
    in
        generate_model Config.Demo.bo_limit "BOAM"
            ["Generate Connector Types", conntype.ToString ();
             "Generate Bases", (!Args.genbase).ToString ()
             ]
            (BOAM.generate !Args.genbase !Args.overwritebomext conntype)
            BOAM.generate_compilation_item
            
let generate_ddl drops =
    let dbname = somethings modelbasename [!Args.dbname; !Args.nettiersname]
    and conntype = not !Args.noconntype
    in
        generate_model Config.Demo.ddl_limit "DDL"
            ["DataBase Name", dbname;
             "Generate Connector Types", conntype.ToString ();
             "Generate Bases", (!Args.genbase).ToString ();
             "Generate Drops", drops.ToString ();
             ]
            (fun _ -> DDL.generate !Args.genbase conntype dbname drops)
            DDL.generate_compilation_item

;;


try
  begin
    let eamodel = new Caffettiera.CSharp.Generator.EAAutomation.EAModel (ow, !Args.modelfilename) in
    
    if !Args.generate_all || !Args.generate_wuc then
      begin
        let wucs = eamodel.RetrieveWUCs (!Args.wucpackagepath, something null !Args.wucdiagramname) in
        let wucs = Caffettiera.FSharp.Common.CSharpInterop.list_of_enumerable (wucs :> System.Collections.Generic.IEnumerable<Caffettiera.CSharp.Generator.WUC>) in
        let wucs = List.map (fun (wuc : Caffettiera.CSharp.Generator.WUC) -> wuc.ToFSharp ()) wucs in
        let packagename = let l = String.split ['/'] !Args.wucpackagepath in List.nth l ((List.length l) - 1)
        in
            ow.WriteLine (sprintf "generating WUCs in package %s:" packagename);
            ow.BeginChapter ();
            let f wuc =
				try generate_wuc packagename wuc (somethings "./" [!Args.wucoutpath; !Args.outpath])
				with e -> ow.WriteLine (sprintf "FAILURE: %s" e.Message);
			in
				List.iter f wucs;
	            ow.EndChapter ();
      end;
	
	if !Args.generate_all || !Args.generate_bll then
	  begin
		let bllm = (eamodel.RetrieveBLLM !Args.blldiagrampath).ToFSharp ()
		in
			generate_bll bllm (somethings "./" [!Args.blloutpath; !Args.outpath])
	  end;  

    if !Args.generate_all || !Args.generate_bom || !Args.generate_boam || !Args.generate_ddl then
      begin
        let bomclassmodel = (eamodel.RetrieveBOM !Args.bomdiagrampath).ToFSharp ()
        in 
            if !Args.generate_all || !Args.generate_boam then
                generate_boam bomclassmodel (somethings "./" [!Args.boamoutpath; !Args.outpath]);
            if !Args.generate_all || !Args.generate_bom then
                generate_bom bomclassmodel (somethings "./" [!Args.bomoutpath; !Args.outpath]);
            if !Args.generate_all || !Args.generate_ddl then
                generate_ddl (not !Args.nodrops) bomclassmodel (somethings "./" [!Args.ddloutpath; !Args.outpath]);
      end;
	
    ow.WriteLine "exiting successfully";
  end
with e ->
  begin
    ow.ResetChapter ();
    ow.WriteLine ();
    ow.WriteLine "program terminated due to exception:";
    ow.BeginChapter ();
    ow.WriteLine (e.ToString ());
    ow.EndChapter ();
  end


