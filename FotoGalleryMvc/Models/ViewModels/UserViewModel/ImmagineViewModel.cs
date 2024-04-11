namespace FotoGalleryMvc.Models;

public class ImmagineViewModel
{
    public int Id { get; set; }
    public double Stars { get; set; }
    public string? Commento { get; set; }
    public string? UrlBack { get; set; }
    public required Immagine Immagine { get; set; }
    public required IEnumerable<Voto> Voti { get; set; }
}