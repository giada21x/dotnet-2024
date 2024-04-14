using FotoGalleryMvc.Data;

namespace FotoGalleryMvc.Models;

public class GestioneImmaginiViewModel
{
    //attibuti per le view GET
    public int NumeroPagine { get; set; }
    public int? PageIndex { get; set; }
    public required IEnumerable<Immagine> Immagini { get; set; }
    public required IEnumerable<string> Categorie { get; set; }
    

}