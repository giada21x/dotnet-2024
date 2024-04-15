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

    // Seleziono l'utente attuale
    var user = await _userManager.GetUserAsync(User);

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

    // Carico la lista dei ruoli disponibili
    var roles = await _roleManager.Roles.Select(r => r.Name).ToArrayAsync();

    // Creo il modello per gestire la view
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
        PageIndex = pageIndex,
        Roles = roles.ToList()
    };

    // Rimuovo l'utente attuale dalla lista
    if (user != null)
    {
        model.Utenti = model.Utenti.Where(u => u.Id != user.Id).ToList();
    }

    model.NumeroPagine = (int)Math.Ceiling((double)model.Utenti.Count() / model.ElementiPerPagina);
    model.Utenti = model.Utenti.Skip((pageIndex - 1) * model.ElementiPerPagina).Take(model.ElementiPerPagina);

    return View(model);
}

  
public async Task<IActionResult> EliminaUtente(string id)
{
    var user = await _userManager.FindByIdAsync(id);
    if (user == null)
    {
        return NotFound();
    }

    var viewModel = new EliminaUtenteViewModel
    {
        UserId = user.Id,
        UserName = user.UserName
    };

    return View(viewModel);
}
 public async Task<IActionResult> EliminaUtenteConferma(string id)
{
    var user = await _userManager.FindByIdAsync(id);
    if (user == null)
    {
        return NotFound();
    }

    // Rimuovi l'utente
    var result = await _userManager.DeleteAsync(user);
    if (result.Succeeded)
    {
        _logger.LogInformation("Utente eliminato con successo: {userId}", id);
        return RedirectToAction(nameof(GestioneUtenti));
    }
    else
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }
        return RedirectToAction(nameof(GestioneUtenti));
    }
        
}
public async Task<IActionResult> ModificaRuolo(string id)
{
    var user = await _userManager.FindByIdAsync(id);
    if (user == null)
    {
        return NotFound();
    }
     var userRoles = await _userManager.GetRolesAsync(user);
    var userCurrentRole = userRoles.FirstOrDefault();
    var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
    var model = new ModificaRuoloViewModel
    {
        UserId = user.Id,
        RuoloAttuale = userCurrentRole,
        UserName = user.UserName,
        Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync()
    };

    return View(model);
}
[HttpPost]
public async Task<IActionResult> ModificaRuolo(string id, string nuovoRuolo)
{
    // Trova l'utente
    var user = await _userManager.FindByIdAsync(id);
    if (user == null)
    {
        return NotFound();
    }

    // Trova il ruolo esistente dell'utente
    var userRoles = await _userManager.GetRolesAsync(user);
    var userCurrentRole = userRoles.FirstOrDefault();

    // Se l'utente non ha un ruolo attualmente oppure il nuovo ruolo è diverso dal ruolo attuale
    if (userCurrentRole == null || userCurrentRole != nuovoRuolo)
    {
        // Rimuove l'utente dal ruolo attuale (se esiste)
        if (userCurrentRole != null)
        
        {
            
            var removeRoleResult = await _userManager.RemoveFromRoleAsync(user, userCurrentRole);
            if (!removeRoleResult.Succeeded)
            {
                foreach (var error in removeRoleResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return RedirectToAction(nameof(GestioneUtenti));
            }
        }

        // Aggiunge il nuovo ruolo all'utente
        var addRoleResult = await _userManager.AddToRoleAsync(user, nuovoRuolo);
        if (addRoleResult.Succeeded)
        {
            _logger.LogInformation("Ruolo utente modificato con successo: {userId}, Nuovo ruolo: {newRole}", id, nuovoRuolo);
            return RedirectToAction(nameof(GestioneUtenti));
        }
        else
        {
            foreach (var error in addRoleResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return RedirectToAction(nameof(GestioneUtenti));
        }
    }
    else
    {
        // Il ruolo è lo stesso, non è necessario fare nulla
        ModelState.AddModelError("", "Il ruolo selezionato è già assegnato all'utente.");
        return RedirectToAction(nameof(GestioneUtenti));
    }
}


    }}
        
 