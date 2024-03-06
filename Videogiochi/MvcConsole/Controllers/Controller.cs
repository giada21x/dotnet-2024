using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

class Controller
{
    private Database _db;
    private View _view;

    public Controller(Database db, View view)
    {
        _db = db;
        _view = view;
    }

    /*public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu();
            var input = _view.GetInput();
            if (input == "1")
            {
                AddVideogioco();
            }
            else if (input == "2")
            {
                AddUtente();
            }
            else if (input == "3")
            {
                ShowVideogiochi();
            }
            else if (input == "4")
            {
                ShowUtenti();
            }
            /*else if (input == "5")
            {
                UpdateVideogiochi();
            }
            else if (input == "6")
            {
                UpdateUtenti();
            }
            else if (input == "7")
            {
                RemoveVideogiochi();
            }
            else if (input == "8")
            {
                RemoveUtenti();
            }
            else if (input == "9")
            {
                break;
            }
        }
    }

    private void AddVideogioco()
    {
        Console.WriteLine("Inserisci l'id utente");
        var id = _view.GetInput();
        _db.AddVideogioco(id);
        Console.WriteLine("Inserisci il titolo del videogioco");
        var titolo = _view.GetInput();
        _db.AddVideogioco(titolo);
        Console.WriteLine("Inserisci l'anno di uscita del videogioco");
        var anno = _view.GetInput();
        _db.AddVideogioco(anno);
        Console.WriteLine("Inserisci il voto del videogioco");
        var voto = _view.GetInput();
        _db.AddVideogioco(voto);
        Console.WriteLine("Inserisci l'Id del genere");
        var id_genere = _view.GetInput();
        _db.AddVideogioco(id_genere);
        Console.WriteLine("Insersic l'Id della console");
        var id_console = _view.GetInput();
        _db.AddVideogioco(id_console);
    }

    private void AddUtente()
    {
        Console.WriteLine("Insersci il nome dell'utente:");
        var nome = _view.GetInput();
        _db.AddUtenti(nome);
        Console.WriteLine("Inserisci il cognome dell'utente:");
        var cognome = _view.GetInput();
        _db.AddUtenti(cognome);
        Console.WriteLine("Inserisci l'età dell'utente");
        var eta = _view.GetInput();
        _db.AddUtenti(eta);
    }

    private void ShowVideogiochi()
    {
        var videogiochi = _db.GetVideogiochi();
        _view.ShowVideogiochi(videogiochi);
    }
    private void ShowUtenti()
    {
        var utenti = _db.GetUtenti();
        _view.ShowUtenti(utenti);
    }
    private void UpdateVideogiochi()
    {
        Console.WriteLine("Modifica il videogioco");
        ShowVideogiochi();
        Console.WriteLine("Seleziona il videogioco");
        var dati = _view.GetInput();
        Console.WriteLine("Inserisci i nuovi dati");
        var newDati = _view.GetInput();
        _db.UpdateVideogioc

        
        
        
    }*/


}