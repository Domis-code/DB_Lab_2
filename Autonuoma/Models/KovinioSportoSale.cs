using System.ComponentModel.DataAnnotations;

namespace Lab_2_DB.Models
{
    public class KovinioSportoSale
    {
        [Display(Name = "Klubo pavadinimas")]
        [Required(ErrorMessage = "Įveskite kovinio klubo pavadinimą")]
        [StringLength(255)]
        public string KluboPavadinimas { get; set; } = null!;

        [Display(Name = "Miestas")]
        [Required(ErrorMessage = "Įveskite miestą, kuriame yra ši sporto salė")]
        [StringLength(100)]
        public string Miestas { get; set; } = null!;

        [Display(Name = "Šalis")]
        [Required(ErrorMessage = "Įveskite šalį")]
        [StringLength(100)]
        public string Salis { get; set; } = null!;

        [Display(Name = "Adresas")]
        [Required(ErrorMessage = "Įveskite sporto salės adresą")]
        [StringLength(100)]
        public string Adresas { get; set; } = null!;

        [Display(Name = "Telefono nr.")]
        [Required(ErrorMessage = "Telefono numeris yra privalomas")]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string TelefonoNr { get; set; } = null!;

        public string? OriginalPK { get; set; }
    }
}




