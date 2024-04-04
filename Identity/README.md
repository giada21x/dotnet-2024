# IDENTITY FRAMEWORK

Identity Framework è un framework di autenticazione e autorizzazione per applicazioni web. (Register e Login)

- Comando creazione progetto **mvc** con autenticazione:

```c#
dotnet new mvc --auth Individual -o MvcAuthApp
``` 
- Comando creazione progetto **webapp** o **razor** con autenticazione:

```c#
dotnet new webapp --auth Individual -o WebApp
```

- Comando creazione progetto **blazor** o con autenticazione:

```c#
dotnet new blazorserver --auth Individual -o BlazorApp
```

## VISUALIZZARE I DATI

Nel file Views/Home/Index.cshtml viene creata la pagina della home:

```c#
@{
    ViewData["Title"] = "Home Page";
}

<div class="text-center">
     <h1 class="display-4">Ciao @User.Identity!.Name</h1>
    <h1>@User.Identity.IsAuthenticated</h1> 
    <p>Learn about <a href="https://learn.microsoft.com/aspnet/core">building Web apps with ASP.NET Core</a>.</p>
</div>

<div>
    @if (User.Identity!.IsAuthenticated)
    {
        <h1>Ciao, @User.Identity.Name</h1>
    }
    else
    {
        <h1>Ciao guest!</h1>
    }
</div>

```

- Per visualizzare il nome dell'utente registrato:

```c#
<h1>@User.Identity.IsAuthenticated</h1>
```

- Per visualizzare lo stato dell'autenticazione:

```c#
@if (User.Identity.IsAuthenticated)
{
    <h1>Hello, @User.Identity.Name!</h1>
}
else
{
    <h1>Hello, guest!</h1>
}
```

## CREARE UN APAGINA RISERVATA AGLI UTENTI

Per creare una pagina riservata agli utenti che sia accessibile solo agli utenti autenticati, puoi utilizzare l'attributo [Authorize]. Questo attributo può essere applicato a livelo di controller o di azione (metodo) per limitare l'accesso solo agli utenti che hanno eseguito l'accesso.

- ReservedController.cs (nella cartella Controllers)

```c#
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers;

public class ReservedController : Controller
{
    //GET: autorizzati Reserved/Index
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }

    //GET: /Reserved/Admin
    [Authorize(Roles = "Admin")]
    public IActionResult Admin()
    {
        return View();
    }

    //GET: /Reserved/User
    [Authorize(Roles = "User")]
    public IActionResult Users()
    {
        return View();
    }
}
```
- Index.cshtml (nella cartella Views/Reserved)

```c#
@{
    ViewData["Title"] = "Pagina Riservata";
}

<h2>Pagina Riservata</h2>

<p>Questa pagina è accessibile solo agli utenti autenticati.</p>
```

## AGGIUNGERE IL LINK ALLA PAGINA RISERVATA NEL MENU 

per aggiungere un link alla pagina riservata nel menu, è possibile utilizzare il tag helper **asp-area** per spcificare l'area, **asp-controller** per specificare il controller e **asp-action** per specificare l'azione

- _Layout.cshtml (nella cartella Views/Shared)

```c#
<li class="nav-item">
    <a class="nav-link text-dark" asp-area="" asp-controller="Reserved" asp-action="Index">Pagina Riservata</a>
</li>
```

## AGGIUNGERE UNA VOCE DI MENU VISIBILE SOLO AGLI UTENTI AUTENTICATI 

- _Layout.cshtml (nella cartella Views/Shared)

```c#
@if (User.Identity.IsAuthenticated)
{
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="" asp-controller="Reserved" asp-action="Index">Pagina Riservata</a>
    </li>
}
```

## AGGIUNGERE RUOLI 

è possibile aggiungere ruoli agli utenti per limitare l'accesso a determinate parti dell'applicazione. Per farlo bisogna sviluppare varie fasi: 

- Program.cs 

