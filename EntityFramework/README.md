# ENTITY FRAMEWORK

Entity Framework supporta lo sviluppo di applicazioni basate su dati con un modello di programmazione orientato agli oggetti. Consente di mappare i dati tra il database e il codice .NET, fornendo un'esperienza di sviluppo di database più semplice e più produttiva.

## INSTALLAZIONE 

Scaricare i seguenti pacchetti:

> dotnet add package Microsoft.EntityFrameworkCore
> dotnet add package Microsoft.EntityFrameworkCore.InMemory
> dotnet add package Microsoft.EntityFrameworkCore.Sqlite
> dotnet add package Microsoft.EntityFrameworkCore.Design 
> dotnet add package Microsoft.EntityFrameworkCore.Tools  
  
Assicurati aver installato .NET runtime 8.0

### CRUD CON DATABASE IN MEMORY

```c#
using Microsoft.EntityFrameworkCore;
/*----------------------CLASSE CLIENTE---------------------*/
class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
}

/*----------------------CLASSE DATABASE---------------------*/
class Database : DbContext
{
    public DbSet<Cliente> Clienti { get; set; } // DbSet rappresenta una tabella del database in memoria tramite il modello Cliente recupera i dati

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // OnCofiguring imposta le opzioni del database in memoria
    {
        optionsBuilder.UseInMemoryDatabase("MyDatabase"); // UseInMemoryDatabase imposta il database in memoria
    }
}

/*----------------------PROGRAM---------------------*/
class Program
{
    static void Main(string[] args)
    {
        using (var db = new Database()) // using si utilizza per garantire che il database venga chiuso
        {
            var cliente = new Cliente { Nome = "Mario", Cognome = "Rossi" }; // Creazione di un nuovo cliente
            db.Clienti.Add(cliente); // Aggiunta del cliente al database
            db.SaveChanges(); // Salvataggio delle modifiche

            var clienti = db.Clienti.ToList(); // Recupero di tutti i clienti dal database
            foreach (var c in clienti)
            {
                Console.WriteLine($"{c.Id} - {c.Nome} {c.Cognome}"); // Stampa di tutti i clienti
            }
        }
    }
}
```
### AGGIUNTA DI FUNZIONALITÀ AL MODELLO CRUD IN MEMORY

- Campo telefono aggiunto
- Funzionalità Inserisci clienti aggiunta
- Funzionalità Stampa clienti aggiunta
- Funzionalità Modifica Telefono

```c#
using Microsoft.EntityFrameworkCore;

/*----------------------CLASSE CLIENTE---------------------*/
class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Telefono { get; set; } // Aggiunta del campo telefono
}

/*----------------------CLASSE DATABASE---------------------*/
class Database : DbContext
{
    public DbSet<Cliente> Clienti { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MyDatabase");
    }

    //AGGIUNTA INSERISCI CLIENTI
    public void InserisciClienti(List<Cliente> clienti) 
    {
        Clienti.AddRange(clienti);
        SaveChanges();
    }

    //AGGIUNTA STAMPA CLIENTI
    public void StampaClienti()
    {
        var clienti = Clienti.ToList();
        foreach (var c in clienti)
        {
            Console.WriteLine($"{c.Id} - {c.Nome} {c.Cognome} - {c.Telefono}");
        }
    }

    //AGGIUNTA MODIFICA TELEFONO
    public void UpdateTelefono(int id, string telefono)
    {
        var cliente = Clienti.Find(id); // Find recupera un cliente dal database in base all'id
        cliente.Telefono = telefono; // Modifica del campo telefono
        SaveChanges();
    }
}

/*----------------------PROGRAM---------------------*/
class Program
{
    static void Main(string[] args)
    {
        using (var db = new Database())
        {
            var clienti = new List<Cliente>
            {
                new Cliente { Nome = "Mario", Cognome = "Rossi", Telefono = "1234567890" },
                new Cliente { Nome = "Luigi", Cognome = "Verdi", Telefono = "1234567890" },
                new Cliente { Nome = "Giovanni", Cognome = "Bianchi", Telefono = "1234567890" }
            };
            db.InserisciClienti(clienti);
            db.StampaClienti();

            db.UpdateTelefono(1, "0987654321"); // Modifica del campo telefono del cliente con id 1
            db.StampaClienti();
        }
    }
}
```
### AGGIUNTA NUOVA TABELLA AL MODELLO CRUD IN MEMORY

