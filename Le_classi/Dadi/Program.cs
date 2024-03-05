//Creo la classe dado. La classe dado ha un metodo Lancia che restituisce un numero casuale compreso tra 1 e 6
class Dado 
{
    private Random random = new Random(); //Random è l'oggetto, new è il costruttore
    public int Lancia()
    {
        return random.Next(1, 7);
    }
}
