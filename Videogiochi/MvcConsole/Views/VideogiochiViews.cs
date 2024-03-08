public class VideogiochiViews
{
    
    public void ShowMenuVideogioco()
    {
        Console.WriteLine("1. Aggiungi un videogioco");
        Console.WriteLine("2. Visualizza tutti i videoigiochi");
        Console.WriteLine("3. Modifica un videogioco");
        Console.WriteLine("4. Rimuovi un videogioco");
        Console.WriteLine("5. Esci");
        
    }

    public void ShowAggiungiVideogioco()
    {
        Console.WriteLine("Inserisci titolo, anno di uscita, id_genere e id_platform");
    }
    public void ShowVisualizzaVideogiochi(List<Videogioco> videogiochi)
    {
        foreach (var videogioco in videogiochi)
        {
            Console.WriteLine(videogioco.Titolo, videogioco.Anno, videogioco.Genere, videogioco.Platform);
            
        }
    }
     public void ShowModificaVideogioco()
    {
        Console.WriteLine("1. Modifica il titolo");
        Console.WriteLine("2. Modifica l'anno di uscita");
        Console.WriteLine("3. Modifica l'id genere");
        Console.WriteLine("4. Modifica l'id platform");
        
    }

    
    public void ShowRimuoviVideogioco()
    {
        Console.WriteLine("Che videogioco vuoi eliminare?");
        
    }
    

    public string GetInput()
    {
        return Console.ReadLine()!;
    }
    public int GetInputInt()
    {
        return int.Parse(Console.ReadLine()!);
        
    }
}