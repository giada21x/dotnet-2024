using System.Runtime.ConstrainedExecution;

class Program
{
    static void Main(string[] args)
    {
        int timeoutInSeconds = 5; //inizialiazza il tempo di timeout
        Console.WriteLine($"Inserisci un input entro {timeoutInSeconds} secondi");

        bool inputReceived = false; //inizializza input come non ricevuto finchè non si verifica il Console.KeyAvailable
        string? input = ""; //inizializza una variabile di tipo string chiamata input con una stringa vuota così puoi assegnare un valore a input all'interno del ciclo e poi accedere a quel valore anche al di fuori del ciclo (all'interno dell'intera funzione Main)
        DateTime endTime = DateTime.Now.AddSeconds(timeoutInSeconds);//DateTime.now restuituisce l'ora corrente. il metodo AddSeconds(timeoutInseconds) aggiunge il numero specificato di secondi (in questo, il valore della variabile timeoutinseconds) all'ora corrente.Il risultato è un DateTime che rappresenta il momento esatto quando il tempo di attesa in scadenza.
        while (DateTime.Now < endTime)//il ciclo while (DateTime.Now < endtime) continua a eseguirsi finchè l'ora corrente (Datetime.Now) è inferiore a endTime. Questo significa che il ciclo continuerà a girare per la durata specificata da timeoutInSeconds (5)
        {
            if (Console.KeyAvailable) //viene utilizzato per verificare se è stato premuto un tasto, permettendo al programma di reagire immediatamente all'input dell'utente senza bloccare l'esecuzione.
            {
                input = Console.ReadLine();
                inputReceived = true; //dato che il valore di input viene controlalto dopo il ciclo per dterminare se l'utente ha fornito con input, inizializzando con una stringa vuota si stabilice un valore di patenza noto. Se input rimane una stringa vuota dopo il ciclo, significa che l'utente non ha inserito alcun dato.
                break;
            }
            Thread.Sleep(100);//piccola pausa per ridurre il carico dela CPU
        }

        if (inputReceived)
        {
            Console.WriteLine($"hai inserito: {input}");
            
        }
        else
        {
            Console.WriteLine($"Tempo scaduto!");
            
        }

    }
}







