class Program 
{
   static void Main(string[] args)
    {
        Dictionary<string, int> eta = new Dictionary<string, int> 
        {
            {"Mario", 25}, 
            {"Luigi", 30},
            {"Giovanni", 35}
        }; 
        foreach (string nome in eta.Keys)
        {
            Console.WriteLine($"il signor {nome} ha {eta[$"{nome}"]} anni");
        }
    }
    
}
    
    
