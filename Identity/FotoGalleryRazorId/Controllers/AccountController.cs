//questo controller fornisce due azioni che consentono di aggiungere l'utente corrente a ruoli specifici come "Admin" o "User".

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FotoGalleryRazorId.Controllers;

// Definizione della classe Controller
public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    
    //Costruttore del controller: Viene definito un costruttore che accetta un parametro di tipo UserManager<IdentityUser>.
    public AccountController(UserManager<IdentityUser> userManager)
    {
        //Inizializzazione del campo _userManager: Nel costruttore, viene iniettato il servizio UserManager all'interno del campo _userManager.
        _userManager = userManager;
    }

    //GET: /Account/AddToRoleAdmin
    //Metodo AddToRoleAdmin: Questo metodo è un'azione che gestisce una richiesta GET per aggiungere un utente al ruolo "Admin". Viene utilizzato async Task<IActionResult> per indicare che questo metodo restituisce un'attività asincrona che restituirà un'azione che restituisce un oggetto IActionResult.
    public async Task<IActionResult> AddToRoleAdmin()
    {
        //Ricerca dell'utente corrente: Viene recuperato l'utente corrente dal gestore utenti _userManager utilizzando il nome utente dell'utente corrente (User.Identity.Name).
        var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
        //Aggiunta dell'utente al ruolo "Admin": Utilizzando il gestore utenti _userManager, l'utente corrente viene aggiunto al ruolo "Admin".
        await _userManager.AddToRoleAsync(user!, "Admin");
        //Reindirizzamento: Dopo aver aggiunto l'utente al ruolo "Admin", viene eseguito un reindirizzamento alla pagina "Index" del controller "Pages"
        return RedirectToAction("Index", "Pages");
    }

    //GET: /Account/GetRole
    public async Task<IActionResult> GetRole()
    {
        var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
        var roles = await _userManager.GetRolesAsync(user!);
        return Content(string.Join(", ", roles));
    }  

    //GET: /Account/AddToRoleUser
    //Metodo AddToRoleUser: Funziona in modo simile a AddToRoleAdmin, ma aggiunge l'utente al ruolo "User" anziché al ruolo "Admin".
    public async Task<IActionResult> AddToRoleUser()
    {
        var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
        await _userManager.AddToRoleAsync(user!, "User");
        return RedirectToAction("Index", "Pages");
    }
}