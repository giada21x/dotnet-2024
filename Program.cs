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
  
    
    
    
