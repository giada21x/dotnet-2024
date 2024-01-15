# ESERCITAZIONI BASE SU C# .NET CORE

Ecco alcune esercitzioni base su C# .NET 

**dotnet run >> eseguire il rogramma
**git add --all
**git commit -m "messaggio commit"
**git push -u origin main

### DICHIARARE UNA VARIABILE DI TIPO
```c#
class Program
    {
        static void Main(string[] args)
        {
            string nome = "Giada";
            string cognome = "Adamo";
            Console.WriteLine($"Ciao {nome} {cognome}"); //interpolazione con $
            Console.Writeline("Ciao " + nome + " " + cognome); //concatenazione con +
        }

    }
```

### DICHIARARE UNA VARIABILE DI TIPO 
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

### DICHIARARE UNA VARIABILE DI TIPO
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
### DICHIARARE UNA VARIABILE DI TIPO DECIMALE
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
### DICHIARARE UNA VARIABILE DI TIPO DATA
```c#
class Program
    {
        static void Main(string[] args)
        {
            DateTime dataDiNascita = new DateTime (2001, 03, 21);
            Console.WriteLine($"Sei nato il ? {DataDiNascita}"); 
        }
    }
```
### DICHIARARE UNA VARIABILE DI TIPO DATA E UTILIZZARE IL METODO ToShortDateString():
```c#
class Program
    {
        static void Main(string[] args)
        {
            DateTime dataDiNascita = new DateTime (2001, 03, 21);
            Console.WriteLine($"Sei nato il ? {DataDiNascita.ToShortDateString()}"); 
        }
    }
```
### DICHIARARE UNA VARIABILE DI TIPO DATA E UTILIZZARE IL METODO ToLongDateString():
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
### UTILIZZARE L'OPERATORE + PER SOMMARE DUE INTERI
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

### UTILIZZARE L'OPERATORE + PER SOMMARE DUE INTERI
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

### UTILIZZARE L'OPERATORE == != PER CONFRONTARE DUE STRINGHE
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
            Console.WriteLine($"I due nome sono diversi? {diversi});
       }
    }       
      
```

### UTILIZZARE L'OPERATORE > < == PER CONFRONTARE DUE INTERI
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

### DICHIARARE UN ARRAY DI STRINGHE
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

### DICHIARARE UN ARRAY DI INTERI
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

### DICHIARARE UN ARRAY DI STRINGHE E UTILIZZARE IL METODO LENGTH
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
            Console.WriteLine($"Il numero di elementi è {nomi.Lenght}");
       }
    }       
      
```
 
### DICHIARARE UNA LISTA DI STRINGHE
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


### DICHIARARE UNA LISTA DI INTERI
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


### DICHIARARE UNA LISTA DI STRINGHE CON IL METODO COUNT
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



### DICHIARARE UNA PILA DI STRINGHE
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


### DICHIARARE UNA CODA DI STRINGHE
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
### METODI
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

### UTILIZZARE L'ISTRUZIONE IF
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

### UTILIZZARE L'ISTRUZIONE IF-ELSE
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

### UTILIZZARE L'ISTRUZIONE IF-ELSE IF-ELSE
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

### UTILIZZARE LO SWITCH
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

### DICHIARARE UN DIZIONARIO DI STRINGHE
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

### DICHIARARE UN DIZIONARIO DI STRINGHE E NUMERI
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

### UTILIZZARE IL CICLO FOR
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

### UTILIZZARE IL CICLO FOREACH CON UN ARRAY DI STRINGHE
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

### UTILIZZARE IL CICLO FOREACH E LA PROPRIETA KEYS PER SCOPRIRE QUALI CHIAVI SONO PRESENTI IN UN DIZIONARIO
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

### UTILIZZARE CICLO WHILE CON ARRAY D INTERI
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
        {
            Console.WriteLine($"Ciao {nomi[i]}");
            i++; // Incremento dell'indice
        }
    }
}

```

### UTILIZZARE CICLO WHILE CON UNA LISTA DI STRINGHE
```c#
// using System;
// using System.Collections.Generic;
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
        {
            Console.WriteLine($"Ciao {nomi[i]}");
            i++; // Incremento dell'indice
        }
    }
}

```


