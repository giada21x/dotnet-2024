using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebAppProdotti.Models;

namespace WebAppProdotti.Pages;

public class ProdottiModel : PageModel
{
    private readonly ILogger<ProdottiModel> _logger;    //non è necessario

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }

    public IEnumerable<Prodotto> Prodotti { get; set; } //creo oggetto di tipo lista per la paginazione del filtro
    public int numeroPagine { get; set; }
    public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)
    {


        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        Prodotti = JsonConvert.DeserializeObject < List < Prodotto >>(json);
           

        if (minPrezzo.HasValue)
        {
            Prodotti = Prodotti.Where(p => p.Prezzo >= minPrezzo);

        }
        if (maxPrezzo.HasValue)
        {
            Prodotti = Prodotti.Where(p => p.Prezzo <= maxPrezzo);

        }
        _logger.LogInformation("Prodotti filtrati per prezzo");
        Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 5).Take(5);
        numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 5.0);
    }
}


