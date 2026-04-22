using System.ComponentModel.DataAnnotations;

namespace Autonuoma.Models
{
    public class Kovotojas
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

        [Display(Name = "Gimimo data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Įveskite gimimo datą")]
        public DateTime GimimoData { get; set; }

        [Display(Name = "Svoris (kg)")]
        [Required(ErrorMessage = "Įveskite kovotojo svorį")]
        [Range(20.0, 250.0, ErrorMessage = "Svoris turi būti intervale 20-250 kg")]
        public decimal SvorisKg { get; set; }

        [Display(Name = "Ūgis (cm)")]
        [Range(100, 260, ErrorMessage = "Ūgis turi būti intervale 100-260 cm")]
        public int? UgisCm { get; set; }
    }
}
