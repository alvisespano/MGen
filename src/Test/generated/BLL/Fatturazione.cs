//
        // BLL [C#]
        // Fatturazione
        //
        // Generated by MGen/Caffettiera
        // (C) 2008 Netical 
        //
        
        using System;
        using System.Collections;
        using System.Collections.Generic;
        using Caffettiera.CSharp.Common;
        
        
        namespace GenTest.BLL
        {
        
        public interface IFatturazione
		{
			DateTime P2 { get; set; }
int P1 { get; set; }
			
			void H(double f);
string G();
void F(int count, List<GenTest.BOM.Fattura> fatture, GenTest.BOAM.RigaFattura riga);
		}
		
public partial class Fatturazione : IFatturazione
		{
		    protected IAnagrafica stubbedAnagrafica;
		    
		    public Fatturazione()
		    {
		        stubbedAnagrafica = new Anagrafica();
		    }
		
			public void F(int count, List<GenTest.BOM.Fattura> fatture, GenTest.BOAM.RigaFattura riga)
        {
             stubbedAnagrafica.F(count, riga);
        }
        
public string G()
        {
            return stubbedAnagrafica.G();
        }
        
public void H(double f)
        {
             stubbedAnagrafica.H(f);
        }
        
		}
		
        
        }
        
