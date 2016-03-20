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
        
        
        namespace GenTest
        {
        
        public partial class FatturaFormDataObject
        {
            
        }
        
public partial class FatturaFormView
		{
			protected override void Fill()
			{
				if (presenter != null && Visible && this.UId >= 0)
					presenter.Fill(this.UId);
				else
				{
					fview.DataSource = null;
					fview.DataBind();
				}
			}
			
			protected void fviewItemDeleting(object sender, FormViewDeleteEventArgs e)
			{
				try
				{
					presenter.Delete(this.UId);
					if (Action != null) Action(this, new FormActionEventArgs(FormAction.Deleted, this.UId));
					this.UId = -1;
					Fill();
				}
				catch (Exception exn)
				{
					controlMessage.ShowErrorMessage(exn.Message);
				}
			}
			
			protected void fviewItemInserting(object sender, FormViewInsertEventArgs e)
			{
				var dataobject = new FatturaFormDataObject();
				
				dataobject.Intestatario = ((TextBox)fview.FindControl("dataIntestatario")).Text;
dataobject.Descrizione = ((TextBox)fview.FindControl("dataDescrizione")).Text;
dataobject.Numero = ((TextBox)fview.FindControl("dataNumero")).Text;
dataobject.Data = ((TextBox)fview.FindControl("dataData")).Text;
								
				// write custom item insertion code here
				
				fview.ChangeMode(FormViewMode.ReadOnly);
				try
				{
					presenter.Insert(dataobject);
					if (Action != null) Action(this, new FormActionEventArgs(FormAction.Inserted, this.UId));
				}
				catch (Exception exn)
				{
					e.Cancel = true;
					controlMessage.ShowErrorMessage(exn.Message);
				}
			}

			protected void fviewItemUpdating(object sender, FormViewUpdateEventArgs e)
			{
				var uid = (int)fview.DataKey.Value;
				var dataobject = new FatturaFormDataObject(uid);
				
				dataobject.Intestatario = ((TextBox)fview.FindControl("dataIntestatario")).Text;
dataobject.Descrizione = ((TextBox)fview.FindControl("dataDescrizione")).Text;
dataobject.Numero = ((TextBox)fview.FindControl("dataNumero")).Text;
dataobject.Data = ((TextBox)fview.FindControl("dataData")).Text;

				// write custom item update code here
				
				fview.ChangeMode(FormViewMode.ReadOnly);
				try
				{
					presenter.Update(dataobject);
					if (Action != null) Action(this, new FormActionEventArgs(FormAction.Inserted, this.UId));
				}
				catch (Exception ex)
				{
					e.Cancel = true;
					controlMessage.ShowErrorMessage(ex.Message);
				}
			}

			protected void fviewItemCommand(object sender, FormViewCommandEventArgs e)
			{
				switch (e.CommandName)
				{
					case "Cancel":
						if (Action != null) Action(this, new FormActionEventArgs(FormAction.Cancelled, this.UId));
						break;
						
					// write custom command code here
				}
			}
		}
		
public partial class FatturaFormPresenter
		{
			public void Insert(FatturaFormDataObject dataobject)
		    {
				((GenTest.BOM.Fattura)dataobject).Commit();
				view.DataObject = dataobject;
			}
			
			public void Update(FatturaFormDataObject dataobject)
		    {
				((GenTest.BOM.Fattura)dataobject).Commit();
				view.DataObject = dataobject;
			}

			public void Delete(int uid)
			{
				var bo = GenTest.BOM.Fattura.RetrieveByUId(uid);
				if (bo == null) throw new BONotFoundException<GenTest.BOM.Fattura>(uid);
				bo.Remove();
				bo.Commit();
			}
		}
		
        
        }
        
