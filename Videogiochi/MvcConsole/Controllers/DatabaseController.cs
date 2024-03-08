public class DatabaseController
{
    private Database _db;
   

    public DatabaseController(Database db)
    {
        _db = db;
        
    }
    //SEZIONE TABELLA UTENTE
    public void AggiungiUtente(string nome, string cognome, int eta)
    {
        _db.Utenti.Add(new Utente { Nome = nome, Cognome = cognome, Eta = eta});
        _db.SaveChanges();
    }
    public List<Utente> GetUtenti()
    {
        return _db.Utenti.ToList();
    }
    public void ModificaNomeUtente(string nome, string NewNome)
    {
        Utente utente = null;
        foreach (var u in _db.Utenti)
        {
            if (u.Nome == nome)
            {
                utente = u;
                break;
            }
        }
        if (utente != null)
        {
            utente.Nome = NewNome;
            _db.SaveChanges();
        }
    }
    public void ModificaCognomeUtente(string cognome, string NewCognome)
    {
        Utente utente = null;
        foreach (var u in _db.Utenti)
        {
            if (u.Cognome == cognome)
            {
                utente = u;
                break;
            }
        }
        if (utente != null)
        {
            utente.Cognome = NewCognome;
            _db.SaveChanges();
        }
    }
    public void ModificaEtaUtente(int eta, int NewEta)
    {
        Utente utente = null;
        foreach (var u in _db.Utenti)
        {
            if (u.Eta == eta)
            {
                utente = u;
                break;
            }
        }
        if (utente != null)
        {
            utente.Eta = NewEta;
            _db.SaveChanges();
        }
    }
    public void RimuoviUtente(string nome)
    {
        Utente utenteDaEliminare = null;
        foreach (var u in _db.Utenti)
        {
            if (u.Nome == nome)
            {
                utenteDaEliminare = u;
                break;
            }
        }
        if (utenteDaEliminare != null)
        {
            _db.Utenti.Remove(utenteDaEliminare);
            _db.SaveChanges();
        }
    }
    //SEZIONE TABELLA VIDEOGIOCO
    /*public void AggiungiVideogioco(string titolo, int anno, Genere genere, Platform platform)
    {
        _db.Videogiochi.Add(new Videogioco { Titolo = titolo, Anno = anno, Genere = genere, Platform = platform});
        _db.SaveChanges();
    }

    public List<Videogioco> GetVideogiochi()
    {
        return _db.Videogiochi.ToList();
    }

    public Genere GetGenereById(int id)
    {
        return _db.Generi.FirstOrDefault(g => g.Id == id);
    }

    public Platform GetPlatformById(int id)
    {
        return _db.Platforms.FirstOrDefault(p => p.Id == id);
    }

    public void ModificaTitoloVideogioco(string titolo, string NewTitolo)
    {
        Videogioco videogioco = null;
        foreach (var v in _db.Videogiochi)
        {
            if (v.Titolo == titolo)
            {
                videogioco = v;
                break;
            }
        }
        if (videogioco != null)
        {
            videogioco.Titolo = NewTitolo;
            _db.SaveChanges();
        }
    }

    public void ModificaAnnoVideogioco(int anno, int NewAnno)
    {
        Videogioco videogioco = null;
        foreach (var v in _db.Videogiochi)
        {
            if (v.Anno == anno)
            {
                videogioco = v;
                break;
            }
        }
        if (videogioco != null)
        {
            videogioco.Anno = NewAnno;
            _db.SaveChanges();
        }
    }

    public void ModificaGenereVideogioco(Genere genere, int NewGenere)
    {
        Videogioco videogioco = null;
        foreach (var v in _db.Videogiochi)
        {
            if (v.Anno == anno)
            {
                videogioco = v;
                break;
            }
        }
        if (videogioco != null)
        {
            videogioco.Anno = NewAnno;
            _db.SaveChanges();
        }
    }
*/



    /*public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu();
            var input = _view.GetInput();
            if (input == "1")
            {
                ShowAddMenu();
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