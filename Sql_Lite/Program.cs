
//crea il database dall'interno
class Program
{
    static void Main(string[] args)
    {
        string path = @"database.db"; //la rotta del file del database
        if (!File.Exists(path)) //se il file del database non esiste 
        {
            SQLiteConnection.CreateFile(path); //crea il file del database
            SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=1.0.118;"); //crea la connessione al database la versione 3 è un un indicatore 
            connection.Open(); //apre la connessione al database
            string sql = @"
                        CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita >= 0 ));
                        INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p1', 1, 10);
                        INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p2', 2, 20);
                        INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p3', 3, 30);
                        ";
            SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione al database
            command.ExecuteNonQuery(); //esegue il comando sql sulla connessione al database
            connection.Close(); //chiude la connessione al database
        }
        while (true)
        {
            Console.WriteLine("1 - Inserisci prodotto");
            Console.WriteLine("2 - visualizza i prodotti");
            Console.WriteLine("3 - elimina prodotti");
            Console.WriteLine("4 - esci");
            Console.WriteLine("scegli un'opzione");
            string scelta = Console.ReadLine()!;
            if (scelta == "1")
            {
                InserisciProdotto();

            }
            else if (scelta == "2")
            {
                VisualizzaProdotto();
            }
            else if (scelta == "3")
            {
                Eliminaprodotto();
            }
            else if (scelta == "4")
            {
                break;
            }
        }
    }

    static void InserisciProdotto()
    {
        Console.WriteLine("Inserisci il nome del prodotto");
        string nome = Console.ReadLine();
        Console.WriteLine("Inserisci il prezzo del prodotto");
        string prezzo = Console.ReadLine();
        Console.WriteLine("Inserisci la quantità del prodotto");
        string quantita = Console.ReadLine();
        SQLiteConnection connection = new SQLiteConnection($"Data Source = database.db; Version = 1.0.118;"); //crea la connessione al database
        connection.Open(); //apre la connessione al database
        string sql = $"INSERT INTO prodotti (nome, prezzo, quantità) VALUES ('{nome}', {prezzo}, {quantita})";
        SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione
        command.ExecuteNonQuery(); //esegue il comando sql sulla connessione al database
        connection.Close(); //chiude la connessione al database
    }
    static void VisualizzaProdotto()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=1.0.118;"); // crea la connessione al database
        connection.Open(); //apre la connessione al dtatabase
        string sql = "SELECT * FROM prodotti";
        SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione al database
        SQLiteReader reader = command.ExecuteReader(); //esegue il comando sql sulla connessione al database e salva i dati in reader
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome:{reader["nome"]}, prezzo:{reader["prezzo"]}, quantita:{reader["quantita"]}");

        }
    }
    static void Eliminaprodotto()
    {
        Console.WriteLine("Inserisci il nome del prodotto");
        string nome = Console.ReadLine();
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=1.0.118; ");
        connection.Open(); //apre la connessione al dtatabase
        string sql = $"DELETE FROM prodotti WHERE nome = '{nome}';";
        SQLiteCommand command = new SQLiteCommand(sql, connection); //crea il comando sql da eseguire sulla connessione
        command.ExecuteNonQuery(); //esegue il comando sql sulla connessione al database
        connection.Close();  //chiude la connessione al database

    }

}