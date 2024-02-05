using Newtonsoft.Json;

class Program
{
   static void Main(string[] args)
   {
      string path = @"videogiochi.json";
      File.Create(path).Close();
      File.AppendAllText(path, "[\n");

      Console.WriteLine($"Benvenuto nel Database Videogiochi!");
      Console.WriteLine($"Qui potrai inserire le varie informazioni relative al videogioco");

      while (true)
      {
         Console.WriteLine($"Inserisci il nome");
         string nome = Console.ReadLine()!;

         Console.WriteLine($"Inserisci il genere");
         string genere = Console.ReadLine()!;
         Console.WriteLine($"Inserisci l'anno di uscita");
         string anno = Console.ReadLine()!;
         Console.WriteLine($"Inserisci la tua personale recensione");
         string recensione = Console.ReadLine()!;
         Console.WriteLine($"Inserisci il voto");
         int voto = int.Parse(Console.ReadLine()!);


         string[] lines = File.ReadAllLines(path); //legge tutte le righe del file
         string[][] nomi = new string[lines.Length][];
         for (int i = 0; i < lines.Length; i++)
         {
            if (nomi[i][0] == nome) //comtrolla se il nome è già presente nel file
            {
               Console.WriteLine($"Il nome è già presente nel file");
               
            }
            else{
                File.AppendAllText(path, JsonConvert.SerializeObject(new { nome, genere, anno, recensione, voto }) + ",\n");//scrive la riga nel file
            }
            

         }

      }


      //togli la virgola
      string file = File.ReadAllText(path);
      file = file.Remove(file.Length - 2, 1); //vado indietro di due caratteri e ne tolgo 1
      File.WriteAllText(path, file);
      File.AppendAllText(path, "]"); //scrive la riga nel file
   }

}


