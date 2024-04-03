using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;
using Newtonsoft.Json;

namespace WebAppProdotti.Pages
{
    public class ModificaPrezzoProdottoModel : PageModel
    {
        public Prodotto Prodotto { get; set; }
        
        public void OnGet(string nome)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
            var prodotti = JsonConvert.DeserializeObject < List < Prodotto >>(json);
            Prodotto = prodotti.FirstOrDefault(p => p.Nome == nome);
            
        } 
        public IActionResult OnPost(decimal prezzo, string nome)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
            var prodotti = JsonConvert.DeserializeObject < List < Prodotto >>(json);
            var prodotto = prodotti.FirstOrDefault(p => p.Nome == nome);
            prodotto.Prezzo = prezzo;
            //salva il file json formattato
            System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented) );
            return RedirectToPage("Prodotti");
        }
    }
}
