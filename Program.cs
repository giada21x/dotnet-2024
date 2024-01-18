//inseriamo un numero, inseriamo un secondo numero e mettiamo un'operazione //metodo console che mi chieda il primo numero //console secondo numero //console operazione //
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        bool continua = true;
        do
        {
            Console.WriteLine("Inserisci i due operandi: ");
            int a = Int32.Parse(Console.ReadLine());
            int b = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Scegli l'operazione:");

            Console.WriteLine("1. Moltiplicazione ");
            Console.WriteLine("2. Divisione ");
            Console.WriteLine("3. Somma ");
            Console.WriteLine("4. Sottrazione ");
            Console.WriteLine("5. Uscita ");

            int risultato = 0;

            string input = Console.ReadLine();
            switch (input)
            {

                case "1":


                    risultato = a * b;
                    Console.WriteLine($"Il risultato della moltiplicazione è: {risultato}");
                    break;
                case "2":


                    risultato = a / b;
                    Console.WriteLine($"Il risultato della divisione è: {risultato}");
                    break;
                case "3":


                    risultato = a + b;
                    Console.WriteLine($"Il risultato della somma è: {risultato}");
                    break;
                case "4":


                    risultato = a - b;
                    Console.WriteLine($"Il risultato della sottrazione è: {risultato}");
                    break;
                default:
                    Console.WriteLine("Uscita in corso...");
                    return;
            }
            Console.WriteLine($"Vuoi continuare? (s/n)");
            string? risposta = Console.ReadLine();
            if (risposta == "n")
            {
                return;
            }
        }
        while (continua);
    }
}







