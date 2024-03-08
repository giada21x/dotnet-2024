public class MenuController
{
    //private DatabaseController _dbController;
    private View _view = new View();
    private UtenteController _utenteController;
    public MenuController(UtenteController utenteController, View view)

    {
        _utenteController = utenteController;
        _view = view;
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
                break;
            }

            Console.ReadKey();
        }
    }
}