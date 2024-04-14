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
using System.ComponentModel.DataAnnotations;

namespace FotoGalleryMvc.Controllers
{
    [Authorize(Roles = "Admin, Moderatore")]
    public class ModeratoreController : Controller
    {
        private readonly string jsonPath = @"wwwroot/json/immagini.json";
        private readonly string jsonPath3 = @"wwwroot/json/categorie.json";
        private readonly UserManager<AppUser> _userManager; private readonly ILogger<ModeratoreController> _logger;

        public ModeratoreController(ILogger<ModeratoreController> logger)
        {
            _logger = logger;
        }
         public IActionResult GestioneImmagini(int pageIndex)
        {
            _logger.LogInformation("GestioneImmagini - PageIndex: {0}", pageIndex);
            ViewBag.UrlBack = HttpContext.Request.Path + HttpContext.Request.QueryString;
             var model = new GestioneImmaginiViewModel
    {
        Immagini = new List<Immagine>(), // Inizializza la lista di immagini vuota
        Categorie = new List<string>(), // Inizializza la lista di categorie vuota
        NumeroPagine = 0 // Inizializza il numero di pagine a 0
    };

            var jsonFile = System.IO.File.ReadAllText(jsonPath);
            model.Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!.OrderBy(i => i.Id);

            var jsonFile3 = System.IO.File.ReadAllText(jsonPath3);
            model.Categorie = JsonConvert.DeserializeObject<List<string>>(jsonFile3)!;

            model.NumeroPagine = (int)Math.Ceiling((double)model.Immagini.Count() / 10);
             model.Immagini = model.Immagini.Skip((pageIndex - 1) * 10).Take(10);
            return View(model);
        }
       
  [HttpGet]
    public IActionResult ModificaImmagine(List<int> selezione)
    {
        // creo il modello per gestire la view
        var model = new ModificaImmagineViewModel
        {
            Selezione = selezione
        };

        _logger.LogInformation("{0} - Modifica immagine --> (Oggetti selezionati: {1})", DateTime.Now.ToString("T"), selezione);

        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        model.Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> ModificaImmagine(ModificaImmagineViewModel model)
    {
        //assicura che i dati inviati siano validi, altrimenti ricarica la pagina
        if (!ModelState.IsValid)
        {
            //log errore selezione
            _logger.LogInformation("{0} - Errore validazione modulo (Errori: {1})", DateTime.Now.ToString("T"), ModelState.ErrorCount.ToString());
            return View(model);
        }
        else
        {
            _logger.LogInformation("{0} - Modifica Immegini --> (Avvio salvataggio dati)", DateTime.Now.ToString("T"));
            // Verifica se la lista delle immagini modificate è vuota
            if (model.ImgMod != null && model.ImgMod.Count != 0)
            {
                foreach (var img in model.ImgMod!)
                {
                    _logger.LogInformation("ID: {0}", img.Id);
                    foreach (var i in model.Immagini)
                    {
                        if (i.Id == img.Id)
                        {
                            i.Autore = img.Autore;
                            i.Titolo = img.Titolo;
                            i.Categoria = img.Categoria;
                            i.Path = img.Path;
                            break;
                        }
                    }
                }

                //salvo i dati aggiornati nel file immagini.json
                System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(model.Immagini, Formatting.Indented));

                _logger.LogInformation("{0} - Modifica Immegini --> (Eseguito!!!)", DateTime.Now.ToString("T"));

                

            }
            else
            {
                _logger.LogInformation("{0} - Modifica Immegini --> (Problema con Lista ImgMod!!!)", DateTime.Now.ToString("T"));
            }

            return RedirectToAction(nameof(GestioneImmagini));
        }
    }
    [HttpGet]
    public IActionResult EliminaImmagine(List<int> selezione)
    {
        // creo il modello per gestire la view
        var model = new EliminaImmagineViewModel
        {
            Selezione = selezione
        };

        _logger.LogInformation("{0} - EliminaImmagine --> (Oggetti selezionati: {1})", DateTime.Now.ToString("T"), selezione);

        var jsonFile = System.IO.File.ReadAllText(jsonPath);
        model.Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;

        return View(model);
    }

    
    [HttpPost]
    public async Task<IActionResult> EliminaImmagine(EliminaImmagineViewModel model)
    {
         var jsonFile = System.IO.File.ReadAllText(jsonPath);
        model.Immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile)!;

