# GIOCO INDOVINA IL NUMERO

Programma che permette all'utente di provare a indovinare un numero randomico (tra 1 e 50) sorteggiato dal computer. L'utente ha a diposizione 10 tentativi per poter indovinare il numero segreto. Inoltre ha anche a disposizione dei suggerimenti da poter utilizzare. Perdi un punto ad ogni tentativo e perdi toto punti in base al suggerimento ch utilizzi. Il massimo di punti che ha a disposzione il giocatore a inizio partita equivale a 20. Il giocatore perde se non ha indovinato il numero segreto al termine dei 10 tentativi oppure se arriva a 0 punti.

### DEFINIZIONE DEI REQUISITI E ANALSI:
- [X] L'applicazione permette di inserire il nome del giocatore
- [X] L'applicazione permette di salvare la partita in un file txt già esistente (salva nel file txt il giocatore della partita precedente e il punteggio)
- [X] L'applicazione permette di inserire un numero ad ogni tentativo
- [X] L'applicazione permette ad ogni tentativo di chiedere al giocatore se vuole usufruire di un suggerimento
- [X] L'applicazione permette di sottrarre un punto ad ogni tentativo
- [X] L'applicazione permette di sottrarre 1 punto se si utilizza il suggerimento numero 1
- [X] L'applicazione permette di sottrarre 2 punti se si utilizza il suggerimento numero 2
- [X] L'applicazione permette di sottrarre 3 punti se si utilizza il suggerimento numero 3
- [X] L'applicazione permette di sottrarre 5 punti se si utilizza il suggerimento numero 4
- [X] L'applicazione permette di sottrarre 4 punti se si utilizza il suggerimento numero 5
- [X] L'applicazione permette di chiedere all'utente se vuole ricominciare la partita (solo nel caso in cui il giocatore h aperso)

### PIANIFICAZIONE E DESIGN DELL'ARCHITETTURA

- [X] L'applicazione deve memorizzare il vincitore della partita in un file txt

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

# BETATESTING DATABASE VIDEOGIOCHI
> OBIETTIVI
- Testare il gioco per individuare errori, bug, eccezioni non gestite e controllare i file csv e json

> BUG
- Controlla che non ci siano errori e se riesci dammi qualche consiglio per corregerlo
- Controlla il file json 

> ECCEZIONI
- Controlla se ci sono eventuali eccezioni non gestite

> USER EXPERIENCE
- Hai consigli o suggerimenti da darmi per migliorare il programma?
- Come valuti l'usabilità e la chiarezza del gioco?





## POST BETA TEST
<details>
    <summary> Raccolta Feedback </summary>


<details>   
    <summary> Feedback di Fabio </summary>

### RACCOLTA DEI FEEDBACK DI FABIO:




**ECCEZIONI**
- ECCEZIONE TRY-CATCH: L'inserimento iniziale dei numeri è corretto, mi piace il "non hai inserito un numero" dopo che si inserisce una lettera! Peccato però che alla richiesta di inserire un nuovo numero, se scrivo nuovamente una lettera mi dà l'errore "System.FormatException",
magari potresti provare ad inserire pure un try/catch alla seconda stringa di risposta. 

**BUG**
- BUG PUNTEGGIO: Ho notato anche che nonostante finisca i punti continui a contarli sotto lo 0 e non si ferma (ad esempio in questo caso se finisco il punteggio a -1, non 0),
credo che mettendo "punteggio <= 0" alla fine questo problema si sistemi

- BUG TENTETIVI: Se ho capito bene vuoi che si fermi il gioco anche dopo 10 tentativi, ho provato 12 volte ma mi fa ancora andare avanti

- BUG SORTEGGIO: Molto particolare anche il fatto che, quando mi chiede "s" per il suggerimento, anche se scrivo "pinguino" me lo dà comunque buono. 
 
Se sistemi queste piccole cose secondo me questo giochino è un bel passatempo!


### PRIORITA'
- [X] BUG PUNTEGGIO
- [X] BUG TENTATIVI
- [X] ECCEZIONE TRY CATCH INSERIMENTO LETTERE AL POSTO DEI NUMERI
- [X] BUG SUGGERIMENTO


</details>

### CODICE

