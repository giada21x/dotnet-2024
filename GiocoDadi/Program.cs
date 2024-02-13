class Progra
{
   static void Main(string[] args)
   {
      ConsoleColor currentForeground = Console.ForegroundColor;
      ConsoleColor currentBackground = Console.BackgroundColor;

      string risposta = "ciao";
      while (risposta != "n")
      {


         Console.Clear();

         Console.WriteLine($"Controllo dati personali");
         Console.WriteLine($"Inserisci nome, cognome ed eta");

         string path1 = @"controlloetà.csv"; //il file deve essere nella stessa cartella del programma
         File.Create(path1).Close(); //crea il file

         string nome = null;
         string cognome = null;
         int eta = 0;

         DatiValidi(nome, cognome, path1);
         EtaValida(eta, path1);


         //File.AppendAllText(path1, nome + "," + cognome + "," + eta + "\n");//scrive la riga nel file

         Console.WriteLine($"Inserimento dati...");
         Thread.Sleep(3000);
         Console.Clear();


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
         Thread.Sleep(2000);
         Console.Clear();

         int manche = 0;

         //Console.WriteLine("Inserisci di nuovo il tuo nome:");

         Console.ForegroundColor = ConsoleColor.DarkGreen;
         //string nome = Console.ReadLine()!; 
         Console.ForegroundColor = currentForeground;
         Random random = new Random();
         int mancheVintegiocatore1 = 0;
         int mancheVinteComputer = 0;
         Console.WriteLine("REGOLE DEL GIOCO:");
         Console.WriteLine("Le manche si vincono in base ai punti che si totalizzano:");
         Console.WriteLine("- semplice somma dei dadi");
         Console.WriteLine("- quando escono due dadi dello stesso numero si applica un moltiplicatore x2");
         Console.WriteLine("- quando escono un dado da 5 e un dado da 6 oppure un dado da 12 e un dado da 18 si vince automaticamente la partita");
         Console.WriteLine("- quando escono due numeri la cui somma equivale a 9 o 23 si subisce una penalità, si perdono 5 punti");
         Thread.Sleep(500);
         Console.WriteLine("\n");

         Console.WriteLine("quanto vuoi scommettere?");//per giocare si devono scommettere un quantitativo di soldi a piacimento. 
         int scommessa = 0;
         while (true)
         {

            try
            {
                scommessa = int.Parse(Console.ReadLine()!); //se vinci li raddoppi,se non vinci perdi i soldi della puntata
               break;
            }
            catch
            {
               Console.WriteLine("Devi inserire un numero");

            }
         }
         Console.Clear();
         Console.WriteLine($"Hai scommesso {scommessa} euro");
         Thread.Sleep(1000);
         Console.WriteLine("Inizio del gioco!");
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
            Console.Clear();

         }
         string risultato1 = $"Hai vinto tu";
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
   static void DatiValidi(string nome, string cognome, string path1)
   {
      bool nomeValido = true;
      bool cognomeValido = true;

      while (nomeValido)
      {

         nome = Console.ReadLine()!;


         if (string.IsNullOrWhiteSpace(nome))
         {

            Console.WriteLine("Nome non valido");
            Console.WriteLine("Inserisci un nome valido:");

         }
         else
         {
            Console.WriteLine($"Ok! Inserisci cognome:");
            File.AppendAllText(path1, nome + "\n");
            nomeValido = false;
         }

      }

      while (cognomeValido)
      {
         cognome = Console.ReadLine()!;
         if (string.IsNullOrWhiteSpace(cognome))
         {
            Console.WriteLine("Cognome non valido");
            Console.WriteLine("Inserisci un cognome valido");
         }
         else
         {
            Console.WriteLine("Ok! Inserisci l'età:");
            File.AppendAllText(path1, cognome + "\n");
            cognomeValido = false;

         }

      }

   }
   static void EtaValida(int eta, string path1)
   {
      bool etaValida = true;
      while (etaValida)
      {
         try
         {
            eta = int.Parse(Console.ReadLine()!);
            if (eta < 18)
            {
               Console.WriteLine("Mi dispiace non puoi giocare, sei troppo piccolo");
               return;
            }
            else
            {
               Console.WriteLine("Ok, proseguiamo");
               File.AppendAllText(path1, eta + "\n");
               etaValida = false;
            }



         }
         catch
         {
            Console.WriteLine("Non hai inserito un numero valido");
            Console.WriteLine("Riprova");

         }

      }
   }
}