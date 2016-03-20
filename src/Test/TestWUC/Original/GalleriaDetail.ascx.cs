using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Netical.Fotografia;
using Netical.Fotografia.BLL.BOM;

namespace Netical.Fotografia.UIL
{

    public delegate void WUC_GalleriaDetail_ActionEventHandler(WUC_GalleriaDetail sender, WUC_FormActionEventArgs e);

    public partial class WUC_GalleriaDetail : System.Web.UI.UserControl, WUC_IGalleria
    {
        public event WUC_GalleriaDetail_ActionEventHandler Action;

        GalleriaDetailPresenter _presenter;

        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new GalleriaDetailPresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            controlMessage.Text = "";
            if (!IsPostBack)
                Fill();
        }

        #region WUC Properties

        public FormViewMode ViewMode
        {
            get
            {
                return fview.CurrentMode;
            }
            set
            {
                fview.ChangeMode(value);
            }
        }

        public int UId
        {
            get
            {
                if (ViewState["UId"] == null)
                    return -1;
                else
                    return (int)ViewState["UId"];
            }
            set
            {
                ViewState["UId"] = value;
            }
        }

        #endregion

        #region WUC_IGalleria Members

        public Netical.Fotografia.BLL.BOM.Galleria DataObject
        {
            set
            {
                var list = new System.Collections.Generic.List<Netical.Fotografia.BLL.BOM.Galleria>();
                if (value != null)
                {
                    this.UId = value.UId;
                    list.Add(value);
                }
                fview.DataSource = list;
                fview.DataBind();
            }
        }

        #endregion

        public override void DataBind()
        {
            Fill();
        }

        private void Fill()
        {
            if (_presenter != null && Visible && this.UId >= 0)
                _presenter.Fill(this.UId);
            else
            {
                fview.DataSource = null;
                fview.DataBind();
            }
        }

        protected void fview_DataBound(object sender, EventArgs e)
        {
            switch (fview.CurrentMode)
            {
                case FormViewMode.ReadOnly:
                    {
                        var item = (Galleria)fview.DataItem;
                        if (item != null)
                        {
                            var lnkDelete = (LinkButton)fview.FindControl("btnDelete");
                            lnkDelete.Attributes.Add("onclick", "if (! confirm('Confermi?')) return false;");

                            var categoria = (Label)fview.FindControl("dataCategoria");
                            var titolo = (Label)fview.FindControl("dataTitolo");
                            var sede = (Label)fview.FindControl("dataSede");
                            var persona = (Label)fview.FindControl("dataPersona");
                            var indirizzo = (Label)fview.FindControl("dataIndirizzo");
                            var indirizzo2 = (Label)fview.FindControl("dataIndirizzo2");
                            var citta = (Label)fview.FindControl("dataCitta");
                            var cap = (Label)fview.FindControl("dataCAP");
                            var provincia = (Label)fview.FindControl("dataProvincia");
                            var nazione = (Label)fview.FindControl("dataNazione");
                            var telefono = (Label)fview.FindControl("dataTelefono");
                            var fax = (Label)fview.FindControl("dataFax");
                            var note = (Label)fview.FindControl("dataNote");

                            categoria.Text = item.AggregatedGalleriaCategoria.Nome;
                            titolo.Text = item.Titolo;
                            sede.Text = item.Sede;
                            persona.Text = item.Persona;
                            indirizzo.Text = item.Indirizzo;
                            indirizzo2.Text = item.Indirizzo2;
                            citta.Text = item.Citta;
                            cap.Text = item.CAP;
                            provincia.Text = item.Provincia;
                            nazione.Text = item.AggregatedNazione.Nome;
                            telefono.Text = item.Telefono;
                            fax.Text = item.Fax;
                            note.Text = item.Note;
                        }
                    }
                    break;
                case FormViewMode.Edit:
                    {
                        var categoria = (DropDownList)fview.FindControl("dataCategoria");
                        var titolo = (TextBox)fview.FindControl("dataTitolo");
                        var sede = (TextBox)fview.FindControl("dataSede");
                        var persona = (TextBox)fview.FindControl("dataPersona");
                        var indirizzo = (TextBox)fview.FindControl("dataIndirizzo");
                        var indirizzo2 = (TextBox)fview.FindControl("dataIndirizzo2");
                        var citta = (TextBox)fview.FindControl("dataCitta");
                        var cap = (TextBox)fview.FindControl("dataCAP");
                        var provincia = (TextBox)fview.FindControl("dataProvincia");
                        var nazione = (DropDownList)fview.FindControl("dataNazione");
                        var telefono = (TextBox)fview.FindControl("dataTelefono");
                        var fax = (TextBox)fview.FindControl("dataFax");
                        var note = (TextBox)fview.FindControl("dataNote");

                        var item = (Galleria)fview.DataItem;
                        categoria.DataSource = _presenter.GetCategoriaList();
                        categoria.DataBind();
                        categoria.SelectedValue = item.AggregatedGalleriaCategoria.UId.ToString();
                        titolo.Text = item.Titolo;
                        sede.Text = item.Sede;
                        persona.Text = item.Persona;
                        indirizzo.Text = item.Indirizzo;
                        indirizzo2.Text = item.Indirizzo2;
                        citta.Text = item.Citta;
                        cap.Text = item.CAP;
                        provincia.Text = item.Provincia;
                        nazione.DataSource = _presenter.GetNazioneList();
                        nazione.DataBind();
                        nazione.SelectedValue = item.AggregatedNazione.UId.ToString();
                        telefono.Text = item.Telefono;
                        fax.Text = item.Fax;
                        note.Text = item.Note;
                    }
                    break;
                case FormViewMode.Insert:
                    {
                        var categoria = (DropDownList)fview.FindControl("dataCategoria");
                        var nazione = (DropDownList)fview.FindControl("dataNazione");

                        categoria.DataSource = _presenter.GetCategoriaList();
                        categoria.DataBind();
                        nazione.DataSource = _presenter.GetNazioneList();
                        nazione.DataBind();
                    }
                    break;
            }
        }

