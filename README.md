# ESERCITAZIONI BASE SU C# .NET CORE

Ecco alcune esercitzioni base su C# .NET 

**dotnet run >> eseguire il rogramma
**git add --all
**git commit -m "messaggio commit"
**git push -u origin main

### 1 - DICHIARARE UNA VARIABILE DI TIPO STRINGA
<details>
    <summary> codice </summary>
    
```c#
class Program
    {
        static void Main(string[] args)
        {
            string nome = "Giada";
            string cognome = "Adamo";
            Console.WriteLine($"Ciao {nome} {cognome}"); //interpolazione con $
            Console.WriteLine("Ciao " + nome + " " + cognome); //concatenazione con +
        }
    }
      
```
</details>

### 2 - DICHIARARE UNA VARIABILE DI TIPO INTERO
<details>
    <summary> codice </summary>
    
```c#
class Program
    {
        static void Main(string[] args)
        {
            int eta = 22; //gli interi non necessiano di apici doppi 
                          //evitare i caratteri accentati nel nome delle variabili
            Console.WriteLine($"Hai {eta} anni"); 
        }
    }
      
```
</details>

### 3 - DICHIARARE UNA VARIABILE DI TIPO BOOL
<details>
    <summary> codice </summary>
    
```c#
class Program
    {
        static void Main(string[] args)
        {
            int eta = 22; //gli interi non necessiano di apici doppi 
                          //evitare i caratteri accentati nel nome delle variabili
            Console.WriteLine($"Hai {eta} anni"); 
        }
    }
      
```
</details>

### 4 - DICHIARARE UNA VARIABILE DI TIPO DECIMALE
<details>
    <summary> codice </summary>
    
```c#
class Program
    {
        static void Main(string[] args)
        {
            decimal altezza = 1.55m;
            Console.WriteLine($"Sei alto? {altezza} metri"); 
        }
    }
      
```
</details>

### 5 - DICHIARARE UNA VARIABILE DI TIPO DATA
<details>
    <summary> codice </summary>
    
```c#
class Program
    {
        static void Main(string[] args)
        {
            DateTime dataDiNascita = new DateTime (2001, 03, 21);
            Console.WriteLine($"Sei nato il ? {dataDiNascita}"); 
        }
    }

      
```
</details>

### 6 - DICHIARARE UNA VARIABILE DI TIPO DATA E UTILIZZARE IL METODO ToShortDateString():
<details>
    <summary> codice </summary>
    
```c#
class Program
    {
        static void Main(string[] args)
        {
            DateTime dataDiNascita = new DateTime (2001, 03, 21);
            Console.WriteLine($"Sei nato il ? {dataDiNascita.ToShortDateString()}"); 
        }
    }
      
```
</details>

### 7 - DICHIARARE UNA VARIABILE DI TIPO DATA E UTILIZZARE IL METODO ToLongDateString():
<details>
    <summary> codice </summary>
    
```c#
class Program
    {
        static void Main(string[] args)
        {
            DateTime dataDiNascita = new DateTime (2001, 03, 21);
            Console.WriteLine($"Sei nato il {dataDiNascita.ToLongDateString()}"); 
            
        }
    }
```
</details>

### 8 - UTILIZZARE L'OPERATORE + PER SOMMARE DUE INTERI
<details>
    <summary> codice </summary>
    
```c#
class Program 
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            int c = a+ b;
            Console.WriteLine($"La somma di {a} e {b} è {c}"); 
            
        }
    }
```
</details>

### 9 - UTILIZZARE L'OPERATORE + PER SOMMARE DUE INTERI E DUE DECIMALI
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
            Console.WriteLine($"La somma di {a} e {b} e {c} è {d} "); 
       }
    }  
```
</details>

### 10 - UTILIZZARE L'OPERATORE == E != PER CONFRONTARE DUE STRINGHE
<details>
    <summary> codice </summary>
    
```c#
class Program 
    {
        static void Main(string[] args)
        {
            string nome = "Mario";
            string cognome = "Rossi";
            bool uguali = nome == cognome;
            bool diversi = nome != cognome;
            Console.WriteLine($"I due nomi sono uguali? {uguali}"); 
            Console.WriteLine($"I due nome sono diversi? {diversi}");
       }
    }  