- Aggiunta di una tabella prodotti
- Relazione uno a molti con la tabella clienti 
- Aggiunta metodo Inserici Prodotti e Stampa Prodotti

```c#
using Microsoft.EntityFrameworkCore;

/*----------------------CLASSE CLIENTE---------------------*/
class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Telefono { get; set; }
    public List<Prodotto> Prodotti { get; set; } // Relazione uno a molti con la tabella prodotti
}

/*----------------------CLASSE PRODOTTO---------------------*/
class Prodotto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Prezzo { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } // Relazione con la tabella clienti
}

/*----------------------CLASSE DATABASE---------------------*/
class Database : DbContext
{
    public DbSet<Cliente> Clienti { get; set; }
    public DbSet<Prodotto> Prodotti { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MyDatabase");
    }

    public void InserisciClienti(List<Cliente> clienti)
    {
        Clienti.AddRange(clienti);
        SaveChanges();
    }

    public void StampaClienti()
    {
        var clienti = Clienti.Include(c => c.Prodotti).ToList(); // Include recupera i prodotti per ogni cliente
        foreach (var c in clienti)
        {
            Console.WriteLine($"{c.Id} - {c.Nome} {c.Cognome} - {c.Telefono}");
            foreach (var p in c.Prodotti)
            {
                Console.WriteLine($"  {p.Id} - {p.Nome} - {p.Prezzo}");
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
}

/*----------------------PROGRAM---------------------*/
class Program
{
    static void Main(string[] args)
    {
        using (var db = new Database())
        {
            var clienti = new List<Cliente>
            {
                new Cliente { Nome = "Mario", Cognome = "Rossi", Telefono = "1234567890" },
                new Cliente { Nome = "Luigi", Cognome = "Verdi", Telefono = "1234567890" },
                new Cliente { Nome = "Giovanni", Cognome = "Bianchi", Telefono = "1234567890" }
            };
            Console.WriteLine("clienti");
            db.InserisciClienti(clienti);
            db.StampaClienti();

            var prodotti = new List<Prodotto>
            {
                new Prodotto { Nome = "Prodotto 1", Prezzo = 10, ClienteId = 1 },
                new Prodotto { Nome = "Prodotto 2", Prezzo = 20, ClienteId = 1 },
                new Prodotto { Nome = "Prodotto 3", Prezzo = 30, ClienteId = 2 },
                new Prodotto { Nome = "Prodotto 4", Prezzo = 40, ClienteId = 2 },
                new Prodotto { Nome = "Prodotto 5", Prezzo = 50, ClienteId = 3 },
                new Prodotto { Nome = "Prodotto 6", Prezzo = 60, ClienteId = 3 }
            };
            Console.WriteLine("prodotti per clienti");
            db.InserisciProdotti(prodotti);
            db.StampaProdotti();
        }
    }
}
```
### AGGIUNTA ULTERIORE TABELLA AL MODELLO CRUD IN MEMORY

- Aggiunta tabella Ordini
- Relazione molti a molti con la tabella Prodotti
- Relazione uno a molti con la tabella clienti
- Aggiunta metodo Stampa Ordini 

