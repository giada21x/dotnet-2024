public class View
{
    public void ShowMainMenu()
    {
        Console.WriteLine("Benvenuto!");

        Console.WriteLine("In quale menu vuoi accedere?:");
        Console.WriteLine("1. Menu Utente");
        Console.WriteLine("2. Menu Videogioco");
        Console.WriteLine("3. Menu Voti");
        Console.WriteLine("4. Menu Genere");
        Console.WriteLine("5. Menu Platform");
        Console.WriteLine("6. Esci");
        
    }
    public string GetInput()
    {
        return Console.ReadLine()!;
    }
}

