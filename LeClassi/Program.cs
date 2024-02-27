class Persona //definizione della classe
{
    public string nome; //definiizione di un campo pubblico cioè accessibile dall'esterno
    public string cognome;
    public int eta;
}

class Program
{
    static void Main(string[] args)
    {
        Persona p = new Persona(); //creazione di un oggetto di tipo Persona tramite il costruttore di default (senza parametri)
        p.nome = "Mario"; //accesso ai campi pubblici dell'oggetto
        p.cognome = "Rossi";
        p.eta = 30;

        Console.WriteLine("Nome: "+ p.nome); // stampa dei campi dell'oggetto
        Console.WriteLine("Cognome: "+ p.cognome);
        Console.WriteLine("Età: "+ p.eta);
    }
}
