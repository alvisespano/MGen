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
using Caffettiera.CSharp.UI.WebUserControls.MVP;

namespace Netical.Fotografia.UIL
{

    public partial class FatturaGridDataObject
    {
        private GenTest.BOM.Fattura bo;

        protected internal FatturaGridDataObject(GenTest.BOM.Fattura bo)
        {
            this.bo = bo;
        }

        public int ID
        {
            get { return bo.UId; }
        }

        public string Intestatario
        {
            get { return bo.Intestatario; }
            set { bo.Intestatario = value; }
        }

        public int Numero
        {
            get { return bo.Numero; }
            set { bo.Numero = value; }
        }

    }


    public partial class FatturaGrid : GridViewBase<FatturaGridDataObject>
    {

        public override ICollection<FatturaGridDataObject> DataObjects
        {
            set
            {
                this.FatturaGridControl.DataSource = value;
                this.FatturaGridControl.DataBind();
            }
        }

        protected override void Fill()
        {
            if (presenter != null) presenter.Fill();
            // write a custom Fill() method implementation if necessary
        }

        protected void gridOnSelect(object sender, Obout.Grid.GridRecordEventArgs e)
        {
            var grid = ((Obout.Grid.Grid)sender);
            if (grid.SelectedRecords != null && grid.SelectedRecords.Count == 1)
            {
                var rowvalues = (Hashtable)grid.SelectedRecords[0];
                var id = Convert.ToInt32(rowvalues["UId"]);
                this.SelectedUId = id;
                if (Selected != null) Selected(this, id);
            }
        }

        protected void gridOnLoad(object sender, EventArgs e)
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

                    // da generare
                    oRecord.Add("Titolo", item.Titolo);
                    //

                    gridGalleria.SelectedRecords = new ArrayList();
                    gridGalleria.SelectedRecords.Add(oRecord);
                }
            }
            else
                gridGalleria.SelectedRecords = new ArrayList();

            if (gridGalleria.DataSource == null) Fill();
        }

        /*protected void gridOnRowDataBound(object sender, Obout.Grid.GridRowEventArgs e)
        {
            var row = (DataRowView)e.Row.DataItem;
            //var categoria = (BLL.BOAM.GalleriaCategoria)row.Row.ItemArray[row.Row.Table.Columns["AggregatedGalleriaCategoria"].Ordinal];
            var uid = (int)row.Row.ItemArray[row.Row.Table.Columns["UId"].Ordinal];
            var bo = presenter.GetGalleria(uid);
            e.Row.Cells[1].Text = bo.AggregatedGalleriaCategoria.Nome;
        }*/
    }

}
