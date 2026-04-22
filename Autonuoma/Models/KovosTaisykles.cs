using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Autonuoma.Models
{
    public class KovosTaisykles
    {
        [Display(Name = "Taisyklų pavadinimas")]
        [Required(ErrorMessage = "Įveskite taisyklių pavadinimą")]
        [StringLength(100)]
        public string TaisykliuPavadinimas { get; set; } = null!;

        [Display(Name = "Raundų skaičius")]
        [Required(ErrorMessage = "Įveskite raundų skaičių")]
        [Range(1, 20, ErrorMessage = "Raundų skaičius turi būti intervale 1-20")]
        public int RaunduSkaicius { get; set; }

        [Display(Name = "Raundo trukmė (min)")]
        [Required(ErrorMessage = "Įveskite raundo trukmę (min)")]
        [Range(1, 60, ErrorMessage = "Raundo trukmė turi būti intervale 1-60 min")]
        public int RaundoTrukmeMin { get; set; }

        [Display(Name = "Taisyklų tipas")]
        [Required(ErrorMessage = "Pasirinkite taisyklių tipą")]
        public int KovosTaisykliuTipas { get; set; }

        [Display(Name = "Taškų sistema")]
        [Required(ErrorMessage = "Pasirinkite taškų sistemą")]
        public int TaskuSistema { get; set; }

        public IList<SelectListItem> TaisykliuTipaiList { get; set; } = new List<SelectListItem>();
        public IList<SelectListItem> TaskuSistemaList { get; set; } = new List<SelectListItem>();
    }
}
