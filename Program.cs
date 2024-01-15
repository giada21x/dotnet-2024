class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Inserisci un comando speciale (esempio: 'cmd:info' , 'cmd:exit')");
        string nome = "Giada";
        while (true)
        {
            string? input = Console.ReadLine();
            //analizzare l'input per vedere se segue un formato specifico
            if (input.StartsWith("cmd:"))
            {
                string comando = input.Substring(4); //estrae la parte del comando dopo "cmd:"

                switch (comando.ToLower())
                {
                    case "info":
                        Console.WriteLine("Comando 'info' riconosciuto. Mostrando le informazioni...");
                        //aggiungi qui la logica per mostrare le informazioni
                        break;
                    case "nome":
                        Console.WriteLine($"Ciao {nome}");
                        //aggiungi qui la logica per mostrare le informazioni
                        break;
                    case "exit":
                        Console.WriteLine("Comando 'exit' riconosciuto. Uscita in corso...");
                        return; //esce dal programma
                    default:
                        Console.WriteLine($"Comando '{comando}' non riconosciuto.");
                        break;

                }
            }
            else
            {
                Console.WriteLine("Input non valido. Inserici un comando");
            }

            Console.WriteLine("\nInserisci un altro comando");

        }
    }
}