```c#
 .AddRoles<IdentityRole>() // Assicurati di avere questo per abilitare il supporto ai ruoli
```
```c#
var app = builder.Build();

// Crea un ambito di servizio
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        // Risolvi il RoleManager dal provider di servizi
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        // Chiamata al metodo per assicurare che i ruoli esistano
        await ApplicationDbInitializer.EnsureRolesAsync(roleManager);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Un errore è avvenuto durante la creazione dei ruoli");
    }
}
```

```c#
public static class ApplicationDbInitializer
{
    public static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        var roles = new List<string> { "Admin", "User" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
```

## AGGIUNGERE UN UTENTE A UN RUOLO

Per aggiungere un utente a un ruolo, è possibile utilizzare il metodo AddToRoleAsync di UserManager

- AccountController.cs (nella cartella Controllers)

```c#
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    // GET: /Account/AddToRole
    public async Task<IActionResult> AddToRoleAdmin()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        await _userManager.AddToRoleAsync(user, "Admin");
        return RedirectToAction("Index", "Home");
    }
}
```

- _Layout.cshtml (nella cartella Views/Shared)

```c#
@if (User.Identity.IsAuthenticated)
{
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="" asp-controller="Account" asp-action="AddToRoleAdmin">Aggiungi a ruolo Admin</a>
    </li>
}
```

Premendo il link "Aggiungi a ruolo" verrà agginto l'utente corrente al ruolo "Admin". Per stampare i lruolo dell'utente corrente è possibile utilizzare il metodo GetRoleAsync di UserManager

- AccountController.cs (nella cartella Controllers)


```c# 
// GET: /Account/GetRole
public async Task<IActionResult> GetRole()
{
    var user = await _userManager.FindByNameAsync(User.Identity.Name);
    var roles = await _userManager.GetRolesAsync(user);
    return Content(string.Join(", ", roles)); // serve a stampare il ruolo dell'utente
}
```

- _Layout.cshtml (nella cartella Views/Shared)

```c#
@if (User.Identity.IsAuthenticated)
{
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="" asp-controller="Account" asp-action="GetRole">Ruolo</a>
    </li>
}
```

Premendo il link "Ruolo" verrà stampato il ruolo dell'utente corrente.

## RIMUOVERE IL RUOLO DI UN UTENTE ADMIN

per verificare il ruolo di un utente e modificarlo da "Admin" a "User", è possibile utilizzare il metodo RemoveFromRoleAsync di UserManager

- AccountController.cs (nella cartella Controllers)

```c#
// GET: /Account/RemoveFromRole
public async Task<IActionResult> RemoveFromRoleAdmin()
{
    var user = await _userManager.FindByNameAsync(User.Identity.Name);
    await _userManager.RemoveFromRoleAsync(user, "Admin");
    return RedirectToAction("Index", "Home");
}
```

- _Layout.cshtml (nella cartella Views/Shared)

```c#
@if (User.Identity.IsAuthenticated)
{
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="" asp-controller="Account" asp-action="RemoveFromRoleAdmin">Rimuovi da ruolo Admin</a>
    </li>
}
```

Premendo il link "Rimuovi da ruolo" verrà rimosso l'utente corrente dal ruolo "Admin"

## ASSEGNARE IL RUOLO DI USER ALL'UTENTE 

Per assenare il ruolo di "User" all'utente corrente, è possibile utilizzare il metodo AddToRoleAsync di UserManager

- AccountController.cs (nella cartella Controllers)

```c#
// GET: /Account/AddToRoleUser
public async Task<IActionResult> AddToRoleUser()
{
    var user = await _userManager.FindByNameAsync(User.Identity.Name);
    await _userManager.AddToRoleAsync(user, "User");
    return RedirectToAction("Index", "Home");
}
```

- _Layout.cshtml (nella cartella Views/Shared)

```c#
@if (User.Identity.IsAuthenticated)
{
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="" asp-controller="Account" asp-action="AddToRoleUser">Aggiungi a ruolo User</a>
    </li>
}
```

## RIMUOVERE IL RUOLO DI UN UTENTE  USER 

Per rimuovere il ruolo di "User" all'utente corrente, è possibile utilizzare il metodo RemoveFromRoleAsync di UserManager

- AccountController.cs (nella cartella Controllers)

