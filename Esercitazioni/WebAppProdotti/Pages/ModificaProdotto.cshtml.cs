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
     public List<string> Categorie { get; set; }

    public ModificaProdottoModel(ILogger<ModificaProdottoModel> logger)
    {
        _logger = logger;
    }

    public Prodotto Prodotto { get; set; }

    public void OnGet(int id)
    {
        // Carica tutti i prodotti dal file JSON
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        var categoriejson = System.IO.File.ReadAllText("wwwroot/json/categorie.json");
        Categorie = JsonConvert.DeserializeObject<List<string>>(categoriejson);

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

    public IActionResult OnPost(int id, string nome, decimal prezzo, string dettaglio, string immagine,int quantita,string categoria)
    {
        // Carica tutti i prodotti dal file JSON
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

        // Trova il prodotto con l'ID corrispondente e aggiorna le proprietà
        foreach (var prodotto in tuttiProdotti)
        {
            if (prodotto.Id == id)
            {
                prodotto.Nome = nome;
                prodotto.Prezzo = prezzo;
                prodotto.Dettaglio = dettaglio;
                prodotto.Immagine = immagine;
                prodotto.Quantita = quantita;
                prodotto.Categoria = categoria;
                break;
            }
        }

        // Salva il file JSON aggiornato
        System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(tuttiProdotti, Formatting.Indented));

        // Reindirizza alla pagina dei prodotti dopo il salvataggio
        return RedirectToPage("/Prodotti");
    }
}
