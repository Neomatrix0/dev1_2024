using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

    public class ModificaProdottoModel : PageModel
    {
        private readonly ILogger<ModificaProdottoModel> _logger;

        public ModificaProdottoModel(ILogger<ModificaProdottoModel> logger)
        {
            _logger = logger;
        }
public Prodotto Prodotto { get; set; }
        public void OnGet(int Id)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
            var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
            foreach(var prodotto in tuttiProdotti){
                if(prodotto.Id == Id){
                    Prodotto = prodotto;
                    break;
                }
            }
        }

public IActionResult OnPost(int id, string nome,decimal prezzo,string dettaglio,string immagine )
        
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
            var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
            Prodotto prodotto =null;

             foreach(var p in tuttiProdotti){
                if(p.Id == id){
                    Prodotto = p;
                    break;
                }
            }
            prodotto.Nome =nome;
            prodotto.Prezzo =prezzo;
            prodotto.Dettaglio =dettaglio;
            prodotto.Immagine =immagine;
 System.IO.File.WriteAllText("wwwroot/json/prodotti.json",JsonConvert.SerializeObject(tuttiProdotti, Formatting.Indented));
            return RedirectToPage("Prodotti");
        }
    }
