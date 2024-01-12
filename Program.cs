//array di stringhe con tre nomi. cicliamo con foreach e se il nome è uguale a mario con metodo add aggiunge il nome ad una lista
class Program 
{
    static void Main(string[] args)
    {
        string[] nomi = ["Mario", "Luigi", "Giovanni"];
        
        //creare una lista di destinazione
        List<string> lista = new List<string>(); 
        //creare un ciclo che iteri sugli elementi dell'array
        foreach (string nome in nomi) 
        {
        //se il nome è uguale a 'Mario' con metodo add aggiunge il nome ad una lista
            if (nome == "Mario") 
            {
                lista.Add(nome);
            }
        } 
        //versioniamo e veifichiamo che 'Mario' sia stato aggiunto alla lista
        foreach (string nome in lista)
        {
            Console.WriteLine($"{nome}");
        }
     }
}
