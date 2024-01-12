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
            Console.WriteLine($"L'età dei tre ragazzi è {eta["Mario"]} {eta["Luigi"]} e {eta["Giovanni"]}");
        
    }
}

    
    
