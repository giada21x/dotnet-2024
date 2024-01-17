﻿

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







