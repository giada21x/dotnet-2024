# ESERCITAZIONI BASE SU C#

### 01-DICHIARARE UNA VARIABILE DI TIPO STRINGA

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        string nome = "Giada";
        Console.WriteLine($"Ciao {nome}");
    }
}

// oppure

class Program
{
    static void Main(string[] args)
    {
        string nome = "Giada";
        Console.WriteLine($"Ciao {nome}");
        Console.WriteLine("Ciao " + nome);
        Console.WriteLine($"Ciao {nome} Adamo");
    } 
}

```
</details>

### 02-DICHIARARE UNA VARIABILE DI TIPO INTERO

<details>
    <summary> codice </summary>

```c#

class Program
{
    static void Main(string[] args)
    {
        int eta = 20;
        Console.WriteLine($"Hai {eta} anni");
    }
}

```
</details>

### 03-DICHIARARE UNA VARIANILE DI TIPO BOOLEANO

<details>
    <summary> codice </summary>

```c#

class Program
{
    static void Main(string[] args)
    {
        bool maggiorenne = true;
        Console.WriteLine($"Sei maggiorenne? {maggiorenne}");
    } 
}

```
</details>

### 04-DICHIARARE UNA VARIABILE DI TIPO DECIMALE

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        decimal altezza = 1.60M;
        Console.WriteLine($"Sei alto {altezza} metri");
    }
}

```
</details>

### 05-DICHIARARE UNA VARIABILE DI TIPO DATA

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        DateTime dataDiNascita = new DateTime(2001, 3, 21);
        Console.WriteLine($"Sei nato il {dataDiNascita}");
    }
}

```
</details>

### 06-DICHIARARE UNA VARIABILE DI TIPO DATA UTILIZZANDO IL METODO ToShortDateString()

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        DateTime dataDiNascita = new DateTime(2001, 3, 21);
        Console.WriteLine($"Sei nato il {dataDiNascita.ToShortDateString()}");
    }
}

```
</details>

### 07-DICHIARARE UNA VARIABILE DI TIPO DATA UTILIZZANDO IL METODO ToLongDateString()

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        DateTime dataDiNascita = new DateTime(2001, 3, 21);
        Console.WriteLine($"Sei nato il {dataDiNascita.ToLongDateString()}");
    }
}

```
</details>

### 08-UTILIZZARE L'OPERATORE + PR SOMMARE DUE INTERI 

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        int c = a + b;
        Console.WriteLine($"La somma di {a} e {b} è {c}");
    }
}

```
</details>

### 09-UTILIZZARE L'OPERATORE + PER SOMMARE DUE INTERI E UN DECIMALE

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        decimal c = 1.5m;
        decimal d = a + b + c;
        Console.WriteLine($"La somma di {a}, {b}, {c} e {d}");
    }
}

```
</details>

### 10-UTILIZZARE L'OPERATORE == PER CONFRONTARE DUE STRINGHE

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        string nome = "Giada";
        string cognome = "Adamo";
        bool uguali = (nome == cognome);
        Console.WriteLine($"I due nomi sono uguali? {uguali}");
    }
}

```
</details>

### 11-UTILIZZARE L'OPERATORE != PER CONFRONTARE DUE STRINGHE

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        string nome = "Giada";
        string cognome = "Adamo";
        bool diversi = (nome != cognome);
        Console.WriteLine($"I due nomi sono uguali? {diversi}");
    }
}

```
</details>

### 12-UTILIZZARE L'OPERATORE > PER CONFRONTARE DUE INTERI

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        bool maggiore = (a > b);
        Console.WriteLine($"Il primo numero è maggiore del secondo? {maggiore}");
    }
}

```
</details>

### 13-DICHIARARE UN ARRAY DI STRINGHE

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        string[] nomi = new string[3]; // array con numero predeterminato di elementi
        nomi[0] = "Mario";             // si può inserire un elemento in una posizione specifica
        nomi[1] = "Luigi";             // deve contenere dati allo stesso tipo
        nomi[2] = "Giovanni";
        Console.WriteLine($"Ciao {nomi[0]}, {nomi[2]} e {nomi[2]}");
    }
}

