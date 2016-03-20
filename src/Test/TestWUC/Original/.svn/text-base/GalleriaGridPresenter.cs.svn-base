using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Netical.Fotografia;

namespace Netical.Fotografia.UIL
{

    public interface WUC_IGalleriaList
    {
        ICollection<BLL.BOAM.Galleria> Gallerie { set; }
    }

    public class GalleriaGridPresenter
    {
        WUC_IGalleriaList _view;

        public GalleriaGridPresenter(WUC_IGalleriaList view)
        {
            _view = view;
        }

        public void Fill()
        {
            var list = new List<BLL.BOAM.Galleria>();
            foreach (var bo in BLL.BOM.Galleria.RetrieveAll())
                list.Add(bo);
            _view.Gallerie = list;

            //_view.Gallerie = Galleria.RetrieveAll();
        }

        public BLL.BOM.Galleria GetGalleria(int uid)
        {
            return BLL.BOM.Galleria.RetrieveByUId(uid);
        }

    }
}
