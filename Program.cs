class Program
{
    static async Task Main(string[] args)
    {
        int timeoutInSeconds = 5; //imposta il tempo di attesa in secondi
        Task inputTask = Task.Run(() =>
       {
            Console.WriteLine($"Inserisci un input entro {5} secondi");
            return Console.ReadLine();
            
        });
        Task delayTask = Task.Delay(TimeSpan.FromSeconds(timeoutInSeconds));

        if (await Task.WhenAny(inputTask, delayTask) == inputTask)
        {
            //l'utente ha inserito l'input
            string input = await (inputTask as Task<string>);
            Console.WriteLine($"Hai inserito: {input}");
        }
        else 
        {
            //il tempo è scaduto
            Console.WriteLine("Tempo scaduto!");
        }
    }
}
