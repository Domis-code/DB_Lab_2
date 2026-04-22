namespace Lab_2_DB.Models.KovosF2;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

public class KovaL
{
    [Display(Name = "ID")]
    public int Id { get; set; }

    [Display(Name = "Kovos eilė")]
    public int KovosEile { get; set; }

    [Display(Name = "Kovos data")]
    public DateTime KovosLaikasData { get; set; }

    [Display(Name = "Titulinė")]
    public string TitulineKova { get; set; } = string.Empty;

    [Display(Name = "Statusas")]
    public string Statusas { get; set; } = string.Empty;

    [Display(Name = "Renginys")]
    public string Renginys { get; set; } = string.Empty;
}

public class KovaCE
{
    public class KovaM
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Kovos eilė")]
        [Required]
        [Range(1, 100)]
        public int KovosEile { get; set; }

        [Display(Name = "Titulinė kova")]
        public bool TitulineKova { get; set; }

        [Display(Name = "Pastabos")]
        [StringLength(100)]
        public string? Pastabos { get; set; }

        [Display(Name = "Kovos data ir laikas")]
        [Required]
        public DateTime KovosLaikasData { get; set; }

        [Display(Name = "Kovos statusas")]
        [Required]
        public int KovosStatutas { get; set; }

        [Display(Name = "Svorio kategorija")]
        [Required]
        public int FkSvorioKategorija { get; set; }

        [Display(Name = "Renginys")]
        [Required]
        public string FkRenginys { get; set; } = string.Empty;

        [Display(Name = "Kovos taisyklės")]
        [Required]
        public string FkKovosTaisykles { get; set; } = string.Empty;
    }

    public class KovotojoDalyvavimasM
    {
        public int InListId { get; set; }

        [Display(Name = "Kovotojas")]
        [Required]
        public int FkKovotojai { get; set; }

        [Display(Name = "Baigties raundas")]
        [Required]
        [Range(1, 20)]
        public int BaigtiesRaundas { get; set; }

        [Display(Name = "Baigties laikas (min)")]
        [Required]
        [Range(0, 120)]
        public int BaigtiesLaikasMin { get; set; }

        [Display(Name = "Baigties laikas (sek)")]
        [Required]
        [Range(0, 59)]
        public int BaigtiesLaikasSek { get; set; }

        [Display(Name = "Baigties būdas")]
        [Required]
        public int BaigtiesBudas { get; set; }

        [Display(Name = "Rezultatas")]
        [Required]
        public int Rezultatas { get; set; }
    }

    public class ListsM
    {
        public IList<SelectListItem> KovosStatusai { get; set; } = new List<SelectListItem>();
        public IList<SelectListItem> SvorioKategorijos { get; set; } = new List<SelectListItem>();
        public IList<SelectListItem> Renginiai { get; set; } = new List<SelectListItem>();
        public IList<SelectListItem> KovosTaisykles { get; set; } = new List<SelectListItem>();
        public IList<SelectListItem> Kovotojai { get; set; } = new List<SelectListItem>();
        public IList<SelectListItem> BaigtiesBudai { get; set; } = new List<SelectListItem>();
        public IList<SelectListItem> Rezultatai { get; set; } = new List<SelectListItem>();
    }

    public KovaM Kova { get; set; } = new KovaM();
    public IList<KovotojoDalyvavimasM> KovotojuDalyvavimai { get; set; } = new List<KovotojoDalyvavimasM>();
    public ListsM Lists { get; set; } = new ListsM();
}
