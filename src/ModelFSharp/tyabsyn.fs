(*
 * Caffettiera
 * MGen
 * tyabsyn.fs: type representation and abstract syntax
 * (C) 2008 Netical
 *)
 
#light "off" 
 
namespace Caffettiera.FSharp.Generator

module Tyabsyn =
  struct
	
	exception ParseError of string
	
	type special = Bo | Boa
	
	type simple = Verbatim of string
	 		    | String of int option
				| Int
				| Bool
				| Float
				| Datetime
				| Binary
				| Char
				| Decimal of (int * int) option
	
	type complex = Special of special * string
				 | App of string * complex
				 | Simple of simple
				 
	type ret = Void | Complex of complex
	
  end
  