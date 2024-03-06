
using Microsoft.EntityFrameworkCore;

public class Database : DbContext
{
    public DbSet<Utente> Utenti { get; set; }
    public DbSet<Videogioco> Videogiochi { get; set; }
    /*public DbSet<Genere> Generi { get; set; }
    public DbSet<Platform> Platforms { get; set; }
*/
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");
    }

    /*public void AddUtenti(string nome)
    {
        var utente = new Utente { Nome = nome};
        Utenti.Add(utente);
        SaveChanges();
    }
    public List<object> GetUtenti()
    {
        var utenti = Utenti.ToList();
        List<object> lista = new();
        foreach (var utente in utenti)
        {
            lista.Add(new {Nome = utente.Nome, Cognome = utente.Cognome, Eta = utente.Eta});
            
        }
        return lista;
    }
    public void AddVideogioco(string titolo)
    {
        var videogioco = new Videogioco { Titolo = titolo};
        Videogiochi.Add(videogioco);
        SaveChanges();
    }

    public List<object> GetVideogiochi()
    {
        var videogiochi = Videogiochi.ToList();
        List<object> lista1 = new();
        foreach (var videogioco in videogiochi)
        {
            lista1.Add(new {Id_utente = videogioco.Id_utente, Titolo = videogioco.Titolo, Anno = videogioco.Anno, Voto = videogioco.Voto, Id_genere = videogioco.Id_genere, Id_console = videogioco.Id_console});
           
        }
        return lista1;
    } 
    public void AddGenere(List<Genere> generi)
    {
        Generi.AddRange(generi); //AddRange aggiunge una lista di generi al database
        SaveChanges();
    }

    public List<Genere> GetGeneri()
    {
        return GetGeneri();

    }*/
    
    

}