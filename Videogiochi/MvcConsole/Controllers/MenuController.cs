public class MenuController
{
    
    private View _view = new View();
    private VideogiocoView _videogiochiViews; 
    private UtenteController _utenteController;
    private VideogiocoController _videogiocoController;
    public MenuController(UtenteController utenteController, View view, VideogiocoController videogiocoController, VideogiocoView videogiochiViews)

    {
        _utenteController = utenteController;
        _view = view;
        _videogiocoController = videogiocoController;
        _videogiochiViews = videogiochiViews;
    }
    

    public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu();
            var input = _view.GetInput();
            if (input == "1")
            {
                _utenteController.MenuUtente();
                
            }
            else if (input == "2")
            {
                _videogiocoController.MenuVideogioco();
            }
            else if (input == "6")
            {
                break;
            }

            
        }
    }
}