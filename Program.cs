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
            Console.WriteLine($"{a} è uguale a {b}");
        }
        else if (a < b)
        {
            Console.WriteLine($"{a} è minore di {b}");
        }    
        
    }
}
    
    
    
