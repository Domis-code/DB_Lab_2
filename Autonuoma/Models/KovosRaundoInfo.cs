using System.ComponentModel.DataAnnotations;

namespace Lab_2_DB.Models
{
    public class KovosRaundoInfo
    {

        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Raundo numeris")]
        [Required(ErrorMessage = "Įveskite raundo numerį")]
        [Range(1, 20, ErrorMessage = "Raundo numeris turi būti intervale 1-20")]
        public int RaundoNumeris { get; set; }

        [Display(Name = "Raundo trukmė (min)")]
        [Range(0, 120, ErrorMessage = "Minutės turi būti intervale 0-120")]
        public int? RaundoTrukmeMin { get; set; }

        [Display(Name = "Raundo trukmė (sek)")]
        [Required(ErrorMessage = "Įveskite raundo sekundes")]
        [Range(0, 59, ErrorMessage = "Sekundės turi būti intervale 0-59")]
        public int RaundoTrukmeSek { get; set; }

        [Display(Name = "Pastabos")]
        [StringLength(100)]
        public string? Pastabos { get; set; }

        [Display(Name = "Raundo pabaiga")]
        [Required(ErrorMessage = "Pasirinkite raundo pabaigos tipą")]
        public int RaundoPabaiga { get; set; }

        [Display(Name = "Kova")]
        [Required]
        public int FkKovosDuomenys { get; set; }
    }
}

