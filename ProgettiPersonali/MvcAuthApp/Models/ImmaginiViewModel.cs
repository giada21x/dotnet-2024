namespace MvcAuthApp.Models;


     public class ImmaginiViewModel
    {
        public int NumeroPagine { get; set; }
        public string Categoria { get; set; }
        public int? PageIndex { get; set; }
        public IEnumerable<Immagine> Immagini { get; set; }
        public List<string> Categorie { get; set; }

        // public IndexViewModel()
        // {
        //     Immagini = new List<Immagine>();
        //     Categorie = new List<string>();
        // }
    

    public string jsonPath = @"wwwroot/json/immagini.json";
    public string jsonPath3 = @"wwwroot/json/categorie.json";

    
}
