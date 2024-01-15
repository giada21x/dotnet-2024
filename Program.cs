class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Trascina un file qui e premi invio:");
        string filePath = Console.ReadLine().Trim('"'); //Rimuove le virgolette che possono apparire nel percorso

        try
        {
            string content = File.ReadAllText(filePath);
            Console.WriteLine("Contenuto del file:");
            Console.WriteLine(content);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Si è verificato un errore: {ex.Message}");

        }




    }
}