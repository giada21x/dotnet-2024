

public class Program
{
    static void Main(string[] args)
    {
        var db = new Database();
        var view = new View();
        var viewUtente = new UtenteView();
        var viewVideogioco = new VideogiocoView();

        var dbController = new DatabaseController(db);


        var generi = new List<Genere>
        {

        new Genere { Nome = "Avventura" },
        new Genere { Nome = "Sparatutto" },
        new Genere { Nome = "Picchiaduro" },
        new Genere { Nome = "Giochi di ruolo" },
        new Genere { Nome = "Giochi Platform" },
        new Genere { Nome = "Racing" },
        new Genere { Nome = "Giochi sportivi" },
        };

        dbController.InserisciGeneri(generi);
        
        var platforms = new List <Platform>
        {
        new Platform { Nome = "Playstation 5" },
        new Platform { Nome = "Nintendo Switch" },
        new Platform { Nome = "PC" },
        new Platform { Nome = "Xbox" },
        new Platform { Nome = "Smartphone" },
        
        };
        dbController.InserisciPlatforms(platforms);
        var controllerUtente = new UtenteController(dbController, viewUtente);
        var controllerVideogioco = new VideogiocoController(dbController, viewVideogioco);
        var controllerMenu = new MenuController(controllerUtente, view, controllerVideogioco, viewVideogioco);

        controllerMenu.MainMenu();


    }
}