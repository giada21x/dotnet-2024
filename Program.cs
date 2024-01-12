 class Program 
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
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
    
    
