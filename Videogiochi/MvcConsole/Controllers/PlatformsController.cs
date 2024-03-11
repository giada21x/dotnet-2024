public class PlatformController
{
    private DatabaseController _dbController;
    private PlatformViews _view = new PlatformViews();
    public PlatformController(DatabaseController dbController, PlatformViews view)
    {
        _dbController = dbController;
        _view = view;
    }
    public void MenuPlatform()
    {
        while (true)
        {
            _view.ShowMenuPlatform();
            var input = _view.GetInput();
            if (input == "1")
            {
                AggiungiPlatform();
            }
            else if (input == "2")
            {
                VisualizzaPlatforms();
            }
            else if (input == "3")
            {
                ModificaPlatform();
            }
            else if (input == "4")
            {
                RimuoviPlatform();
            }
            else if (input == "5")
            {
                break;
            }
        }
    }
    private void AggiungiPlatform()
    {
        _view.ShowAggiungiPlatform();
        var nome = _view.GetInput();
        _dbController.AggiungiPlatform(nome);
    }
    private void VisualizzaPlatforms()
    {
        var platforms = _dbController.GetPlatforms();
        _view.ShowVisualizzaPLatform(platforms);
    }
    private void ModificaPlatform()
    {
        _view.ShowModificaPlatform();
        var input = _view.GetInput();
        if (input == "1")
        {
            var platforms = _dbController.GetPlatforms();
            _view.ShowVisualizzaPLatform(platforms);
            Console.WriteLine("Inserisci il nome della console che vuoi modificare");
            var nome = _view.GetInput();
            Console.WriteLine("Inserisci la nuova console");
            var NewNome = _view.GetInput();
            _dbController.ModificaPlatform(nome, NewNome);
            
        }
    }
    private void RimuoviPlatform()
    {
        var platforms = _dbController.GetPlatforms();
        _view.ShowVisualizzaPLatform(platforms);
        _view.ShowRimuoviPlatform();
        var nome = _view.GetInput();
        _dbController.RimuoviPlatform(nome);
    }
}