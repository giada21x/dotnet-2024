class View
{
    public void ShowMainMenu()
    {
        Console.WriteLine("Cosa vuoi fare?:");
        Console.WriteLine("1. Aggiungere");
        Console.WriteLine("2. Visualizzare");
        Console.WriteLine("3. Modificare");
        Console.WriteLine("4. Eliminare");
        Console.WriteLine("5. Esci");
    }

    public void ShowAddMenu()
    {
        Console.WriteLine("1. Aggiungi un videogioco");
        Console.WriteLine("2. Aggiungi un utente");
        Console.WriteLine("3. Aggiungi un voto ");
        Console.WriteLine("4. Aggiungi un genere");
        Console.WriteLine("5. Aggiungi una console");
    }

    public void ShowShowMenu()
    {
        Console.WriteLine("1. Visualizza la tabella videogioco");
        Console.WriteLine("2. Visualizza la tabella utente");
        Console.WriteLine("3. Visualizza la tabella voto");
        Console.WriteLine("4. Visualizza la tabella genere");
        Console.WriteLine("5. Visualizza la tabella console");
    }
    public void ShowUpdateMenu()
    {
        Console.WriteLine("1. Modifica la tabella videogioco");
        Console.WriteLine("2. Modifica la tabella utente");
        Console.WriteLine("3. Modifica la tabella voto");
        Console.WriteLine("4. Modifica la tabella genere");
        Console.WriteLine("5. Modifica la tabella console");
    }
    public void ShowUpdateVideogioco()
    {
        Console.WriteLine("1. Modifica il titolo del videogioco");
        Console.WriteLine("2. Modifica l'anno di uscita del videogioco");
        Console.WriteLine("3. Modifica il genere del videogioco");
        Console.WriteLine("4. Modifica la console del videogioco");
    }
    public void ShowUpdateUtente()
    {
        Console.WriteLine("1. Modifica il nome di un utente");
        Console.WriteLine("2. Modifica il cognome di un utente");
        Console.WriteLine("3. Modifica l'età di un utente");
    }
    public void ShowUpdateVoti()
    {
        Console.WriteLine("1. Modifica il voto");
        
        
    }
    public void ShowRemoveMenu()
    {
        Console.WriteLine("1. Rimuovi elementi della tabella videogioco");
        Console.WriteLine("2. Rimuovi elementi della tabella utente");
        Console.WriteLine("3. Rimuovi elementi della tabella voto");
        Console.WriteLine("4. Rimuovi elementi della tabella genere");
        Console.WriteLine("5. Rimuovi elementi della tabella console");
    }
     public string GetInput()
    {
        return Console.ReadLine()!;
        
    }
}