```
</details>

### 14-DICHIARARE UN ARRAY DI INTERI

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        int[] numeri = new int[3];
        numeri[0] = 10;
        numeri[1] = 20;
        numeri[2] = 20;
        Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]} e {numeri[2]}");
    }
}

```
</details>

### 15-DICHIARATE UN ARRAY DI STRINGHE E UTILIZZARE IL METODO LENGTH

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        string[] nomi = new string[3];
        nomi[0] = "Mario";
        nomi[1] = "Luigi";
        nomi[2] = "Giovanni";
        Console.WriteLine($"IL numero di elementi è {nomi.Length}");
    }
}

```
</details>

### 16-DICHIARARE UNA LISTA DI STRINGHE

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        List<string> nomi = new List<string>(); // utilizziamo il diamond invece di parentesi quadre
        nomi.Add("Mario");                      // aggiungo elemento con metodo add
        nomi.Add("Luigi");
        nomi.Add("Giovanni");
        Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");
    }
}

```
</details>

### 17-DICHIARARE UNA LISTA DI INTERI

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        List<int> numeri = new List<int>();
        numeri.Add(10);
        numeri.Add(20);
        numeri.Add(30);
        Console.WriteLine($"I numeri sono {numeri[0]}, {numeriè[1]} e {numeir[2]}");
    }
}

```
</details>

### 18-DICHIARARE UNA LISTA DI STRINGHE E UTILIZZARE IL METODO COUNT

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        List<string> nomi = new List<string>();
        nomi.Add("Mario"); 
        nomi.Add("Luigi");
        nomi.Add("Giovanni");
        Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");
        Console.WriteLine($"Il numero di elementi e' {nomi.Count}");
    }
}

```
</details>

### 19-DICHIARARE UNA PILA DI STRINGHE

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        Stack<string> nomi = new Stack<string>();
        nomi.Push("Mario"); // aggiungo elemento con metodo Push
        nomi.Push("Luigi");
        nomi.Push("Giovanni");
        Console.WriteLine($"Ciao {nomi.Pop()}, {nomi.Pop()} e {nomi.Pop()}");
    }
}

```
</details>

### 20-DICHIARARE UNA CODA DI STRINGHE

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        Queue<string> nomi = new Queue<string>();
        nomi.Enqueue("Mario"); // aggiungo elemento con metodo Enqueue
        nomi.Enqueue("Luigi");
        nomi.Enqueue("Giovanni");
        Console.WriteLine($"Ciao {nomi.Dequeue()}, {nomi.Dequeue()} e {nomi.Dequeue()}");
    }
}

```
</details>

### 21-RIORDINARE UNA LISTA CON METODO SORT E FUNZIONE DI STAMPA

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        // riordino lista numerica
        List<int> numeri = new List<int> {2,1,5,25,9,10,15};
        numeri.Sort();

        stampa(numeri);
    }

    static void stampa(List<int> listString)
    {   
        Console.WriteLine("Funzione stampa lista di stringhe:");

        for(int i = 0; i < listString.Count; i++)
        {
            Console.Write(listString[i] + ", ");
        }

        Console.WriteLine("\n"); //  ritorno a capo


    }
}

```
</details>

### 22-UTILIZZARE L'ISTRUZIONE IF

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        if (a > b) // la condizione da verificare si scrive tra parentesi
        {
            Console.WriteLine($"{a} e' maggiore di {b}");
        }
        Console.WriteLine("Fine!");
    }
}

```
</details>

### 23-UTILIZZARE L'ISTRUZIONE IF CON ELSE

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        if (a > b) // la condizione da verificare si scrive tra parentesi
        {
            System.Console.WriteLine($"{a} e' maggiore di {b}");
        }
        else
        {
            System.Console.WriteLine($"{a} e' minore di {b}");
        }
    }
}

```
</details>

### 24-UTLIZZARE L'ISTRUZIONE IF CON IF-ELSE E ELSE

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        if (a > b) // la condizione da verificare si scrive tra parentesi
        {
            Console.WriteLine("{a} e' maggiore di {b}");
        }
        if (a < b)
        {
            Console.WriteLine("{a} e' minore di {b}");
        }
        else
        {
            Console.WriteLine($"{a} e' uguale a {b}");
        }
    }
}

```
</details>

