# ESERCITAZIONI BASE SU C# .NET CORE

Ecco alcune esercitzioni base su C# .NET 

**dotnet run >> eseguire il 

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