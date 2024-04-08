using Microsoft.AspNetCore.Identity;
public class AppUser : IdentityUser
{
    //Aggiungi qui le proprietà personalizzate per i fornitori 
    public string Nome { get; set; }
    public string CodiceFornitore  { get; set; }
    public bool StatoAttivo { get; set; }
}