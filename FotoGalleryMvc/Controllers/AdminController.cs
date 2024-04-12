using FotoGalleryMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FotoGalleryMvc.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FotoGalleryMvc.Models;


namespace FotoGalleryMvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager; private readonly ILogger<AdminController> _logger;
    private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(ILogger<AdminController> logger,UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
        _roleManager = roleManager;
        }
        
        public async Task<IActionResult> GestioneUtenti(int pageIndex = 1)
        {
              ViewBag.UrlBack = HttpContext.Request.Path;

        //seleziono l'utene attuale
        var user = await _userManager.GetUserAsync(User);
        
        var roles = await _userManager.GetRolesAsync(user!);
        
        var utenti = await _userManager.Users.ToListAsync();
         var utentiRuoli = new Dictionary<string, string>();
    foreach (var u in utenti)
    {
        var uRoles = await _userManager.GetRolesAsync(u);
        if (uRoles.Any())
        {
            utentiRuoli.Add(u.Id, string.Join(",", uRoles));
        }
    }
        //creo il modello per gestire la view
        var model = new GestioneUtentiViewModel
        {
           Utenti = utenti.Select(u => new AppUser
        {
            Id = u.Id,
            Nome = u.Nome,
            Cognome = u.Cognome,
            Ruolo = utentiRuoli.ContainsKey(u.Id) ? utentiRuoli[u.Id] : "N/D",
            Email = u.Email
        }).ToList(),
        ElementiPerPagina = 10,
        PageIndex = pageIndex
            
        
            
        };

        //rimuovo l'utente attuale dalla lista
        if (user != null)
        {
            model.Utenti = model.Utenti.Where(u => u.Id != user.Id).ToList();
        }
         model.NumeroPagine = (int)Math.Ceiling((double)model.Utenti.Count() / model.ElementiPerPagina);
        model.Utenti = model.Utenti.Skip((pageIndex - 1) * model.ElementiPerPagina).Take(model.ElementiPerPagina);

        return View(model);
        }
  

 public async Task<IActionResult> EliminaUtente(string id, bool conferma)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        if (conferma)
        {
            await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(GestioneUtenti));
        }

        return RedirectToAction(nameof(GestioneUtenti));
    }

    public async Task<IActionResult> GestioneImmagini(int? pageIndex)
        {
              ViewBag.UrlBack = HttpContext.Request.Path;
              _logger.LogInformation("GestisciImmagini - PageIndex: {0}", pageIndex);

            pageIndex ??= 1;

            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "immagini.json");
            var jsonPath3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "categorie.json");

            var jsonFile = System.IO.File.ReadAllText(jsonPath);
            var immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!.OrderByDescending(i => i.Id);

            var jsonFile3 = System.IO.File.ReadAllText(jsonPath3);
            var categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3)!;

            var numeroPagine = (int)Math.Ceiling((double)immagini.Count() / 10);
            var immaginiPaginate = immagini.Skip((pageIndex.Value - 1) * 10).Take(10);

            var model = new GestioneImmaginiViewModel
            {
                NumeroPagine = numeroPagine,
                PageIndex = pageIndex,
                Immagini = immaginiPaginate,
                Categorie = categorie
            };

            return View(model);
        }
        
          public IActionResult EliminaImmagine(List<int> selezione)
        {
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "immagini.json");
            var jsonFile = System.IO.File.ReadAllText(jsonPath);
            var immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile) ?? new List<Immagine>();

            foreach (var id in selezione)
            {
                _logger.LogInformation("Selezione: {0}", id);
                var immagineToRemove = immagini.FirstOrDefault(i => i.Id == id);
                if (immagineToRemove != null)
                {
                    immagini.Remove(immagineToRemove);
                }
            }

            System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(immagini, Formatting.Indented));

            return RedirectToAction(nameof(GestioneImmagini));
        }
        
        [HttpGet]
        public IActionResult ModificaImmagine(List<int> selezione)
        {
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "immagini.json");
             var jsonPath3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "categorie.json");
            var model = new ModificaImmagineViewModel();

            model.Selezione = selezione;

            // Log selezione 
            foreach (var id in selezione)
            {
                _logger.LogInformation("Selezione: {0}", id);
            }

            // Leggi le categorie dal file JSON
            var jsonFile3 = System.IO.File.ReadAllText(jsonPath3);
            var categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3) ?? new List<string>();

            // Costruisci oggetti SelectListItem e assegnali a Categorie
            foreach (var c in categorie)
            {
                model.Categorie.Add(new SelectListItem { Value = c, Text = c });
            }

            // Memorizza le immagini per la selezione degli Id input
            var jsonFile = System.IO.File.ReadAllText(jsonPath);
            model.Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;

            return View(model);
        }

        [HttpPost]
        public IActionResult Modifica(List<InputModelMod> imgMod)
        {
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "immagini.json");
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Errore validazione modulo - " + DateTime.Now.ToString("T"));
                return RedirectToAction(nameof(Index));
            }

            var immagini = new List<Immagine>();

            if (imgMod != null && imgMod.Any())
            {
                var jsonFile = System.IO.File.ReadAllText(jsonPath);
                immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile) ?? new List<Immagine>();

                foreach (var img in imgMod)
                {
                    _logger.LogInformation("ID: {0}", img.Id);
                    var immagine = immagini.FirstOrDefault(i => i.Id == img.Id);
                    if (immagine != null)
                    {
                        immagine.Autore = img.Autore;
                        immagine.Titolo = img.Titolo;
                        immagine.Categoria = img.Categoria;
                        immagine.Path = img.Path;
                    }
                }

                System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(immagini, Formatting.Indented));
            }

            return RedirectToAction(nameof(GestioneImmagini));
        }

       
    
    }

    

    
}
