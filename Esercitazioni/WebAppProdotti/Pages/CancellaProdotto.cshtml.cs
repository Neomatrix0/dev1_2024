/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

    public class CancellaProdottoModel : PageModel
    {
        private readonly ILogger<CancellaProdottoModel> _logger;

        public CancellaProdottoModel(ILogger<CancellaProdottoModel> logger)
        {
            _logger = logger;
        }
public CancellaProdottoModel Prodotto{ get; set; }
        public void OnGet(int id)
        {

              var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        // Trova il prodotto con l'ID corrispondente
        foreach (var prodotto in tuttiProdotti)
        {
            if (prodotto.Id == id)   // Se l'ID del prodotto corrente corrisponde all'ID cercato
            {
                Prodotto = prodotto; // Assegna il prodotto alla proprietà Prodotto del modello
                break;
            }
        }

        }
    
    public IActionResult OnPost(int id){
        
              var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        for(int i =0;i < tuttiProdotti.Count;i++){
            if(tuttiProdotti[i].Id == id){
                tuttiProdotti.RemoveAt(i);
                break;
            }
        }
System.IO.File.WriteAllText("wwwroot/json/prodotti.json",JsonConvert.SerializeObject(tuttiProdotti));
        return RedirectToPage("/Prodotti");

    }
    }
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public class CancellaProdottoModel : PageModel
{
    private readonly ILogger<CancellaProdottoModel> _logger;

    public CancellaProdottoModel(ILogger<CancellaProdottoModel> logger)
    {
        _logger = logger;
    }

    // Correzione: Prodotto è di tipo Prodotto, non CancellaProdottoModel
    public Prodotto Prodotto { get; set; }

    public void OnGet(int id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        // Trova il prodotto con l'ID corrispondente
        foreach (var prodotto in tuttiProdotti)
        {
            if (prodotto.Id == id)   // Se l'ID del prodotto corrente corrisponde all'ID cercato
            {
                Prodotto = prodotto; // Assegna il prodotto alla proprietà Prodotto del modello
                break;
            }
        }
    }

    public IActionResult OnPost(int id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        // Rimuovi il prodotto con l'ID corrispondente
        for (int i = 0; i < tuttiProdotti.Count; i++)
        {
            if (tuttiProdotti[i].Id == id)
            {
                tuttiProdotti.RemoveAt(i);
                break;
            }
        }

        // Salva le modifiche nel file JSON
        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(tuttiProdotti, Formatting.Indented));

        return RedirectToPage("/Prodotti");
    }
}
