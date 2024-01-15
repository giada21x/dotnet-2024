//

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Premi 'N' per terminare...");

        //ciclo che continua fino a quando viene premuto il tasto 'N'
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.N)
            {
                break; //esce dal ciclo se viene premuto 'N'
            }
        }
    }
}
