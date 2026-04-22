using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Autonuoma.Models
{
    public class SvorioKategorija
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Sporto šaka")]
        [Required(ErrorMessage = "Įveskite kovinio sporto šaką")]
        [StringLength(100)]
        public string SportoSaka { get; set; } = null!;

        [Display(Name = "Kategorijos pavadinimas")]
        [Required(ErrorMessage = "Įveskite kovotojo kategoriją")]
        [StringLength(30)]
        public string KategorijosPavadinimas { get; set; } = null!;

        [Display(Name = "Min. svoris (kg)")]
        [Required]
        [Range(0.01, 300.0, ErrorMessage = "Svoris turi būti intervale 0,01-300")]
        public decimal MinKg { get; set; }

        [Display(Name = "Maks. svoris (kg)")]
        [Required]
        [Range(0.01, 300.0, ErrorMessage = "Svoris turi būti intervale 0,01-300")]
        public decimal MaxKg { get; set; }

        [Display(Name = "Amžiaus grupė")]
        [Required(ErrorMessage = "Įveskite amžiaus grupę")]
        [Range(1, 120, ErrorMessage = "Amžiaus grupė turi būti intervale 1-120")]
        public int AmziausGrupe { get; set; }

        [Display(Name = "Lytis")]
        [Required(ErrorMessage = "Pasirinkite lyties grupę")]
        public int LytiesGrupe { get; set; }

        public IList<SelectListItem> LytisList { get; set; } = new List<SelectListItem>();
    }
}
