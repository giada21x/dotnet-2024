using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        var db = new Database();
        var view = new View(db);
        var controller = new Controller(db, view);
        controller.MainMenu();
    }
}

class Database : DbContext
{
    public DbSet<Users> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = MyDatabase.sqlite");


    }

    public void AddUsers(string nome)
    {
        var user = new Users { Nome = nome };
        Users.Add(user);
        SaveChanges();

    }

    public List<string> GetUsers()
    {
        var users = Users.ToList();
        List<string> lista = new();
        foreach (var user in users)
        {
            lista.Add(user.Nome);
        }
        return lista;
    }

    public void RemoveUsers(string name)
    {
        foreach (var user in Users)
        {
            if (user.Nome == name)
            {
                Users.Remove(user);
            }
        }
        SaveChanges();
    }

    public void UpdateUsers(string name, string newName)
    {
        foreach (var user in Users)
        {
            if (user.Nome == name)
            {
                user.Nome = newName;
            }
           
        }
        SaveChanges();
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
        Console.WriteLine("2. Leggi user");
        Console.WriteLine("3. Elimina user");
        Console.WriteLine("4. Modifica user");
        Console.WriteLine("5. Esci");
    }
    public void ShowUsers(List<string> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }

    public string GetInput()
    {
        return Console.ReadLine()!;

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
                break;
            }
        }
    }

    private void AddUser()
    {
        Console.WriteLine("Enter user name");
        var name = _view.GetInput();
        _db.AddUsers(name);

    }

    private void ShowUsers()
    {
        var users = _db.GetUsers();
        _view.ShowUsers(users);
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
        Console.WriteLine("Update user");
        ShowUsers();
        Console.WriteLine("Select name");
        var name = _view.GetInput();
        Console.WriteLine("Insert new name");
        var newName = _view.GetInput();
        _db.UpdateUsers(name, newName);
        

    }
}