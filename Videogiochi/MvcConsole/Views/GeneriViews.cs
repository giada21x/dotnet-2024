public class GeneriView
{
    public void ShowMenuGenere()
    {
        Console.WriteLine("Cosa desideri fare?");
        
        Console.WriteLine("1. Aggiungi un genere");
        Console.WriteLine("2. Visualizza tutti i generi");
        Console.WriteLine("3. Modifica un genere");
        Console.WriteLine("4. Rimuovi un genere");
        Console.WriteLine("5. Esci");
    } 
    public void ShowAggiungiGenere()
    {
        Console.WriteLine("Inserisci il genere da inserire");
    }

    public void ShowVisualizzaGeneri(List<Genere> generi)
    {
        foreach (var genere in generi)
        {
            Console.WriteLine(genere);
        }
    }
    public void ShowModificaGenere()
    {
        Console.WriteLine("1. Modifica il nome del genere");
    }
    public void ShowRimuoviGenere()
    {
        Console.WriteLine("Quale genere vuoi eliminare?");
        
    }
    public string GetInput()
    {
        return Console.ReadLine()!;
    }
}