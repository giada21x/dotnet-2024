using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppProdotti.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger) 
    {
        _logger = logger;
    }

    public void OnGet()
    {
        ViewData["Message"] = "Hello from Razor"; //metodo main in cui passano gli argomenti per essere viusalizzati. In questo modo stiamo assegnando un valore alla chiave "Message" del dizionario ViewData.
        
    }
   
}
