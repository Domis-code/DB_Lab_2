using System.ComponentModel.DataAnnotations;

namespace Autonuoma.Models
{
    public class Renginys
    {
        [Display(Name = "Renginio pavadinimas")]
        [Required(ErrorMessage = "Įveskite renginio pavadinimą")]
        [StringLength(255)]
        public string RenginioPavadinimas { get; set; } = null!;

        [Display(Name = "Renginio data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Įveskite renginio datą")]
        public DateTime RenginioData { get; set; }

        [Display(Name = "Vietos adresas")]
        [Required(ErrorMessage = "Įveskite renginio adresą")]
        [StringLength(255)]
        public string VietaAdresas { get; set; } = null!;

        [Display(Name = "Miestas")]
        [Required(ErrorMessage = "Įveskite miestą, kuriame vyksta renginys")]
        [StringLength(255)]
        public string Miestas { get; set; } = null!;

        [Display(Name = "Organizatorius")]
        [Required(ErrorMessage = "Įveskite renginio organizatorių")]
        [StringLength(255)]
        public string Organizatorius { get; set; } = null!;

        public string? OriginalPK { get; set; }
    }
}
