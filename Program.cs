class Program
{
    static void Main(string[] args)
    {
        string[] nomi = new string[3];
        nomi[0] = "Mario";
        nomi[1] = "Luigi";
        nomi[2] = "Giovanni";
        // string[] nomi = new string[] { "Mario", "Luigi", "Giovanni" };

        int i = 0; // Variabile indice inizializzata a 0
        while (i < nomi.Length) // Il ciclo continua finché l'indice è minore della lunghezza dell'array
        {
            Console.WriteLine($"Ciao {nomi[i]}");
            i++; // Incremento dell'indice
        }
    }
}