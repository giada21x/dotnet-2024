class Program
{
   static void Main(string[] args)
   {
      string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv"); //legge tutti i file csv nella cartella del programma
      foreach (string file in files)
      {
         Console.WriteLine(file); //stampa il nome del file

      }
      Console.WriteLine("quale file vuoi eliminare?");
      string fileScelto = Console.ReadLine()!; //legge il nome del file scelto 
      string[] lines = File.ReadAllLines(fileScelto); //legge tutte le righe del file
      if (File.Exists(fileScelto))
      {
         File.Delete(fileScelto); //elimina il file
      }
      else
      {
         Console.WriteLine("il file non esiste");

      }
   }
}
