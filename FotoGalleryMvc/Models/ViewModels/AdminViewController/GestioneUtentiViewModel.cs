using FotoGalleryMvc.Data;

namespace FotoGalleryMvc.Models;

public class GestioneUtentiViewModel
{
    //attibuti per le view GET
    public int NumeroPagine { get; set; }
    public int PageIndex { get; set; }
    public int ElementiPerPagina { get; set; }
    public int TotaleImmagini { get; set; }
   
    public IEnumerable<AppUser>? Utenti { get; set; }
    public List<string> Roles { get; set; }
}