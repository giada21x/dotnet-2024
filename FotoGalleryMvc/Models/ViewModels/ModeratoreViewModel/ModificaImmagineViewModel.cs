using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FotoGalleryMvc.Models;

public class ModificaImmagineViewModel
{
    //attibuti per le view POST
    [BindProperty]
    public List<InputModel>? ImgMod { get; set; }

    [BindProperty]  //la lista degli id selezionati per la modifica
    public List<int>? Selezione { get; set; }

    //attibuti per le view GET
    public IList<SelectListItem> Categorie { get; set; } = []; // Inizializza la lista vuota

    //la lista di tutte le immagini per OnGet input Id
    public List<Immagine> Immagini { get; set; }

    //costruttore per generare il SelectListItem e La lista immagini
    public ModificaImmagineViewModel()
    {
        
        // Leggi le categorie dal file JSON
        var jsonPath3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "categorie.json");
        var jsonFile3 = System.IO.File.ReadAllText(jsonPath3);
        // Se ho problemi con il file JSON...
        var categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3) ?? new List<string>();

        // Costruisci oggetti SelectListItem e assegnali a Categorie
        foreach (var c in categorie)
        {
            Categorie.Add(new SelectListItem { Value = c, Text = c });
        }
var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "immagini.json");
        //memorizzo le immagini per la selezione degli Id input
       var jsonFile = System.IO.File.ReadAllText(jsonPath);
        Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;
    }
}