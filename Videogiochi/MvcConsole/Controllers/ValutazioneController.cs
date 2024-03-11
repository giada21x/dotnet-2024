

public class ValutazioneController
{
    private DatabaseController _dbController;
    private ValutazioneView _view = new ValutazioneView();
    public ValutazioneController(DatabaseController dbController, ValutazioneView view)
    {
        _dbController = dbController;
        _view = view;
    }

    public void MenuVoti()
    {
        while (true)
        {
            _view.ShowMenuVoti();
            var input = _view.GetInput();
            if (input == "1")
            {
                AggiungiVoto();
            }
            else if (input == "2")
            {
                VisualizzaVoti();
            }
            else if (input == "3")
            {
                ModificaVoto();
            }
            else if (input == "4")
            {
                RimuoviVoto();
            }
            else if (input == "5")
            {
                break;
            }
        }
    }
    private void AggiungiVoto()
    {
        _view.ShowAggiungiVoto();
        var voto = _view.GetInputInt();
        
        _dbController.AggiungiVoto(voto);
    }
    private void VisualizzaVoti()
    {
        var voti = _dbController.GetVoti();
        _view.ShowVisualizzaVoti(voti);
    }
    private void ModificaVoto()
    {
        _view.ShowModificaVoto();
        var input = _view.GetInput();
        if (input == "1")
        {
            var voti = _dbController.GetVoti();
            _view.ShowVisualizzaVoti(voti);
            Console.WriteLine("Inserisci il voto che vuoi modificare");
            var voto = _view.GetInputInt();
            Console.WriteLine("Inserisci il nuovo voto");
            var NewVoto = _view.GetInputInt();
            _dbController.ModificaVoto(voto, NewVoto);
            
        }
        
    }
    private void RimuoviVoto()
    {
        var voti = _dbController.GetVoti();
        _view.ShowVisualizzaVoti(voti);
        _view.ShowRimuoviVoto();
        var voto = _view.GetInputInt();
        _dbController.RimuoviVoto(voto);
    }

}

