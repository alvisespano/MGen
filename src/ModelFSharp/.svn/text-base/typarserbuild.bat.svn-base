@if "%_echo%"=="" echo off

setlocal

REM ------------------------------------------------------------------
REM Configure the sample, i.e. where to find the F# compiler and C# compiler.

if "%FSHARP_HOME%"=="" ( set FSHARP_HOME=C:\Programmi\FSharp-1.9.6.2)
if "%FSC%"=="" ( set FSC=%FSHARP_HOME%\bin\fsc.exe )
if "%FSYACC%"=="" ( set FSYACC=%FSHARP_HOME%\bin\fsyacc.exe )
if "%FSLEX%"=="" ( set FSLEX=%FSHARP_HOME%\bin\fslex.exe )

if "%CSC%"=="" ( 
  set CSC=csc.exe 
  for /f %%i in ('%FSHARP_HOME%\setup\cordir') do ( 
     if exist %%i\csc.exe ( set CSC=%%i\csc.exe )
  )
)

REM ------------------------------------------------------------------
ECHO Building lexer and parser...

%FSLEX% -o tylexer.fs tylexer.fsl
if ERRORLEVEL 1 goto Exit

%FSYACC% -o typarser.fs typarser.fsy
if ERRORLEVEL 1 goto Exit

	
:Exit
endlocal

exit /b %ERRORLEVEL%
