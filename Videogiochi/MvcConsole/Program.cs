

public class Program 
{
    static void Main(string[] args)
    {
        var db = new Database();
        var view = new View();
        var viewUtente = new UtenteView();

        var dbController = new DatabaseController(db);
        var controllerUtente = new UtenteController(dbController, viewUtente);
        var controller = new MenuController(controllerUtente, view);
        
        controller.MainMenu();
        
        
    }
}