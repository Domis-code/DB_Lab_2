using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab_2_DB.Models
{
    public class KovotojoSportoSaliuIstorija
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Narystės pradžia")]
        [Required(ErrorMessage = "Įveskite narystės pradžios datą")]
        [DataType(DataType.Date)]
        public DateTime NarystesPradzia { get; set; }

        [Display(Name = "Narystės pabaiga")]
        [Required(ErrorMessage = "Įveskite narystės pabaigos datą")]
        [DataType(DataType.Date)]
        public DateTime NarystesPabaiga { get; set; }

        [Display(Name = "Pastabos")]
        [StringLength(100)]
        public string? Pastabos { get; set; }

        [Display(Name = "Narystės tipas")]
        [Required(ErrorMessage = "Pasirinkite narystės tipą")]
        public int NarystesTipas { get; set; }

        [Display(Name = "Statusas")]
        public int? Statusas { get; set; }

        [Display(Name = "Kovotojas")]
        [Required(ErrorMessage = "Pasirinkite kovotoją")]
        public int FkKovotojai { get; set; }

        [Display(Name = "Sporto salė")]
        [Required(ErrorMessage = "Pasirinkite sporto salę")]
        [StringLength(255)]
        public string FkKovinioSportoSales { get; set; } = null!;

        public string? KovotojoVardasPavarde { get; set; }
        public string? SportoSalesPavadinimas { get; set; }
        public string? NarystesTipoPavadinimas { get; set; }
        public string? StatusoPavadinimas { get; set; }

        public IList<SelectListItem> NarystesTipaiList { get; set; } = new List<SelectListItem>();
        public IList<SelectListItem> StatusaiList { get; set; } = new List<SelectListItem>();
        public IList<SelectListItem> KovotojaiList { get; set; } = new List<SelectListItem>();
        public IList<SelectListItem> SportoSalesList { get; set; } = new List<SelectListItem>();
    }
}




