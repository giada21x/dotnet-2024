using System.ComponentModel.DataAnnotations;
using FotoGalleryMvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FotoGalleryMvc.Models;

public class ModificaRuoloViewModel
{
    //attibuti per le view GET
    
   public string UserId { get; set; }
    public List<string> Roles { get; set; }
    public string RuoloAttuale { get; set; }
    public string UserName { get; set; }
}