using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FotoGalleryMvc.Models;
/// <summary>
/// Classe di validazione input per l'aggiunta di un'immagine
/// </summary>
public class InputModel
{
    [HiddenInput]
    public int Id { get; set; }
      [BindProperty]
    [Required(ErrorMessage = "Devi inserire un titolo")]
    [Display(Name = "Titolo ")]
    public string? Titolo { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Devi inserire un titolo")]
    [Display(Name = "Autore ")]
    public string? Autore { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Devi selezionare una categoria")]
    [Display(Name = "Categoria")]
    public string? Categoria { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Devi inserire un link")]
    [Display(Name = "Link immagine")]
    
    [RegularExpression(@".+\.(jpg|jpeg)(\?.+)?$", ErrorMessage = "L'URL deve contenere un'imagine .jpg o .jpeg")]
    public string? Path { get; set; }
}