```c#
// GET: /Account/RemoveFromRoleUser
public async Task<IActionResult> RemoveFromRoleUser()
{
    var user = await _userManager.FindByNameAsync(User.Identity.Name);
    await _userManager.RemoveFromRoleAsync(user, "User");
    return RedirectToAction("Index", "Home");
}
```

- _Layout.cshtml (nella cartella Views/Shared)

```c#
@if (User.Identity.IsAuthenticated)
{
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="" asp-controller="Account" asp-action="RemoveFromRoleUser">Rimuovi da ruolo User</a>
    </li>
}
```

## AGGIUNGERE UNA PAGINA RISERVATA AI SOLI UTENTI DI UN RUOLO SPECIFICO:
## ADMIN (RICORDARSI LOGOUT E LOGIN)

Per creare una pagina riservata in un'applicazione  che sia accessibile solo agli utenti di un ruolo specifico, è possibile utilizzare l'attributo [Authorize] con il parametro Roles.

- ReservedController.cs (nella cartella Controllers)

```c#
// GET: /Reserved/Admin
[Authorize(Roles = "Admin")]
public IActionResult Admin()
{
    return View();
}
```

- Admin.cshtml ( nella cartella Views/Reserved)

```c#
@{
    ViewData["Title"] = "Pagina Riservata Admin";
}

<h3>@ViewData["Title"]</h3>

<p>Questa pagina è accessibile solo agli utenti del ruolo "Admin".</p>
```

- _Layout.cshtml (nella cartella Views/Shared)

```c#
@if (User.Identity.IsAuthenticated)
{
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="" asp-controller="Reserved" asp-action="Admin">Pagina Riservata Admin</a>
    </li>
}
```

## AGGIUNGERE UNA PAGINA RISERVATA AI SOLI UTENTI DI UN RUOLO SPECIFICO:
## USER

Per creare una pagina riservata in un'applicazione che sia accessibile solo agli utenti di un ruolo specifico è possibile utilozzare l'attributo [Authorize] con il parametro Roles.

- ReservedController.cs ( nella cartella Controllers)

```c#
// GET: /Reserved/User
[Authorize(Roles = "User")]
public IActionResult User()
{
    return View();
}
```

- User.cshtml (nella cartella Views/Shared)

```c#
@{
    ViewData["Title"] = "Pagina Riservata User";
}

<h3>@ViewData["Title"]</h3>

<p>Questa pagina è accessibile solo agli utenti del ruolo "User".</p>
```

-  _Layout.cshtml (nella cartella Views/Shared)

```c#
@if (User.Identity.IsAuthenticated)
{
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="" asp-controller="Reserved" asp-action="User">Pagina Riservata User</a>
    </li>
}
```

## PERMETTERE LA VISUALIZZAZIONE DI UN TESTO NELLA PAGINA SOLO AGLI UTENTI DI UN RUOLO SPECIFICO 

Per permettere la visualizzazione di un testo nella pagina solo agli utenti di un ruolo specifico 

- Privacy.cshtml (nella cartella Views/Home)

```c#
@if (User.IsInRole("User"))
{
    <p>Questo testo è visibile solo agli utenti del ruolo "User".</p>
}
else
{
    <p>Non sei autorizzato a visualizzare questo testo che è solo per gli Users.</p>
}

@if (User.IsInRole("Admin"))
{
    <p>Questo testo è visibile solo agli utenti del ruolo "Admin".</p>
}
else
{
    <p>Non sei autorizzato a visualizzare questo testo che è solo per gli Admin.</p>
}
```

## AGGIUNGERE UNA PAGINA DI ERRORE PER GLI UTENTI NON AUTORIZZATI 

Per aggiungere una pagina di errore per gli utenti non autorizzati, è possibile utilizzare il metodo UseStatusCodePagesWithReExecute

- Program.cs

```c#
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseStatusCodePagesWithReExecute("/Home/Error");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
```

- Error.cshtml (nella cartella Views/Home)

```c#
@{
    ViewData["Title"] = "Errore";
}

<h1 class="text-danger">Errore</h1>
<h2 class="text-danger">Non sei autorizzato a visualizzare questa pagina.</h2>
```

