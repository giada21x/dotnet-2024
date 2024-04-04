//Questo codice configura e avvia un'applicazione web ASP.NET Core 
//che utilizza Identity Framework per la gestione degli utenti e dei ruoli.


using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FotoGalleryRazorId.Data;

// Creazione del Web Host Builder: viene creato un WebApplication builder che contiene le configurazioni iniziali per l'applicazione web
var builder = WebApplication.CreateBuilder(args); 

// Aggiunta dei servizi al container. 
//Viene configurato il il servizio per l'accesso al database utilizzando SQLite. Viene aggiunto il supporto per Identity Framework e i servizi necessari per gestire l'autenticazione e l'autorizzazione degli utenti.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()   //!!! aggiunto per gestire i ruoli  (1/5)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

//!!! crea un ambito di servizio    (2/5). 
// Viene creato uno scope di servizio per risolvere le dipendenze. 
// Viene ottenuto il "Rolemanager" per gestire i ruoli dell'utente. 
// Viene chiamato un metodo per assicurarsi che i ruoli predefiniti esistano nel database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        //Risolvi il RoleManager del provider di servizi
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        //chiamata al metodo per assicurare che i ruoli esistano
        await ApplicationDbInitializer.EnsureRolesAsync(roleManager);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Un errore è avvenuto durante la creazione dei ruoli");
    }
}

// Configurazione della pipeline delle richieste HTTP.
// Viene configurata la pipeline per gestirele richieste HTTP.
// In ambiente di sviluppo, viene aggiunto un endpoint per visualizare le migrazioni del databse. 
// In ambiente di produzione, viene gestito l'errore e viene impostato HSTS (HTTP Strict Transport Security) per aumentare la sicurezza
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//!!! script di seed per la creazione admin (3/5)
// Viene creato un nuovo scope di servizio. 
// Viene ottenuto il "UserManager" e il "RoleManager".
// Viene chiamato un metodo per creare un utente amministratore predefinito e assegnargli il ruolo "Admin" 
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await SeedAdminUser(userManager, roleManager);
}

// Configurazione degli altri middleware:
// Vine configurato il middleware per reindirizzare le richieste HTTP su HTTPS, servire i file statici, gestire il routing e l'autorizzazione
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Avvio dell'applicazione
app.Run();

//!!! classe che crea l'admin (4/5)
async Task SeedAdminUser(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
{
    //controllo che il ruolo admin esiste e se non esiste lo crea 
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    //controlla se esite un utente con l'email specificata e, se esiste, gli assegna il ruolo di amministratore.
    var user = await userManager.FindByEmailAsync("giada01.adamo@gmail.com");

    if (user != null)
    {
        await userManager.AddToRoleAsync(user, "Admin");
    }
    else
    {
        await userManager.AddToRoleAsync(user, "User");
    }
    
}

//!!! classe che crea i ruoli nel dbContext (5/5)
//Definisce un metodo che assicura che i ruoli specificati esistano nel database. Se un ruolo non esiste, lo crea.
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
