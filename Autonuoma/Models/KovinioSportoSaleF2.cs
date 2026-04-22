namespace Lab_2_DB.Models;

using Microsoft.AspNetCore.Mvc.Rendering;

public class KovinioSportoSaleF2
{
    public KovinioSportoSale Sale { get; set; } = new KovinioSportoSale();
    public IList<Treneris> PriskirtiTreneriai { get; set; } = new List<Treneris>();
    public IList<SelectListItem> TreneriaiPasirinkimui { get; set; } = new List<SelectListItem>();
    public int? PasirinktasTrenerisId { get; set; }
}



