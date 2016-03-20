(*
 * Caffettiera
 * MGen
 * ddltemplates.fs: code template for DDL generation [MSSQL2005]
 * (C) 2008 Alvise Spano' @ Netical
 *)
 
#light "off" 

namespace Caffettiera.FSharp.Generator

module DDLTemplates =
  struct
    open Caffettiera.FSharp.Generator
    open Caffettiera.FSharp.Generator.Gen
    open Caffettiera.FSharp.Common.Prelude
  
    let compilation_item =
        Template (["NAME"; "DROPS"; "TABLES"; "PKCONSTRAINTS"; "FKCONSTRAINTS"],
        "/*
         * DDL
         * $NAME$ [MSSQL2005]
         *
         * Generated by MGen/Caffettiera
         * (C) 2008 Netical
         */
        
        USE $NAME$
        ;
        
        /* Drop constraints and tables */
        
        $DROPS$
        
        
        
        /* Tables */
        
        $TABLES$
        
        
        
        /* Constraints on Primary Keys */
        
        $PKCONSTRAINTS$
        
        
        
        /* Constraints on Foreign Keys */
        
        $FKCONSTRAINTS$
        ")
        
 
    let create_table =
        Template (["NAME"; "FIELDS"],
        "CREATE TABLE $NAME$ (
        $FIELDS$
        )
        ;
        ")
  
    let pk = Template (["IDENTITY"], "ID Integer NOT NULL $IDENTITY$")
  
    let fk = Template (["NAME"], "$NAME$ID Integer")
  
    let field = Template (["NAME"; "TYPE"], "$NAME$ $TYPE$ NOT NULL")
  
    let composition_fk = Template (["NAME"; "TYPE"; "TARGET"], "$NAME$$TYPE$$TARGET$ID Integer")
    
    let aggregation_fk = Template (["NAME"; "TYPE"; "TARGET"], "$NAME$$TYPE$$TARGET$ID Integer")
    
    let association_fk = Template (["NAME"; "TYPE"; "TARGET"], "$NAME$$TYPE$$TARGET$ID Integer UNIQUE")

    let alter_table_pk =
        Template (["NAME"],
        "ALTER TABLE $NAME$ ADD CONSTRAINT PK_$NAME$
	    PRIMARY KEY CLUSTERED (ID)
	    ;
	    ")
	    
	let __alter_table =
	    Template (["SOURCETABLE"; "SOURCEID"; "TARGETTABLE"; "TARGETID"; "FK"],
	    "ALTER TABLE $SOURCETABLE$ ADD CONSTRAINT FK_$FK$
	    FOREIGN KEY ($SOURCEID$) REFERENCES $TARGETTABLE$ ($TARGETID$)
	    ;
	    ")
	    
	let alter_table_subtype =    
	    TemplateMap (["NAME"; "SUPERTYPE"],
	    ["SOURCETABLE", "$NAME$";
	     "SOURCEID", "ID";
	     "FK", "$NAME$_$SUPERTYPE$";
	     "TARGETTABLE", "$SUPERTYPE$";
	     "TARGETID", "ID"],
	    __alter_table)
	    
	let alter_table_relation =    
	    TemplateMap (["SOURCE"; "TARGET"; "NAME"; "TYPE"],
	    ["SOURCETABLE", "$SOURCE$";
	     "SOURCEID", "$NAME$$TYPE$$TARGET$ID";
	     "FK", "$NAME$$TYPE$_$SOURCE$_$TARGET$";
	     "TARGETTABLE", "$TARGET$";
	     "TARGETID", "ID"],
	    __alter_table)
	    
	let alter_table_composition = alter_table_relation    
	    
	let alter_table_aggregation = alter_table_composition
	    
    let alter_table_association = alter_table_composition

    let __drop_statement =
        Template (["OBJECTID"; "OBJECTPROPERTY"; "BODY"],
        "IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('$OBJECTID$') AND OBJECTPROPERTY(id, '$OBJECTPROPERTY$') = 1)
        $BODY$
        ;
        ")
        
    let __drop_constraint =
        TemplateMap (["NAME"; "FK"],
        ["BODY", "ALTER TABLE $NAME$ DROP CONSTRAINT FK_$FK$";
         "OBJECTID", "FK_$FK$";
         "OBJECTPROPERTY", "IsForeignKey";
        ],
        __drop_statement)

    let drop_subtype_constraint =
        TemplateMap (["NAME"; "SUPERTYPE"],
        ["FK", "$NAME$_$SUPERTYPE$"],
        __drop_constraint)
        
    let drop_relation_constraint =
        TemplateMap (["SOURCE"; "TARGET"; "NAME"; "TYPE"],
        ["FK", "$NAME$$TYPE$_$SOURCE$_$TARGET$";
         "NAME", "$SOURCE$";
        ],
        __drop_constraint)

    let drop_table =
        TemplateMap (["NAME"],
         ["BODY", "DROP TABLE $NAME$";
         "OBJECTID", "$NAME$";
         "OBJECTPROPERTY", "IsUserTable";
        ],
        __drop_statement)
        
  end