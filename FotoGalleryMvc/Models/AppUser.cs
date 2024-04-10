using Microsoft.AspNetCore.Identity;
namespace FotoGalleryMvc.Data;
public class AppUser : IdentityUser
{
   
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public bool Stato { get; set; }
}