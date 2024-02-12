using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
class Program
{
   static void Main(string[] args)
   {
      Console.Clear();

      Console.WriteLine("Benvenuto/a!");

      //Verifico se all'interno della cartella del programma siano già presenti file json di videogiochi

      string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*json"); //legge tutti i file json nella cartella del programma

      //Se sono prsenti mi stampa i nomi dei file
      if (files.Any())
      {
         Console.WriteLine($"Sono già presenti questi videogiochi:");
         foreach (string file in files)
         {
            Console.WriteLine(Path.GetFileName(file)); //stampa il nome del file
            Thread.Sleep(200);
         }
      }
      else
      {
         Console.WriteLine("Non sono ancora presenti videogiochi");

      }




      while (true)
      {
         //Inserisco il nome del videogioco 
         bool nomeValido = true;
         Console.WriteLine("Inserisci il titolo del videogioco che voglio aggiungere al database");
         string nome = null;
         //verifico che il nome sia valido
         while (nomeValido)
         {

            nome = Console.ReadLine()!;
            Console.Clear();
            if (string.IsNullOrWhiteSpace(nome))
            {

               Console.WriteLine("Nome non valido");
               Console.WriteLine("Inserisci un nome nuovo ");

            }
            else
            {
               Console.WriteLine("Il nome è valido");
               break;
            }
         }

         string nomeVideogioco = nome.Trim();
         nomeVideogioco = nomeVideogioco.Replace(" ", "-");
         string percorso = $"{nomeVideogioco}" + ".json"; //ogni file json è chiamato con il nome del videogioco 
         if (!File.Exists(percorso)) //verifico che non ci siano già file con lo stesso nome
         {
            File.Create(percorso).Close();

            Console.WriteLine("Assegna un voto da 1 a 10:");

            int voto = 0;
            int anno = 0;
            //assegno un voto da 1 a 10 al videogioco e gestisco eventuali eccezioni
            while (true)
            {
               try
               {
                  voto = int.Parse(Console.ReadLine()!);
                  Console.Clear();

                  if (voto <= 10)
                  {
                     Console.WriteLine("Voto convalidato");
                     break;
                  }
                  else
                  {
                     Console.WriteLine("Errore...Non hai inserito un voto valido");
                     Console.WriteLine("Riprova");
                  }
               }
               catch
               {
                  Console.WriteLine("Non hai inserito un numero valido");
                  Console.WriteLine("Riprova");

               }

            }
            //inserisco l'anno di uscita e gestico eventuali eccezioni
            Console.WriteLine("Inserisci l'anno di uscita del videogioco:");
            bool annoValido = true;
            while (annoValido)
            {
               try
               {
                  anno = int.Parse(Console.ReadLine()!);
                  Console.Clear();

                  int annoCorrente = 2024;
                  int annoVecchio = 1972;
                  if (anno < annoCorrente && anno > annoVecchio)
                  {
                     Console.WriteLine("Anno convalidato");
                     annoValido = false;
                  }

                  else
                  {
                     Console.WriteLine("Errore...Non hai inserito un anno valido");
                     Console.WriteLine("Riprova");
                  }
               }
               catch (Exception)
               {
                  Console.WriteLine("Non hai inserito un numero valido");
                  Console.WriteLine("Riprova");

               }
            }

            //stampa nome, anno di uscita e voto nel file json dedicato al videogioco
            File.AppendAllText(percorso, "[\n");
            File.AppendAllText(percorso, JsonConvert.SerializeObject(new { nome, anno, voto }) + ",\n");
            File.AppendAllText(percorso, "\n");


            //inseriamo nuove informazioni riguardo il videogioco
            bool rispostaValida = true;
            Console.WriteLine($"Vuoi darci più informazioni riguardo al videogioco (s/n)");
            while (rispostaValida)
            {

               string risposta = Console.ReadLine()!;


               if (risposta == "s")
               {
                  Console.Clear();

                  //informazione riguardo alla console
                  Console.WriteLine("Domanda 1: Su che console hai giocato?");
                  bool InformazioneValida = true;
                  while (InformazioneValida)
                  {
                     Console.WriteLine("Playstation 5");
                     Thread.Sleep(200);
                     Console.WriteLine("Xbox");
                     Thread.Sleep(200);
                     Console.WriteLine("Nintendo Switch");
                     Thread.Sleep(200);
                     Console.WriteLine("PC");
                     Thread.Sleep(200);
                     Console.WriteLine("Smartphone");
<<<<<<< HEAD
=======



                     string console = Console.ReadLine()!;
                     Console.Clear();


                     switch (console)
                     {
                        case "Playstation 5":
                           Console.WriteLine("Hai selezionato Playstation 5");
                           InformazioneValida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { console }) + ",\n");

                           break;
                        case "Xbox":
                           Console.WriteLine("Hai selezionato Xbox");
                           InformazioneValida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { console }) + ",\n");

                           break;
                        case "Nintendo Switch":
                           Console.WriteLine("Hai selezionato Nintendo Switch");
                           InformazioneValida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { console }) + ",\n");

                           break;
                        case "PC":
                           Console.WriteLine("Hai selezionato PC");
                           InformazioneValida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { console }) + ",\n");

                           break;
                        case "Smartphone":
                           Console.WriteLine("Hai selezionato smartphone");
                           InformazioneValida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { console }) + ",\n");

                           break;
                        default:
                           Console.WriteLine("Selezione non valida");
                           Console.WriteLine($"Riprova");

                           break;
                     }
                  }
                  File.AppendAllText(percorso, "\n");
                  //rispostaValida = false;



                  //informazione riguardo il genere
                  Console.WriteLine("Domanda 2: A che genere appartiene il videogioco?");
                  bool Informazione2Valida = true;
                  while (Informazione2Valida)
                  {
                     Console.WriteLine("Sparatutto");
                     Thread.Sleep(200);
                     Console.WriteLine("Picchiaduro");
                     Thread.Sleep(200);
                     Console.WriteLine("Giochi di ruolo");
                     Thread.Sleep(200);
                     Console.WriteLine("Giochi Platform");
                     Thread.Sleep(200);
                     Console.WriteLine("Racing");
                     Thread.Sleep(200);
                     Console.WriteLine("Giochi sportivi");
                     Thread.Sleep(200);
                     Console.WriteLine("Avventura");


                     string genere = Console.ReadLine()!;
                     Console.Clear();

                     switch (genere)
                     {
                        case "Sparatutto":
                           Console.WriteLine("è uno sparatutto");
                           Informazione2Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                           File.AppendAllText(percorso, "\n");
                           break;
                        case "Picchiaduro":
                           Console.WriteLine("è un picchiaduro");
                           Informazione2Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                           File.AppendAllText(percorso, "\n");
                           break;
                        case "Giochi di ruolo":
                           Console.WriteLine("è un gioco di ruolo");
                           Informazione2Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                           File.AppendAllText(percorso, "\n");
                           break;
                        case "Giochi Platform":
                           Console.WriteLine("è un gioco platform");
                           Informazione2Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                           File.AppendAllText(percorso, "\n");
                           break;
                        case "Racing":
                           Console.WriteLine("è un racing game");
                           Informazione2Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                           File.AppendAllText(percorso, "\n");
                           break;
                        case "Giochi Sportivi":
                           Console.WriteLine("è un gioco sportivo");
                           Informazione2Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                           File.AppendAllText(percorso, "\n");
                           break;
                        case "Avventura":
                           Console.WriteLine("è un gioco di avventura");
                           Informazione2Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                           File.AppendAllText(percorso, "\n");
                           break;
                        default:
                           Console.WriteLine("Selezione non valida");
                           Console.WriteLine("Riprova");

                           break;

                     }
                  }

                  Console.WriteLine("Domanda 3: Livello di difficoltà?");
                  bool Informazione3Valida = true;
                  while (Informazione3Valida)
                  {
                     Console.WriteLine("Facile");
                     Thread.Sleep(200);
                     Console.WriteLine("Medio");
                     Thread.Sleep(200);
                     Console.WriteLine("Difficile");
                     string difficoltà = Console.ReadLine()!;
                     Console.Clear();
                     switch (difficoltà)
                     {
                        case "Facile":
                           Console.WriteLine("Hai selezionato Facile");
                           Informazione3Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { difficoltà }) + ",\n");
                           break;
                        case "Medio":
                           Console.WriteLine("Hai selezionato Medio");
                           Informazione3Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { difficoltà }) + ",\n");
                           break;
                        case "Difficile":
                           Console.WriteLine("Hai selezionato Difficile");
                           Informazione3Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { difficoltà }) + ",\n");
                           break;
                        default:
                           Console.WriteLine("Selezione non valida");
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { difficoltà }) + ",\n");
                           break;

                     }
                  }

               }
               else if (risposta == "n")
               {
                  Console.WriteLine("Come preferisci...");
                  rispostaValida = false;
               }
               else
               {
                  Console.WriteLine("Non hai risposto alla domanda...");
                  Console.WriteLine("Riprova");
               }
               rispostaValida = false;
            }

            Console.WriteLine("Vuoi aggiungere una recensione personale? (s/n)");

            bool risposta1Valida = true;
            while (risposta1Valida)
            {


               string risposta1 = Console.ReadLine()!;
               Console.Clear();
               if (risposta1 == "s")
               {
                  string recensione = Console.ReadLine()!;
                  Console.Clear();
                  File.AppendAllText(percorso, JsonConvert.SerializeObject(new { recensione }));
                  File.AppendAllText(percorso, "\n");
                  risposta1Valida = false;
               }
               else if (risposta1 == "n")
               {
                  Console.WriteLine("Ok, proseguiamo");
                  risposta1Valida = false;

               }
               else
               {
                  Console.WriteLine("Non hai risposto alla domanda...");
                  Console.WriteLine("Riprova");
               }
            }
            string file = File.ReadAllText(percorso);
            file = file.Remove(file.Length - 2, 1); //vado indietro di due caratteri e ne tolgo 1
            File.WriteAllText(percorso, file);
            File.AppendAllText(percorso, "]"); //scrive l ariga nel file
         }
         else
         {
            Console.WriteLine("Il file è già esistente");


         }
         Console.WriteLine($"Vuoi inserire un altro videogioco? (s/n)");
         bool risposta2Valida = true;
         while (risposta2Valida)
         {
            string risposta2 = Console.ReadLine()!;
            Console.Clear();
            if (risposta2 == "n")
            {

               Console.WriteLine("Vuoi vedere tutti i giochi che hai inserito o eliminarne qualcuno? (s/n)");
               bool risposta4Valida = true;
               while (risposta4Valida)
               {
                  string risposta4 = Console.ReadLine()!;
                  Console.Clear();
                  if (risposta4 == "s")
                  {
                     //bool risposta4Valida = true;

                     Console.WriteLine("Vuoi leggere o eliminare un file? (l/e)");
                     bool risposta5Valida = true;
                     while (risposta5Valida)
                     {
                        string risposta5 = Console.ReadLine()!;
                        Console.Clear();
                        if (risposta5 == "l")
                        {



                           files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*json"); //legge tutti i file json nella cartella del programma
                           if (files.Any())
                           {
                              foreach (string file in files)
                              {
                                 Console.WriteLine(Path.GetFileName(file)); //stampa il nome del file

                              }

                              Console.WriteLine("quale file vuoi leggere?");
                              string fileScelto = Console.ReadLine()!; //legge il nome del file scelto
                              if (File.Exists(fileScelto)) //controlla se il file esiste
                              {
                                 string[] lines = File.ReadAllLines(fileScelto); //legge tutte le righe del file
                                 foreach (string line in lines)
                                 {
                                    Console.WriteLine(line); //stampa la riga

                                 }
                                 risposta5Valida = false;
                              }
                              else
                              {
                                 Console.WriteLine("Questo file non esiste");

                              }

                           }
                           else
                           {
                              Console.WriteLine("Non ci sono file da eliminare");
                           }

                        }
                        else if (risposta5 == "e")
                        {
                           // bool Elimina = true;
                           //while (Elimina)
                           // {
                           files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*json"); //legge tutti i file json nella cartella del programma
                           if (files.Any())
                           {
                              foreach (string file in files)
                              {
                                 Console.WriteLine(Path.GetFileName(file)); //stampa il nome del file

                              }

                              //if (!FileExists(file))
                              Console.WriteLine("quale file vuoi eliminare?");
                              string fileScelto = Console.ReadLine()!;

                              if (File.Exists(fileScelto))
                              {
                                 File.Delete(fileScelto); //elimina il file
                                 Console.Clear();
                                 Console.WriteLine("File eliminato con successo");
                                 risposta5Valida = false;
                              }
                              else
                              {
                                 Console.WriteLine("Questo file non esiste");
                                 //Console.WriteLine("Cosa vuoi fare? (l/e)");
                              }
                           }
                           else
                           {
                              Console.WriteLine("Non ci sono file da eliminare");
                           }

                        }
                        else
                        {
                           Console.WriteLine("Non hai risposto alla domanda");
                           Console.WriteLine("Riprova");


                        }

                        Console.WriteLine("Vuoi fare altro? (s/n)");
                        string risposta7 = Console.ReadLine()!;
                        EliminaLeggi(risposta7);
                        
                     }


                  }
                  else if (risposta4 == "n")
                  {
                     Console.WriteLine("Grazie, Alla prossima!");

                     return;
                  }
                  else
                  {
                     Console.WriteLine("Non hai risposto alla domanda");
                     Console.WriteLine("Riprova: rispondi s o n");


                  }

               }
            }
            else if (risposta2 == "s")
            {
               Console.WriteLine($"Ok!");
               risposta2Valida = false;
            }
            else
            {
               Console.WriteLine("Non hai risposto alla domanda");
               Console.WriteLine("Rispondi: s o n");


            }
         }
      }
   }
   static void EliminaLeggi(string risposta7)
   {


      if (risposta7 == "s")
      {
         Console.WriteLine($"OK!");
         Console.WriteLine("Cosa vuoi fare? (l/e)");


      }
      else if (risposta7 == "n")
      {

         Console.WriteLine("Grazie alla prossima!");
         Environment.Exit(0);
      }
      else
      {
         Console.WriteLine("Non hai risposto alla domanda");
         Console.WriteLine("Riprova");

      }
   }
}
>>>>>>> 3fe19f888c9e61e734c5afd9cf0f9b341c116bc7



                     string console = Console.ReadLine()!;
                     Console.Clear();


                     switch (console)
                     {
                        case "Playstation 5":
                           Console.WriteLine("Hai selezionato Playstation 5");
                           InformazioneValida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { console }) + ",\n");

                           break;
                        case "Xbox":
                           Console.WriteLine("Hai selezionato Xbox");
                           InformazioneValida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { console }) + ",\n");

                           break;
                        case "Nintendo Switch":
                           Console.WriteLine("Hai selezionato Nintendo Switch");
                           InformazioneValida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { console }) + ",\n");

                           break;
                        case "PC":
                           Console.WriteLine("Hai selezionato PC");
                           InformazioneValida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { console }) + ",\n");

                           break;
                        case "Smartphone":
                           Console.WriteLine("Hai selezionato smartphone");
                           InformazioneValida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { console }) + ",\n");

                           break;
                        default:
                           Console.WriteLine("Selezione non valida");
                           Console.WriteLine($"Riprova");

                           break;
                     }
                  }
                  File.AppendAllText(percorso, "\n");
                  //rispostaValida = false;



                  //informazione riguardo il genere
                  Console.WriteLine("Domanda 2: A che genere appartiene il videogioco?");
                  bool Informazione2Valida = true;
                  while (Informazione2Valida)
                  {
                     Console.WriteLine("Sparatutto");
                     Thread.Sleep(200);
                     Console.WriteLine("Picchiaduro");
                     Thread.Sleep(200);
                     Console.WriteLine("Giochi di ruolo");
                     Thread.Sleep(200);
                     Console.WriteLine("Giochi Platform");
                     Thread.Sleep(200);
                     Console.WriteLine("Racing");
                     Thread.Sleep(200);
                     Console.WriteLine("Giochi sportivi");
                     Thread.Sleep(200);
                     Console.WriteLine("Avventura");


<<<<<<< HEAD
                     string genere = Console.ReadLine()!;
                     Console.Clear();

                     switch (genere)
                     {
                        case "Sparatutto":
                           Console.WriteLine("è uno sparatutto");
                           Informazione2Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                           File.AppendAllText(percorso, "\n");
                           break;
                        case "Picchiaduro":
                           Console.WriteLine("è un picchiaduro");
                           Informazione2Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                           File.AppendAllText(percorso, "\n");
                           break;
                        case "Giochi di ruolo":
                           Console.WriteLine("è un gioco di ruolo");
                           Informazione2Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                           File.AppendAllText(percorso, "\n");
                           break;
                        case "Giochi Platform":
                           Console.WriteLine("è un gioco platform");
                           Informazione2Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                           File.AppendAllText(percorso, "\n");
                           break;
                        case "Racing":
                           Console.WriteLine("è un racing game");
                           Informazione2Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                           File.AppendAllText(percorso, "\n");
                           break;
                        case "Giochi Sportivi":
                           Console.WriteLine("è un gioco sportivo");
                           Informazione2Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                           File.AppendAllText(percorso, "\n");
                           break;
                        case "Avventura":
                           Console.WriteLine("è un gioco di avventura");
                           Informazione2Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                           File.AppendAllText(percorso, "\n");
                           break;
                        default:
                           Console.WriteLine("Selezione non valida");
                           Console.WriteLine("Riprova");

                           break;

                     }
                  }

                  Console.WriteLine("Domanda 3: Livello di difficoltà?");
                  bool Informazione3Valida = true;
                  while (Informazione3Valida)
                  {
                     Console.WriteLine("Facile");
                     Thread.Sleep(200);
                     Console.WriteLine("Medio");
                     Thread.Sleep(200);
                     Console.WriteLine("Difficile");
                     string difficoltà = Console.ReadLine()!;
                     Console.Clear();
                     switch (difficoltà)
                     {
                        case "Facile":
                           Console.WriteLine("Hai selezionato Facile");
                           Informazione3Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { difficoltà }) + ",\n");
                           break;
                        case "Medio":
                           Console.WriteLine("Hai selezionato Medio");
                           Informazione3Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { difficoltà }) + ",\n");
                           break;
                        case "Difficile":
                           Console.WriteLine("Hai selezionato Difficile");
                           Informazione3Valida = false;
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { difficoltà }) + ",\n");
                           break;
                        default:
                           Console.WriteLine("Selezione non valida");
                           File.AppendAllText(percorso, JsonConvert.SerializeObject(new { difficoltà }) + ",\n");
                           break;

                     }
                  }

               }
               else if (risposta == "n")
               {
                  Console.WriteLine("Come preferisci...");
                  rispostaValida = false;
               }
               else
               {
                  Console.WriteLine("Non hai risposto alla domanda...");
                  Console.WriteLine("Riprova");
               }
               rispostaValida = false;
            }

            Console.WriteLine("Vuoi aggiungere una recensione personale? (s/n)");

            bool risposta1Valida = true;
            while (risposta1Valida)
            {


               string risposta1 = Console.ReadLine()!;
               Console.Clear();
               if (risposta1 == "s")
               {
                  string recensione = Console.ReadLine()!;
                  Console.Clear();
                  File.AppendAllText(percorso, JsonConvert.SerializeObject(new { recensione }));
                  File.AppendAllText(percorso, "\n");
                  risposta1Valida = false;
               }
               else if (risposta1 == "n")
               {
                  Console.WriteLine("Ok, proseguiamo");
                  risposta1Valida = false;

               }
               else
               {
                  Console.WriteLine("Non hai risposto alla domanda...");
                  Console.WriteLine("Riprova");
               }
            }
            string file = File.ReadAllText(percorso);
            file = file.Remove(file.Length - 2, 1); //vado indietro di due caratteri e ne tolgo 1
            File.WriteAllText(percorso, file);
            File.AppendAllText(percorso, "]"); //scrive l ariga nel file
         }
         else
         {
            Console.WriteLine("Il file è già esistente");


         }
         Console.WriteLine($"Vuoi inserire un altro videogioco? (s/n)");
         bool risposta2Valida = true;
         while (risposta2Valida)
         {
            string risposta2 = Console.ReadLine()!;
            Console.Clear();
            if (risposta2 == "n")
            {

               Console.WriteLine("Vuoi vedere tutti i giochi che hai inserito o eliminarne qualcuno? (s/n)");
               bool risposta4Valida = true;
               while (risposta4Valida)
               {
                  string risposta4 = Console.ReadLine()!;
                  Console.Clear();
                  if (risposta4 == "s")
                  {
                     //bool risposta4Valida = true;

                     Console.WriteLine("Vuoi leggere o eliminare un file? (l/e)");
                     bool risposta5Valida = true;
                     while (risposta5Valida)
                     {
                        string risposta5 = Console.ReadLine()!;
                        Console.Clear();
                        if (risposta5 == "l")
                        {



                           files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*json"); //legge tutti i file json nella cartella del programma
                           if (files.Any())
                           {
                              foreach (string file in files)
                              {
                                 Console.WriteLine(Path.GetFileName(file)); //stampa il nome del file

                              }

                              Console.WriteLine("quale file vuoi leggere?");
                              string fileScelto = Console.ReadLine()!; //legge il nome del file scelto
                              if (File.Exists(fileScelto)) //controlla se il file esiste
                              {
                                 string[] lines = File.ReadAllLines(fileScelto); //legge tutte le righe del file
                                 foreach (string line in lines)
                                 {
                                    Console.WriteLine(line); //stampa la riga

                                 }
                                 risposta5Valida = false;
                              }
                              else
                              {
                                 Console.WriteLine("Questo file non esiste");

                              }

                           }
                           else
                           {
                              Console.WriteLine("Non ci sono file da eliminare");
                           }

                        }
                        else if (risposta5 == "e")
                        {
                           // bool Elimina = true;
                           //while (Elimina)
                           // {
                           files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*json"); //legge tutti i file json nella cartella del programma
                           if (files.Any())
                           {
                              foreach (string file in files)
                              {
                                 Console.WriteLine(Path.GetFileName(file)); //stampa il nome del file

                              }

                              //if (!FileExists(file))
                              Console.WriteLine("quale file vuoi eliminare?");
                              string fileScelto = Console.ReadLine()!;

                              if (File.Exists(fileScelto))
                              {
                                 File.Delete(fileScelto); //elimina il file
                                 Console.Clear();
                                 Console.WriteLine("File eliminato con successo");
                                 risposta5Valida = false;
                              }
                              else
                              {
                                 Console.WriteLine("Questo file non esiste");
                                 //Console.WriteLine("Cosa vuoi fare? (l/e)");
                              }
                           }
                           else
                           {
                              Console.WriteLine("Non ci sono file da eliminare");
                           }

                        }
                        else
                        {
                           Console.WriteLine("Non hai risposto alla domanda");
                           Console.WriteLine("Riprova");


                        }

                        Console.WriteLine("Vuoi fare altro? (s/n)");
                        string risposta7 = Console.ReadLine()!;
                        EliminaLeggi(risposta7);
                        
                     }


                  }
                  else if (risposta4 == "n")
                  {
                     Console.WriteLine("Grazie, Alla prossima!");

                     return;
                  }
                  else
                  {
                     Console.WriteLine("Non hai risposto alla domanda");
                     Console.WriteLine("Riprova: rispondi s o n");


                  }

               }
            }
            else if (risposta2 == "s")
            {
               Console.WriteLine($"Ok!");
               risposta2Valida = false;
            }
            else
            {
               Console.WriteLine("Non hai risposto alla domanda");
               Console.WriteLine("Rispondi: s o n");


            }
         }
      }
   }
   static void EliminaLeggi(string risposta7)
   {
      if (risposta7 == "s")
      {
         Console.WriteLine($"OK!");
         Console.WriteLine("Cosa vuoi fare? (l/e)");


      }
      else if (risposta7 == "n")
      {

         Console.WriteLine("Grazie alla prossima!");
         Environment.Exit(0);
      }
      else
      {
         Console.WriteLine("Non hai risposto alla domanda");
         Console.WriteLine("Riprova");

      }
   }
}
=======




>>>>>>> 3fe19f888c9e61e734c5afd9cf0f9b341c116bc7