```c#
using Microsoft.EntityFrameworkCore;

/*----------------------CLASSE CLIENTE---------------------*/
class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Telefono { get; set; }
    public List<Prodotto> Prodotti { get; set; }
}

/*----------------------CLASSE PRODOTTO---------------------*/
class Prodotto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Prezzo { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public List<Ordine> Ordini { get; set; }
}

/*----------------------CLASSE ORDINE---------------------*/
class Ordine
{
    public int Id { get; set; }
    public int ProdottoId { get; set; }
    public Prodotto Prodotto { get; set; }
}

/*----------------------CLASSE DATABASE---------------------*/
class Database : DbContext
{
    public DbSet<Cliente> Clienti { get; set; }
    public DbSet<Prodotto> Prodotti { get; set; }
    public DbSet<Ordine> Ordini { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MyDatabase");
    }

    public void InserisciClienti(List<Cliente> clienti)
    {
        Clienti.AddRange(clienti);
        SaveChanges();
    }

    public void StampaClienti()
    {
        var clienti = Clienti.Include(c => c.Prodotti).ToList();
        foreach (var c in clienti)
        {
            Console.WriteLine($"{c.Id} - {c.Nome} {c.Cognome} - {c.Telefono}");
            foreach (var p in c.Prodotti)
            {
                Console.WriteLine($"  {p.Id} - {p.Nome} - {p.Prezzo}");
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
        var prodotti = Prodotti.Include(p => p.Cliente).ToList();
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
        var ordini = Ordini.Include(o => o.Prodotto).ThenInclude(p => p.Cliente).ToList(); // ThenInclude recupera i clienti per ogni prodotto dato che non si può utilizzare Include per più di un livello
        foreach (var o in ordini)
        {
            Console.WriteLine($"{o.Id} - {o.Prodotto.Nome} - {o.Prodotto.Cliente.Nome} {o.Prodotto.Cliente.Cognome}");
        }
    }
}

/*----------------------PROGRAM---------------------*/
class Program
{
    static void Main(string[] args)
    {
        using (var db = new Database())
        {
            var clienti = new List<Cliente>
            {
                new Cliente { Nome = "Mario", Cognome = "Rossi", Telefono = "1234567890" },
                new Cliente { Nome = "Luigi", Cognome = "Verdi", Telefono = "1234567890" },
                new Cliente { Nome = "Giovanni", Cognome = "Bianchi", Telefono = "1234567890" }
            };
            Console.WriteLine("clienti");
            db.InserisciClienti(clienti);
            db.StampaClienti();

            var prodotti = new List<Prodotto>
            {
                new Prodotto { Nome = "Prodotto 1", Prezzo = 10, ClienteId = 1 },
                new Prodotto { Nome = "Prodotto 2", Prezzo = 20, ClienteId = 1 },
                new Prodotto { Nome = "Prodotto 3", Prezzo = 30, ClienteId = 2 },
                new Prodotto { Nome = "Prodotto 4", Prezzo = 40, ClienteId = 2 },
                new Prodotto { Nome = "Prodotto 5", Prezzo = 50, ClienteId = 3 },
                new Prodotto { Nome = "Prodotto 6", Prezzo = 60, ClienteId = 3 }
            };
            Console.WriteLine("prodotti per clienti");
            db.InserisciProdotti(prodotti);
            db.StampaProdotti();

            var ordini = new List<Ordine>
            {
                new Ordine { ProdottoId = 1 },
                new Ordine { ProdottoId = 2 },
                new Ordine { ProdottoId = 3 },
                new Ordine { ProdottoId = 4 },
                new Ordine { ProdottoId = 5 },
                new Ordine { ProdottoId = 6 }
            };
            Console.WriteLine("ordini");
            db.InserisciOrdini(ordini);
            db.StampaOrdini();
        }
    }
}
```
Per eseguire la migrazione del database, è possibile utilizzare il comando `dotnet ef migrations add <nome_migrazione>` per creare una nuova migrazione e `dotnet ef database update` per applicare le migrazioni al database.

Bisogna installare il tool `dotnet-ef` con il comando:
`dotnet tool install --global dotnet-ef`

