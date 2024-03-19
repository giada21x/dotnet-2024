namespace WebAppVideogiochi.Models;
public class Videogioco
{
    public int Id { get; set; }
    public string? Titolo { get; set; }
    public string? Anno { get; set; }
    public string Genere { get; set; }
    public string Immagine { get; set; }
}