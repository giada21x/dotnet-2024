using FotoGalleryMvc.Data;
using Microsoft.AspNetCore.Mvc;

namespace FotoGalleryMvc.Models;

public class EliminaImmagineViewModel
{
    //attibuti per le view GET
    
   public required List<Immagine> Immagini { get; set; }
   
    
     [BindProperty]
    public required List<int> Selezione { get; set; } 
}