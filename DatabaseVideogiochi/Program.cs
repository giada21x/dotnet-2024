using System.Runtime.CompilerServices;
using Newtonsoft.Json;

class P
{
    static void Main(string[] args)
    {
        string path = @"videogiochi.csv";
        File.Create(path).Close();

        while (true)
        {
            Console.WriteLine("Inserisci nome");
            string nome = Console.ReadLine()!;

            Console.WriteLine("Inserisci genere");
            string genere = Console.ReadLine()!;
            Console.WriteLine("Inserisci anno di uscita");
            string anno = Console.ReadLine()!;
            Console.WriteLine("Inserisci voto");
            int voto = int.Parse(Console.ReadLine()!);

            File.AppendAllText(path, nome + "," + genere + "," + anno + "," + voto + "," + "\n");//scrive la riga nel file

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
                    File.AppendAllText(path2, JsonConvert.SerializeObject(new { nome = videogiochi[i][0], genere = videogiochi[i][1], anno = videogiochi[i][2], voto = videogiochi[i][3] } ));
                    File.AppendAllText(path2, "\n");
                    Console.WriteLine("Vuoi aggiungere una recensione personale? (s/n)");
                    string risposta2 = Console.ReadLine()!;

                    if (risposta2 == "s")
                    {
                        string recensione = Console.ReadLine()!;
                        File.AppendAllText(path2, JsonConvert.SerializeObject(new { recensione }));
                        File.AppendAllText(path2, "\n");
                    }
                    Console.WriteLine($"Vuoi accedere al menù del questionario? (s/n)");
                    string risposta3 = Console.ReadLine()!;
                    if (risposta3 == "s")
                    {
                        Console.WriteLine("1.Personaggio preferito");
                        Console.WriteLine("2.Arma preferita");
                        Console.WriteLine("3.Livello di difficoltà");
                        Console.WriteLine("4.Punti di forza");
                        Console.WriteLine("5.Punti deboli");
                        
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        string opzione = key.KeyChar.ToString();
                        
                        
                        
                        switch (opzione)
                        {
                            case "1":
                            string risposta1 = Console.ReadLine()!;
                            Console.WriteLine("1.Link");
                            Console.WriteLine("2.Zelda");
                            Console.WriteLine("3.Ganondorf");
                            Console.WriteLine("4.Raul");
                            Console.WriteLine("5.");
                            
                            
                            
                            
                            
                            switch (risposta1)
                            {
                                case "1":
                                Console.WriteLine("Link");
                                break;
                                case "2":
                                Console.WriteLine("Zelda");
                                break;
                                
                                

                                

                            }
                            break;
                            //case "2":
                            //string ArmaPreferita

                            

                        }
                        
                        
                        
                        
                        
                    }
                    
                    
                    



                    string scelta = Console.ReadLine()!;

                    switch (scelta)
                    {

                    }
                }
                else
                {
                    Console.WriteLine($"Hai già inserito questo videogioco");

                }



                Console.WriteLine($"Vuoi inserire un altro videogioco? (s/n)");
                string risposta = Console.ReadLine()!;
                if (risposta == "n")
                {
                    break;

                }
            }



        }
    }
}


