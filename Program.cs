class Program
{
   static void Main(string[] args)
   {
      ConsoleColor currentForeground = Console.ForegroundColor;
      ConsoleColor currentBackground = Console.BackgroundColor;
      string risposta = "ciao";
      while (risposta != "n")
      {
         string path1 = @"controlloetà.csv"; //il file deve essere nella stessa cartella del programma
         File.Create(path1).Close(); //crea il file
         Console.WriteLine($"Controllo dati personali");
         Console.WriteLine($"Inserisci nome, cognome ed eta");
         Console.ForegroundColor = ConsoleColor.DarkGreen;
         string nome = Console.ReadLine()!; //legge il nome
         string cognome = Console.ReadLine()!;//legge il cognome
         int eta = int.Parse(Console.ReadLine()!);//legge l'età
         Console.ForegroundColor = currentForeground;
         File.AppendAllText(path1, nome + "," + cognome + "," + eta + "\n");//scrive la riga nel file
         if (eta < 18)
         {
            Console.WriteLine("Mi dispiace! Non puoi giocare...");
            return;
         }
         else
         {
            Console.WriteLine($"Ok! Proseguiamo");
         }
         Console.WriteLine($"Inserimento dati...");
         Thread.Sleep(3000);
         string path = @"vincitoregiocodadi.txt"; // il file deve essere nella stessa cartella del programma
         string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
         string[] nomi = new string[lines.Length];
         for (int i = 0; i < lines.Length; i++)
         {
            nomi[i] = lines[i];
         }
         string domanda = lines[0];
         string risultato = lines[1];
         Console.WriteLine("Chi ha vinto la partita precedente?");
         Console.WriteLine(risultato);
         int manche = 0;
         Console.WriteLine("Inizio del gioco!");
         Console.WriteLine("Inserisci di nuovo il tuo nome:");
         Console.ForegroundColor = ConsoleColor.DarkGreen;
         string nome1 = Console.ReadLine()!; ;
         Console.ForegroundColor = currentForeground;
         Random random = new Random();
         int mancheVintegiocatore1 = 0;
         int mancheVinteComputer = 0;
         Console.WriteLine($"{nome1}, quanto vuoi scommettere?");//per giocare si devono scommettere un quantitativo di soldi a piacimento. 
         int scommessa = int.Parse(Console.ReadLine()!); //se vinci li raddoppi,se non vinci perdi i soldi della puntata
         Console.WriteLine($"Hai scommesso {scommessa} euro");
         Thread.Sleep(1000);
         while (manche != 5)
         {
            manche++;
            //manche giocatore1 
            int dado1 = random.Next(1, 21);
            int dado2 = random.Next(1, 21);
            int punteggio1 = dado1 + dado2;
            Console.WriteLine($"INIZIO MANCHE");
            Console.WriteLine($"Sono usciti i numeri: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{dado1}  {dado2}");
            Console.ForegroundColor = currentForeground;
            int punteggio = dado1 + dado2;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Sei a {punteggio1} punti");
            Console.ForegroundColor = currentForeground;
            Thread.Sleep(2000);
            
            //funzioni per gestire i vari casi punteggio (bonus, penalità e vittoria immediata)
            StampaUguali(dado1, dado2, punteggio1); //dadi uguali
            StampaCombinazione(dado1, dado2); //combinazione di numeri 
            StampaPunteggio(punteggio1); //somma dadi = determinato punteggio  
            Thread.Sleep(2000);
            
            //manche computer
            dado1 = random.Next(1, 21);
            dado2 = random.Next(1, 21);
            int punteggioComputer = dado1 + dado2;
            Console.WriteLine("Sono usciti i numeri:");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{dado1}  {dado2}");
            Console.ForegroundColor = currentForeground;
            punteggio = dado1 + dado2;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Il computer è a {punteggioComputer} punti");
            Console.ForegroundColor = currentForeground;
            Thread.Sleep(2000);
            
            //funzioni per gestire i vari casi punteggio (bonus, penalità e vittoria immediata)
            StampaUguali(dado1, dado2, punteggioComputer);//dadi uguali
            StampaCombinazione(dado1, dado2);//combinazione di numeri 
            StampaPunteggio(punteggioComputer);//somma dadi = determinato punteggio
            Thread.Sleep(2000);

            Console.WriteLine("Chi ha vinto questa manche?");
            if (punteggio1 > punteggioComputer)
            {
               Console.ForegroundColor = ConsoleColor.DarkGreen;
               Console.WriteLine("HAI VINTO LA MANCHE");
               Console.ForegroundColor = currentForeground;
               mancheVintegiocatore1++;
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
         string risultato1 = $"Ha vinto {nome1}";
         string risultato2 = "Ha vinto il computer";
         string risultato3 = "Pareggio";
         if (mancheVintegiocatore1 > mancheVinteComputer)
         {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($" HAI VINTO");
            Console.BackgroundColor = currentBackground;
            lines[1] = risultato1.ToString();
            File.WriteAllLines(path, lines);
            scommessa *= 2;
            Console.WriteLine($"Complimenti! Hai guadagnato {scommessa} euro ");
         }
         else if (mancheVintegiocatore1 < mancheVinteComputer)
         {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("IL COMPUTER HA VINTO LA PARTITA");
            Console.BackgroundColor = currentBackground;
            lines[1] = risultato2.ToString();
            File.WriteAllLines(path, lines);
            scommessa -= scommessa;
            Console.WriteLine($"Mi spiace, hai perso i soldi. Sei a {scommessa} euro");
         }
         else if (mancheVintegiocatore1 == mancheVinteComputer)
         {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("PAREGGIO");
            Console.BackgroundColor = currentBackground;
            lines[1] = risultato3.ToString();
            File.WriteAllLines(path, lines);
            Console.WriteLine($"Riprenditi pure i tuoi {scommessa} euro");
         }
         Console.WriteLine($"Vuoi fare un'altra partita? (s/n)");
         ConsoleKeyInfo key = Console.ReadKey(true);
         risposta = key.KeyChar.ToString();
         if (risposta == "s")
         {
            Console.WriteLine("Buona partita!");
            Thread.Sleep(2000);
         }
         else if (risposta == "n")
         {
            Console.WriteLine($"Addio...");
         }
      }
   }
   static bool Uguali(int dado1, int dado2)
   {
      return dado1 == dado2;
   }
   static void StampaUguali(int dado1, int dado2, int punteggio1)
   {
      if (Uguali(dado1, dado2))
      {
         ConsoleColor currentForeground = Console.ForegroundColor;
         Console.WriteLine("Punteggio raddoppiato!");
         punteggio1 *= 2;
         Console.ForegroundColor = ConsoleColor.DarkMagenta;
         Console.WriteLine($"Punteggio: {punteggio1} punti");
         Console.ForegroundColor = currentForeground;
      }
   }
   static bool Combinazione(int dado1, int dado2)
   {
      return (dado1 == 5 && dado2 == 6) || (dado1 == 12 && dado2 == 18);
   }
   static void StampaCombinazione(int dado1, int dado2)
   {
      if (Combinazione(dado1, dado2))
      {
         Console.WriteLine("COMPLIMENTI! HAI VINTO!");
         return;
      }
   }
   static bool Punteggio(int punteggio)
   {
      return punteggio == 9 || punteggio == 23;
   }
   static void StampaPunteggio(int punteggio)
   {
      if (Punteggio(punteggio))
      {
         ConsoleColor currentForeground = Console.ForegroundColor;
         Console.WriteLine($"5 punti persi!");
         punteggio -= 5;
         Console.ForegroundColor = ConsoleColor.DarkMagenta;
         Console.WriteLine($"Punteggio: {punteggio} punti");
         Console.ForegroundColor = currentForeground;
      }
   }
}