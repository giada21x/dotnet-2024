
using System.Data.SQLite;

class Prog
{
   public static void Main(string[] args)
   {
      

      string path = @"database.db"; // la rotta del file del database
      if (!File.Exists(path)) // se il file del database non esiste
      {
         SQLiteConnection.CreateFile(path); // crea il file del database
         SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"); // crea la connessione al database la versione 3 è un indicazione della versione del database e può esser personalizzata
         connection.Open(); // apre la connessione al database
         string sql = @"
                        CREATE TABLE generi (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                        CREATE TABLE console (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);

                        CREATE TABLE utenti (id_utente INTEGER PRIMARY KEY, nome TEXT , cognome TEXT , eta INTEGER);
                        CREATE TABLE videogiochi (id_videogioco INTEGER PRIMARY KEY, id_utente INTEGER, titolo TEXT, anno INTEGER, voto INTEGER CHECK (voto >= 0), id_genere INTEGER,id_console INTEGER, FOREIGN KEY (id_utente) REFERENCES utenti(id),  FOREIGN KEY (id_console) REFERENCES console(id) FOREIGN KEY (id_genere) REFERENCES generi(id),  FOREIGN KEY (id_console) REFERENCES console(id));
                        

                        INSERT INTO generi (nome) VALUES ('avventura');
                        INSERT INTO generi (nome) VALUES ('sparatutto');
                        INSERT INTO generi (nome) VALUES ('picchiaduro');
                        INSERT INTO generi (nome) VALUES ('giochi di ruolo');
                        INSERT INTO generi (nome) VALUES ('giochi platform');
                        INSERT INTO generi (nome) VALUES ('racing');
                        INSERT INTO generi (nome) VALUES ('giochi sportivi');

                        INSERT INTO console (nome) VALUES ('playstation 5');
                        INSERT INTO console (nome) VALUES ('nintendo switch');
                        INSERT INTO console (nome) VALUES ('pc');
                        INSERT INTO console (nome) VALUES ('xbox');
                        INSERT INTO console (nome) VALUES ('pc');
                        INSERT INTO console (nome) VALUES ('smartphone');

                        INSERT INTO videogiochi (id_utente, titolo, anno, voto, id_genere, id_console) VALUES (1,'zelda tears of the kingdom', 2023, 10, 1, 2);
                        INSERT INTO videogiochi (id_utente, titolo, anno, voto, id_genere, id_console) VALUES (1,'resident evil 4 remake', 2023, 9, 2, 3);
                        INSERT INTO videogiochi (id_utente, titolo, anno, voto, id_genere, id_console) VALUES (2,'resident evil 4 remake', 2023, 9, 2, 3);          
                        INSERT INTO videogiochi (id_utente, titolo, anno, voto, id_genere, id_console) VALUES (2,'rainbow six', 2015, 8, 2, 3); 
                        INSERT INTO videogiochi (id_utente, titolo, anno, voto, id_genere, id_console) VALUES (3,'fortnite', 2023, 7, 2, 3); 

                        INSERT INTO utenti ( nome, cognome, eta) VALUES ( 'giada', 'adamo', 22);
                        INSERT INTO utenti ( nome, cognome, eta) VALUES ( 'giorgio', 'adamo', 20);
                        INSERT INTO utenti ( nome, cognome, eta) VALUES ( 'pinco', 'pallo', 15);
                        ";

         SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
         command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
         connection.Close(); // chiude la connessione al database
      }
      while (true)
      {
         Console.WriteLine("Cosa vuoi fare?");
         
         Console.WriteLine("1 - Inserire");
         Console.WriteLine("2 - Visualizare");
         Console.WriteLine("3 - Modificare");
         Console.WriteLine("4 - Eliminare");
         Console.WriteLine("5 - Esci");
         Console.WriteLine("scegli un'opzione");
         string scelta = Console.ReadLine()!;
         Console.Clear();
         if (scelta == "1")
         {
            Console.WriteLine("1 - Inserisci il videogioco");
            Console.WriteLine("2 - Inserisci un utente");
            Console.WriteLine("3 - Inserire una categoria");
            if (scelta == "1")
            {
               InserisciVideogioco();
            }
            else if (scelta == "2")
            {
               InserisciUtente();
            }
            else if (scelta == "3")
            {
               InserisciCategoria();
            }
         }
         else if (scelta == "2")
         {
            Console.WriteLine("1 - Visualizza tutti videogiochi");
            Console.WriteLine("2 - Visualizza i videogiochi ordinati per anno di uscita");
            Console.WriteLine("3 - Visualizza i videogiochi ordinati per voto");
            Console.WriteLine("4 - Visualizza il videogioco con il voto più alto");
            Console.WriteLine("5 - Visualizza il videogioco con il voto più basso");
            Console.WriteLine("6 - Visualizza un videogioco specifico");
            Console.WriteLine("7 - Visualizza i videogiochi in base al genere");
            Console.WriteLine("8 - Visualizza i videogiochi in base alla console");
            Console.WriteLine("9 - Visualizza gli utenti");
            Console.WriteLine("10 - Visualizza la tabella completa");
            if (scelta == "1")
            {
               VisualizzaVideogiochi();
            }
            else if (scelta == "2")
            {
               VisualizzaVideogiochiOrdinatiPerAnno();
            }
            else if (scelta == "3")
            {
               VisualizzaVideogiochiOrdinatiPerVoto();
            }
            else if (scelta == "4")
            {
               VisualizzaVideogiocoConVotoPiuAlto();
            }
            else if (scelta == "5")
            {
               VisualizzaVideogiocoConVotoPiuBasso();
            }
            else if (scelta == "6")
            {
               VisualizzaVideogioco();
            }
            else if (scelta == "7")
            {
                VisualizzaVideogiochiGenere();
            }
            else if (scelta == "8")
            {
               VisualizzaVideogiochiConsole();
            }
            else if (scelta == "9")
            {
               VisualizzaUtenti();
            }
            else if (scelta == "10")
            {
               VisualizzaTabellaCompleta();
            }
         }
         else if (scelta == "3")
         {
            Console.WriteLine("1 - Modificare il voto di un videogioco");
            if (scelta == "1")
            {
               ModificaVotoVideogioco();
            }
            
         }
         else if (scelta == "4")
         {
            Console.WriteLine("1 - Elimina videogioco");
            Console.WriteLine("2 - Elimina una categoria");
            Console.WriteLine("3 - Elimina un utente");
            if (scelta == "1")
            {
               EliminaVideogioco();
            }
            else if (scelta == "2")
            {
               EliminaCategoria();
            }
            else if (scelta == "3")
            {
               EliminaUtente();
            }
         }
      }
   }
   

   static void InserisciVideogioco()
   {
      Console.WriteLine("inserisci l'id utente");
      string id_utente = Console.ReadLine()!;
      Console.WriteLine("inserisci il nome del videogioco");
      string titolo = Console.ReadLine()!;
      Console.WriteLine("inserisci l'anno di uscita del videogioco");
      string anno = Console.ReadLine()!;
      Console.WriteLine("inserisci il voto del videogioco");
      string voto = Console.ReadLine()!;
      Console.WriteLine("inserisci l'id del genere");
      string id_genere = Console.ReadLine()!;
      Console.WriteLine("inserisci l'id della console");
      string id_console = Console.ReadLine()!;
      
      SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
      connection.Open(); // apre la connessione al database
      string sql = $"INSERT INTO videogiochi (id_utente, titolo, anno, voto, id_genere, id_console) VALUES ({id_utente},'{titolo}', {anno}, {voto}, {id_genere}, {id_console})";
      SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
      command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
      connection.Close(); // chiude la connessione al database
   }

   static void VisualizzaVideogiochi()
   {
      SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
      connection.Open(); // apre la connessione al database
      string sql = "SELECT * FROM videogiochi";
      SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
      SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al database e salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
      while (reader.Read())
      {
         Console.WriteLine($"id_videogioco: {reader["id_videogioco"]}, titolo: {reader["titolo"]}, anno: {reader["anno"]}, voto: {reader["voto"]}, id_genere: {reader["id_genere"]}. id_console: {reader["id_console"]}");
      }
      connection.Close(); // chiude la connessione al database
   }

   static void VisualizzaVideogiochiOrdinatiPerAnno()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = "SELECT * FROM videogiochi ORDER BY anno"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti ordinati per prezzo
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, titolo: {reader["titolo"]}, anno: {reader["anno"]}, voto: {reader["voto"]}, id_genere: {reader["id_genere"]}. id_console: {reader["id_console"]}");
        }
        connection.Close();
    }

     static void VisualizzaVideogiochiOrdinatiPerVoto()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = "SELECT * FROM videogiochi ORDER BY voto"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti ordinati per prezzo
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, titolo: {reader["titolo"]}, anno: {reader["anno"]}, voto: {reader["voto"]}, id_genere: {reader["id_genere"]}. id_console: {reader["id_console"]}");
        }
        connection.Close();
    }

   static void VisualizzaVideogiocoConVotoPiuAlto()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = "SELECT * FROM videogiochi ORDER BY voto DESC LIMIT 1"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti ordinati per prezzo in modo decrescente e ne prende solo il primo
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, titolo: {reader["titolo"]}, anno: {reader["anno"]}, voto: {reader["voto"]}, id_genere: {reader["id_genere"]}, id_console: {reader["id_console"]}");
        }
        connection.Close();
    }
   
   static void VisualizzaVideogiocoConVotoPiuBasso()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = "SELECT * FROM videogiochi ORDER BY voto ASC LIMIT 1"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti ordinati per prezzo in modo decrescente e ne prende solo il primo
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, titolo: {reader["titolo"]}, anno: {reader["anno"]}, voto: {reader["voto"]}, id_genere: {reader["id_genere"]}, id_console: {reader["id_console"]}");
        }
        connection.Close();
    }

   static void VisualizzaVideogioco()
    {
        Console.WriteLine("inserisci il nome del videogioco");
        string titolo = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"SELECT * FROM videogiochi WHERE nome = '{titolo}'"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, titolo: {reader["titolo"]}, anno: {reader["anno"]}, voto: {reader["voto"]}, id_genere: {reader["id_genere"]}, id_console: {reader["id_console"]}");
        }
        connection.Close();
    }
   
   static void VisualizzaVideogiochiGenere()
   {
        Console.WriteLine("inserisci l'id della categoria genere");
        string id_genere = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"SELECT * FROM videogiochi WHERE id_genere = {id_genere}"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti con id_categoria uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, titolo: {reader["titolo"]}, anno: {reader["anno"]}, voto: {reader["voto"]}, id_genere: {reader["id_genere"]}, id_console: {reader["id_console"]}");
        
        }
        connection.Close();
    }

   static void VisualizzaVideogiochiConsole()
   {
        Console.WriteLine("inserisci l'id della categoria console");
        string id_console = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"SELECT * FROM videogiochi WHERE id_genere = {id_console}"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti con id_categoria uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, titolo: {reader["titolo"]}, anno: {reader["anno"]}, voto: {reader["voto"]}, id_genere: {reader["id_genere"]}, id_console: {reader["id_console"]}");
        
        }
        connection.Close();
    }

   static void InserisciUtente()
   {
      
      Console.WriteLine("inserisci il nome dell'utente");
      string nome = Console.ReadLine()!;
      Console.WriteLine("inserisci il cognome dell'utente");
      string cognome = Console.ReadLine()!;
      Console.WriteLine("inserisci l'età dell'utente");
      string eta = Console.ReadLine()!;
      
      
      SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
      connection.Open(); // apre la connessione al database
      string sql = $"INSERT INTO utenti (nome, cognome, eta) VALUES ('{nome}', '{cognome}', {eta})";
      SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
      command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
      connection.Close(); // chiude la connessione al database
   }

   static void VisualizzaUtenti()
   {
      SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
      connection.Open(); // apre la connessione al database
      string sql = "SELECT * FROM utenti";
      SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
      SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al database e salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
      while (reader.Read())
      {
         Console.WriteLine($"id_utente: {reader["id_utente"]}, nome: {reader["nome"]}, cognome: {reader["cognome"]}, eta: {reader["eta"]}");
      }
      connection.Close(); // chiude la connessione al database
   }

   static void VisualizzaTabellaCompleta()
   {
      SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
      connection.Open(); // apre la connessione al database
      string sql = "SELECT utenti.id_utente, utenti.nome, utenti.cognome, videogiochi.titolo, videogiochi.voto FROM utenti JOIN videogiochi ON utenti.id_utente = videogiochi.id_utente;";
      SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
      SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al database e salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
      while (reader.Read())
      {
         Console.WriteLine($"id_utente: {reader["id_utente"]}, nome: {reader["nome"]}, cognome: {reader["cognome"]}, titolo: {reader["titolo"]}, voto: {reader["voto"]}");
      }
      connection.Close(); // chiude la connessione al database
   }
   
   static void InserisciCategoria()
    {
        Console.WriteLine("inserisci il nome della categoria");
        string nome = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"INSERT INTO categorie (nome) VALUES ('{nome}')"; // crea il comando sql che inserisce una categoria
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }
   
    static void EliminaCategoria()
    {
        Console.WriteLine("inserisci il nome della categoria");
        string nome = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"DELETE FROM categorie WHERE nome = '{nome}'"; // crea il comando sql che elimina la categoria con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }
   static void ModificaVotoVideogioco()
    {
        Console.WriteLine("inserisci il nome del videogioco"); // chiede il nome del prodotto da modificare
        string nome = Console.ReadLine()!; // legge il nome del prodotto da modificare
        Console.WriteLine("inserisci il nuovo voto"); // chiede il nuovo prezzo del prodotto da modificare
        string voto = Console.ReadLine()!; // legge il nuovo prezzo del prodotto da modificare
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"UPDATE videogiochi SET voto = {voto} WHERE nome = '{nome}'"; // crea il comando sql che modifica il prezzo del prodotto con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database ExecuteNonQuery() viene utilizzato per eseguire comandi che non restituiscono dati, ad esempio i comandi INSERT, UPDATE, DELETE
        connection.Close();
    }

   static void EliminaVideogioco()
   {
      Console.WriteLine("inserisci il titolo del videogioco");
      string titolo = Console.ReadLine()!;
      SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
      connection.Open(); // apre la connessione al database
      string sql = $"DELETE FROM videogiochi WHERE titolo = '{titolo}'";
      SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
      command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
      connection.Close(); // chiude la connessione al database
   }

   static void EliminaUtente()
   {
      Console.WriteLine("inserisci il nome dell'utente");
      string nome = Console.ReadLine()!;
      SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database
      connection.Open(); // apre la connessione al database
      string sql = $"DELETE FROM utenti WHERE nome = '{nome}'";
      SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
      command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
      connection.Close(); // chiude la connessione al database
   }
   
   
}
