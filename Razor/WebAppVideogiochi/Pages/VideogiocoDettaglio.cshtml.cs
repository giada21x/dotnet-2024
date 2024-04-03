using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Mvc.RazorPages; 
using Newtonsoft.Json;  
 using WebAppVideogiochi.Models;
 
namespace WebAppVideogiochi.Pages; 
 
 
public class VideogiocoDettaglioModel : PageModel 
{ 
  public required Videogioco Videogioco {get; set;} 
  public void OnGet(int id) 
  { 
    var json = System.IO.File.ReadAllText("wwwroot/json/videogiochi.json");  
    List<Videogioco> Videogiochi = JsonConvert.DeserializeObject<List<Videogioco>>(json); 
    Videogioco = Videogiochi.FirstOrDefault(p => p.Id == id); 
  } 
}