```
</details>

### 11 - UTILIZZARE L'OPERATORE >, < E == PER CONFRONTARE DUE INTERI
<details>
    <summary> codice </summary>
    
```c#
 class Program 
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            bool maggiore = a > b;
            bool minore = a < b;
            bool uguale = a == b;
            Console.WriteLine($"Il primo numero è maggiore del secndoo? {maggiore}"); 
            Console.WriteLine($"Il primo numero è maggiore del secndoo? {minore}"); 
            Console.WriteLine($"Il primo numero è maggiore del secndoo? {uguale}");
       }
    }   
```
</details>

### 12 - DICHIARARE UN ARRAY DI STRINGHE
<details>
    <summary> codice </summary>
    
```c#
class Program 
    {
        static void Main(string[] args)
        {
            string[] nomi = new string[3]; //array ha un numero predeterminato di elementi
            nomi[0] =  "Mario"; //si può inserire un elemento in una posizione specifica
            nomi[1] = "Luigi"; //array deve contenee dati dello stesso tipo
            nomi[2] = "Giovanni";
            Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]}, {nomi[2]}");
       }
    }  
```
</details>

### 13 - DICHIARARE UN ARRAY DI INTERI
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
            numeri[2] = 30;
            Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]}, {numeri[2]}");
       }
    }      
```
</details>

### 14 - DICHIARARE UN ARRAY DI STRINGHE E UTILIZZARE IL METODO LENGTH
   
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
            Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]}, {nomi[2]}");
            Console.WriteLine($"Il numero di elementi è {nomi.Length}");
       }
    } 
```
</details>
 
### 15 - DICHIARARE UNA LISTA DI STRINGHE
<details>
    <summary> codice </summary>
    
```c#
class Program 
    {
        static void Main(string[] args)
         {
            List<string> nomi = new List<string>(); //utilizziamo il diamond invece di parentesi quadre
            nomi.Add("Mario"); //l'aggiunta di un elemento avviene attraverso il metodo Add
            nomi.Add("Luigi"); //ogni elemento deve essere tra parentesi
            nomi.Add("Giovanni"); //gli elementi vengono inseriti nell'ordine in cui li mettiamo
            Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]}, {nomi[2]}");
         }
    }      
```
```c#
//inizializzazione di un List di stringhe
class Program 
    {
        static void Main(string[] args)
        {
            List<string> listanomi = new List<string>  {"Mario", "Luigi", "Giovanni"};
        }
    }
```

</details>
 
### 16 - DICHIARARE UNA LISTA DI INTERI
<details>
    <summary> codice </summary>
    
```c#
class Program 
    {
        static void Main(string[] args)
         {
            List<int> numeri = new List<int>(); 
            numeri.Add(10); //come nelle altre strutture gli int non necessitano di apici doppi
            numeri.Add(20); 
            numeri.Add(30); 
            Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]}, {numeri[2]}");
         }
    }  
```

```c#
//inizializzazione di un List di interi
class Program 
    {
        static void Main(string[] args)
        {
            List<int> listanumeri = new List<int>  {1, 2, 3, 4, 5};
        }
    }
```
</details>

### 17 - DICHIARARE UNA LISTA DI STRINGHE CON IL METODO COUNT
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
            Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]}, {nomi[2]}");
            Console.WriteLine($"Il numero di elementi è {nomi.Count}");
         }
    } 
      
```
</details>

### 18 - DICHIARARE UNA PILA DI STRINGHE
<details>
    <summary> codice </summary>

```c#
class Program 
    {
        static void Main(string[] args)
         {
            Stack<string> nomi = new Stack<string>(); 
            nomi.Push("Mario"); 
            nomi.Push("Luigi");
            nomi.Push("Giovanni"); 
            Console.WriteLine($"Ciao {nomi.Pop()}, {nomi.Pop()}, {nomi.Pop()}");
         }
    }       
      
```

