using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Mvc.RazorPages; 
using Newtonsoft.Json;  
 using WebAppPersone.Models;
 
namespace WebAppPersone.Pages; 
 
 
public class PersonaDettaglioModel : PageModel 
{ 
  public required Persona Persona {get; set;} 
  public void OnGet(int id) 
  { 
    var json = System.IO.File.ReadAllText("wwwroot/json/persone.json");  
    List<Persona> Persone = JsonConvert.DeserializeObject<List<Persona>>(json); 
    Persona = Persone.FirstOrDefault(p => p.Id == id); 
  } 
}