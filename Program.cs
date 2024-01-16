class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        System.Console.WriteLine("1. Inserisci opzione uno ");
        System.Console.WriteLine("2. Insersci opzione due ");
        System.Console.WriteLine("3. Inserisci opzione tre ");
        System.Console.WriteLine("4. Inserisci opzion quattro ");
        System.Console.WriteLine("5. Insersci opzione cinque ");
        System.Console.WriteLine("6. Inserisci opzione sei ");
         //cwl=inserisci autimaticamente il console

        while (true)
        {
            Console.WriteLine($"Digita...");
            
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Beep();
                    break;
                case "2":
                    Console.Beep(750, 300);
                    break;
                case "3":
                    Console.CursorVisible = true;
                    break;
                case "4":
                    Console.CursorVisible = false;
                    break;
                case "5":
                    Console.WriteLine($"Inserisci la frequenza");
                    int freq = Int32.Parse(Console.ReadLine());

                    Console.WriteLine($"Inserisci durata in ms");
                    int ms = Int32.Parse(Console.ReadLine());

                    Console.Beep(freq, ms);
                    break;


                default:
                Console.Clear();
                    break;
            }

        }
    }
}
