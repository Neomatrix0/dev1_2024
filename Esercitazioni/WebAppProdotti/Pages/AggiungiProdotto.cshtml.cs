
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using  Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


    public class AggiungiProdottoModel : PageModel
    {
        private readonly ILogger<AggiungiProdottoModel> _logger;

       [BindProperty]
       public Prodotto Prodotto{ get; set; }  // passo tutta istanza del prodotto

       [BindProperty]  //viene utilizzato per includere la propeità nella fase di model binding
       [Required(ErrorMessage = "Il campo codice è obbligatorio")]
       public string Codice{ get; set; }
      // [Required(ErrorMessage = "Il campo nome è obbligatorio")]
        
       
          public List<string> Categorie { get; set; }

        public AggiungiProdottoModel(ILogger<AggiungiProdottoModel> logger)
        {
            _logger = logger;
        }


       

// metodo che riceve i dati dal server
        public void OnGet(){
       // var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
      /*  var categoriejson = System.IO.File.ReadAllText("wwwroot/json/categorie.json");
        var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        Categorie = JsonConvert.DeserializeObject<List<string>>(categoriejson);*/

        var categoriejson = System.IO.File.ReadAllText("wwwroot/json/categorie.json");
    Categorie = JsonConvert.DeserializeObject<List<string>>(categoriejson);

    //    Categorie = new List<string> { "Elettronica", "Abbigliamento", "Libri", "Giocattoli", "Cucina" };
        
        }



//invia dati al server web
// i parametri vengono passati attraverso il form nella pagina web
        public IActionResult OnPost(){

 
            if(Codice != "1234"){
       
               return RedirectToPage("Error",new { message = "Codice non valido" });
            }  else{

            

          //   if(!ModelState.IsValid){
          //      return RedirectToPage("Error",new { message = "Codice non valido" });
          //  }  

            

            //carica i prodotti esistenti
             
            var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
            var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json) ?? new List<Prodotto>();
            //?? serve a inizializzare la lista se è null ed è un operatore ternario
            int id =1;
            if(tuttiProdotti.Count >0){
                id = tuttiProdotti[tuttiProdotti.Count-1].Id+1;
            }

           Prodotto.Id =id;

           if(Prodotto.Immagine == null){
            Prodotto.Immagine = "img/shoes.jpg";
           }

           tuttiProdotti.Add(Prodotto);
       /*     tuttiProdotti.Add(new Prodotto{
                Id =id,
                Nome = nome,
                Prezzo = prezzo,
                Dettaglio = dettaglio,
                Immagine =immagine,
                Quantita = quantita,
                Categoria=categoria
            }); */
            System.IO.File.WriteAllText("wwwroot/json/prodotti.json",JsonConvert.SerializeObject(tuttiProdotti, Formatting.Indented));
            return RedirectToPage("Prodotti");


        }
    }
    }

/*

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using  Newtonsoft.Json;


 public class AggiungiProdottoModel : PageModel
{
    private readonly ILogger<AggiungiProdottoModel> _logger;

    [BindProperty]  // Questa proprietà sarà legata al form
    public Prodotto Prodotto { get; set; }

    [BindProperty]
    public string Codice { get; set; }
     [BindProperty]

     public 
    
    public List<string> Categorie { get; set; }

    public AggiungiProdottoModel(ILogger<AggiungiProdottoModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var categoriejson = System.IO.File.ReadAllText("wwwroot/json/categorie.json");
        Categorie = JsonConvert.DeserializeObject<List<string>>(categoriejson);
    }

    public IActionResult OnPost()
    {
        if (Codice != "1234" || !ModelState.IsValid)
        {
            return Page(); // Ritorna alla pagina con eventuali errori di validazione
        }

        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        int id = 1;
        if (tuttiProdotti.Count > 0)
        {
            id = tuttiProdotti[tuttiProdotti.Count - 1].Id + 1;
        }

        Prodotto.Id = id;
        tuttiProdotti.Add(Prodotto);

        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(tuttiProdotti, Formatting.Indented));

        return RedirectToPage("Prodotti");
    }
}

*/