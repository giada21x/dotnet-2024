# DATABASE VIDEOGIOCHI:

Creare un programma che permetta all'utente di inserire una serie di videogiochi giocati durante l'anno con le relative informazioni (nome,genere anno di uscita...) aggiundendo un voto e una brevissima recensione. Lo scopo del programma è quello di salvare le informazioni in un file json in modo tale che, una volta finito, si possa avere una chiara valutazione sui determinati videogiochi.

### DEFINIZIONE REQUISITI E ANALISI:

- [X] L'applicazione permette di inserire il nome, il genere, l'anno di uscita, il voto e una brevissima recensione di un videogioco.
- [X] L'applicazione permette di creare un file json
- [X] L'applicazione permette di serializzare le risposte nel file json
- [X] L'applicazione permette all'utente di rispondere a delle semplici domande rigurado il videogioco (livello di dificoltà, su quale console ha giocato) 
- [X] L'applicazione permette di chiedere all'utente se vuole inserire le informazioni di un nuovo videogioco
- [X] L'applicazione permette di verificare se sono già stati inseriti i dati di un videogioco (in modo tale da non avere ripetizioni o doppioni)


### PIANIFICAZIONE E DESIGN DELL'ARCHITETTURA

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
<summary>Raccolta feedback</summary>
<details>

<summary> Feedback di Alessando </summary>


> ECCEZIONI


