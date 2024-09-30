using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;




    public class ProdottoDettaglioModel : PageModel
    {
        private readonly ILogger<ProdottoDettaglioModel> _logger;

        public ProdottoDettaglioModel(ILogger<ProdottoDettaglioModel> logger)
        {
            _logger = logger;
            logger.LogInformation("Prodotto Dettaglio caricato");
        }

        public Prodotto prodotto{ get; set; }

        public void OnGet(int id,string nome,decimal prezzo,string dettaglio,string immagine)
        {
            prodotto = new Prodotto{Id =id,Nome = nome,Prezzo = prezzo,Dettaglio = dettaglio,Immagine =immagine};
        }
    }
