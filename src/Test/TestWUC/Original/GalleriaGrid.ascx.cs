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

namespace Netical.Fotografia.UIL
{

    public delegate void WUC_GalleriaGrid_SelectedEventHandler(WUC_GalleriaGrid sender, int id);

    public partial class WUC_GalleriaGrid : System.Web.UI.UserControl, WUC_IGalleriaList
    {
        public event WUC_GalleriaGrid_SelectedEventHandler Selected;

        GalleriaGridPresenter presenter;
        protected void Page_Init(object sender, EventArgs e)
        {
            presenter = new GalleriaGridPresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) Fill();
        }

        public int SelectedUId
        {
            get
            {
                if (ViewState["SelectedUId"] == null)
                    return -1;
                else
                    return (int)ViewState["SelectedUId"];
            }
            set
            {
                ViewState["SelectedUId"] = value;
            }
        }

        #region WUC_IGalleriaList Members

        public System.Collections.Generic.ICollection<BLL.BOAM.Galleria> Gallerie
        {
            set
            {
                gridGalleria.DataSource = value;
                gridGalleria.DataBind();
            }
        }

        #endregion

        protected void Fill()
        {
            if (presenter != null) presenter.Fill();
        }

        public override void DataBind()
        {
            Fill();
        }

        protected void gridGalleria_OnSelect(object sender, Obout.Grid.GridRecordEventArgs e)
        {
            if (Selected != null)
            {
                var grid = ((Obout.Grid.Grid)sender);
                if (grid.SelectedRecords != null && grid.SelectedRecords.Count == 1)
                {
                    var rowvalues = (Hashtable)grid.SelectedRecords[0];
                    var id = Convert.ToInt32(rowvalues["UId"]);
                    this.SelectedUId = id;
                    Selected(this, id);
                }
            }
        }

        protected void gridGalleria_Load(object sender, EventArgs e)
        {
            int selected = -1;
            if (gridGalleria.SelectedRecords != null && gridGalleria.SelectedRecords.Count == 1)
            {
                var rowvalues = (Hashtable)gridGalleria.SelectedRecords[0];
                selected = Convert.ToInt32(rowvalues["UId"]);
            }

            if (this.SelectedUId > 0)
            {
                if (this.SelectedUId != selected)
                {
                    var item = presenter.GetGalleria(this.SelectedUId);
                    Hashtable oRecord = new Hashtable();
                    oRecord.Add("UId", item.UId);
                    oRecord.Add("Titolo", item.Titolo);

                    gridGalleria.SelectedRecords = new ArrayList();
                    gridGalleria.SelectedRecords.Add(oRecord);
                }
            }
            else
                gridGalleria.SelectedRecords = new ArrayList();

            if (gridGalleria.DataSource == null) Fill();
        }

        protected void gridGalleria_RowDataBound(object sender, Obout.Grid.GridRowEventArgs e)
        {
            var row = (DataRowView)e.Row.DataItem;
            //var categoria = (BLL.BOAM.GalleriaCategoria)row.Row.ItemArray[row.Row.Table.Columns["AggregatedGalleriaCategoria"].Ordinal];
            var uid = (int)row.Row.ItemArray[row.Row.Table.Columns["UId"].Ordinal];
            var bo = presenter.GetGalleria(uid);
            e.Row.Cells[1].Text = bo.AggregatedGalleriaCategoria.Nome;
        }
    }

}
