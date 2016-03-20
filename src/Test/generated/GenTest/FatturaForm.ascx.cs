//
        // UI/WebUserControls [C#]
        // FatturaForm
        //
        // Generated by Caffettiera
        // (C) 2008 Netical 
        //
        
        using System;
        using System.Data;
        using System.Configuration;
        using System.Web;
        using System.Web.Security;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        using System.Web.UI.WebControls.WebParts;
        using System.Web.UI.HtmlControls;
        using System.Collections.Generic;
        using Obout.Grid;
        using Caffettiera.CSharp.UI.WebUserControls.MVP;
        
        
        namespace WebUserControls
        {
        
        public partial class FatturaFormDataObject
        {
            private WebUserControls.BOM.Fattura bo;

			protected internal FatturaFormDataObject()
			{
				this.bo = new Fattura();
			}

            protected internal FatturaFormDataObject(WebUserControls.BOM.Fattura bo)
            {
                this.bo = bo;
            }

			protected internal FatturaFormDataObject(int uid)
			{
				this.bo = Fattura.RetrieveByUId(uid);
			}

            public int UId
            {
                get { return bo.UId; }
            }

			public static explicit operator Fattura(FatturaFormDataObject dataobject) { return dataobject.bo; }

            public string Intestatario
        {
            get { return bo.Intestatario; }
            set { bo.Intestatario = value; }
        }
        
public string Descrizione
        {
            get { return bo.Descrizione; }
            set { bo.Descrizione = value; }
        }
        
public int Numero
        {
            get { return bo.Numero; }
            set { bo.Numero = value; }
        }
        
public string Data
        {
            get { return bo.Data; }
            set { bo.Data = value; }
        }
        
        }
        
public partial class FatturaFormView : FormViewBase<FatturaFormDataObject>
        {
			public event ActionEventHandler Action;

			protected override void OnLoad(EventArgs e)
			{
				base.OnLoad(e);
				controlMessage.Text = "";
			}
			
            protected override IFormPresenter<FatturaFormDataObject> CreatePresenter()
            {
				return new FatturaFormPresenter(this);
            }
           
            public override FatturaFormDataObject DataObject
            {
                set
                {
                    grid.DataSource = value;
                    grid.DataBind();
                }
            }
            
            public FormViewMode ViewMode
			{
				get	{ return fview.CurrentMode; }
				set	{ fview.ChangeMode(value); }
			}
			
			protected void fviewModeChanging(object sender, FormViewModeEventArgs e)
			{
				fview.ChangeMode(e.NewMode);
				Fill();
			}
        }    
        
public partial class FatturaFormPresenter : FormPresenterBase<FatturaFormDataObject, WebUserControls.BOM.Fattura, WebUserControls.BOM.Transaction>
		{
			protected internal FatturaFormPresenter(IFormView<FatturaFormDataObject> view) : base(view) {}
			
			public void Fill(int uid)
			{
				view.DataObject = new FatturaFormDataObject(WebUserControls.BOM.Fattura.RetrieveByUId(uid));
			}
		}
		
        
        }
        