### 25-UTILIZZARE L'ISTRUZIONE SWITCH

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        // int b = 20;
        switch (a)
        {
            case 10:
                Console.WriteLine($"{a} e' uguale a 10");
                break;
            case 20:
                Console.WriteLine($"{a} e' uguale a 20");
                break;
            default:
                Console.WriteLine($"{a} non e' uguale a 10 o 20");
                break;
        }

    }
}

```
</details>

### 26-DICHIARARE UN DIZIONARIO DI STRINGHE

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> nomi = new Dictionary<string, string>();
        nomi.Add("Mario", "Rossi");
        nomi.Add("Luigi", "Verdi");
        nomi.Add("Giovanni", "Bianchi");
        Console.WriteLine($"Ciao {nomi["Mario"]} {nomi["Luigi"]} e {nomi["Giovanni"]}");
    }
}

```
</details>

### 27-INIZIALIZZARE UN DIZIONARIO SENZA IL METODO ADD

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
         Dictionary<string, int> nomi = new Dictionary<string, int>()
        {
            {"Mario", 25},
            {"Luigi", 30},
            {"Giovanni", 35}
        };

        Console.WriteLine($"Le vostre età sono {nomi["Mario"]} {nomi["Luigi"]} e {nomi["Giovanni"]}");

    }
}

```
</details>

### 28-UTILIZZARE IL CICLO FOR

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Il valore di i è {i}");
        }

    }
}

```
</details>

### 29-UTILIZZARE IL CICLO FOREACH CON UN ARRAY DI STRINGHE

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        string[] nomi = new string[3];
        nomi[0] = "Mario";
        nomi[1] = "Luigi";
        nomi[2] = "Giovanni";

        foreach (string nome in nomi)
        {
            Console.WriteLine($"Ciao {nome}");
        }
    }
}

```
</details>

### 30-UILIZZARE IL CICLO FOREACH CON UNA LISTA

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        List<string> nomi = new List<string>();
        nomi.Add("Mario");
        nomi.Add("Luigi");
        nomi.Add("Giovanni");

        foreach (string nome in nomi)
        {
            Console.WriteLine($"Ciao {nome}");
        }
    }
}

```
</details>

### 31-UTILIZZARE FOREACH PER SOCPRIRE QUALI KEY CONTIENE UN DICTIONARY

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> eta = new ()
        {
            {"Mario", 25},
            {"Luigi", 30},
            {"Giovanni", 35}
        };

        foreach (string nome in eta.Keys)
        {
            Console.WriteLine($"Ciao {nome} hai {eta[$"{nome}"]} anni");
        }
    }
}

```
</details>

### 32-CERCA UN VALORE STRING IN UN ARRAY E LO COPIA IN UNA LISTA

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        string[] nomi = new string[5];
        nomi[0] = "Luigi";
        nomi[1] = "Mario";
        nomi[2] = "Luca";
        nomi[3] = "Mario";
        nomi[4] = "Mario";

        List<string> lista = new List<string>();

        foreach (string nome in nomi)
        {
            if (nome == "Mario")
            {
                System.Console.WriteLine("Trovato!");
                lista.Add(nome);
            }
        }

        Console.WriteLine($"La lista contiene {lista.Count} elementi");
    }
}

```
</details>

### 33-UTILIZZARE CICLO WHILE CON ARRAY DI STRINGHE 

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        List<string> nomi = ["Mario", "Luca", "Paolo"];
        int i = 0; // creo contatore

        while (i < nomi.Count)
        {
            Console.WriteLine($"Ciao {nomi[i]}");
            i++; // incremento contatore
        }

        Console.WriteLine($"Fine");
    }
}

```
</details>


### 35-UTILIZZARE LA CLASSE ConsoleKeyInfo E IL CICLO WHILE

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Premi 'N' per temrinare...");

       // ciclo loop
       while (true)
       {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.N)
            {
                break; // esce dal ciclo se viene premuto N
            }  
       }
    }
}

// OPPURE

class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("Premi 'Ctrl' + 'N' per terminare...");

       // ciclo loop
       while (true)
       {
            // aspetta finche non viene premuto un tasto
            ConsoleKeyInfo keyInfo = Console.ReadKey(true); // ???

            // verifica se il tasto 'Ctrl' è tenuto premuto
            if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0)
            {
                // controlla se il tasto premuto è N
                if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine("Combinazione 'Ctrl' + 'N' rilevata...");
                    break; ///
                }
            }  
       }
    }
}

```
</details>

