# DATABASE VIDEOGIOCHI:

Creare un programma che permetta all'utente di inserire una serie di videogiochi giocati durante l'anno con le relative informazioni (nome,genere anno di uscita...) aggiundendo un voto e una brevissima recensione. Lo scopo del programma è quello di salvare le informazioni in un file json in modo tale che, una volta finito, si possa avere una chiara valutazione sui determinati videogiochi e magari decretare quale sia il migliore.

### DEFINIZIONE REQUISITI E ANALISI:
- [X] L'applicazione permette di creare un file csv
- [X] L'applicazione permette di inserire il nome, il genere, l'anno di uscita, il voto e una brevissima recensione di un videogioco.
- [X] L'applicazione permette di creare un file json
- [X] L'applicazione permette di serializzare le risposte nel file json
- [X] L'applicazione permette all'utente di rispondere a delle semplici domande rigurado il videogioco (livello di dificoltà, su quale console ha giocato) 
- [X] L'applicazione permette di chiedere all'utente se vuole inserire le informazioni di un nuovo videogioco
- [X] L'applicazione permette di verificare se sono già stati inseriti i dati di un videogioco (in modo tale da non avere ripetizioni o doppioni)


### PIANIFICAZIONE E DESIGN DELL'ARCHITETTURA
- [X] L'applicazione deve permettere all'utente di scrivere i dati di un videogioco in un file csv
- [X] L'applicazione deve memorizzare i dati di ogni singolo videogioco in un file json

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
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        
        string path = @"videogiochi.csv";
        File.Create(path).Close();

        Console.WriteLine("Benvenuto/a!");


        while (true)
        {
            
            Console.WriteLine("Inserisci il titolo del videogioco");
            string nome = Console.ReadLine()!;
            Console.Clear();
            Console.WriteLine("Inserisci l'anno di uscita del videogioco");
            string anno = Console.ReadLine()!;
            Console.Clear();
            Console.WriteLine("Assegna un voto");
            int voto = int.Parse(Console.ReadLine()!);
            Console.Clear();

            File.AppendAllText(path, nome + "," + anno + "," + voto + "," + "\n");//scrive la riga nel file

            string[] lines = File.ReadAllLines(path);
            string[][] videogiochi = new string[lines.Length][]; //crea un array di array
            for (int i = 0; i < lines.Length; i++)
            {
                videogiochi[i] = lines[i].Split(",");
            }
            for (int i = 0; i < videogiochi.Length; i++)
            {
                string path2 = videogiochi[i][0] + ".json";

                if (!File.Exists(path2)) //controlla se il file esiste
                {
                    File.Create(path2).Close();
                    
                    File.AppendAllText(path2, JsonConvert.SerializeObject(new { nome = videogiochi[i][0],  anno = videogiochi[i][1], voto = videogiochi[i][2] }));
                    File.AppendAllText(path2, "\n");

                    Console.WriteLine($"Vuoi darci più informazioni riguardo al videogioco (s/n)");
                    string risposta3 = Console.ReadLine()!;
                    if (risposta3 == "s")
                    {
                        Console.Clear();
                        Console.WriteLine("Domanda 1: Su che console hai giocato?");

                        Console.WriteLine("1.Playstation 5");
                        Thread.Sleep(200);
                        Console.WriteLine("2.Xbox");
                        Thread.Sleep(200);
                        Console.WriteLine("3.Nintendo Switch");
                        Thread.Sleep(200);
                        Console.WriteLine("4.PC");
                        Thread.Sleep(200);
                        Console.WriteLine("5.Smartphone");

                        string console = Console.ReadLine()!;

                        switch (console)
                        {
                            case "Playstation 5":
                                Console.WriteLine("Hai giocato sulla Playstation 5");
                                break;
                            case "Xbox":
                                Console.WriteLine("Hai giocato sull'Xbox");
                                break;
                            case "Nintendo Switch":
                                Console.WriteLine("Hai giocato sulla Nintendo Switch");
                                break;
                            case "PC":
                                Console.WriteLine("Hai giocato sul PC");
                                break;
                            case "smartphone":
                                Console.WriteLine("hai giocato sullo smartphone");
                                break;
                        }

                        Console.Clear();

                        File.AppendAllText(path2, JsonConvert.SerializeObject(new { console }));
                        File.AppendAllText(path2, "\n");

                        Console.WriteLine("");
                        Console.WriteLine("Domanda 2: A che genere appartiene il videogioco?");

                        Console.WriteLine("1.Sparatutto");
                        Thread.Sleep(200);
                        Console.WriteLine("2.Picchiaduro");
                        Thread.Sleep(200);
                        Console.WriteLine("3.Giochi di ruolo");
                        Thread.Sleep(200);
                        Console.WriteLine("4.Giochi Platform");
                        Thread.Sleep(200);
                        Console.WriteLine("5.Racing");
                        Thread.Sleep(200);
                        Console.WriteLine("6.Giochi sportivi");
                        Thread.Sleep(200);
                        Console.WriteLine("7.Avventura");


                        string genere = Console.ReadLine()!;

                        switch (genere)
                        {
                            case "Sparatutto":
                                Console.WriteLine("è uno sparatutto");
                                break;
                            case "Picchiaduro":
                                Console.WriteLine("è un picchiaduro");
                                break;
                            case "Gioco di ruolo":
                                Console.WriteLine("è un gioco di ruolo");
                                break;
                            case "Gioco Platform":
                                Console.WriteLine("è un gioco platform");
                                break;
                            case "Racing Game":
                                Console.WriteLine("è un racing game");
                                break;
                            case "Gioco Sportivo":
                                Console.WriteLine("è un gioco sportivo");
                                break;
                            case "Gioco di Avventura":
                                Console.WriteLine("è un gioco di avventura");
                                break;
                        }
                        Console.Clear();
                        File.AppendAllText(path2, JsonConvert.SerializeObject(new { genere }));
                        File.AppendAllText(path2, "\n");

                        Console.WriteLine("Domanda 3: Livello di difficoltà?");
                        Console.WriteLine("1. Facile");
                        Thread.Sleep(200);
                        Console.WriteLine("2. Medio");
                        Thread.Sleep(200);
                        Console.WriteLine("3. Difficile");
                        string difficoltà = Console.ReadLine()!;
                        switch (difficoltà)
                        {
                            case "Facile":
                                Console.WriteLine("Facile");
                                break;
                            case "Medio":
                                Console.WriteLine("Medio");
                                break;
                            case "Difficile":
                                Console.WriteLine("Difficile");
                                break;
                        }

                        Console.Clear();
                        File.AppendAllText(path2, JsonConvert.SerializeObject(new { difficoltà }));
                        File.AppendAllText(path2, "\n");

                    }
                    Console.WriteLine("Vuoi aggiungere una recensione personale? (s/n)");
                    string risposta2 = Console.ReadLine()!;
                    Console.Clear();

                    if (risposta2 == "s")
                    {
                        string recensione = Console.ReadLine()!;
                        Console.Clear();
                        File.AppendAllText(path2, JsonConvert.SerializeObject(new { recensione }));
                        File.AppendAllText(path2, "\n");
                    }
                    
                }

                else
                {


                }
            }
            Console.WriteLine("Grazie per il tuo feedback!");

            Console.WriteLine($"Vuoi inserire un altro videogioco? (s/n)");
            string risposta = Console.ReadLine()!;
            if (risposta == "n")
            {
                Console.WriteLine("Grazie! Alla prossima");
                
                break;
            }
        }

    }
}

```

```json 
//da sistemare
{"nome":"re4","anno":"2023","voto":"9"},

{"console":"PC"},

{"genere":"Sparatutto"}
{"difficoltà":"Difficile"}
```

```csv
re4,2023,9,
```