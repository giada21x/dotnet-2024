<<<<<<< HEAD
﻿using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        
        List<int> listaFizzBuzz = new List<int>();
        List<int> listaFizz = new List<int>();
        List<int> listaBuzz = new List<int>();
        
        for (int i = 0; i < 10; i++)
        {
            
            if((i % 5 == 0) & (i % 3 == 0) )
            {
                listaFizzBuzz.Add(i);
                Console.WriteLine($"{i} = Fizz-Buzz");
                
                
                
                
            }
            else if(i % 5 == 0)
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
        
            
            
           
    
            
       
=======
﻿class Program
{
    static void Main(string[] args)
    {
        string[] nomi = ["Mario", "Luigi", "Giovanni"]; //array di stringhe 
        Random random = new Random(); //oggetto per generare numeri casuali in questo caso tra 0 e 2 
        int indice = random.Next(0, 3); //random.next è un metodo della classe Random
        Console.WriteLine($"Il nome selezionato è {nomi[indice]}");//stampa il nome sorteggiato
        
>>>>>>> 07cd73db9f5018094edc2a642ec93fea5cd6e696
    }
}