### 36-MENU DI SELEZIONE SEMPLICE

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
         while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu di selezione");
            Console.WriteLine("1. Opzione Uno");
            Console.WriteLine("2. Opzione Due");
            Console.WriteLine("3. Opzione Tre");
            Console.WriteLine("4. Esci");

            Console.WriteLine("\nInserisci il numero dell'opzione desiderata: ");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Hai selezionato l'opzione 1");
                    break;

                case "2":
                    Console.WriteLine("Hai selezionato l'opzione 2");
                    break;

                case "3":
                    Console.WriteLine("Hai selezionato l'opzione 3");
                    break;

                case "4":
                    Console.WriteLine("Uscita in corso..");
                    return;
                    
                default :
                    Console.WriteLine("Errore nella selezione. Riprova");
                    break;
            }

            Console.WriteLine("Premi un tasto per continuare");
            Console.ReadKey();
            
        }
    }
}

```
</details>

### 37-MENU DI SELEZIONE DOPPIO CONTROLLO

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Inserisci un comando speciale ('cmd:info', 'cmd:exit')");

        while (true)
        {
            //
            string? input = Console.ReadLine();

            if (input.StartsWith("cmd:"))
            {
                string comando = input.Substring(4);

                switch (comando)
                {
                    case "info":
                        Console.WriteLine("Comando 'info' riconosciuto. Ecco le informazioni...");
                        break;

                    case "exit":
                        Console.WriteLine("Comando 'exit' riconosciuto. Uscita in corso...");
                        return;
                    
                    default:
                        Console.WriteLine($"Comando '{comando}' non riconosciuto.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Input non valido. Inserisci un comando valido");
            }

            Console.WriteLine("\nInserisci un altro comando");
            
        }
    }
}

// OPPURE

class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Inserisci il tuo nome");
        string? nome = Console.ReadLine();

        while (true)
        {
            Console.Clear();
            System.Console.WriteLine("Selezione un opzione:");
            System.Console.WriteLine("1 - saluto");
            System.Console.WriteLine("e - exit");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    System.Console.WriteLine($"Ciao {nome}");
                    break;

                case "e":
                    return;

                default:
                    System.Console.WriteLine($"Opzione {input} non valida. Riprova");
                    break;
            }

            System.Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
            
        }

    }
}

```
</details>

### 38-DRAG AND DROP DI UN FILE PER LEGGERNE IL CONTENUTO

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
         System.Console.WriteLine("Trascina un file qui e premi invio:");
        string? filePath = Console.ReadLine().Trim('"'); // rimuove le virgolette

        try
        {
            string contenuto = File.ReadAllText(filePath);
            Console.WriteLine("Contenuto del file: ");
            Console.WriteLine(contenuto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Si è verificato un errore: {ex.Message}");
            
        }
    }
}

```
</details>

### 39-MENU CON OPZIONI

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        System.Console.WriteLine("Seleziona l'opzione:");
        System.Console.WriteLine("1 - Nascondi il cursore");
        System.Console.WriteLine("2 - Mostra il cursore");
        System.Console.WriteLine("3 - Pulisci console");
        System.Console.WriteLine("4 - Emetti beep");
        System.Console.WriteLine("5 - Emetti beep prolungato");
        System.Console.WriteLine("6 - Imposta il titolo");
        System.Console.WriteLine("e - exit\n");

        while (true)
        {
            Console.WriteLine("Digita...");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.CursorVisible = false;
                    break;

                case "2":
                    Console.CursorVisible = true;
                    break;

                case "3":
                    Console.Clear();
                    break;

                case "4":
                    Console.Beep();
                    break;

                case "5":
                    Console.WriteLine("Inserisci la frequenza");
                    int freq = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Inserisci durata in ms");
                    int ms = Int32.Parse(Console.ReadLine());

                    Console.Beep(freq, ms);
                    break;

                case "6":
                    Console.Title = "La mia app";
                    break;

                case "e":
                    return;

                default:
                    Console.WriteLine("Opzione errata:");
                    break;

            }
    }
}
}

```
</details>

