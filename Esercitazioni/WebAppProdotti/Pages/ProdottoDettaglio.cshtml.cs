using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;



    public class ProdottoDettaglioModel : PageModel
    {
        private readonly ILogger<ProdottoDettaglioModel> _logger;

        public ProdottoDettaglioModel(ILogger<ProdottoDettaglioModel> logger)
        {
            _logger = logger;
            logger.LogInformation("Prodotto Dettaglio caricato");
        }

        public Prodotto prodotto{ get; set; }
/*
        public void OnGet(int id,string nome,decimal prezzo,string dettaglio,string immagine)
        {
            prodotto = new Prodotto{Id =id,Nome = nome,Prezzo = prezzo,Dettaglio = dettaglio,Immagine =immagine};
        }  */

        public void OnGet(int id){
            var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
            var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
            foreach(var p in prodotti ){
                if(p.Id == id){
                    prodotto = p;  // se l'id del prodotto corrisponde a quello passato come parametro allora assegno il prodotto a Prodotto
                    break;  
                }
            }
        

        }
    }
