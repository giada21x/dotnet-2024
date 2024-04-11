namespace FotoGalleryMvc.Models;

public class CategorieViewModel
{
    public required IEnumerable<Immagine> Immagini { get; set; }
    public required IEnumerable<string> Categorie { get; set; }
}