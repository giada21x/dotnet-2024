using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FotoGalleryMvc.Models
{
    public class AggiungiImmagineViewModel
    {
        
        public IList<SelectListItem> Categorie { get; set; } = new List<SelectListItem>();
         public string jsonPath3 = @"wwwroot/json/categorie.json";

        [BindProperty]
        [Display(Name = "Titolo ")]
        public string? Titolo { get; set; }

        [BindProperty]
        [Display(Name = "Autore ")]
        public string? Autore { get; set; }

        [Required(ErrorMessage = "Devi inserire un link")]
        [Display(Name = "Link immagine")]
        [Url(ErrorMessage = "Url non valido")]
        [RegularExpression(@".+\.(jpg|jpeg)(\?.+)?$", ErrorMessage = "L'URL deve contenere un'imagine .jpg o .jpeg")]
        public string Path { get; set; }

        [Required(ErrorMessage = "Devi selezionare una categoria")]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }

        
    }
}
