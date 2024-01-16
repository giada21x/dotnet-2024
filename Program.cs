class Program
{
    static void Main(string[] args)
    {
       Console.Clear();
       bool continua = true;
       do
       {
            Console.Clear();

            Console.WriteLine("Menù di selezione");
            Console.WriteLine("1.Opzione uno");
            Console.WriteLine("2.Opzione due");
            Console.WriteLine("3.Opzione tre");
            Console.WriteLine("4.Esci");
            Console.WriteLine("Scegli un opzione");
            string? scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.WriteLine("Hai selezionato l'opzione uno");
                    break;
                case "2":
                    Console.WriteLine($"Hai selezionato l'opzione due");
                    break;
                case "3":
                    Console.WriteLine($"Hai selezionato l'opzione tre");
                    break;
                case "4":
                    Console.WriteLine($"Uscita in corso");
                    return; //con return mi esce dal programma
                default:
                    Console.WriteLine($"Selezione non valida. Riprova.");
                    break;

    
            }
            if (continua)
            {
                Console.WriteLine($"Premi un tasto per continuare...");
                Console.ReadKey(); //Aspetta che l'utente prema un tasto prima di mostrare il menu
                
                
            }
            
        }
        while (continua);
    }
}
