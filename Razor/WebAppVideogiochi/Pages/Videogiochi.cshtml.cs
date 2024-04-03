using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Mvc.RazorPages; 
using Newtonsoft.Json;  
using WebAppVideogiochi.Models;
namespace WebAppVideogiochi.Pages; 
public class VideogiochiModel : PageModel 
{ 
  public required IEnumerable<Videogioco> Videogiochi { get; set; } 
  public void OnGet() 
  { 
    var json = System.IO.File.ReadAllText("wwwroot/json/videogiochi.json");  
    Videogiochi = JsonConvert.DeserializeObject<List<Videogioco>>(json);  
  } 
}