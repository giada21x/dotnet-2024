using Microsoft.EntityFrameworkCore; 
 
class Database : DbContext 
{ 
  public DbSet<Cliente> Clienti { get; set; } // DbSet rappresenta una tabella del database in memoria 
  public DbSet<Prodotto> Prodotti { get; set; } // DbSet rappresenta una tabella del database in memoria 

  public DbSet<Ordine> Ordini { get; set; }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
  { 
    // optionsBuilder.UseInMemoryDatabase("MyDatabase"); // crea database provvisorio 
    optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite"); // crea database con sqlite 
  } 
  public void InserisciClienti(List<Cliente> clienti) 
  { 
    Clienti.AddRange(clienti); // AddRange aggiunge una lista di clienti al database 
    SaveChanges(); 
  } 
 
  public void StampaClienti() 
  { 
    var clienti = Clienti.Include(c => c.Prodotti).ToList(); // Include recupera tutti i prodotti per ogni cliente dal db 
    foreach (var c in clienti) 
    { 
      Console.WriteLine($"{c.Id} - {c.Nome} {c.Cognome} - Assunto? {c.Assunto}"); // Stampa di tutti i clienti 
      foreach (var p in Prodotti) 
      { 
        Console.WriteLine($"{p.Id} - {p.Nome} - {p.Prezzo}"); 
      } 
    } 
  } 
 
  public void InserisciProdotti(List<Prodotto> prodotti) 
  { 
    Prodotti.AddRange(prodotti); 
    SaveChanges(); 
  } 
 
  public void StampaProdotti() 
  { 
    var prodotti = Prodotti.ToList(); 
    foreach (var p in prodotti) 
    { 
      Console.WriteLine($"{p.Id} - {p.Nome} - {p.Prezzo} - {p.Cliente.Nome} {p.Cliente.Cognome}"); 
    } 
  } 

  public void InserisciOrdini(List<Ordine> ordini) 
  { 
    Ordini.AddRange(ordini); 
    SaveChanges(); 
  } 
  public void StampaOrdini() 
  { 
    var ordini = Ordini.Include(o => o.Prodotto).ThenInclude(p => p.Cliente).ToList(); 
    foreach (var o in ordini) 
    { 
      Console.WriteLine($"{o.Id} - {o.Prodotto.Nome} - {o.Prodotto.Cliente.Nome} - {o.Prodotto.Cliente.Cognome} "); 
    } 
  } 


}
  