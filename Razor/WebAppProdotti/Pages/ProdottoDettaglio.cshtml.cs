using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;

namespace WebAppProdotti.Pages
{
    public class ProdottoDettaglioModel : PageModel
    {
        public  Prodotto Prodotto { get; set; }
        public void OnGet(string nome, string dettaglio, decimal prezzo, string immagine)
        {
            Prodotto = new Prodotto { Nome = nome, Prezzo = prezzo, Dettaglio = dettaglio, Immagine = immagine};
        }//creiamo un nuovo oggetto di tipo prodotto 
    }
}
