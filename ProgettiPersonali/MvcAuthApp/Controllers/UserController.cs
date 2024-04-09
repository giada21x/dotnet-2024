using MvcAuthApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace MvcAuthApp.Controllers;
[Authorize(Roles = "User")]
public class UserController : Controller
{



    #region  Logger
    private readonly ILogger<UserController> _logger;
    private readonly UserManager<AppUser> _userManager;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }
    #endregion

    public IActionResult Immagini(int? pageIndex, string? categoria)
    {
        _logger.LogInformation("Index - PageIndex: {0}", pageIndex);

        var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "immagini.json");
        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        var immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile) ?? new List<Immagine>();

        var jsonPath3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "categorie.json");
        var jsonFile3 = System.IO.File.ReadAllText(jsonPath3);
        var categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3) ?? new List<string>();

        categorie.RemoveAll(c => immagini.All(i => i.Categoria != c));

        if (!string.IsNullOrEmpty(categoria))
        {
            immagini = immagini.Where(i => i.Categoria == categoria).ToList();
        }

        var model = new ImmaginiViewModel
        {
            Categoria = categoria ?? "",
            PageIndex = pageIndex,
             NumeroPagine = (int)Math.Ceiling((double)immagini.Count() / 12),
             Immagini = immagini.Skip(((pageIndex ?? 1) - 1) * 12).Take(12).ToList()
        };




        return View(model);
    }

    // public IActionResult Immagine(int id, string urlBack)
    // {


    //     var model = new ImmagineViewModel
    //     {
    //         // memorizzo il valore passato dalla pagina precedente
    //         UrlBack = urlBack
    //         // Immagine = new Immagine(), // Inizializza con un valore di default
    //         // Voti = new List<Voto>()
    //     };

    //     //verifica log
    //     //_logger.LogInformation("url back : {0}", urlBack);

    //     // seleziono da tutte le immagini quella attuale
    //     var jsonFile = System.IO.File.ReadAllText(model.jsonPath);


    //     var immagine = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)?.FirstOrDefault(i => i.Id == id);
    //     if (immagine != null)
    //     {
    //         model.Immagine = immagine;
    //     }
       

    //     //carico i voti per la view della card immagine
    //     var jsonFile2 = System.IO.File.ReadAllText(model.jsonPath2);
    //     model.Voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFile2)!;
    //     return View(model);
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