        foreach (var id in model.Selezione!)
        {
            _logger.LogInformation("Selezione: {0}", id);
            model.Immagini.Remove(model.Immagini.First(i => i.Id == id));
        }
         System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(model.Immagini, Formatting.Indented));

        //log immagine aggiunta correttamente 
        _logger.LogInformation("{0} - Elimina immagine --> (Immagini: {1})", DateTime.Now.ToString("T"), model.Selezione);

        

        return RedirectToAction(nameof(GestioneImmagini));
    }
    
    [HttpGet]
    public IActionResult GestioneCommenti(int pageIndex = 1)
    {
        // creo il modello per gestire la view
        var model = new GestioneCommentiViewModel
        {
            ElementiPerPagina = 16,
            PageIndex = pageIndex,
            
        };

        var jsonPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "voti.json");
        var jsonFile2 = System.IO.File.ReadAllText(jsonPath2);

        //seleziono solo i commenti che non sono vuoti ordinati per ultimo commento
        model.Voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFile2)!.Where(v => !string.IsNullOrWhiteSpace(v.Commento));

        //gestione ordinameneto tabella
       
        //paginazione
        model.NumeroPagine = (int)Math.Ceiling((double)model.Voti.Count() / model.ElementiPerPagina);
        model.Voti = model.Voti.Skip((pageIndex - 1) * model.ElementiPerPagina).Take(model.ElementiPerPagina);

        

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> GestioneCommenti(GestioneCommentiViewModel model)
    {
        //assicura che i dati inviati siano validi, altrimenti ricarica la pagina
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        else
        {
            // verifica log
            _logger.LogInformation("{0} - ModeraCommenti --> (Oggetti selezionati: {1})", DateTime.Now.ToString("T"), model.Selezione);

            //inizio la procedura di modifica del file voti.json
            var jsonPath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "voti.json");
        var jsonFile2 = System.IO.File.ReadAllText(jsonPath2);
            
            model.Voti = JsonConvert.DeserializeObject<List<Voto>>(jsonFile2)!;

            if (model.SubmitButton == "censura")
            {
                //verifica log
                _logger.LogInformation("{0} - ModeraCommenti --> (Opzione Censura)", DateTime.Now.ToString("T"));

                foreach (var id in model.Selezione!)   //per ogni checkbox (id del voto)
                {
                    foreach (var voto in model.Voti)  //cerco l'id e setto il voto a non visibile
                    {
                        if (voto.Id == id)
                        {
                            voto.Visibile = false;
                            voto.Moderato = true;
                            break;
                        }
                    }
                }
            }
            else if (model.SubmitButton == "approva")
            {
                //verifica log
                _logger.LogInformation("{0} - ModeraCommenti --> (Opzione Approva)", DateTime.Now.ToString("T"));

                foreach (var id in model.Selezione!)   //per ogni checkbox (id del voto)
                {
                    foreach (var voto in model.Voti)  //cerco l'id e setto il voto a non visibile
                    {
                        if (voto.Id == id)
                        {
                            voto.Moderato = true;
                            break;
                        }
                    }
                }
            }

            //salvo i dati aggiornati nel file voti.json
            System.IO.File.WriteAllText(jsonPath2, JsonConvert.SerializeObject(model.Voti, Formatting.Indented));

           
           return RedirectToAction(nameof(GestioneCommenti));

        }
        }

    }
    }