```c#
//inizializzazione di una Pila di stringhe
class Program 
    {
        static void Main(string[] args)
        {
            Stack<string> listanomi = new Stack<string>(new string[]  {"Mario", "Luigi", "Giovanni"});
        
        }
    }
```
</details>

### 19 - DICHIARARE UNA CODA DI STRINGHE
<details>
    <summary> codice </summary>

```c#
class Program 
    {
        static void Main(string[] args)
         {
            Queue<string> nomi = new Queue<string>(); 
            nomi.Enqueue("Mario"); 
            nomi.Enqueue("Luigi"); 
            nomi.Enqueue("Giovanni"); 
            Console.WriteLine($"Ciao {nomi.Dequeue()}, {nomi.Dequeue()}, {nomi.Dequeue()}");
         }
    }       
      
```

```c#
//inizializzazione di una Coda di stringhe
class Program 
    {
        static void Main(string[] args)
        {
            Queue<string> listanomi = new Queue<string>(new string[]  {"Mario", "Luigi", "Giovanni"});
        
        }
    }
```
</details>

### 20 - METODI VARI
<details>
    <summary> codice </summary>

```c#
//metodo array join
string[] nomi = new string[] {"Alice", "Bob", "Charlie"};

//Unisce tutti gli elementi dell'array 'nomi' in una singola stringa, separati da virgola e spazio
string nomiConcatenati = String.Join(", ", nomi);

Console.WriteLine($"Ciao {nomiConcatenati}");

//Il metodo Add è usato per aggiungere un nuovo elemento alla fine della lista
List<int> numeri = new List<int>();
numeri.Add(1); //aggiunge 1 alla lista

//Il metodo Remove rimuove la prima occorenza di un elemento specifico della lista
numeri.Remove(1); //rimuove 1 alla lista

//Il metodo Sort ordina gli elementi della lista. Per i tipi predefiniti, l'ordinamento è in ordine crescente
List<int> numeri = new List<int> {3, 1, 4, 1, 5, ;9}
numeri.Sort()

```
</details>

### 21 - UTILIZZARE L'ISTRUZIONE IF
<details>
    <summary> codice </summary>

```c#
class Program 
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        if (a > b) //la condizione da verificare si scrive tra parentesi
        {
            Console.WriteLine($"{a} è maggiore di {b}");
        }
    }
}
```
</detail>

### 22 - UTILIZZARE L'ISTRUZIONE IF-ELSE
<details>
    <summary> codice </summary>

```c#
class Program 
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        if (a > b) //la condizione da verificare si scrive tra parentesi
        {
            Console.WriteLine($"{a} è maggiore di {b}");
        }
        else
        {
            Console.WriteLine($"{a} è minore di {b}");
        }
    }
}
```
</details>

### 23 - UTILIZZARE L'ISTRUZIONE IF-ELSE IF-ELSE
<details>
    <summary> codice </summary>

```c#
class Program 
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        if (a > b) //la condizione da verificare si scrive tra parentesi
        {
            Console.WriteLine($"{a} è maggiore di {b}");
        }
        else if (a < b) //prima si mette la condizione else if 
        {
            Console.WriteLine($"{a} è minore di {b}");
        }
        else
            Console.WriteLine($"{a} è uguale a {b}");
    }
}
```
</details>

### 24 - UTILIZZARE LO SWITCH
<details>
    <summary> codice </summary>

```c#
class Program 
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20; //b è dichiarata ma il suo valore non viene mai usato, il programma funziona comunque 
        switch (a)
        {
            case 10:
                Console.WriteLine($"{a} è uguale a 10");
                break;
            case 20:
                Console.WriteLine($"{a} è uguale a 20"); 
                break;
            default:
                Console.WriteLine($"{a} non è uguale a 10 o 20");
                break;
        }
    }
}
```
</details>