        protected void fview_ModeChanging(object sender, FormViewModeEventArgs e)
        {
            fview.ChangeMode(e.NewMode);
            Fill();
        }

        protected void fview_ItemDeleting(object sender, FormViewDeleteEventArgs e)
        {
            try
            {
                _presenter.DeleteItem(this.UId);
                if (Action != null) Action(this, new WUC_FormActionEventArgs(WUC_FormAction.Deleted, this.UId));
                this.UId = -1;
                Fill();
            }
            catch (Netical.Fotografia.Exception ex)
            {
                controlMessage.ShowErrorMessage(ex.Message);
            }
        }
        protected void fview_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            var categoriaid = Convert.ToInt32(((DropDownList)fview.FindControl("dataCategoria")).SelectedValue);
            var titolo = ((TextBox)fview.FindControl("dataTitolo")).Text;
            var sede = ((TextBox)fview.FindControl("dataSede")).Text;
            var persona = ((TextBox)fview.FindControl("dataPersona")).Text;
            var indirizzo = ((TextBox)fview.FindControl("dataIndirizzo")).Text;
            var indirizzo2 = ((TextBox)fview.FindControl("dataIndirizzo2")).Text;
            var citta = ((TextBox)fview.FindControl("dataCitta")).Text;
            var cap = ((TextBox)fview.FindControl("dataCAP")).Text;
            var provincia = ((TextBox)fview.FindControl("dataProvincia")).Text;
            var nazioneid = Convert.ToInt32(((DropDownList)fview.FindControl("dataNazione")).SelectedValue);
            var telefono = ((TextBox)fview.FindControl("dataTelefono")).Text;
            var fax = ((TextBox)fview.FindControl("dataFax")).Text;
            var note = ((TextBox)fview.FindControl("dataNote")).Text;

            fview.ChangeMode(FormViewMode.ReadOnly);
            try
            {
                _presenter.InsertItem(titolo, sede, persona, indirizzo, indirizzo2, citta, cap, provincia, telefono, fax, note, categoriaid, nazioneid); 
                if (Action != null) Action(this, new WUC_FormActionEventArgs(WUC_FormAction.Inserted, this.UId));
            }
            catch (Netical.Fotografia.Exception ex)
            {
                e.Cancel = true;
                controlMessage.ShowErrorMessage(ex.Message);
            }
        }

        protected void fview_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            var categoriaid = Convert.ToInt32(((DropDownList)fview.FindControl("dataCategoria")).SelectedValue);
            var titolo = ((TextBox)fview.FindControl("dataTitolo")).Text;
            var sede = ((TextBox)fview.FindControl("dataSede")).Text;
            var persona = ((TextBox)fview.FindControl("dataPersona")).Text;
            var indirizzo = ((TextBox)fview.FindControl("dataIndirizzo")).Text;
            var indirizzo2 = ((TextBox)fview.FindControl("dataIndirizzo2")).Text;
            var citta = ((TextBox)fview.FindControl("dataCitta")).Text;
            var cap = ((TextBox)fview.FindControl("dataCAP")).Text;
            var provincia = ((TextBox)fview.FindControl("dataProvincia")).Text;
            var nazioneid = Convert.ToInt32(((DropDownList)fview.FindControl("dataNazione")).SelectedValue);
            var telefono = ((TextBox)fview.FindControl("dataTelefono")).Text;
            var fax = ((TextBox)fview.FindControl("dataFax")).Text;
            var note = ((TextBox)fview.FindControl("dataNote")).Text;

            fview.ChangeMode(FormViewMode.ReadOnly);
            try
            {
                _presenter.SaveItem((int)fview.DataKey.Value, titolo, sede, persona, indirizzo, indirizzo2, citta, cap, provincia, telefono, fax, note, categoriaid, nazioneid);
                if (Action != null) Action(this, new WUC_FormActionEventArgs(WUC_FormAction.Inserted, this.UId));
            }
            catch (Netical.Fotografia.Exception ex)
            {
                e.Cancel = true;
                controlMessage.ShowErrorMessage(ex.Message);
            }
        }

        protected void fview_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Cancel":
                    if (Action != null) Action(this, new WUC_FormActionEventArgs(WUC_FormAction.Cancelled, this.UId));
                    break;
            }
        }
    }
}