### 40-GESTIONE DEL TIMEOUT NELL'INSERIMENTO DI UN INPUT ASINCRONO CON TASK

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        int timeoutInSeconds = 5; // imposta il tempo di attesa in secondi

        Task inputTask = Task.Run(() =>
        {
            Console.WriteLine($"Inserisici un input entro {timeoutInSeconds} secondi:");            
            return Console.ReadLine();
        });

        Task delayTask = Task.Delay(TimeSpan.FromSeconds(timeoutInSeconds));

        if (await Task.WhenAny(inputTask, delayTask) == inputTask)
        {
            // l'utente ha inserito un input
            string input = await (inputTask as Task<string>);
            Console.WriteLine($"Hai inserito: {input}");            
        }
        else 
        {
            // il tempo è scaduto
            Console.WriteLine("Tempo scaduto!");
        }
    }
}

```
</details>

### 41-GESTIONE DEL TIMEOUT NELL'INSERIMENTO DI UN INPUT SEMPLICE

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        int timeoutInSeconds = 5;
        Console.WriteLine($"Inserisci input entro {timeoutInSeconds} secondi:");

        bool inputReceived = false;
        string? input = "";

        DateTime endTime = DateTime.Now.AddSeconds(timeoutInSeconds);

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                input = Console.ReadLine();
                inputReceived = true;
                break;
            }
            // Thread.Sleep(400);
            // System.Console.WriteLine($"{DateTime.Now}");
        }

        if (inputReceived)
        {
            Console.WriteLine($"Hai inserito: {input}");
            
        }
        else
        {
            Console.WriteLine("Tempo scaduto!");
        }
    }
}

```
</details>

### 42-UTILIZZARE LA CLASSE RANDOM PER GENERARE UN NUMERO CASULAE TRA 1 E 10 E LO SOMMA 10 VOLTE

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
       Random random = new Random();           // Generatore di numeri casuali
        int somma = 0;
        for (int i = 0; i < 10; i++)
        {
            int numero = random.Next(1,10);     // Genera un numero casuale tra 1 e 10 si dice che l'intervallo è [1,11)
            somma += numero;
            Console.WriteLine($"Il numero casuale è {numero}"); // interpolazione di stringhe
            
        }
        
        Console.WriteLine($"La somma è {somma}");
    }
}

```
</details>

### 43-GENERA UN NUMERO CASUALE PER SORTEGGIARE UN NOME DALL'ARRAY 

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        string[] nomi = ["Mario", "Luigi", "Giovanni"];
        Random random = new Random();
        int indice = random.Next(0, nomi.Length);
        Console.WriteLine($"Il nome sorteggiato è {nomi[indice]}");
    }
}

```
</details>