### 25 - DICHIARARE UN DIZIONARIO DI STRINGHE
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
} //nel terminale mi uscirà 'Ciao Rossi, Verdi e Bianchi'
```
</details>

### 26 - DICHIARARE UN DIZIONARIO DI STRINGHE E NUMERI
<details>
    <summary> codice </summary>

```c#
class Program 
{
    static void Main(string[] args)
    {
        Dictionary<string, int> eta = new Dictionary<string, int> //a differenza dell'esempio precedente in questo metodo non ci vanno le parentesi tonde
        {
            {"Mario", 25}, //ho utilizzato questo metodo al posto del metodo Add come nell'esempio sopra
            {"Luigi", 30},
            {"Giovanni", 35}
        }; //ricordati di mettere il punto e virgola subito dopo la chiusura del blocco
            Console.WriteLine($"L'età dei tre ragazzi è {eta["Mario"]} {eta["Luigi"]} e {eta["Giovanni"]}");
        
    }
}
```
</details> 

### 27 - UTILIZZARE IL CICLO FOR
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
} //nel terminale mi uscirà l'incremento di i fino a 9
```
</details>

### 28 - UTILIZZARE IL CICLO FOREACH CON UN ARRAY DI STRINGHE
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
        //string[] nomi = new string[] {"Mario", "Luigi", "Giovanni"}; metodo alternativo
        foreach (string nome in nomi)
        
    }
} 
```
```c#
//versione con la lista e Add
class Program 
{
    static void Main(string[] args)
    {
        List<string> nomi = new List<string>();
        nomi.Add("Mario");
        nomi.Add("Luigi");
        nomi.Add("Giovanni"); 
        //List<string> nomi = new List<string> {"Mario", "Luigi", "Giovanni"}; metodo alternativo
        foreach (string nome in nomi)
        {
            Console.WriteLine($"Ciao {nome}");
        }     
    }
} 
```
</details>

### 29 - UTILIZZARE IL CICLO FOREACH E LA PROPRIETA KEYS PER SCOPRIRE QUALI CHIAVI SONO PRESENTI IN UN DIZIONARIO
<details>
    <summary> codice </summary> 

```c#
class Program 
{
   static void Main(string[] args)
    {
        Dictionary<string, int> eta = new Dictionary<string, int> 
        {
            {"Mario", 25}, 
            {"Luigi", 30},
            {"Giovanni", 35}
        }; 
        foreach (string nome in eta.Keys)
        {
            Console.WriteLine($"il signor {nome} ha {eta[$"{nome}"]} anni");
        }
    }
    
} 
```
</details>

### ESEECIZIO CHE UNISCE IL FOREACH, L'IF E IL METODO ADD
```c#
//array di stringhe con tre nomi. cicliamo con foreach e se il nome è uguale a mario con metodo add aggiunge il nome ad una lista
class Program 
{
    static void Main(string[] args)
    {
        string[] nomi = ["Mario", "Luigi", "Giovanni"];
        
        //creare una lista di destinazione
        List<string> lista = new List<string>(); 
        //creare un ciclo che iteri sugli elementi dell'array
        foreach (string nome in nomi) 
        {
        //se il nome è uguale a 'Mario' con metodo add aggiunge il nome ad una lista
            if (nome == "Mario") 
            {
                lista.Add(nome);
            }
        } 
        //versioniamo e veifichiamo che 'Mario' sia stato aggiunto alla lista
        foreach (string nome in lista)
        {
            Console.WriteLine($"{nome}");
        }
     }
}
```

### INTRODUZIONE AL CONSOLE.READLINE()
```c#
class Program
{
    static void Main(string[] args)
    {
        string? nome = Console.ReadLine();
        Console.WriteLine($"Ciao {nome}");
    }
}
```

### INTRODUZIONE AL CONSOLE.READKEY()
```c#
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Premi un tasto per terminare...");
        Console.ReadKey();
    }
}

```

### UTILIZZARE CICLO WHILE CON ARRAY DI INTERI
```c#
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
        {   //si utilizza il metodo .Length per calcolare la lunghezza dell'array
            Console.WriteLine($"Ciao {nomi[i]}");
            i++; // Incremento dell'indice
        }
    }
}

```

### UTILIZZARE CICLO WHILE CON UNA LISTA DI STRINGHE
```c#

