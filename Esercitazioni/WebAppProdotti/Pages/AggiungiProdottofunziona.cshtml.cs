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