public class Videogioco
{
    public int Id { get; set; }
    
    public string Titolo { get; set; }
    public int Anno { get; set; }
    
    public Genere Genere { get; set; }
    public Platform Platform { get; set; }
}