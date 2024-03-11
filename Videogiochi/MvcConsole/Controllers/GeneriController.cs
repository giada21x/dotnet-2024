public class GenereController
{
    private DatabaseController _dbController;
    private GeneriView _view = new GeneriView();
    public GenereController(DatabaseController dbController, GeneriView view)
    {
        _dbController = dbController;
        _view = view;
    }
    public void MenuGenere()
    {
        while (true)
        {
            _view.ShowMenuGenere();
            var input = _view.GetInput();
            if (input == "1")
            {
                AggiungiGenere();
            }
            else if (input == "2")
            {
                VisualizzaGeneri();
            }
            else if (input == "3")
            {
                ModificaGenere();
            }
            else if (input == "4")
            {
                RimuoviGenere();
            }
            else if (input == "5")
            {
                break;
            }
        }
    }
    private void AggiungiGenere()
    {
        _view.ShowAggiungiGenere();
        var nome = _view.GetInput();
        _dbController.AggiungiGenere(nome);
    }
    private void VisualizzaGeneri()
    {
        var generi = _dbController.GetGeneri();
        _view.ShowVisualizzaGeneri(generi);
    }
    private void ModificaGenere()
    {
        _view.ShowModificaGenere();
        var input = _view.GetInput();
        if (input == "1")
        {
            var generi = _dbController.GetGeneri();
            _view.ShowVisualizzaGeneri(generi);
            Console.WriteLine("Inserisci il nome del genere che vuoi modificare");
            var nome = _view.GetInput();
            Console.WriteLine("Inserisci il nuovo genere");
            var NewNome = _view.GetInput();
            _dbController.ModificaGenere(nome, NewNome);
            
        }
    }
    private void RimuoviGenere()
    {
        var generi = _dbController.GetGeneri();
        _view.ShowVisualizzaGeneri(generi);
        _view.ShowRimuoviGenere();
        var nome = _view.GetInput();
        _dbController.RimuoviGenere(nome);
    }
}

