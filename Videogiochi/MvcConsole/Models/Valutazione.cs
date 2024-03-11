public class Valutazione
{
    public int Id { get; set; }
    
    public Videogioco Videogioco { get; set; }
    public Utente Utente { get; set; }
    public int Voto { get; set; }
    
}