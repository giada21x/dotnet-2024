
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;




Console.WriteLine("Benvenuto/a!");

string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*json"); //legge tutti i file csv nella cartella del programma
if (File.Exists("*json"))


{
    foreach (string file in files)
    {
        Console.WriteLine($"Sono già presenti questi file");
        
        Console.WriteLine(Path.GetFileName(file)); //stampa il nome del file

    }
}
else 
{
    Console.WriteLine("Non sono ancora presenti videogiochi");
    
}




while (true)
{
    bool nomeValido = true;
    Console.WriteLine("Inserisci il titolo del videogioco");
    string nome = null;
    while (nomeValido)
    {
        nome = Console.ReadLine()!;

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
    string percorso = $"{nomeVideogioco}" + ".json";
    if (!File.Exists(percorso))
    {
        File.Create(percorso).Close();



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


        File.AppendAllText(percorso, "[\n");
        File.AppendAllText(percorso, JsonConvert.SerializeObject(new { nome, anno, voto }) + ",\n");
        File.AppendAllText(percorso, "\n");



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

                        File.AppendAllText(percorso, JsonConvert.SerializeObject(new { console }) + ",\n");

                        break;
                    case "Xbox":
                        Console.WriteLine("Hai selezionato Xbox");

                        File.AppendAllText(percorso, JsonConvert.SerializeObject(new { console }) + ",\n");

                        break;
                    case "Nintendo Switch":
                        Console.WriteLine("Hai selezionato Nintendo Switch");

                        File.AppendAllText(percorso, JsonConvert.SerializeObject(new { console }) + ",\n");

                        break;
                    case "PC":
                        Console.WriteLine("Hai selezionato PC");

                        File.AppendAllText(percorso, JsonConvert.SerializeObject(new { console }) + ",\n");

                        break;
                    case "Smartphone":
                        Console.WriteLine("Hai selezionato smartphone");

                        File.AppendAllText(percorso, JsonConvert.SerializeObject(new { console }) + ",\n");

                        break;
                    default:
                        Console.WriteLine("Selezione non valida");
                        break;
                }



                //File.AppendAllText(path2, JsonConvert.SerializeObject(new { console }) + ",\n");
                File.AppendAllText(percorso, "\n");
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
                        File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                        File.AppendAllText(percorso, "\n");
                        break;
                    case "Picchiaduro":
                        Console.WriteLine("è un picchiaduro");
                        File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                        File.AppendAllText(percorso, "\n");
                        break;
                    case "Giochi di ruolo":
                        Console.WriteLine("è un gioco di ruolo");
                        File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                        File.AppendAllText(percorso, "\n");
                        break;
                    case "Giochi Platform":
                        Console.WriteLine("è un gioco platform");
                        File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                        File.AppendAllText(percorso, "\n");
                        break;
                    case "Racing":
                        Console.WriteLine("è un racing game");
                        File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                        File.AppendAllText(percorso, "\n");
                        break;
                    case "Giochi Sportivi":
                        Console.WriteLine("è un gioco sportivo");
                        File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                        File.AppendAllText(percorso, "\n");
                        break;
                    case "Avventura":
                        Console.WriteLine("è un gioco di avventura");
                        File.AppendAllText(percorso, JsonConvert.SerializeObject(new { genere }) + ",\n");
                        File.AppendAllText(percorso, "\n");
                        break;
                    default:
                        Console.WriteLine("Selezione non valida");
                        break;

                }

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
                        File.AppendAllText(percorso, JsonConvert.SerializeObject(new { difficoltà }) + "\n");
                        break;
                    case "Medio":
                        Console.WriteLine("Hai selezionato Medio");
                        File.AppendAllText(percorso, JsonConvert.SerializeObject(new { difficoltà }) + "\n");
                        break;
                    case "Difficile":
                        Console.WriteLine("Hai selezionato Difficile");
                        File.AppendAllText(percorso, JsonConvert.SerializeObject(new { difficoltà }) + "\n");
                        break;
                    default:
                        Console.WriteLine("Selezione non valida");
                        File.AppendAllText(percorso, JsonConvert.SerializeObject(new { difficoltà }) + "\n");
                        break;

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
        File.AppendAllText(percorso, "]"); Console.WriteLine("Grazie per il tuo feedback!");

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

        if (risposta2 == "n")
        {

            Console.WriteLine("Vuoi vedere tutti i giochi che hai inserito o eliminarne qualcuno? (s/n)");
            string risposta4 = Console.ReadLine()!;

            if (risposta4 == "s")
            {
                bool risposta4Valida = true;
                while (risposta4Valida)
                {
                    Console.WriteLine("Vuoi leggere o eliminare un file? (l/e)");
                    string risposta5 = Console.ReadLine()!;
                    if (risposta5 == "l")
                    {

                        files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*json"); //legge tutti i file csv nella cartella del programma
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

                        }
                    }
                    else if (risposta5 == "e")
                    {
                        files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*json"); //legge tutti i file csv nella cartella del programma
                        foreach (string file in files)
                        {
                            Console.WriteLine(Path.GetFileName(file)); //stampa il nome del file

                        }
                        Console.WriteLine("quale file vuoi eliminare?");
                        string fileScelto = Console.ReadLine()!;

                        if (File.Exists(fileScelto))
                        {
                            File.Delete(fileScelto); //elimina il file
                        }
                    }
                    Console.WriteLine("Vuoi fare altro? (s/n)");
                    risposta4 = Console.ReadLine()!;

                    if (risposta4 == "s")
                    {
                        risposta2Valida = false;
                    }
                    else if (risposta4 == "n")
                    {
                        Console.WriteLine("Grazie, Alla prossima!");

                        return;
                    }
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

        }
    }


}








