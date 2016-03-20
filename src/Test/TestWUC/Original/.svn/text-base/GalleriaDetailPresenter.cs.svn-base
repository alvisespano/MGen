using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;
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

public interface WUC_IGalleria
{
    Galleria DataObject { set; }
}

public class GalleriaDetailPresenter
{
    WUC_IGalleria _view;
    public GalleriaDetailPresenter(WUC_IGalleria view)
    {
        _view = view;
    }

    public void Fill(int uid)
    {
        _view.DataObject = Galleria.RetrieveByUId(uid);
    }

    public IEnumerable<Netical.Fotografia.BLL.BOM.GalleriaCategoria> GetCategoriaList()
    {
        return GalleriaCategoria.RetrieveAll();
    }

    public IEnumerable<Netical.Fotografia.BLL.BOM.Nazione> GetNazioneList()
    {
        return Nazione.RetrieveAll();
    }

    public void InsertItem(string titolo, string sede, string persona, string indirizzo, string indirizzo2, string citta, string cap, string provincia, string telefono, string fax, string note, int categoriauid, int nazioneuid)
    {
        var categoria = GalleriaCategoria.RetrieveByUId(categoriauid);
        if (categoria == null) throw new BONotFoundException<GalleriaCategoria>(categoriauid);
        var nazione = Nazione.RetrieveByUId(nazioneuid);
        if (nazione == null) throw new BONotFoundException<Nazione>(nazioneuid);

        var item = new Galleria();
        item.Titolo = titolo;
        item.Sede = sede;
        item.Persona = persona;
        item.Indirizzo = indirizzo;
        item.Indirizzo2 = indirizzo2;
        item.Citta = citta;
        item.CAP = cap;
        item.Provincia = provincia;
        item.Telefono = telefono;
        item.Fax = fax;
        item.Note = note;
        item.DataInserimento = DateTime.Now;
        item.Commit();

        categoria.AggregationGalleria.Add(item);
        nazione.AggregationGalleria.Add(item);
        item.Commit();

        _view.DataObject = item;
    }

    public void SaveItem(int uid, string titolo, string sede, string persona, string indirizzo, string indirizzo2, string citta, string cap, string provincia, string telefono, string fax, string note, int categoriauid, int nazioneuid)
    {
        var item = Galleria.RetrieveByUId(uid);
        if (item == null) throw new BONotFoundException<Galleria>(uid);
        var categoria = GalleriaCategoria.RetrieveByUId(categoriauid);
        if (categoria == null) throw new BONotFoundException<GalleriaCategoria>(categoriauid);
        var nazione = Nazione.RetrieveByUId(nazioneuid);
        if (nazione == null) throw new BONotFoundException<Nazione>(nazioneuid);

        item.Titolo = titolo;
        item.Sede = sede;
        item.Persona = persona;
        item.Indirizzo = indirizzo;
        item.Indirizzo2 = indirizzo2;
        item.Citta = citta;
        item.CAP = cap;
        item.Provincia = provincia;
        item.Telefono = telefono;
        item.Fax = fax;
        item.Note = note;
        item.Commit();

        categoria.AggregationGalleria.Add(item);
        nazione.AggregationGalleria.Add(item);
        item.Commit();

        _view.DataObject = item;
    }

    public void DeleteItem(int uid)
    {
        var item = Galleria.RetrieveByUId(uid);
        if (item == null) throw new BONotFoundException<Galleria>(uid);
        if (item.AggregationMostra.Count > 0) throw new BOException<Galleria>("Impossibile eliminare. Mostre collegate.");

        item.Remove();
        item.Commit();

    }

    public System.Collections.Generic.IList<Netical.Fotografia.BLL.BOM.Fotografo> GetFotografoList()
    {
        return Fotografo.RetrieveAll();
    }
}
}
