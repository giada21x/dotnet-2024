class Program
{
    static void Main(string[] args)
    {
        
        
        for (int i = 0; i < 10; i++)
        {
            if((i % 5 == 0) & (i % 3 == 0) )
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{i} = Fizz-Buzz");
                
            }
            else if(i % 5 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{i} = Fizz");
                
            }
            else if (i % 3 == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"{i} = Buzz");
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{i} non divisibile");
            }
            Thread.Sleep(300);
        }  
       

       
        
            
            
           
    
            
       
    }
}







