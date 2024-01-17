class Program
{
    static void Main(string[] args)
    {
        string[] nomi = ["Mario", "Luigi", "Giovanni"]; //array di stringhe 
        Random random = new Random(); //oggetto per generare numeri casuali in questo caso tra 0 e 2 
        int indice = random.Next(0, 3); //random.next è un metodo della classe Random
        Console.WriteLine($"Il nome selezionato è {nomi[indice]}");//stampa il nome sorteggiato
        
    }
}








