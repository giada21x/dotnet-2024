//vogliamo gestire il System.NullReferenceException (si verifica quando si tenta di accedere ad un oggetto null)
class Program
{
   static void Main(string[] args)
   {
      string? nome = null; //stiamo spingendo volontariamente verso l'errore 
      try
      {
         Console.WriteLine(nome.Length);
      }
      catch (Exception e)
      {
         Console.WriteLine("Il nome non è valido");
         return;
         
      }
   
   }
}




