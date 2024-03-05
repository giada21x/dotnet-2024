
using System.Data.SQLite;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        var db = new Database(); //Model
        var view = new View(db); //View
        var controller = new Controller(db, view); //Controller
        controller.MainMenu(); //Menu principale dell'app
    }
}

class Database
{
    private SQLiteConnection _connection;
    public Database()
    {
        _connection = new SQLiteConnection("Data Source=database.db");
        _connection.Open();
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS users ( id INTEGER PRIMARY KEY, name TEXT)", _connection);
        command.ExecuteNonQuery();
    }
    public void AddUser(string name)
    {
        var command = new SQLiteCommand($"INSERT INTO users (name) VALUES ('{name}')", _connection);
        command.ExecuteNonQuery();
    }

    public List<string> GetUsers()
    {
        var command = new SQLiteCommand("SELECT name FROM users", _connection);
        var reader = command.ExecuteReader();
        var users = new List<string>();
        while (reader.Read())
        {
            users.Add(reader.GetString(0));
        }
        return users;
    }

    public void RemoveUsers(string name)
    {
        var command = new SQLiteCommand($"DELETE FROM users WHERE name = '{name}'", _connection);
        command.ExecuteNonQuery();
    }

    public void UpdateUsers(string name, string newName)
    {
        var command = new SQLiteCommand($"UPDATE users SET name = '{newName}' WHERE name = '{name}'", _connection);
        command.ExecuteNonQuery();
    }
}
class View
{
    private Database _db;
    public View(Database db)
    {
        _db = db;
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi users");
        Console.WriteLine("3. Elimina");
        Console.WriteLine("4. Modifica");
        Console.WriteLine("5. Esci");
    }

    public void ShowUsers(List<string> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine(user); //Visualizzazione dei nomi degli utenti
        }
    }

    public string GetInput()
    {
        return Console.ReadLine()!; //Lettura dell'input
    }

    
}

class Controller
{
    private Database _db;
    private View _view;

    

    public Controller(Database db, View view)
    {
        _db = db;
        _view = view;
    }

    public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu();
            var input = _view.GetInput();
            
            if (input == "1")
            {
                AddUser();
            }
            else if (input == "2")
            {
                ShowUsers();
            }
            else if (input == "3")
            {
                RemoveUsers();
            }
            else if (input == "4")
            {
                UpdateUsers();
            }
            else if (input == "5")
            {
                 break; //Uscita dal programma
            }
        }
    }

    private void AddUser()
    {
        Console.WriteLine("Enter user name:"); //Richiesta del nome dell'utente
        var name = _view.GetInput(); //Lettura del nome dell'utente
        _db.AddUser(name); //Aggiunta dell'utente al database 

    }

    private void ShowUsers()
    {
        var users = _db.GetUsers(); //Lettura degli utenti dal database
        _view.ShowUsers(users); //Visualizzazione degli utenti
    }

    private void RemoveUsers()
    {
        Console.WriteLine("Remove user");
        var users = _db.GetUsers();
        var name = _view.GetInput();
        _view.ShowUsers(users);
        _db.RemoveUsers(name);
    }

    private void UpdateUsers()
    {
        Console.WriteLine($"Update user");
        ShowUsers();
        Console.WriteLine($"Select name");
        var name = _view.GetInput();
        Console.WriteLine($"Insert new name");
        var newName = _view.GetInput();
        _db.UpdateUsers(name, newName);
    }
}

