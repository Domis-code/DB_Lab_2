using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab_2_DB.Models
{
    public class KovosDuomenys
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Kovos eilė")]
        [Required(ErrorMessage = "Įveskite kovos eilę")]
        [Range(1, 100, ErrorMessage = "Kovos eilė turi būti intervale 1-100")]
        public int KovosEile { get; set; }

        [Display(Name = "Titulinė kova")]
        public bool TitulineKova { get; set; }

        [Display(Name = "Pastabos")]
        [StringLength(100)]
        public string? Pastabos { get; set; }

        [Display(Name = "Kovos data ir laikas")]
        [Required(ErrorMessage = "Įveskite kovos datą ir laiką")]
        [DataType(DataType.DateTime)]
        public DateTime KovosLaikasData { get; set; }

        [Display(Name = "Kovos statusas")]
        [Required(ErrorMessage = "Pasirinkite kovos statusą")]
        public int KovosStatutas { get; set; }

        [Display(Name = "Svorio kategorija")]
        [Required(ErrorMessage = "Pasirinkite svorio kategoriją")]
        public int FkSvorioKategorija { get; set; }

        [Display(Name = "Renginys")]
        [Required(ErrorMessage = "Pasirinkite renginį")]
        public string FkRenginys { get; set; } = null!;

        [Display(Name = "Kovos taisyklės")]
        [Required(ErrorMessage = "Pasirinkite kovos taisykles")]
        public string FkKovosTaisykles { get; set; } = null!;

        public IList<SelectListItem> KovosStatusasList { get; set; } = new List<SelectListItem>();
        public IList<SelectListItem> SvorioKategorijaList { get; set; } = new List<SelectListItem>();
        public IList<SelectListItem> RenginysList { get; set; } = new List<SelectListItem>();
        public IList<SelectListItem> KovosTaisyklesList { get; set; } = new List<SelectListItem>();
    }
}




