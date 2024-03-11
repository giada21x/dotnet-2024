

public class UtenteController
{
    private DatabaseController _dbController;
    private UtenteView _view = new UtenteView();
    public UtenteController(DatabaseController dbController, UtenteView view)
    {
        _dbController = dbController;
        _view = view;
    }

    public void MenuUtente()
    {
        while (true)
        {
            _view.ShowMenuUtente();
            var input = _view.GetInput();
            if (input == "1")
            {
                AggiungiUtente();
            }
            else if (input == "2")
            {
                VisualizzaUtenti();
            }
            else if (input == "3")
            {
                ModificaUtente();
            }
            else if (input == "4")
            {
                RimuoviUtente();
            }
            else if (input == "5")
            {
                break;
            }
        }
    }
    private void AggiungiUtente()
    {
        _view.ShowAggiungiUtente();
        var nickname = _view.GetInput();
        var nome = _view.GetInput();
        var cognome = _view.GetInput();
        var eta = _view.GetInputInt();
        _dbController.AggiungiUtente(nickname, nome, cognome, eta);
    }
    private void VisualizzaUtenti()
    {
        var utenti = _dbController.GetUtenti();
        _view.ShowVisualizzaUtenti(utenti);
    }
    private void ModificaUtente()
    {
        _view.ShowModificaUtente();
        var input = _view.GetInput();
        if (input == "1")
        {
            var utenti = _dbController.GetUtenti();
            _view.ShowVisualizzaUtenti(utenti);
            Console.WriteLine("A quale utente vuoi modificare il nickname. Inserisci il nickname:");
            var nickname = _view.GetInput();
            Console.WriteLine("Inserisci il nuovo nickname");
            var NewNickname = _view.GetInput();
            _dbController.ModificaNicknameUtente(nickname, NewNickname);
        }
        if (input == "2")
        {
            var utenti = _dbController.GetUtenti();
            _view.ShowVisualizzaUtenti(utenti);
            Console.WriteLine("A quale utente vuoi modificare il nome? Insersici il nickname:");
            var nickname = _view.GetInput();
            Console.WriteLine("Inserisci il nuovo nome");
            var NewNome = _view.GetInput();
            _dbController.ModificaNomeUtente(nickname, NewNome);
            
        }
        else if (input == "3")
        {
            var utenti = _dbController.GetUtenti();
            _view.ShowVisualizzaUtenti(utenti);
            Console.WriteLine("A quale utente vuoi modificare il cognome? Inserisci il nickname");
            var nickname = _view.GetInput();
            Console.WriteLine("Inserisci il nuovo cognome");
            var NewCognome = _view.GetInput();
            _dbController.ModificaCognomeUtente(nickname, NewCognome);
        }
        else if (input == "4")
        {
            var utenti = _dbController.GetUtenti();
            _view.ShowVisualizzaUtenti(utenti);
            Console.WriteLine("A quale utente vuoi modificare l'età? Inserisci il nickname");
            var nickname = _view.GetInput();
            Console.WriteLine("Inserisci l'età nuova");
            var NewEta = _view.GetInputInt();
            _dbController.ModificaEtaUtente(nickname, NewEta);
            
        }
    }
    private void RimuoviUtente()
    {
        var utenti = _dbController.GetUtenti();
        _view.ShowVisualizzaUtenti(utenti);
        _view.ShowRimuoviUtente();
        var nickname = _view.GetInput();
        _dbController.RimuoviUtente(nickname);
    }

}

/*
if (_db.Utenti.Any(u => u.Nickname == nickname))
{

}
*/