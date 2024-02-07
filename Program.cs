using Newtonsoft.Json;

class Program
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
            Console.WriteLine("Inserisci breve recensione");
            string recensione = Console.ReadLine()!;
            File.AppendAllText(path, nome + "," + genere + "," + anno + "," + voto + "," + recensione + "\n");//scrive la riga nel file

            string[] lines = File.ReadAllLines(path);
            string[][] videogiochi = new string[lines.Length][]; //crea un array di array
            for (int i = 0; i < lines.Length; i++)
            {
                videogiochi[i] = lines[i].Split(",");
            }
            for (int i = 0; i < videogiochi.Length; i++)
            {
                string path2 = videogiochi[i][0] + ".json";
                string path3 = videogiochi[i][1] + ".json";
                if (!File.Exists(path2)) //controlla se il file esiste
                {
                    File.Create(path2).Close();
                    File.AppendAllText(path2, JsonConvert.SerializeObject(new { nome = videogiochi[i][0], genere = videogiochi[i][1], anno = videogiochi[i][2], voto = videogiochi[i][3], recensione = videogiochi[i][4] }));

                }
                else
                {
                    Console.WriteLine($"Hai già inserito questo videogioco");

                }
                File.Create(path3).Close();
                File.AppendAllText(path3, JsonConvert.SerializeObject(new { nome = videogiochi[i][0]}));
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

