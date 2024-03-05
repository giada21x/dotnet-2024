class Macchina //dichiarazione della classe macchina
{
    private string marca;
    private string modello;
    private int anno;

    public Macchina(string marca, string modello, int anno) //il costruttore della classe macchina crea una macchina
    {
        this.marca = marca;
        this.modello = modello;
        this.anno = anno;
    }

    public void Stampa() //il metodo Stampa della classe Macchina stampa i campi della macchina
    {
        Console.WriteLine($"Marca: {marca}");
        Console.WriteLine($"Modello: {modello}");
        Console.WriteLine($"Anno: {anno}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Macchina m = new Macchina("Fiat", "Panda", 2010); //il risultato è che il metodo stampa
        m.Stampa();
    }
}
