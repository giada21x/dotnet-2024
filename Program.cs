//questo programma genera 10 numeri casuali (da 1 a 10) e ne calcola la somma
class Program
{
    static void Main(string[] args)
    {
        Random random = new Random(); //generatore di numeri casuali (creo la classe Random)
        int somma = 0; //la somma inziale è zero
        for (int i = 0; i < 10; i++) //definiamo la i(contatore) e gli diamo un valore iniziale di 0 e un valore massimo minore di 10 e lo andiamo a incrementare con ++
        {
            int numero = random.Next(1, 11);//genera un numero casuale tra 1 e 10, si dice che l'intervallo è [1, 10) cioè l'intervallo semiaperto 
            somma += numero; //somma = somma + numero utilizzando operatore di assegnazione composto
            Console.Write($"Il numero casuale è ");//utilizzo il Console.Write per non andare a capo
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"{numero}");
            Console.ResetColor();//resettato il colore di default
            
        }
        Console.Write($"La somma è ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"{somma}");
        
        Console.ResetColor();
    }
}