- [x] se ad "assegna un voto" inserisco una lettera mi genera:
     Unhandled exception. System.FormatException: The input string 'g' was not in a correct format.
   at System.Number.ThrowFormatException[TChar](ReadOnlySpan`1 value)
   at System.Int32.Parse(String s)
   at Program.Main(String[] args) in C:\Users\DOTNET\Documents\Corso-Dotnet-2024\CORSO-DOTNET-2024\esercitazioni-dotnet-2024\esercitazione1\Program.cs:line 25


> BUG

- [x] ad "assegna un voto" sarebbe bene specificare all'utente se da 1 a 10 o cosa, altrimenti potrei anche mettere 90 come voto ad es..

- [x] "inserisci l'anno di uscita" assicurati che non si possano scrivere cose che non siano degli int, e anni che non siano superiori all'anno corrente o minori di un certo anno
(al momento se inserisco una lettera o 3000 ad es, lo prende e va avanti)

- [x] a "Vuoi inserire un altro videogioco?" se invece che s o n premo un altra lettera la prende come fosse una s e riparte a chiedermi le info per il nuovo videogioco da inserire

- [x] Dopo aver inserito il primo videogioco se premo s mi chiede le info per il secondo videogioco ma poi non mi permette + di inserire una recensione
(questo però solo se metto info sbagliate, tipo mettendo 2 a ogni domanda. se le info sono giuste invece da nuovamente la possibilita di inserire una recensione) 
(a volte lo fa anche alla prima se ad esempio inserisco sempre 2 a tutto, si ferma dopo "assegna un voto")
(penso il problema sia che se esiste già un json con quel nome del videogioco si ferma dopo "assegna un voto")

- [x] Se inserisco come titolo del videogioco un nome che è già presente come file json non viene aggiunta la mia recensione al json (ad es, se il json del gioco con titolo "2" è {"nome":"2","anno":"2","voto":"2"}, ora dando come titolo 2, anno 333 e voto 8, questo record non verrà aggiunto al file json, perciò attualmente se un gioco è gia stato recensito una volta poi le recensioni di altri utenti riguardanti quel gioco non vengono prese.)

- [x] A "Vuoi darci più informazioni riguardo al videogioco" e a "Vuoi aggiungere una recensione personale?" se inserisco qualsiasi cosa che non sia o s o n lo prendo come n (ad es se inserisco un numero..)

- [x] A "Vuoi darci più informazioni riguardo al videogioco" se premo s appaiono le varie opzioni da 1 a 5 e cosi via, ma se inserisco un opzione non valida, tipo 58, la prende comunque per buona e va avanti. Questo accade per tutte e 3 le domande a scelta multipla.


Miglioramenti

- [x] sarebbe figo vedere anche una classifica dei giochi con le recensioni migliori o dei giochi con maggiori recensioni

</details>
</details>

</details>

### CODICE
```c#


using System.Runtime.CompilerServices;
using Newtonsoft.Json;




Console.WriteLine("Benvenuto/a!");



while (true)
{

    Console.WriteLine("Inserisci il titolo del videogioco");
    string nome = Console.ReadLine()!;
    string nomeVideogioco = nome.Trim();
    nomeVideogioco = nomeVideogioco.Replace(" ", "-");
    string file = $"{nomeVideogioco}" + ".json";
    if (!File.Exists(file))
    {
        File.Create(file).Close();
    
   
    Console.Clear();

    Console.WriteLine("Assegna un voto da 1 a 10:");

    int voto = 0;
    int anno = 0;

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


    File.AppendAllText(file, "[\n");
    File.AppendAllText(file, JsonConvert.SerializeObject(new { nome, anno, voto }) + ",\n");
    File.AppendAllText(file, "\n");



    bool rispostaValida = true;
    Console.WriteLine($"Vuoi darci più informazioni riguardo al videogioco (s/n)");
    while (rispostaValida)
    {

        string risposta = Console.ReadLine()!;


        if (risposta == "s")
        {
            Console.Clear();

            Console.WriteLine("Domanda 1: Su che console hai giocato?");

            Console.WriteLine("Playstation 5");
            Thread.Sleep(200);
            Console.WriteLine("Xbox");
            Thread.Sleep(200);
            Console.WriteLine("Nintendo Switch");
            Thread.Sleep(200);
            Console.WriteLine("PC");
            Thread.Sleep(200);
            Console.WriteLine("Smartphone");

            string console = Console.ReadLine()!;
            Console.Clear();

            switch (console)
            {
                case "Playstation 5":
                    Console.WriteLine("Hai selezionato Playstation 5");

                    File.AppendAllText(file, JsonConvert.SerializeObject(new { console }) + ",\n");

                    break;
                case "Xbox":
                    Console.WriteLine("Hai selezionato Xbox");

                    File.AppendAllText(file, JsonConvert.SerializeObject(new { console }) + ",\n");

                    break;
                case "Nintendo Switch":
                    Console.WriteLine("Hai selezionato Nintendo Switch");

                    File.AppendAllText(file, JsonConvert.SerializeObject(new { console }) + ",\n");

                    break;
                case "PC":
                    Console.WriteLine("Hai selezionato PC");

                    File.AppendAllText(file, JsonConvert.SerializeObject(new { console }) + ",\n");

                    break;
                case "Smartphone":
                    Console.WriteLine("Hai selezionato smartphone");

                    File.AppendAllText(file, JsonConvert.SerializeObject(new { console }) + ",\n");

                    break;
                default:
                    Console.WriteLine("Selezione non valida");
                    break;
            }



            //File.AppendAllText(path2, JsonConvert.SerializeObject(new { console }) + ",\n");
            File.AppendAllText(file, "\n");
            rispostaValida = false;




            Console.WriteLine("Domanda 2: A che genere appartiene il videogioco?");

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
                    File.AppendAllText(file, JsonConvert.SerializeObject(new { genere })+ ",\n");
                    File.AppendAllText(file, "\n");
                    break;
                case "Picchiaduro":
                    Console.WriteLine("è un picchiaduro");
                    File.AppendAllText(file, JsonConvert.SerializeObject(new { genere })+ ",\n");
                    File.AppendAllText(file, "\n");
                    break;
                case "Giochi di ruolo":
                    Console.WriteLine("è un gioco di ruolo");
                    File.AppendAllText(file, JsonConvert.SerializeObject(new { genere })+ ",\n");
                    File.AppendAllText(file, "\n");
                    break;
                case "Giochi Platform":
                    Console.WriteLine("è un gioco platform");
                    File.AppendAllText(file, JsonConvert.SerializeObject(new { genere })+ ",\n");
                    File.AppendAllText(file, "\n");
                    break;
                case "Racing":
                    Console.WriteLine("è un racing game");
                    File.AppendAllText(file, JsonConvert.SerializeObject(new { genere })+ ",\n");
                    File.AppendAllText(file, "\n");
                    break;
                case "Giochi Sportivi":
                    Console.WriteLine("è un gioco sportivo");
                    File.AppendAllText(file, JsonConvert.SerializeObject(new { genere })+ ",\n");
                    File.AppendAllText(file, "\n");
                    break;
                case "Avventura":
                    Console.WriteLine("è un gioco di avventura");
                    File.AppendAllText(file, JsonConvert.SerializeObject(new { genere })+ ",\n");
                    File.AppendAllText(file, "\n");
                    break;
                default:
                    Console.WriteLine("Selezione non valida");
                    break;

            }

            //File.AppendAllText(path2, JsonConvert.SerializeObject(new { genere }));
            File.AppendAllText(file, "\n");




            Console.WriteLine("Domanda 3: Livello di difficoltà?");
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
                    File.AppendAllText(file, JsonConvert.SerializeObject(new { difficoltà })+ ",\n");
                    break;
                case "Medio":
                    Console.WriteLine("Hai selezionato Medio");
                    File.AppendAllText(file, JsonConvert.SerializeObject(new { difficoltà })+ ",\n");
                    break;
                case "Difficile":
                    Console.WriteLine("Hai selezionato Difficile");
                    File.AppendAllText(file, JsonConvert.SerializeObject(new { difficoltà })+ ",\n");
                    break;
                default:
                    Console.WriteLine("Selezione non valida");
                    File.AppendAllText(file, JsonConvert.SerializeObject(new { difficoltà })+ ",\n");
                    break;

            }


            //File.AppendAllText(path2, JsonConvert.SerializeObject(new { difficoltà }));
            File.AppendAllText(file, "\n");
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
    }




    Console.WriteLine("Vuoi aggiungere una recensione personale? (s/n)");
    string risposta1 = Console.ReadLine()!;
    bool risposta1Valida = true;
    while (risposta1Valida)
    {

        Console.Clear();

        if (risposta1 == "s")
        {
            string recensione = Console.ReadLine()!;
            Console.Clear();
            File.AppendAllText(file, JsonConvert.SerializeObject(new { recensione }));
            File.AppendAllText(file, "\n");
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
    File.AppendAllText(file, "]"); 
    Console.WriteLine("Grazie per il tuo feedback!");
    }

    else 
    {
        Console.WriteLine("Il file è già esistente");
        
    }
    bool risposta2Valida = true;
    Console.WriteLine($"Vuoi inserire un altro videogioco? (s/n)");
    while (risposta2Valida)
    {
        string risposta2 = Console.ReadLine()!;

        if (risposta2 == "n")
        {
            Console.WriteLine("Grazie! Alla prossima");
            return;
        }
        else if (risposta2 == "s")
        {
            Console.WriteLine($"Ok!");
            risposta2Valida = false;
        }
        else
        {
            Console.WriteLine("Non hai risposto alla domanda");

        }
    }

}













```

```json 
[
{"nome":"re4","anno":"2023","voto":"9"},

{"console":"PC"},

{"genere":"Sparatutto"}
{"difficoltà":"Difficile"}
]
```

```csv
re4,2023,9,
```