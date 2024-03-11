using Microsoft.EntityFrameworkCore.Diagnostics;

public class DatabaseController
{
    private Database _db;


    public DatabaseController(Database db)
    {
        _db = db;

    }
    //SEZIONE TABELLA UTENTE
    public void AggiungiUtente(string nickname, string nome, string cognome, int eta)
    {
        if (_db.Utenti.Any(u => u.Nickname == nickname))
        {
            Console.WriteLine($"Questo utente esiste già");

        }
        else
        {
            _db.Utenti.Add(new Utente { Nickname = nickname, Nome = nome, Cognome = cognome, Eta = eta });
            _db.SaveChanges();
        }


    }
    public List<Utente> GetUtenti()
    {
        return _db.Utenti.ToList();
    }
    public void ModificaNicknameUtente(string nickname, string NewNickname)
    {
        Utente utente = _db.Utenti.FirstOrDefault(u => u.Nickname == nickname);

        if (utente != null)
        {
            utente.Nickname = NewNickname;
            _db.SaveChanges();
        }

        else
        {
            Console.WriteLine("Utente non trovato");

        }
    }
    public void ModificaNomeUtente(string nickname, string NewNome)
    {
        Utente utente = _db.Utenti.FirstOrDefault(u => u.Nickname == nickname);

        if (utente != null)
        {
            utente.Nome = NewNome;
            _db.SaveChanges();
        }

        else
        {
            Console.WriteLine("Utente non trovato");

        }
    }
    public void ModificaCognomeUtente(string nickname, string NewCognome)
    {
        Utente utente = _db.Utenti.FirstOrDefault(u => u.Nickname == nickname);
        if (utente != null)
        {
            utente.Cognome = NewCognome;
            _db.SaveChanges();
        }

        else
        {
            Console.WriteLine("Utente non trovato");

        }
    }
    public void ModificaEtaUtente(string nickname, int NewEta)
    {
        Utente utente =  _db.Utenti.FirstOrDefault(u => u.Nickname == nickname);
        if (utente != null)
        {
            utente.Eta = NewEta;
            _db.SaveChanges();
        }

        else
        {
            Console.WriteLine("Utente non trovato");

        }
    }
    public void RimuoviUtente(string nickname)
    {
        Utente utenteDaEliminare = null;
        foreach (var u in _db.Utenti)
        {
            if (u.Nickname == nickname)
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
    //SEZIONE TABELLA GENERE


    public void InserisciGeneri(List<Genere> generi)
    {
        foreach (var genere in generi)
        {
            if (!_db.Generi.Any(g => g.Nome == genere.Nome))
            {
                _db.Generi.Add(genere);
            }
        }
        _db.SaveChanges();
    }
    public void AggiungiGenere(string nome)
    {
        _db.Generi.Add(new Genere { Nome = nome });
        _db.SaveChanges();
    }
    public List<Genere> GetGeneri()
    {
        return _db.Generi.ToList();
    }
    public void ModificaGenere(string nome, string NewNome)
    {
        Genere genere = null;
        foreach (var g in _db.Generi)
        {
            if (g.Nome == nome)
            {
                genere = g;
                break;
            }
        }
        if (genere != null)
        {
            genere.Nome = NewNome;
            _db.SaveChanges();
        }
    }


    public void RimuoviGenere(string nome)
    {
        Genere genereDaEliminare = null;
        foreach (var g in _db.Generi)
        {
            if (g.Nome == nome)
            {
                genereDaEliminare = g;
                break;
            }
        }
        if (genereDaEliminare != null)
        {
            _db.Generi.Remove(genereDaEliminare);
            _db.SaveChanges();
        }
    }
    //SEZIONE TABELLA PLATFORM
    public void InserisciPlatforms(List<Platform> platforms)
    {
        foreach (var platform in platforms)
        {
            if (!_db.Platforms.Any(p => p.Nome == platform.Nome))
            {
                _db.Platforms.Add(platform);
            }

        }
        _db.SaveChanges();
    }
    public void AggiungiPlatform(string nome)
    {
        _db.Platforms.Add(new Platform { Nome = nome });
        _db.SaveChanges();
    }
    public List<Platform> GetPlatforms()
    {
        return _db.Platforms.ToList();
    }
    public void ModificaPlatform(string nome, string NewNome)
    {
        Platform platform = null;
        foreach (var p in _db.Platforms)
        {
            if (p.Nome == nome)
            {
                platform = p;
                break;
            }
        }
        if (platform != null)
        {
            platform.Nome = NewNome;
            _db.SaveChanges();
        }
    }
    public void RimuoviPlatform(string nome)
    {
        Platform platformDaEliminare = null;
        foreach (var p in _db.Platforms)
        {
            if (p.Nome == nome)
            {
                platformDaEliminare = p;
                break;
            }
        }
        if (platformDaEliminare != null)
        {
            _db.Platforms.Remove(platformDaEliminare);
            _db.SaveChanges();
        }
    }

    //SEZIONE TABELLA VOTI
    public void AggiungiVoto(int voto)
    {
        _db.Valutazioni.Add(new Valutazione { Voto = voto });
        _db.SaveChanges();
    }
    public List<Valutazione> GetVoti()
    {
        return _db.Valutazioni.ToList();
    }
    public void ModificaVoto(int voto, int NewVoto)
    {
        Valutazione valutazione = null;
        foreach (var v in _db.Valutazioni)
        {
            if (v.Voto == voto)
            {
                valutazione = v;
                break;
            }
        }
        if (valutazione != null)
        {
            valutazione.Voto = NewVoto;
            _db.SaveChanges();
        }
    }
    public void RimuoviVoto(int voto)
    {
        Valutazione valutazioneDaEliminare = null;
        foreach (var v in _db.Valutazioni)
        {
            if (v.Voto == voto)
            {
                valutazioneDaEliminare = v;
                break;
            }
        }
        if (valutazioneDaEliminare != null)
        {
            _db.Valutazioni.Remove(valutazioneDaEliminare);
            _db.SaveChanges();
        }
    }
    //SEZIONE TABELLA VIDEOGIOCO
    public void AggiungiVideogioco(string titolo, int anno, int id_genere, int id_platform)
    {

        Genere genere = _db.Generi.FirstOrDefault(g => g.Id == id_genere); // Trova il genere corrispondente all'ID nel database
        Platform platform = _db.Platforms.FirstOrDefault(p => p.Id == id_platform); // Trova la console corrispondente all'ID nel database
        _db.Videogiochi.Add(new Videogioco { Titolo = titolo, Anno = anno, Genere = genere, Platform = platform });
        _db.SaveChanges();
    }

    public List<Videogioco> GetVideogiochi()
    {
        return _db.Videogiochi.ToList();
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
    public void ModificaGenereVideogioco(int id_genere, int NewId_genere)
    {
        Genere genere = _db.Generi.FirstOrDefault(g => g.Id == id_genere);
        if (genere != null)
        {
            Videogioco videogioco = _db.Videogiochi.FirstOrDefault(v => v.Genere.Id == id_genere);
            if (videogioco != null)
            {
                Genere newGenere = _db.Generi.FirstOrDefault(g => g.Id == NewId_genere);
                if (newGenere != null)
                {
                    videogioco.Genere = newGenere;
                    _db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Nuovo genere non trovato.");
                }
            }
            else
            {
                Console.WriteLine("Videogioco con l'ID del genere specificato non trovato.");
            }
        }
        else
        {
            Console.WriteLine("Genere non trovato.");
        }
    }
    public void ModificaPlatformVideogioco(int id_platform, int NewId_platform)
    {
        Platform platform = _db.Platforms.FirstOrDefault(p => p.Id == id_platform);
        if (platform != null)
        {
            Videogioco videogioco = _db.Videogiochi.FirstOrDefault(v => v.Platform.Id == id_platform);
            if (videogioco != null)
            {
                Platform newPlatform = _db.Platforms.FirstOrDefault(p => p.Id == NewId_platform);
                if (newPlatform != null)
                {
                    videogioco.Platform = newPlatform;
                    _db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Nuova conosle non trovata.");
                }
            }
            else
            {
                Console.WriteLine("Videogioco con l'ID della console specificata non trovato.");
            }
        }
        else
        {
            Console.WriteLine("Consol non trovata.");
        }
    }
    public void RimuoviVideogioco(string titolo)
    {
        Videogioco videogiocoDaEliminare = null;
        foreach (var v in _db.Videogiochi)
        {
            if (v.Titolo == titolo)
            {
                videogiocoDaEliminare = v;
                break;
            }
        }
        if (videogiocoDaEliminare != null)
        {
            _db.Videogiochi.Remove(videogiocoDaEliminare);
            _db.SaveChanges();
        }
    }
}







