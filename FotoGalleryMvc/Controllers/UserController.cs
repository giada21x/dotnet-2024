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

namespace FotoGalleryMvc.Controllers
{
    
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager; private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Immagini(int pageIndex, string? categoria)
        {
            ViewBag.UrlBack = HttpContext.Request.Path + HttpContext.Request.QueryString;
            //log che visualizza la pagina selezionata
            _logger.LogInformation("Index - PageIndex: {0}", pageIndex);

            var model = new ImmaginiViewModel()
            {
                Categoria = categoria,
                PageIndex = pageIndex
            };


            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "immagini.json");
            var jsonPath3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "categorie.json");

            var jsonFile = System.IO.File.ReadAllText(jsonPath);
            model.Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;

            var jsonFile3 = System.IO.File.ReadAllText(jsonPath3);
            model.Categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3)!;

            //elimino le categorie senza immagini
            model.Categorie.RemoveAll(c => model.Immagini.All(i => i.Categoria != c));

            //filtro le immagini per categoria
            if (!string.IsNullOrEmpty(model.Categoria))
            {var jsonPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "voti.json");
                model.Immagini = model.Immagini.Where(i => i.Categoria == model.Categoria);
            }

            //calcolo numero pagine e paginazione
            model.NumeroPagine = (int)Math.Ceiling((double)model.Immagini.Count() / 12);
            model.Immagini = model.Immagini.Skip((pageIndex - 1) * 12).Take(12).ToList();

            return View(model);
        }

        public IActionResult Immagine(int id, string urlBack, double? stars, string commento)
        {
            ViewBag.UrlBack = urlBack;
            _logger.LogInformation("url back : {0}", urlBack);

            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "immagini.json");
            var jsonPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "voti.json");

            var jsonFile = System.IO.File.ReadAllText(jsonPath);
            var immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile);

            var jsonFile2 = System.IO.File.ReadAllText(jsonPath2);
            var voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFile2);

            var immagine = immagini.FirstOrDefault(i => i.Id == id);

            if (immagine != null && stars.HasValue && !string.IsNullOrEmpty(commento))
            {
                string nome = User.Identity?.Name?.Split("@")[0];
                int idVoto = voti.Count + 1;

                voti.Add(new Voto
                {
                    Id = idVoto,
                    Nome = nome,
                    ImmagineId = id,
                    Stelle = stars.Value,
                    Data = DateTime.Today,
                    Commento = commento,
                    Visibile = true,
                    Moderato = false
                });

                int numeroDiVoti = immagine.NumeroVoti;
                double sommaVoti = immagine.Voto * numeroDiVoti;

                numeroDiVoti++;
                sommaVoti += stars.Value;

                double votoAggiornato = Math.Round(sommaVoti / numeroDiVoti * 1.0, 1);

                immagine.Voto = votoAggiornato;
                immagine.NumeroVoti = numeroDiVoti;

                System.IO.File.WriteAllText(jsonPath2, JsonConvert.SerializeObject(voti, Formatting.Indented));
                System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(immagini, Formatting.Indented));
            }

            var model = new ImmagineViewModel
            {
                Immagine = immagine,
                Voti = voti.Where(v => v.ImmagineId == id),
                UrlBack = urlBack
            };

            return View(model);
        }
        [HttpGet]
        public IActionResult AggiungiImmagine()
        {
            var model = new AggiungiImmagineViewModel();
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "categorie.json");
            var jsonFile3 = System.IO.File.ReadAllText(jsonPath);
            var categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3) ?? new List<string>();

            // Costruisci oggetti SelectListItem e assegnali a Categorie
            foreach (var c in categorie)
            {
                model.Categorie.Add(new SelectListItem { Value = c, Text = c });
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AggiungiImmagine(AggiungiImmagineViewModel model)
        {
            // Assicura che i dati inviati siano validi, altrimenti ricarica la pagina
            if (!ModelState.IsValid)
            {
                // Log dell'errore di validazione
                _logger.LogInformation("Errore validazione modulo - " + DateTime.Now.ToString("T"));
                return View(model);
            }
            else
            {
                _logger.LogInformation("Categoria: {0}", model.Categoria);

                var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "immagini.json");
                var jsonFile = System.IO.File.ReadAllText(jsonPath);
                var immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile) ?? new List<Immagine>();

                int id = immagini.Max(i => i.Id) + 1;

                if (string.IsNullOrEmpty(model.Autore))
                {
                    model.Autore = $"Autore {id}";
                }
                if (string.IsNullOrEmpty(model.Titolo))
                {
                    model.Titolo = $"Titolo {id}";
                }

                Immagine img = new()
                {
                    Id = id,
                    Path = model.Path,
                    Titolo = model.Titolo,
                    Voto = 0,
                    NumeroVoti = 0,
                    Autore = model.Autore,
                    Data = DateTime.Now,
                    Categoria = model.Categoria
                };

                immagini.Add(img);

                System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(immagini, Formatting.Indented));

                _logger.LogInformation("Immagine aggiunta Id: {0}", id);
                return RedirectToAction(nameof(Immagini));
            }
        }

        public IActionResult Categorie()
        {
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "immagini.json");
            var jsonPath3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "categorie.json");

            try
            {
                var jsonFile = System.IO.File.ReadAllText(jsonPath);
                var immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile) ?? new List<Immagine>();

                var jsonFile3 = System.IO.File.ReadAllText(jsonPath3);
                var categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3) ?? new List<string>();

                return View(new CategorieViewModel
                {
                    Immagini = immagini,
                    Categorie = categorie
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il caricamento dei file JSON");
                // Gestione dell'errore
                return View(new CategorieViewModel
                {
                    Immagini = Enumerable.Empty<Immagine>(),
                    Categorie = Enumerable.Empty<string>()
                });
            }
        }
        public ActionResult Classifica(int? pageIndex, bool reverse)
        {
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "immagini.json");
            int pageNumber = pageIndex ?? 1;
            var model = new ClassificaViewModel
            {
                ElementiPerPagina = 10,
                PageIndex = pageIndex,
                Reverse = reverse
            };
            var jsonFile = System.IO.File.ReadAllText(jsonPath);
            model.Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile);
            model.TotaleImmagini = model.Immagini.Count();

            if (reverse)
            {
                
                model.Immagini = model.Immagini.OrderBy(i => i.Voto);
            }
            else
            {
                
                model.Immagini = model.Immagini.OrderByDescending(i => i.Voto);
            }

            model.NumeroPagine = (int)Math.Ceiling((double)model.TotaleImmagini / model.ElementiPerPagina);
            model.Immagini = model.Immagini.Skip(((pageIndex ?? 1) -1) * model.ElementiPerPagina).Take(model.ElementiPerPagina).ToList();
            return View(model);
        }
        









    }
}



