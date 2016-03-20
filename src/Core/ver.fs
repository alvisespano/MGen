(*
 * Caffettiera
 * MGen
 * ver.fs: version information
 * (C) 2008 Alvise Spano' @ Netical
 *)
 
#light "off" 

namespace Caffettiera.FSharp.Generator

module Ver =
  struct
    
    let demo_mode = false

    let major = 0
    let minor = 11
    let revision = 11

    let pretty = sprintf "%d.%d.%d%s" major minor revision (if demo_mode then " demo build" else "")
    
  end