
public class ValutazioneView
{
    public void ShowMenuVoti()
    {
        Console.WriteLine("Cosa desideri fare?");
        
        Console.WriteLine("1. Aggiungi un voto");
        Console.WriteLine("2. Visualizza tutti i voti");
        Console.WriteLine("3. Modifica un voto");
        Console.WriteLine("4. Rimuovi un voto");
        Console.WriteLine("5. Esci");
    } 
    public void ShowAggiungiVoto()
    {
        Console.WriteLine("Inserisci il voto");
    }
    public void ShowVisualizzaVoti(List<Valutazione> voti)
    {
        foreach (var voto in voti)
        {
            Console.WriteLine(voto);

        }
    }
    public void ShowModificaVoto()
    {
        Console.WriteLine("1. Modifica il voto");
    }
    public void ShowRimuoviVoto()
    {
        Console.WriteLine("Quale voto vuoi eliminare?");
        
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