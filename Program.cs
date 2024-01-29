class Program
{
   static void Main(string[] args)
   {

      ConsoleColor currentForeground = Console.ForegroundColor;
      ConsoleColor currentBackground = Console.BackgroundColor;
      int manche= 0;
      Console.WriteLine("Inizio del gioco!");
      Console.WriteLine("Inserisci il tuo nome:");
      
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      string nome = Console.ReadLine()!;
      Console.ForegroundColor = currentForeground;
      Random random = new Random();
      int mancheVinteGiada = 0;
      int mancheVinteComputer = 0;
      


      while (manche != 5)
      {

         manche++;
         int dado1 = random.Next(1, 21);
         int dado2 = random.Next(1, 21);
         int punteggio1 = dado1 + dado2;
         Console.WriteLine($"INIZIO MANCHE");

         
         Console.WriteLine($"Sono usciti i numeri: ");
         Console.ForegroundColor = ConsoleColor.Cyan;
         Console.WriteLine($"{dado1}  {dado2}");
         Console.ForegroundColor = currentForeground;
         
         Console.ForegroundColor = ConsoleColor.DarkGreen;
         Console.WriteLine($"Sei a {punteggio1} punti");
         Console.ForegroundColor = currentForeground;

         Thread.Sleep(2000);

         if (dado1 == dado2)
         {

            Console.WriteLine("Wow! Hai raddoppiato il tuo punteggio!");
            punteggio1 *= 2;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Hai totalizzato {punteggio1} punti");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Thread.Sleep(2000);
         }
         else if (punteggio1 == 9 || punteggio1 == 23)
         {
            punteggio1 -= 5;
            Console.WriteLine($"Peccato! Hai perso -5 punti");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Il tuo punteggio ora è {punteggio1} punti");
            Console.ForegroundColor = currentForeground;
            Thread.Sleep(2000);
         }
         else if ((dado1 == 5 && dado2 == 6) || (dado1 == 12 && dado2 == 18))
         {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("COMPLIMENTI! HAI VINTO!");
            Console.BackgroundColor = currentBackground;
            return;

         }

         Random random2 = new Random();
         int dado3 = random.Next(1, 21);
         int dado4 = random.Next(1, 21);
         int punteggioComputer;
         punteggioComputer = dado3 + dado4;
         Console.WriteLine("Sono usciti i numeri:"); 
         Console.ForegroundColor = ConsoleColor.DarkCyan;
         Console.WriteLine($"{dado3}  {dado4}");
         Console.ForegroundColor = currentForeground;
         Console.ForegroundColor = ConsoleColor.DarkRed;
         Console.WriteLine($"Il computer è a {punteggioComputer} punti");
         Console.ForegroundColor = currentForeground;
         Thread.Sleep(2000);
         
         if (dado3 == dado4)
         {
            punteggioComputer *= 2;
            Console.WriteLine("Il computer ha raddoppiato il suo punteggio!");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Il computer ha totalizzato {punteggioComputer} punti");
            Console.ForegroundColor = currentForeground;
            Thread.Sleep(2000);
         }
         else if (punteggioComputer == 9 || punteggioComputer == 23)
         {
            punteggioComputer -= 5;
            Console.WriteLine("Il computer ha perso -5 punti");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Il computer ha totalizzato {punteggioComputer} punti");
            Console.ForegroundColor = currentForeground;
            Thread.Sleep(2000);
         }
         else if ((dado1 == 5 && dado2 == 6) || (dado1 == 12 && dado2 == 18))
         {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Il computer ha vinto!");
            Console.BackgroundColor = currentBackground;
            return;

         }
         Console.WriteLine("Chi ha vinto questa manche?");
         
         if (punteggio1 > punteggioComputer)
         {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("HAI VINTO LA MANCHE");
            Console.ForegroundColor = currentForeground;
            mancheVinteGiada++;

            
         }
         else if (punteggio1 < punteggioComputer)
         {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("MANCHE VINTA DAL COMPUTER");
            Console.ForegroundColor = currentForeground;
            mancheVinteComputer++;
         }
         else if (punteggio1 == punteggioComputer)
         {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("PAREGGIO!");
            Console.ForegroundColor = currentForeground;
         }
         Thread.Sleep(3000);
          
         }
      
      if (mancheVinteGiada > mancheVinteComputer)
      {
         Console.BackgroundColor = ConsoleColor.DarkGreen;
         Console.WriteLine($"HAI VINTO");
         Console.BackgroundColor = currentBackground;
      }
      else if (mancheVinteGiada < mancheVinteComputer)
      {
         Console.BackgroundColor = ConsoleColor.DarkRed;
         Console.WriteLine($"IL COMPUTER HA VINTO LA PARTITA");
         Console.BackgroundColor = currentBackground;
      } 
      else if (mancheVinteGiada == mancheVinteComputer)
      {
         Console.BackgroundColor = ConsoleColor.DarkYellow;
         Console.WriteLine("PAREGGIO");
         Console.BackgroundColor = currentBackground;
         
      }
   }  
   
}






