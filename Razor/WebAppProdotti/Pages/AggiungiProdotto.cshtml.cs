using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;
using Newtonsoft.Json;

namespace WebAppProdotti.Pages
{
    public class AggiungiProdottoModel : PageModel
    {
        
        public void OnGet()
        {
           //non fa niente
        } 
        public IActionResult OnPost(string nome, decimal prezzo, string dettaglio)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
            var prodotti = JsonConvert.DeserializeObject < List < Prodotto >>(json);
            prodotti.Add(new Prodotto {Nome = nome, Prezzo = prezzo, Dettaglio = dettaglio}); //salva il file json formattato
            System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented) );
            return RedirectToPage("Prodotti");
        }
    }
}
