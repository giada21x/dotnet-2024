using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;

namespace WebAppProdotti.Pages;

public class ProdottiModel : PageModel
{
    private readonly ILogger<ProdottiModel> _logger;    //non è necessario

    public  ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }

    public required IEnumerable<Prodotto> Prodotti { get; set; } //creo oggetto di tipo lista
    public int numeroPagine { get; set; }
    public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)
    {
        Prodotti = new List<Prodotto>
        {
            new Prodotto {Nome = "Prodotto 1", Prezzo = 100, Dettaglio = "Descrizione prodotto 1"},
            new Prodotto {Nome = "Prodotto 2", Prezzo = 200, Dettaglio = "Descrizione prodotto 2"},
            new Prodotto {Nome = "Prodotto 3", Prezzo = 300, Dettaglio = "Descrizione prodotto 3"},
            new Prodotto {Nome = "Prodotto 4", Prezzo = 400, Dettaglio = "Descrizione prodotto 4"},
            new Prodotto {Nome = "Prodotto 5", Prezzo = 500, Dettaglio = "Descrizione prodotto 5"},
            new Prodotto {Nome = "Prodotto 6", Prezzo = 600, Dettaglio = "Descrizione prodotto 6"},
            new Prodotto {Nome = "Prodotto 7", Prezzo = 700, Dettaglio = "Descrizione prodotto 7"},
            new Prodotto {Nome = "Prodotto 8", Prezzo = 800, Dettaglio = "Descrizione prodotto 8"},
            new Prodotto {Nome = "Prodotto 9", Prezzo = 900, Dettaglio = "Descrizione prodotto 9"},
            new Prodotto {Nome = "Prodotto 10", Prezzo = 1000, Dettaglio = "Descrizione prodotto 10"},
            new Prodotto {Nome = "Prodotto 11", Prezzo = 1100, Dettaglio = "Descrizione prodotto 11"}
        };
        if (minPrezzo.HasValue)
        {
            Prodotti = Prodotti.Where(p => p.Prezzo >= minPrezzo);
            
        }
        if (maxPrezzo.HasValue)
        {
            Prodotti = Prodotti.Where(p => p.Prezzo <= maxPrezzo);
            
        }
        _logger.LogInformation("Prodotti filtrati per prezzo");
        Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1)* 5).Take(5);
        numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 5.0);
        
    }
}

