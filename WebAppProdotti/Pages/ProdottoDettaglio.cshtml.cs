using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;

namespace WebAppProdotti.Pages
{
    public class ProdottoDettaglioModel : PageModel
    {
        public required Prodotto Prodotto { get; set; }
        public void OnGet(string nome, string dettaglio, decimal prezzo)
        {
            Prodotto = new Prodotto { Nome = nome, Prezzo = prezzo, Dettaglio = dettaglio };
        }
    }
}