## AGGIUNGERE ASSEGNAZIONE USER IN AUTOMATICO DURANTE LA REGISTRAZIONE

Di default, ASP.NET Core utilizza le Razor Class Libraries (RCL) per fornire le funzionalità legate a Identity. In altre parole, le pagine e i componenti UI per la gestione dell'autenticazione e della registrazione degli utenti sono incapsulati in una libreria di classi e non vengono direttamente aggiunti al tuo progetto. Questo approccio rende più semplice mantenere e aggiornare il sistema di Identity senza dover toccare direttamente il codice dell'applicazione.

Se desideri personalizzare le pagine di Identity (per esempio, la pagina di login, registrazione, conferma dell'account, ecc.), puoi farlo "scaffolding" di quelle pagine nel tuo progetto. Questo processo copia le pagine dalla RCL al tuo progetto, permettendoti di modificarle secondo le tue esigenze.

- Installa il tool per lo scaffolding delle pagine Identity 

```c#
dotnet tool install --global dotnet-aspnet-codegenerator
```
 
- Instala code generator design

```c#
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
```

- Esegui lo scaffolding  delle pagine di Identity 

```c#
dotnet aspnet-codegenerator identity -dc MvcAuthApp.Data.ApplicationDbContext
```
Adesso saranno create le pagine Identity all'interno del progetto 

- Register.chtml.cs (nella cartella Areas/Identity/Pages/Account)

```c#
public async Task<IActionResult> OnPostAsync(string returnUrl = null)
{
    returnUrl = returnUrl ?? Url.Content("~/"); // ~ è la root dell'app
    if (ModelState.IsValid)
    {
        var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
        var result = await _userManager.CreateAsync(user, Input.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
            _logger.LogInformation("User created a new account with password.");
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = user.Id, code = code },
                protocol: Request.Scheme);

            await _emailSender.SendEmailAsync(Input.Email, "Conferma il tuo account",
                $"Conferma il tuo account <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>cliccando qui</a>.");

            if (_userManager.Options.SignIn.RequireConfirmedAccount)
            {
                return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
            }
            else
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
            }
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
    }

    return Page();
}
```

## AGGIUNGERE ADMIN DA PROGRAM.CS

- Program.cs

```c#
// Aggiungi qui lo script di seed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await SeedAdminUser(userManager, roleManager);
}

// Definizione del metodo SeedAdminUser
async Task SeedAdminUser(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
{
    // Assicurati che il ruolo Admin esista
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    // Crea l'utente admin se non esiste
    if (await userManager.FindByEmailAsync("info@admin.com") == null)
    {
        var user = new IdentityUser
        {
            UserName = "info@admin.com",
            Email = "info@admin.com",
        };

        var result = await userManager.CreateAsync(user, "Admin123!");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
```

## PROGRAM.CS CON TUTTE LE MODIFICHE APPORTATE A RUOLI E UTENTI 

```c#
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcAuthApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
.AddRoles<IdentityRole>() // Assicurati di avere questo per abilitare il supporto ai ruoli
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Crea un ambito di servizio
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        // Risolvi il RoleManager dal provider di servizi
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        // Chiamata al metodo per assicurare che i ruoli esistano
        await ApplicationDbInitializer.EnsureRolesAsync(roleManager);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Un errore è avvenuto durante la creazione dei ruoli");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Aggiungi qui lo script di seed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await SeedAdminUser(userManager, roleManager);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

// Definizione del metodo SeedAdminUser
async Task SeedAdminUser(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
{
    // Assicurati che il ruolo Admin esista
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    // Crea l'utente admin se non esiste
    if (await userManager.FindByEmailAsync("info@admin.com") == null)
    {
        var user = new IdentityUser
        {
            UserName = "info@admin.com",
            Email = "info@admin.com",
            EmailConfirmed = true,
        };

        var result = await userManager.CreateAsync(user, "Admin123!");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}

public static class ApplicationDbInitializer
{
    public static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        var roles = new List<string> { "Admin", "User" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
```