```c#
class Program
{
   static void Main()
   {
      string path = @"salvataggio.txt"; // il file deve essere nella stessa cartella del programma
      string[] lines = File.ReadAllLines(path); //legge tutte le righe del file
      string[] nomi = new string[lines.Length];
      

      for (int i = 0; i < lines.Length; i++)
      {
         nomi[i] = lines[i];
      }

      string nomeGiocatore = lines[1];
      string punteggione = lines[3];
      Console.Write("Nella partita predente ha giocato ");
      Console.WriteLine(nomeGiocatore);
      Console.WriteLine("");
      Console.WriteLine("Il punteggio della partita precedente: ");
      Console.WriteLine(punteggione);
      Console.WriteLine("");
      bool inizio = false;
      while (!inizio)
      {
         Random random = new Random();
         int numeroDaIndovinare = random.Next(1, 51); // Genera un numero casuale tra 1 e 50
         int punteggio = 20;
         Console.WriteLine("Inserisci il tuo nome:");
         
         string nome = Console.ReadLine()!;

         Console.WriteLine($"Benvenuta/o {nome}");
         
         
         
         Console.WriteLine("Indovina il numero segreto compreso tra 1 e 50. Hai 10 tentativi.");
         Console.WriteLine("Perdi un punto ad ogni tentativo sbagliato e tot punti per ogni suggerimento che utilizi");
         

         int tentativiRimasti = 10;
         bool indovinato = false;

         while (tentativiRimasti > 0 && punteggio > 0 && !indovinato)
         {
            Console.WriteLine($"Ti mancano ancora {tentativiRimasti} tentativi");
            Console.WriteLine($"Il tuo punteggio è: {punteggio}");


            int numero;

            try
            {
               Console.WriteLine("Inserisci un numero");

               numero = int.Parse(Console.ReadLine()!);
               if (numero < 1 || numero > 50)
               {
                  Console.WriteLine("Devi inserire un numero da 1 a 50");

               }
               else
               {
                  if (numero != numeroDaIndovinare)
                  {
                     Console.WriteLine("Mi spiace, non hai indovinato");
                     tentativiRimasti--;
                     punteggio--;
                     bool rispostaValida = true;
                     while (rispostaValida)
                     {
                        Console.WriteLine("Vuoi usufruire di un suggerimento? (s/n)");
                        string input = Console.ReadLine()!;
                        if (input.ToLower() == "s")
                        {
                           Console.WriteLine("OK! Quale suggerimento vuoi utilizzare?");

                           Console.WriteLine("1. Il numero da indovinare è maggiore o minore? -1 punto");
                           Console.WriteLine("2. Il numero da indovinare è pari o dispari? -2 punti");
                           Console.WriteLine("3. Il numero da indovinare è minore o maggiore di 25? -3 punti");
                           Console.WriteLine("4. Qual è il quadrato del numero da indovinare? -5 punti");
                           Console.WriteLine("5. Qual è la somma delle cifre del numero da indovinare? -4 punti");
                           string suggerimento = Console.ReadLine()!;
                           switch (suggerimento)
                           {
                              case "1":
                                 NumeroMaggiore(numero, numeroDaIndovinare);
                                 punteggio -= 1;
                                 break;
                              case "2":
                                 NumeroPari(numero, numeroDaIndovinare);
                                 punteggio -= 2;
                                 break;
                              case "3":
                                 NumeroMaggiore25(numero, numeroDaIndovinare);
                                 punteggio -= 3;
                                 break;
                              case "4":
                                 double quadrato = Math.Pow(numeroDaIndovinare, 2);
                                 punteggio -= 5;
                                 Console.WriteLine($"Il quadrato del numero è {quadrato}");

                                 break;
                              case "5":
                                 int sommaCifre = SommaCifre(numeroDaIndovinare);
                                 punteggio -= 4;
                                 Console.WriteLine($"La somma delle cifre è {sommaCifre}");

                                 break;
                           }
                           rispostaValida = false;
                        }
                        else if (input.ToLower() == "n")
                        {
                           Console.WriteLine("Ok! Fenomeno");
                           rispostaValida = false;
                        }
                        else
                        {
                           Console.WriteLine("Non hai risposto alla domanda");

                        }
                     }

                  }
                  else
                  {
                     Console.WriteLine($"Bravo! Hai indovinato il numero segreto. Il tuo punteggio finale è: {punteggio}/20.");
                  lines[1] = nome;
                  lines[3] = punteggio.ToString();
                  File.WriteAllLines(path, lines);
                  
                  Console.WriteLine("Salvataggio...");
                     return;
                  }

               }
            }
            catch
            {
               Console.WriteLine("Devi inserire un numero");

            }





         }

         Console.WriteLine($"Spiacenti, hai esaurito tutti i tentativi o hai raggiunto 0 punti. Il numero segreto era: {numeroDaIndovinare}. Il tuo punteggio finale è: {punteggio}.");
         Console.WriteLine("Vuoi ricominciare? (s/n)");
         bool inputValido3 = true;
         while (inputValido3)
         {
            string input3 = Console.ReadLine()!;
            if (input3 == "s")
            {
               Console.WriteLine("Buona Partita!");
               ;
            }
            else if (input3 == "n")
            {
               Console.WriteLine("Alla prossima!");
               return;
            }
            else
            {
               Console.WriteLine("Non hai rsipsoto alla domanda");
               Console.WriteLine("Rispondi correttamente (s/n)");
               
            }
         }
      }
   }
   static bool Maggiore(int numero, int numeroDaIndovinare)
   {
      return numero < numeroDaIndovinare;
   }
   static void NumeroMaggiore(int numero, int numeroDaIndovinare)
   {
      if (Maggiore(numero, numeroDaIndovinare))
      {
         Console.WriteLine($"Il numero è maggiore di {numero}");

      }
      else
      {
         Console.WriteLine($"Il numero è minore di {numero}");

      }
   }
   static bool Pari(int numero, int numeroDaIndovinare)
   {
      return numeroDaIndovinare % 2 == 0;
   }
   static void NumeroPari(int numero, int numeroDaIndovinare)
   {
      if (Pari(numero, numeroDaIndovinare))
      {
         Console.WriteLine("Il numero è pari");

      }
      else
      {
         Console.WriteLine("Il numero è dispari");

      }
   }
   static bool Maggiore25(int numero, int numeroDaIndovinare)
   {
      return numeroDaIndovinare > 25;
   }
   static void NumeroMaggiore25(int numero, int numeroDaIndovinare)
   {
      if (Maggiore25(numero, numeroDaIndovinare))
      {
         Console.WriteLine("Il numero è maggiore di 25");

      }
      else
      {
         Console.WriteLine("Il numero è minore di 25");

      }
   }

   static int SommaCifre(int numeroDaIndovinare)
   {
      int somma = 0;

      // Itera attraverso le cifre del numero
      while (numeroDaIndovinare != 0)
      {
         somma += numeroDaIndovinare % 10; // Aggiungi l'ultima cifra alla somma
         numeroDaIndovinare /= 10; // Rimuovi l'ultima cifra dal numero
      }

      return somma;
   }
}

```

```txt
Nome giocatore partita precedente:
Giada
Punteggio:
14
```