using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using FotoGalleryRazorId.Models;


namespace FotoGalleryRazorId.Pages
{
    public class CancellaImmagineModel : PageModel
    {
        private readonly string jsonPath = @"wwwroot/json/immagini.json";
        [BindProperty]
        public required Immagine Immagine { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost(int id)
        {
            var jsonFile = System.IO.File.ReadAllText(jsonPath);
            var immagini = JsonConvert.DeserializeObject<List<Immagine>>(jsonFile);

            if (immagini != null)
            {
                var immagineToRemove = immagini.FirstOrDefault(i => i.Id == id);
                if (immagineToRemove != null)
                {
                    immagini.Remove(immagineToRemove);
                    System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(immagini, Formatting.Indented));
                    return RedirectToPage("/Index");
                }
            }

            return RedirectToPage("/Index");
        }
    }
}
