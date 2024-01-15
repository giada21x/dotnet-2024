// using System;
// using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        List<string> nomi = new List<string>();
        nomi.Add("Mario");
        nomi.Add("Luigi");
        nomi.Add("Giovanni");
        // List<string> nomi = new List<string> { "Mario", "Luigi", "Giovanni" };

        int i = 0; // Indice inizializzato a 0
        while (i < nomi.Count) // Il ciclo continua finché l'indice è minore del numero di elementi nella lista
        {
            Console.WriteLine($"Ciao {nomi[i]}");
            i++; // Incremento dell'indice
        }
    }
}