public class VideogiocoController
{
    private DatabaseController _dbController;
    private VideogiocoView _view = new VideogiocoView();
    
    public VideogiocoController(DatabaseController dbController, VideogiocoView view)
    {
        _dbController = dbController;
        _view = view;
    }

    public void MenuVideogioco()
    {
        while (true)
        {
            _view.ShowMenuVideogioco();
            var input = _view.GetInput();
            if (input == "1")
            {
                AggiungiVideogioco();
            }
            else if (input == "2")
            {
                VisualizzaVideogiochi();
            }
            else if (input == "3")
            {
                //ModificaVideogioco();
            }
            else if (input == "4")
            {
                //RimuoviVideogioco();
            }
            else if (input == "5")
            {
                break;
            }
        }
    }
    
    private void AggiungiVideogioco()
    {
        Console.WriteLine("Lista dei generi:");
        
        var generi = _dbController.GetGeneri();
        _view.ShowVisualizzaGeneri(generi);
        Console.WriteLine("Lista delle console:");
        var platforms = _dbController.GetPlatforms();
        _view.ShowVisualizzaPlatforms(platforms);
        _view.ShowAggiungiVideogioco();
        var titolo = _view.GetInput();
        var anno = _view.GetInputInt();
        var id_genere = _view.GetInputInt();
        var id_platform = _view.GetInputInt();
        _dbController.AggiungiVideogioco(titolo, anno, id_genere, id_platform);
    }
    private void VisualizzaVideogiochi()
    {
        var videogiochi = _dbController.GetVideogiochi();
        _view.ShowVisualizzaVideogiochi(videogiochi);
    }
    private void ModificaVideogioco()
    {
        _view.ShowModificaVideogioco();
        var input = _view.GetInput();
        if (input == "1")
        {
            var videogiochi = _dbController.GetVideogiochi();
            _view.ShowVisualizzaVideogiochi(videogiochi);
            Console.WriteLine("Inserisci il titolo del videogioco che vuoi modificare");
            var titolo = _view.GetInput();
            Console.WriteLine("Inserisci il nuovo titolo");
            var NewTitolo = _view.GetInput();
            _dbController.ModificaTitoloVideogioco(titolo, NewTitolo);
            
        }
        else if (input == "2")
        {
            var videogiochi = _dbController.GetVideogiochi();
            _view.ShowVisualizzaVideogiochi(videogiochi);
            Console.WriteLine("Inserisci l'anno di uscita del videogioco che vuoi modificare");
            var anno = _view.GetInputInt();
            Console.WriteLine("Inserisci il nuovo anno di uscita");
            var NewAnno = _view.GetInputInt();
            _dbController.ModificaAnnoVideogioco(anno, NewAnno);
        }
        else if (input == "3")
        {
            var videogiochi = _dbController.GetVideogiochi();
            
            _view.ShowVisualizzaVideogiochi(videogiochi);
            Console.WriteLine("Inserisci l'id del genere del videogioco che vuoi modificare");
            var titolo = _view.GetInput();
            Console.WriteLine("Inserisci l'id genere nuovo");
            var NewId_genere = _view.GetInputInt();
            _dbController.ModificaGenereVideogioco(titolo, NewId_genere);
            
            
        }
        else if (input == "4")
        {
            var videogiochi = _dbController.GetVideogiochi();
            
            _view.ShowVisualizzaVideogiochi(videogiochi);
            Console.WriteLine("Inserisci l'id della console del videogioco che vuoi modificare");
            var titolo = _view.GetInput();
            Console.WriteLine("Inserisci l'id console nuovo");
            var NewId_platform = _view.GetInputInt();
            _dbController.ModificaPlatformVideogioco(titolo, NewId_platform);
            
            
        }
    }
    
}
    