class Program
{
    static void Main(string[] args)
    {
        List<string> nomi = new List<string>();
        nomi.Add("Mario");
        nomi.Add("Luigi");
        nomi.Add("Giovanni");
        // List<string> nomi = new List<string> { "Mario", "Luigi", "Giovanni" };

        int i = 0; // Indice inizializzato a 0
        while (i < nomi.Count) // Il ciclo continua finché l'indice è minore del numero di elementi nella lista
        {  //si utilizza il metodo .Count per calcolare la lunghezza della lista
            Console.WriteLine($"Ciao {nomi[i]}"); //metto tra parentesi quadre la variabile indice
            i++; // Incremento dell'indice
        }
    }
}

```

### USCIRE DAL PROGRAMMA PREMENDO UN TASTO
```c#

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
```

### USCIRE DAL PROGRAMMA PREMENDO DUE TASTI CONTEMPORANEAMENTE
```c#

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Premi 'Ctrl' + 'N' per terminare...");
        //non si possono utilizzare delle combinazioni già utilizzate da visual studio code come Ctrl + Q
        
        while (true)
        {
            //aspetto finchè non viene premuto un tasto
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
             //verifica se il tasto 'Ctrl' è tenuto premuto
            if ((keyInfo.Modifiers & ConsoleModifiers.Control) !=0)//Console.Modifiers si utilizza per contorl alt e shift (modificatori di sistema)
            {
                //controlla se il tasto premuto è 'N'
                if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine("Combinazione 'Ctrl' + 'N' rilevata, uscita in corso ...");
                    break;
                }
            }
        }
    }
}
```

### CREARE UN MENU UTILIZZZANDO LO SWITCH E IL WHILE
```c#

class Program
{
    static void Main(string[] args)
    {
        while(true)
        { 
            Console.Clear(); //pulisce la console ad ogni iterazione
            Console.WritLine("Menù di sselezione");
            Console.WriteLine("1. Opzione Uno");
            Console.WriteLine("2. Opzione Due");
            Console.WriteLine("3. Opzione Tre");
            Console.WriteLine("4. Esci");

            Console.WriteLine("Inserisci il numero dell'opzione desiderata");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Hai selezionato l'Opzione Uno" );
                    break;
                case "2":
                    Console.WriteLine("Hai scelto l'Opzione Due");
                    break
                case "3":
                    Console.WriteLine("Hai scelto l'Opzione Tre");
                    break;
                case "4":
                    Console.WriteLine("Uscita in corso...");
                    return;
                default:
                    Console.writeLine("selezione non valida. Riprova.");
                    break;


            }
        }
          
    }
}
```

### GESTIONE DI INPUT COMPLESSE
```c#

class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("Inserisci un comando speciale (esempio: 'cmd:info' , 'cmd:exit')");

        while (true)
        {
            string input = Console.ReadLine();
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
```

### DRAG AND DROP
```c#

class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("Trascina un file qui e premi invio:");
       string filePath = Console.ReadLine().Trim('"'); //Rimuove le virgolette che possono apparire nel percorso
        //oppure inserire il percorso manualmente
        //Console.WriteLine("Inserici il percorso della cartella)
        try
        {
            string content = File.ReadAllText(filePath);
            Console.WriteLine("Contenuto del file:");
            Console.WriteLine(content);
        }
        catch (Exception ex)    
        {
            Console.WriteLine($"Si è verificato un errore: {ex.Message}");
            
        }
    }
}
```

### DO WHILE
```c#

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
                case "5":
                    Console.Clear();//pulisce la console
                    break;
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
```

### TEMPO DI ATTESA
```c#

