

public class Program 
{
    static void Main(string[] args)
    {
        var db = new Database();
        var view = new View();
        var viewUtente = new UtenteView();

        var dbController = new DatabaseController(db);
        var controller = new MenuController(view);
        var controllerUtente = new UtenteController(dbController, viewUtente);
        controller.MainMenu();
        //controllerUtente.MenuUtente();
        
    }
}