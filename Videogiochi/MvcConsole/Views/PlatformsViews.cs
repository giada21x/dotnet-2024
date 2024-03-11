
public class PlatformViews
{
    public void ShowMenuPlatform()
    {
        Console.WriteLine("Cosa desideri fare?");
        
        Console.WriteLine("1. Aggiungi una console");
        Console.WriteLine("2. Visualizza tutti le console");
        Console.WriteLine("3. Modifica una console");
        Console.WriteLine("4. Rimuovi una console");
        Console.WriteLine("5. Esci");
    } 
    public void ShowAggiungiPlatform()
    {
        Console.WriteLine("Inserisci la console da inserire");
    }
    public void ShowVisualizzaPLatform(List<Platform> PLatform)
    {
        foreach (var platform in PLatform)
        {
            Console.WriteLine(platform);
        }
    }
    public void ShowModificaPlatform()
    {
        Console.WriteLine("1. Modifica il nome della console");
    }
    public void ShowRimuoviPlatform()
    {
        Console.WriteLine("Quale console vuoi eliminare?");
        
    }
    public string GetInput()
    {
        return Console.ReadLine()!;
    }
}