# ESERCITAZIONI BASE SU C# .NET CORE

Ecco alcune esercitzioni base su C# .NET 

**dotnet run >> eseguire il 

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
            DateTime dataDiNascita = new DataTime (2001, 03, 21);
            Console.WriteLine($"Sei nato il ? {DataDiNascita}"); 
        }
    }

