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

### UTILIZZARE L'OPERATORE == PER CONFRONTARE DUE STRINGHE
```c#
class Program 
    {
        static void Main(string[] args)
        {
            string nome = "Mario";
            string cognome = "Rossi";
            bool uguali = nome == cognome;
            Console.WriteLine($"I due nomi sono uguali? {uguali}"); 
       }
    }       
      
```

