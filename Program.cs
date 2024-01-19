//genere numeri tra 1 e 10 e ci chiede di indovinar eil numero //se lo indovina dice indovintao e se non lo indovina dice sbahliato
//10 tentativi


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Inserisci un numero:");

        Random random = new Random(); //generatore di numeri casuali 
        int numero = int.Parse(Console.ReadLine()!);
        int numeroRandom = random.Next(1, 10);
        int tentativi = 10;

        
            
            while (tentativi != 0)
            {

                
                if (numero == numeroRandom)
                {
                    Console.WriteLine("Hai indovinato!");
                    Console.WriteLine($"Il numero casuale è {numeroRandom}");
                    return;
                }
                else
                {
                    Console.WriteLine($"Non hai indovinato!");
                    tentativi-- ; //tentativi = tentativi -1
                    Console.WriteLine($"Hai ancora {tentativi}");
                    if (numeroRandom < numero)
                    {
                        Console.WriteLine("Suggerimento: prova a inserire un numero più piccolo...");
                        
                    }
                    else if (numeroRandom > numero)
                    {
                        Console.WriteLine("Suggerimento: prova a inserire un numero più grande...");
                        
                    }
                    else if (numeroRandom % 2 == 0 )
                    {
                        Console.WriteLine($"Suggerimento: Il numero da indovinare è pari");
                        
                    }


                
                    Console.WriteLine("Inserisci un nuovo numero");
                    
                    numero = int.Parse(Console.ReadLine()!);
                }
            }
        

    }
}





