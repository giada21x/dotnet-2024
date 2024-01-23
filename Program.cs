//genere numeri tra 1 e 10 e ci chiede di indovinar eil numero //se lo indovina dice indovintao e se non lo indovina dice sbahliato
//10 tentativi


Console.WriteLine("INIZIO GIOCO!");
         Console.WriteLine($"Il punteggio massimo è 20 punti: perdi tot punti in base al suggerimento che sfrutti");
         
         Console.WriteLine("Inserisci un numero:");

         Random random = new Random(); //generatore di numeri casuali 
         int numero = int.Parse(Console.ReadLine()!);
         int numeroRandom = random.Next(1, 51);
         int tentativi = 0;
         int punteggio = 20;
         
         
         // punteggio in base al numero dei tentativi   //provare a implementare anche i punti derivanti dai casi

         while (true)
         {
            tentativi ++;
             //max punti: 20
            
            
            if (numero == numeroRandom)
            { 
               
               Console.WriteLine("HAI VINTO!");
               Console.WriteLine($"Il numero casuale è {numeroRandom}");
               Console.WriteLine($"Hai indovinato in {tentativi} tentativi");
               Console.WriteLine($"Il tuo punteggio è {punteggio}");
               
               return;


            }
            else
            {
                
               
               Console.WriteLine($"Non hai indovinato!");
               Console.WriteLine($"Vuoi usufruire di un suggerimento? (s/n)");

               string risposta = Console.ReadLine()!;
               if (risposta == "s")
               
               { 
               
               Console.WriteLine("Ecco i suggerimenti: quale preferisci?");
               Console.WriteLine("1. E' maggiore o minore?");
               Console.WriteLine("2. E' Pari o dispari?");
               Console.WriteLine("3. E' maggiore o minore di 25?");
               Console.WriteLine("4. Qual è il suo quadrato? ");

                ConsoleKeyInfo key = Console.ReadKey(true); //serve per nascondere il numero dell'opzione di scelta che andiamo a inserie manualmente nel terminale
               string scelta = key.KeyChar.ToString();
               switch (scelta)
               {
                  case "1":  //penalità suggerimento 1: -1 punti
                     if (numeroRandom < numero)
                     {
                        punteggio -= 1;
                        Console.WriteLine("Suggerimento: prova a inserire un numero più piccolo...");
                        Console.WriteLine($"Sei a {punteggio} punti");
                        
                     }
                     else
                     {
                        punteggio -= 1;
                        Console.WriteLine("Suggerimento: prova a inserire un numero più grande...");
                        Console.WriteLine($"Sei a {punteggio}");
                     }
                     //int penalità1 = puntiTentativo - 1;
                     
                     
                     break;
                  case "2": //penalità suggerimento 2: -3 punti
                     if (numeroRandom % 2 == 0)
                     {
                        punteggio -= 3;
                        Console.WriteLine("Suggerimento: Il numero da indovinare è pari");
                        Console.WriteLine($"Sei a {punteggio} punti");
                     }
                     else
                     {
                        punteggio -= 3;
                        Console.WriteLine("Suggerimento: Il numero da indovinare è pari");
                        Console.WriteLine($"Sei a {punteggio} punti");
                     }
                     break;
                  case "3": //penalità suggerimento 1: -4 punti
                     if (numeroRandom > 25)
                     {
                        punteggio -= 4;
                        Console.WriteLine("Suggerimento: Il numero è maggiore di 25 ");
                        Console.WriteLine($"Sei a {punteggio} punti");
                     }
                     else
                     {
                        punteggio -= 4;
                        Console.WriteLine("Suggerimento: Il numero è minore di 25 ");
                        Console.WriteLine($"Sei a {punteggio} punti");
                     }
                     break;
                  case "4": //penalità suggerimento 1: -5 punti
                     punteggio -= 5;
                     double risultato = Math.Pow(numeroRandom, 2);
                     Console.WriteLine($"Il quadrato è {risultato}");
                     Console.WriteLine($"Sei a {punteggio} punti");

                     break;


               }
               }
               else 
               {
                  Console.WriteLine($"Sei a {punteggio} punti");
                  
               }
               //Console.WriteLine($"Sei a {puntiTentativo}");

               
               
               Console.WriteLine("Inserisci un nuovo numero");
               numero = int.Parse(Console.ReadLine()!);

            }


            if (tentativi == 10 || punteggio == 0)
            {
               Console.WriteLine($" FINE! HAI PERSO!");
               Console.WriteLine($"Hai esaurito i tentativi");
               Console.WriteLine($"Il numero casuale era {numeroRandom}");
            }
         }





