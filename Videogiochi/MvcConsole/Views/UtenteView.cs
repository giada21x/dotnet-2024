public class UtenteView
{
   
   public void ShowMenuUtente()
    {
        Console.WriteLine("Cosa desideri fare?");
        
        Console.WriteLine("1. Aggiungi un utente");
        Console.WriteLine("2. Visualizza tutti gli utenti");
        Console.WriteLine("3. Modifica un utente");
        Console.WriteLine("4. Rimuovi un utente");
        Console.WriteLine("5. Esci");
        
    } 

    public void ShowAggiungiUtente()
    {
        Console.WriteLine("Inserisci nickname, nome, cognome ed età");
    }

    public void ShowVisualizzaUtenti(List<Utente> utenti)
    {
        foreach (var utente in utenti)
        {
            Console.WriteLine($"Nickname: {utente.Nickname}, Nome: {utente.Nome}, Cognome: {utente.Cognome}, Età: {utente.Eta}");

        }
    }
    
    public void ShowModificaUtente()
    {
        Console.WriteLine("Cosa desideri modificare?");
        Console.WriteLine("1. Modifica il nickname");
        Console.WriteLine("2. Modifica il nome");
        Console.WriteLine("3. Modifica il cognome");
        Console.WriteLine("4. Modifica l'età");
    }

    
    public void ShowRimuoviUtente()
    {
        Console.WriteLine("Chi vuoi eliminare?");
        
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



