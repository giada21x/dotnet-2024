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
  
    
    
    
