﻿
class Program
{
   static void Main(string[] args)
   {
      //string path = @"C:\Users\Utente\Desktop\test.txt";
      string path = @"test.txt"; // il file deve essere nella stessa cartella del programma
      string[] lines = File.ReadAllLines(path); //legge tutte le righe del file
      string[] nomi = new string[lines.Length];
      for (int i = 0; i < lines.Length; i++)
      {
         nomi[i] = lines[i]; //assegna ad ogni elemento dell'array di stringhe il valore della riga 
      }
      Random random = new Random(); //crea un oggetto random
      int index = random.Next(nomi.Length); //genera un numero casuale tra 0 e la lunghezza dell'array di stringhe 
      Console.WriteLine(nomi[index]); //stampa il nome corrispondente all'indice generato casualmente 
      string path2 =  @"test2.txt";
      File.Create(path2).Close();
      File.AppendAllText(path2, nomi[index] + "\n"); //scrive la riga nel file
      
   }
}






