class Program
{
    static void Main(string[] args)
    {
        while(true)
        { 
            Console.Clear(); //pulisce la console ad ogni iterazione
            Console.WriteLine("Menù di sselezione");
            Console.WriteLine("1. Opzione Uno");
            Console.WriteLine("2. Opzione Due");
            Console.WriteLine("3. Opzione Tre");
            Console.WriteLine("4, Esci");

            Console.WriteLine("Inserisci il numero dell'opzione desiderata");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Hai selezionato l'Opzione Uno" );
                    break;
                case "2":
                    Console.WriteLine("Hai scelto l'Opzione Due");
                    break;
                case "3":
                    Console.WriteLine("Hai scelto l'Opzione Tre");
                    break;
                case "4":
                    Console.WriteLine("Uscita in corso...");
                    return;
                default:
                    Console.WriteLine("selezione non valida. Riprova.");
                    break;


            }
        }
          
    }
}