class Program
{
    static void Main(string[] args)
    {
        int timeoutInSeconds = 5; //imposta il tempo di attesa in secondi
        Task inputTask = Task.Run(() =>
       {
            ConsoleWriteLine($"Inserisci un input entro {5} secondi");
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
            Console.writeLine("Tempo scaduto!")
        }
    }
}
//inputTask è un task che attende l'input dell'utente
//delayTask è un task che attende per un periodo di tempo specificato 
```

### TEMPO DI ATTESA PIU SEMPLICE
```c#

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
//inputTask è un task che attende l'input dell'utente
//delayTask è un task che attende per un periodo di tempo specificato 
```

### GENERATORE DI NUMERI CASUALI (METODO RANDOM)
```c#
//questo programma genera 10 numeri casuali e ne calcola la somma
class Program
{
    static void Main(string[] args)
    {
        Random random = new Random(); //generatore di numeri casuali 
        int somma = 0;
        for (int i = 0; i < 10; i++) //definiamo la i(contatore) e gli diamo un valore inizilae di 0 e un valore massimo minore di 10 e lo andiamo a incrementare con ++
        {
            int numero = random.Next(1, 10);//genera un numero casuale tra 1 e 10 si dice che l'intervallo è [1, 10) cioè l'intervallo semiaperto 
            somma += numero; //somma = somma + numero utilizzando operatore di assegnazione composto
            Console.WriteLine($"Il numero casuale è {numero}");//interpolazione di stringhe 
            
        }
        Console.WriteLine($"La somma è {somma}");
    }
}

```

### SORTEGGIARE UN NOME DA UN ARRAY DI STRINGHE (METODO RANDOM)
```c#
//questo programma stampa un nome a caso tra tre nomi
class Program
{
    static void Main(string[] args)
    {
        string[] nomi = ["Mario", "Luigi", "Giovanni"]; //array di stringhe 
        Random random = new Random(); //oggetto per generare numeri casuali in questo caso tra 0 e 2 
        int indice = random.Next(0, 4); //random.next è un metodo della classe Random
        Console.WriteLine($"Il nome selezionato è {nomi[indice]}");//stampa il nome sorteggiato
    }
}

```

### FIZZ, BUZZ, FIZZBUZZ + LISTA
<details>
    <summary> codice </summary>

```c#
//stampare numero tra 0 e 100. se il numero è divisibile per tre o 5 //fizz, buzz, fizz-buzz
class Program
{
    static void Main(string[] args)
    {
        List<int> listaFizzBuzz = new List<int>();
        List<int> listaFizz = new List<int>();
        List<int> listaBuzz = new List<int>();

        for (int i = 0; i < 10; i++)
        {

            if ((i % 5 == 0) & (i % 3 == 0))
            {
                listaFizzBuzz.Add(i);
                Console.WriteLine($"{i} = Fizz-Buzz");
            }
            else if (i % 5 == 0)
            {
                listaFizz.Add(i);
                Console.WriteLine($"{i} = Fizz");
            }
            else if (i % 3 == 0)
            {
                listaBuzz.Add(i);
                Console.WriteLine($"{i} = Buzz");
            }
            else
            {
                Console.WriteLine($"{i} non divisibile");
            }
            Console.WriteLine($"");

            Thread.Sleep(300);
        }
        Console.WriteLine("Questa è la lista FizzBuzz");
        foreach (int nuovo in listaFizzBuzz)
        {
            Console.WriteLine($"{nuovo}");

        }
        Console.WriteLine("Questa è la lista Fizz");
        foreach (int nuovo in listaFizz)
        {
            Console.WriteLine($"{nuovo}");

        }
        Console.WriteLine("Questa è la lista Buzz");
        foreach (int nuovo in listaBuzz)
        {
            Console.WriteLine($"{nuovo}");

        }
    }
}

```

```c#
//stesso esercizio ma più bello
class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        List<string> fizzbuzz = new List<string>();
        List<string> fizz = new List<string>();
        List<string> buzz = new List<string>();
        List<string> numero = new List<string>();
        Console.WriteLine("I numeri usciti sono:");
        for (int i = 1; i <= 100; i++)
        {
            int numeroCasuale = random.Next(1, 101);
            Console.Write($"{numeroCasuale}, ");
            if (numeroCasuale % 3 == 0 && numeroCasuale % 5 == 0)
            {
                // aggiungi il numero alla lista fizzbuzz
                fizzbuzz.Add(numeroCasuale.ToString());
            }
            else if (numeroCasuale % 3 == 0)
            {
                // aggiungi il numero alla lista fizz
                fizz.Add(numeroCasuale.ToString());
            }
            else if (numeroCasuale % 5 == 0)
            {
                // aggiungi il numero alla lista buzz
                buzz.Add(numeroCasuale.ToString());
            }
            else
            {
                // aggiungi il numero alla lista numero
                numero.Add(numeroCasuale.ToString());
            }
            Thread.Sleep(30);
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"I numeri FizzBuzz sono {fizzbuzz.Count} ed i numeri contenuti sono:");
        foreach (string item in fizzbuzz)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"I numeri Fizz sono {fizz.Count} ed i numeri contenuti sono {string.Join(", ", fizz)}");
        Console.WriteLine();
        Console.WriteLine($"I numeri Buzz sono {buzz.Count} ed i numeri contenuti sono {string.Join(", ", buzz)}");
        Console.WriteLine();
        Console.WriteLine($"I numeri sono {numero.Count} ed i numeri contenuti sono {string.Join(", ", numero)}");
    }
}

