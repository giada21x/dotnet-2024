# GIOCO DADI:
 
Creare un programmino che simuli una partita a dadi tra utente e computer. Ci sono a disposizione 5 manche, chi ne vince di più vince il gioco.
Le manche si vincono in base ai punti che si totalizzano:
- semplice somma dei dadi
- quando escono due dadi dello stesso numero si applica un moltiplicatore x2
- quando escono un dado da 5 e un dado da 6 oppure un dado da 12 e un dado da 18 si vince automaticamente la partita
- quando escono due numeri la cui somma equivale a 9 o 23 si subisce una penalità, si perdono 5 punti


### DEFINIZIONE DEI REQUISITI E ANALSI:
- [X] L'applicazione pemette di tirare i due dadi a turno
- [X] L'applicazione permette di inserire il nome del giocatore
- [X] L'applicazione permette di fare un salvataggio della partita (salva nel file txt il vincitore della partita)
- [X] L'applicazione permette di terminare il gioco alla fine della quinta manche 
- [X] L'applicazione permette di sommare i valori dei due dadi 
- [X] L'applicazione permette di far vincere il giocatore che ha vinto più manche
- [X] L'applicazione permette di usare un moltiplicatore quando escono due dadi dello stesso numero
- [X] L'applicazione permette di subire una penalità di -5 punti se la somma dei due dadi eqivale a 9 o 23
- [X] L'applicazione permette di vincere subito se escono un dado da 5 e un dado da 6 oppure un dado da 12 e un dado da 18
- [X] L'applicazione permette di verificare se il file txt esiste
- [X] L'applicazione permette la Richiesta di un rematch a fine partita
- [X] L'applicazione permette al giocatore di inserire l'età per verificare che possa giocare in base all'età
- [X] L'applicazione permette al giocatore di scommettere soldi a piacimento
- [X] L'applicazione permette di guadagnare il doppio della puntata se il giocatore vince la partita
- [X] L'applicazione permette di perdere i soldi della puntata se il giocatore non vince la partita
- [X] L'applicazione permette di riavere indietro i soldi della puntata in caso di pareggio

### PIANIFICAZIONE E DESIGN DELL'ARCHITETTURA

- [X] L'applicazione deve memorizzare il vincitore della partita in un file di testo
- [X] L'applicazione verifica attraverso un file csv se una persona può effettivamente giocare in base all'età
- [X] L'applicazione deve essere un minimo colorata 

### DEFINIZIONE DI STRUTTURE E CONVENZIONI

- [X] I nomi delle classi devono essere PascalCase.
- [X] I nomi dei metodi devono essere PascalCase.
- [X] I nomi delle variabili devono essere camelCase.
- [X] I nomi delle costanti devono essere UPPERCASE.
- [X] I nomi dei file devono essere lowercase.
- [X] I nomi dei progetti devono essere PascalCase.
- [X] I nomi dei namespace devono essere PascalCase.


### TEST E DEBUGGING
- [X] Esegui il debugging per individuare e risolvere i bug

### DOCUMENTAZIONE
- [X] Documenta il codice e l'architettura.

### CODICE
```c#
//gioco dadi con implemento funzioni
class Program
{   static void Main(string[] args)
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
            StampaUguali(dado1, dado2, punteggio1);
            StampaCombinazione(dado1, dado2);
            StampaPunteggio(punteggio1);
            Thread.Sleep(2000);
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
            StampaUguali(dado1, dado2, punteggio1);
            StampaCombinazione(dado1, dado2);
            StampaPunteggio(punteggioComputer);
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
         Console.ForegroundColor = currentForeground;
         Console.WriteLine($"Punteggio: {punteggio} punti");
         Console.ForegroundColor = currentForeground;
      }
   }
}
```
### FILE TXT - salva il vincitore della partita precedente
Chi ha vinto la partita precedente? 
Ha vinto giada

### FILE CSV - salva i dati del giocatore (nome, cognome, età)
giada,adamo,22
