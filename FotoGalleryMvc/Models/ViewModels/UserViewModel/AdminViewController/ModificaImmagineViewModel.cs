using System.ComponentModel.DataAnnotations;
using FotoGalleryMvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FotoGalleryMvc.Models;

public class ModificaImmagineViewModel
{
    
    [BindProperty]  //la lista degli id selezionati per la modifica
    public  List<int> Selezione { get; set; }

    [BindProperty]  //la lista delle immagini da modificare
    public   List<InputModelMod> ImgMod { get; set; }

    //la lista di tutte le immagini per OnGet input Id
    public  List<Immagine> Immagini { get; set; }

    //elenco delle categorie disponibili
    public IList<SelectListItem> Categorie { get; set; } = []; // Inizializza la lista vuota
  
}

public class InputModelMod : InputModel
{
    [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Devi inserire un titolo")]
        [Display(Name = "Titolo ")]
        public override string? Titolo { get; set; }

        [Required(ErrorMessage = "Devi inserire un titolo")]
        [Display(Name = "Autore ")]
        public override string? Autore { get; set; }
}