```
```c#
//stesso esercizio con implementazione elementi duplicati ed ordinamento
class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        List<string> fizzbuzz = new List<string>();
        List<string> fizz = new List<string>();
        List<string> buzz = new List<string>();
        List<string> numero = new List<string>();
        Console.WriteLine("I numeri usciti sono:");
        for (int i = 1; i <= 100; i++)
        {
            int numeroCasuale = random.Next(1, 101);
            Console.Write($"{numeroCasuale}, ");
            if (numeroCasuale % 3 == 0 && numeroCasuale % 5 == 0)
            {
                // aggiungi il numero alla lista fizzbuzz
                fizzbuzz.Add(numeroCasuale.ToString());
            }
            else if (numeroCasuale % 3 == 0)
            {
                // aggiungi il numero alla lista fizz
                fizz.Add(numeroCasuale.ToString());
            }
            else if (numeroCasuale % 5 == 0)
            {
                // aggiungi il numero alla lista buzz
                buzz.Add(numeroCasuale.ToString());
            }
            else
            {
                // aggiungi il numero alla lista numero
                numero.Add(numeroCasuale.ToString());
            }
            Thread.Sleep(30);
        }
        // togli gli elementi duplicati dalla lista fizzbuzz
        fizzbuzz = fizzbuzz.Distinct().ToList();
        // ordina la lista fizzbuzz
        fizzbuzz.Sort();
        // togli gli elementi duplicati dalla lista fizz
        fizz = fizz.Distinct().ToList();
        // ordina la lista fizz
        fizz.Sort();
        // togli gli elementi duplicati dalla lista buzz
        buzz = buzz.Distinct().ToList();
        // ordina la lista buzz
        buzz.Sort();
        // togli gli elementi duplicati dalla lista numero
        numero = numero.Distinct().ToList();
        // ordina la lista numero
        numero.Sort();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"I numeri FizzBuzz sono {fizzbuzz.Count} ed i numeri contenuti sono:");
        foreach (string item in fizzbuzz)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"I numeri Fizz sono {fizz.Count} ed i numeri contenuti sono {string.Join(", ", fizz)}");
        Console.WriteLine();
        Console.WriteLine($"I numeri Buzz sono {buzz.Count} ed i numeri contenuti sono {string.Join(", ", buzz)}");
        Console.WriteLine();
        Console.WriteLine($"I numeri sono {numero.Count} ed i numeri contenuti sono {string.Join(", ", numero)}");
    }
}
```
</details>

```c#
//stesso esercizio con ordinamento giusto
class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        List<string> fizzbuzz = new List<string>();
        List<string> fizz = new List<string>();
        List<string> buzz = new List<string>();
        List<string> numero = new List<string>();
        Console.WriteLine("I numeri usciti sono:");
        for (int i = 1; i <= 100; i++)
        {
            int numeroCasuale = random.Next(1, 101);
            Console.Write($"{numeroCasuale}, ");
            if (numeroCasuale % 3 == 0 && numeroCasuale % 5 == 0)
            {
                // aggiungi il numero alla lista fizzbuzz
                fizzbuzz.Add(numeroCasuale.ToString());
            }
            else if (numeroCasuale % 3 == 0)
            {
                // aggiungi il numero alla lista fizz
                fizz.Add(numeroCasuale.ToString());
            }
            else if (numeroCasuale % 5 == 0)
            {
                // aggiungi il numero alla lista buzz
                buzz.Add(numeroCasuale.ToString());
            }
            else
            {
                // aggiungi il numero alla lista numero
                numero.Add(numeroCasuale.ToString());
            }
            Thread.Sleep(30);
        }
        // se la lista fizzbuzz è contiene numeri inferiori a 10 aggiungi uno 0 davanti
        for (int i = 0; i < fizzbuzz.Count; i++)
        {
            if (int.Parse(fizzbuzz[i]) < 10)
            {
                fizzbuzz[i] = $"0{fizzbuzz[i]}";
            }
        }
        // se la lista fizz è contiene numeri inferiori a 10 aggiungi uno 0 davanti
        for (int i = 0; i < fizz.Count; i++)
        {
            if (int.Parse(fizz[i]) < 10)
            {
                fizz[i] = $"0{fizz[i]}";
            }
        }
        // se la lista buzz è contiene numeri inferiori a 10 aggiungi uno 0 davanti
        for (int i = 0; i < buzz.Count; i++)
        {
            if (int.Parse(buzz[i]) < 10)
            {
                buzz[i] = $"0{buzz[i]}";
            }
        }
        // se la lista numero è contiene numeri inferiori a 10 aggiungi uno 0 davanti
        for (int i = 0; i < numero.Count; i++)
        {
            if (int.Parse(numero[i]) < 10)
            {
                numero[i] = $"0{numero[i]}";
            }
        }
        // togli gli elementi duplicati dalla lista fizzbuzz
        fizzbuzz = fizzbuzz.Distinct().ToList();
        // ordina la lista fizzbuzz
        fizzbuzz.Sort();
        // togli gli elementi duplicati dalla lista fizz
        fizz = fizz.Distinct().ToList();
        // ordina la lista fizz
        fizz.Sort();
        // togli gli elementi duplicati dalla lista buzz
        buzz = buzz.Distinct().ToList();
        // ordina la lista buzz
        buzz.Sort();
        // togli gli elementi duplicati dalla lista numero
        numero = numero.Distinct().ToList();
        // ordina la lista numero
        numero.Sort();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"I numeri FizzBuzz sono {fizzbuzz.Count} ed i numeri contenuti sono:");
        foreach (string item in fizzbuzz)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"I numeri Fizz sono {fizz.Count} ed i numeri contenuti sono {string.Join(", ", fizz)}");
        Console.WriteLine();
        Console.WriteLine($"I numeri Buzz sono {buzz.Count} ed i numeri contenuti sono {string.Join(", ", buzz)}");
        Console.WriteLine();
        Console.WriteLine($"I numeri sono {numero.Count} ed i numeri contenuti sono {string.Join(", ", numero)}");
    }
}
```
</details>


### CALCOLATRICE BASE:
<details>
    <summary> codice </summary>
    
```c#
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

            string? input = Console.ReadLine();
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
      
```
</details>

### CALCOLATRICE CON RADICE, QUADRATO E CUBO:
<details>
    <summary> codice </summary>
    
```c#
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Inserisci il primo numero");
            double a = double.Parse(Console.ReadLine()!);
            //tagliare i decimali da un double
            //accorciare i numeri decimali a scelta 
            a = Math.Truncate(a);
            Console.WriteLine("inserisci l'operazione");
            string operazione = Console.ReadLine()!;
            double risultato = 0;
            risultato = Math.Truncate(risultato);
            switch (operazione)
            {
                case "radice":
                    risultato = Math.Sqrt(a);
                    break;
                case "quadrato":
                    risultato = Math.Pow(a, 2);
                    break;
                case "cubo":
                    risultato = Math.Pow(a, 3);
                    break;
            } 
            Console.WriteLine($"Il risultato è {risultato}");
            Console.WriteLine($"Vuoi continuare? (s/n)");
            string risposta = Console.ReadLine()!;
            if (risposta == "n")
            {
                return;
            }
        }

    }
}
      
```
</details>

