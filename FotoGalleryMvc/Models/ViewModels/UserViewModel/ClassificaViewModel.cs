namespace FotoGalleryMvc.Models;

public class ClassificaViewModel
{
    public int NumeroPagine { get; set; }
    public int? PageIndex { get; set; }
    public int ElementiPerPagina { get; set; }
    public bool Reverse { get; set; }
    public int TotaleImmagini { get; set; }

    public  IEnumerable<Immagine> Immagini { get; set; }
}