### 44-MENU DI SELEZIONE CON IL BEST-OFF DEI PROGRAMMI PASSATI

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        int freq, ms; // variabili per le opzioni 5, 6
        bool continua; // variabile per opzione 9
        string? prodotto = ""; // variabile per opzione 9
        List<string> listaSpesa = new List<string>();

        do
        {
            Console.Clear(); // pulisce lo schermo

            // stampa il menu
            Console.WriteLine("Menu delle opzioni:");
            Console.WriteLine("1 - Nascondi il cursore");
            Console.WriteLine("2 - Mostra il cursore");
            Console.WriteLine("3 - Drag&Drop");
            Console.WriteLine("4 - Emetti beep");
            Console.WriteLine("5 - Emetti beep prolungato");
            Console.WriteLine("6 - Crea melodia random");
            Console.WriteLine("7 - Saluto!");
            Console.WriteLine("8 - Timeout della console");
            Console.WriteLine("9 - Lista della spesa");
            Console.WriteLine("e - exit\n");
            Console.Write("Scegli un'opzione: ");

            string? input = Console.ReadLine()!.ToLower(); // prende anche input maiuscoli



            switch (input)
            {
                case "1":
                    Console.WriteLine("Hai selezionato l'opzione 1");
                    Console.CursorVisible = false;
                    break;

                case "2":
                    Console.WriteLine("Hai selezionato l'opzione 2");
                    Console.CursorVisible = true;
                    break;

                case "3":
                    // drag & drop
                    Console.WriteLine("Hai selezionato l'opzione 3");
                    Console.WriteLine("Trascina qui dentro un file...");

                    string? filePath = Console.ReadLine()!.Trim('"'); // rimuove le virgolette
                    Console.WriteLine("Premi invio...");
                    Console.ReadLine();

                    try
                    {
                        string contenuto = File.ReadAllText(filePath);
                        Console.WriteLine("Contenuto del file: ");
                        Console.WriteLine(contenuto);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Si è verificato un errore: {ex.Message}");

                    }
                    break;

                case "4":
                    Console.WriteLine("Hai selezionato l'opzione 4");
                    Console.Beep();
                    break;

                case "5":
                    Console.WriteLine("Hai selezionato l'opzione 5");
                    Console.WriteLine("Inserisci la frequenza");
                    freq = Int32.Parse(Console.ReadLine()!);

                    Console.WriteLine("Inserisci durata in ms");
                    ms = Int32.Parse(Console.ReadLine()!);

                    Console.Beep(freq, ms);
                    break;

                case "6":
                    //
                    Console.WriteLine("Hai selezionato l'opzione 6");
                    Console.WriteLine("Inserisci secondi");

                    int count = Int32.Parse(Console.ReadLine()!);
                    Random random = new Random(); // variabile random

                    for (int i = 0; i < count; i++)
                    {
                        freq = random.Next(1, 10) * 100; // crea un numero random tra 100 e 1000
                        Console.Beep(freq, 500);
                    }
                    break;

                case "7":
                    Console.WriteLine("Hai selezionato l'opzione 7");
                    Console.WriteLine("Inserici il tuo nome");
                    string? nome = Console.ReadLine();

                    Console.WriteLine($"\nCiao {nome}, piacere di conoscerti!");
                    break;

                case "8":
                    Console.WriteLine("Hai selezionato l'opzione 8");
                    Console.Write("Inserisci un timer per la console in secondi: ");
                    int timeoutInSeconds = Int32.Parse(Console.ReadLine()!);

                    Task inputTask = Task.Run(() =>
                    {
                        Console.WriteLine($"Inserisici un input entro {timeoutInSeconds} secondi:");
                        return Console.ReadLine();
                    });

                    Task delayTask = Task.Delay(TimeSpan.FromSeconds(timeoutInSeconds));

                    if (await Task.WhenAny(inputTask, delayTask) == inputTask)
                    {
                        // l'utente ha inserito un input
                        input = await (inputTask as Task<string>)!;
                        Console.WriteLine($"Hai inserito: {input}");
                    }
                    else
                    {
                        // il tempo è scaduto
                        Console.WriteLine("Tempo scaduto! Premi invio...");
                    }
                    break;

                case "9":

                    do
                    {
                        Console.Clear();

                        Console.WriteLine("Hai selezionato l'opzione 9");
                        Console.WriteLine("Lista della spesa:");
                        Console.WriteLine("v - Visualizza lista");
                        Console.WriteLine("a - Aggiungi");
                        Console.WriteLine("d - Elimina");
                        Console.WriteLine("r - Torna indietro\n");
                        Console.Write("Scegli un'opzione: ");

                        input = Console.ReadLine()!.ToLower(); // prende anche input minuscoli
                        continua = true;

                        switch (input)
                        {
                            case "v":
                                // visualizza gli elementi salvati nella lista
                                Console.Clear();

                                if (listaSpesa.Count != 0)
                                {
                                    Console.WriteLine("Lettura lista..\n");
                                    foreach (string elemento in listaSpesa)
                                    {
                                        Console.WriteLine($"- {elemento}");
                                    }
                                    Console.WriteLine("\nPremi per continuare...");
                                    Console.ReadKey();

                                }
                                else
                                {
                                    Console.WriteLine("\nLista vuota\n");
                                    Console.WriteLine("Premi per continuare...");
                                    Console.ReadKey();
                                }

                                break;

                            case "a":
                                // aggiunge elementi alla lista senza ripetizioni
                                bool inserisci = true;

                                while (inserisci)
                                {
                                    Console.Clear();

                                    Console.WriteLine("Premi 'ctrl'+'h' per terminare");
                                    Console.Write("Inserisci un prodotto: ");


                                    ConsoleKeyInfo keyInfo = Console.ReadKey(); // salva il primo carattere digitato

                                    if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0) // verifica se ho premuto 'ctrl'
                                    {
                                        if (keyInfo.Key == ConsoleKey.H)
                                        {
                                            Console.WriteLine("\nFine inserimento..");
                                            inserisci = false;
                                            break;
                                        }
                                    }
                                    else
                                    {

                                        prodotto = keyInfo.KeyChar + Console.ReadLine(); // concateno per non perdere il primo elemento
                                                                                         // Console.WriteLine($"Prova inserimento {prodotto}"); // debug
                                                                                         // Console.WriteLine("Premi invio..");
                                                                                         // Console.ReadLine();

                                        while (listaSpesa.Contains(prodotto)) // controlla che l elemento sia unico nella lista
                                        {
                                            Console.WriteLine("Hai gia inserito questo prodotto.");
                                            Console.Write("Riprova... ");
                                            prodotto = Console.ReadLine();
                                        }

                                        listaSpesa.Add(prodotto);
                                        Console.WriteLine($"Hai inserito '{prodotto}'\n");
                                        Thread.Sleep(1000);
                                    }
                                }

                                break;

                            case "d":
                                // elimina un elemento se nella lista
                                Console.Clear();

                                Console.WriteLine("Elimina prodotti");
                                if (listaSpesa.Count != 0) // se la lista non è gia vuota esegue il codice
                                {
                                    Console.WriteLine("Premi 'ctrl'+'h' per terminare");
                                    Console.Write("Inserisci il prodotto da eliminare: ");

                                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                                    if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0)
                                    {
                                        if (keyInfo.Key == ConsoleKey.H)
                                        {
                                            Console.WriteLine("\nFine inserimento..");
                                            inserisci = false;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        prodotto = keyInfo.KeyChar + Console.ReadLine();

                                        while (!(listaSpesa.Contains(prodotto)))
                                        {
                                            Console.WriteLine($"'{prodotto}' non presente nella lista");
                                            Console.WriteLine("Ecco la lista completa:");
                                            foreach (string elemento in listaSpesa)
                                            {
                                                Console.WriteLine($"- {elemento}");
                                            }
                                            Console.Write("\nQuale prodotto vuoi eliminare? ");
                                            prodotto = Console.ReadLine();

                                        }
                                        listaSpesa.Remove(prodotto);
                                        Console.WriteLine($"Hai eliminato '{prodotto}' dalla lista");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("La lista della spesa è vuota");
                                }
                                break;

                            case "r":
                                // torna al menu principale se premiamo 'crtl' + 'r'
                                Console.WriteLine("Salvataggio lista...");

                                // attende 3 secondi prima di proseguire per simulare un salvataggio
                                Thread.Sleep(1200);

                                Console.WriteLine("Fatto!");
                                continua = false;
                                break;

                            default:
                                // errore di selezione
                                Console.WriteLine("Selezione errata. Riprova");
                                break;
                        }
                    }
                    while (continua);

                    break;

                case "e":
                    Console.WriteLine("Uscita in corso...");
                    return;

                default:
                    Console.WriteLine("Selezione errata. Riprova");
                    break;

            }

            Console.WriteLine("\nPremi un tasto per continuare...");
            Console.ReadKey();

        }
        while (true);
    }
}

```
</details>

### 45-GENERA UN NUMERO CASUALE PER SORTEGGIARE UN NOME DA UNA LISTA 

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        List<string> nomi = ["Alex", "Simone", "Fabio", "Giada",
                             "Carlo", "Dylan", "Natalia", "Ale"];
        Random random = new Random();
        int i = 0;
        while (i < 10)
        {
            int indice = random.Next(0, nomi.Count);
            Console.WriteLine($"Il nome sorteggiato è {nomi[indice]}");
            i++;
        }
    }
}

```
</details>

### 46-BUZZ & FIZZ CON MENU DI SCELTA (FOR O RANDOM)

<details>
    <summary> codice </summary>

```c#
class Program
{
    static void Main(string[] args)
    {
        
    }
}

```
</details>