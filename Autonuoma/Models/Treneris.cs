using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Autonuoma.Models
{
    public class Treneris
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Vardas")]
        [Required(ErrorMessage = "Įveskite vardą")]
        [StringLength(100)]
        public string Vardas { get; set; } = null!;

        [Display(Name = "Pavardė")]
        [Required(ErrorMessage = "Įveskite pavardę")]
        [StringLength(100)]
        public string Pavarde { get; set; } = null!;

        [Display(Name = "Specializacija")]
        [Required(ErrorMessage = "Įveskite trenerio specializaciją")]
        [StringLength(100)]
        public string Specializacija { get; set; } = null!;

        [Display(Name = "Pareigos")]
        [Required(ErrorMessage = "Įveskite trenerio pareigas")]
        [StringLength(100)]
        public string Pareigos { get; set; } = null!;

        [Display(Name = "Patirtis (metais)")]
        [Required(ErrorMessage = "Įveskite trenerio patirtį")]
        [Range(0, 100, ErrorMessage = "Patirtis turi būti intervale 0-100")]
        public int PatirtisMetais { get; set; }

        [Display(Name = "Sporto salė")]
        [Required(ErrorMessage = "Pasirinkite sporto salę, kurioje treneris dirba")]
        public string FkKovinioSportoSale { get; set; } = null!;

        public IList<SelectListItem> SportoSalesList { get; set; } = new List<SelectListItem>();
    }
}
