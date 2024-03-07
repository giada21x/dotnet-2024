public class MenuController
{
    //private DatabaseController _dbController;
    private View _view = new View();
    
    public MenuController(/*DatabaseController dbController,*/ View view)

    {
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
                UtenteView menuUtente = new UtenteView();
                menuUtente.ShowMenuUtente();
            }
            //else if ()

            Console.ReadKey();
        }
    }
}