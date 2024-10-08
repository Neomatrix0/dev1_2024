using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

public class ProdottiController : Controller
{
    private readonly string prodottiFilePath = "wwwroot/json/prodotti.json"; // Path del file prodotti
    private readonly string categorieFilePath = "wwwroot/json/categorie.json"; // Path del file categorie
private readonly ILogger<ProdottiController> _logger; 
    // Metodo per leggere i prodotti dal file JSON

      public ProdottiController(ILogger<ProdottiController> logger)
    {
        _logger = logger;
    }
    private List<Prodotto> LeggiProdottiDaJson()
    {
        var jsonData = System.IO.File.ReadAllText(prodottiFilePath);
        return JsonConvert.DeserializeObject<List<Prodotto>>(jsonData) ?? new List<Prodotto>();
    }

    // Metodo per salvare i prodotti nel file JSON
  private void SalvaProdottiSuJson(List<Prodotto> prodotti)
{
    try
    {
        var jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        System.IO.File.WriteAllText(prodottiFilePath, jsonData);
        _logger.LogInformation("Product list successfully written to JSON.");
    }
    catch (Exception ex)
    {
        _logger.LogError("Error writing to JSON file: {Message}", ex.Message);
    }
}





    // Metodo per leggere le categorie dal file JSON
   /* private List<string> LeggiCategorieDaJson()
    {
        var jsonData = System.IO.File.ReadAllText(categorieFilePath);
        return JsonConvert.DeserializeObject<List<string>>(jsonData) ?? new List<string>();
    }*/

    private List<string> LeggiCategorieDaJson()
{
    try
    {
        var jsonData = System.IO.File.ReadAllText(categorieFilePath);
        _logger.LogInformation("Categorie JSON loaded: " + jsonData); // Log the JSON data
        return JsonConvert.DeserializeObject<List<string>>(jsonData) ?? new List<string>();
    }
    catch (Exception ex)
    {
        _logger.LogError("Error reading categorie.json: " + ex.Message);
        return new List<string>(); // Return an empty list if there's an error
    }
}  






    // Action per visualizzare la lista dei prodotti con filtro prezzo e paginazione
    public IActionResult Index(int? minPrezzo, int? maxPrezzo, int pageIndex = 1)
    {
        var prodotti = LeggiProdottiDaJson();

        // Filtro per prezzo minimo e massimo
        if (minPrezzo.HasValue)
        {
            prodotti = prodotti.Where(p => p.Prezzo >= minPrezzo.Value).ToList();
        }
        if (maxPrezzo.HasValue)
        {
            prodotti = prodotti.Where(p => p.Prezzo <= maxPrezzo.Value).ToList();
        }

        // Paginazione
        int numeroProdottiPerPagina = 10;
        var prodottiPaginati = prodotti.Skip((pageIndex - 1) * numeroProdottiPerPagina).Take(numeroProdottiPerPagina);

        var viewModel = new ProdottiViewModel
        {
            Prodotti = prodottiPaginati,
            MinPrezzo = minPrezzo ?? 0,
            MaxPrezzo = maxPrezzo ?? prodotti.Max(p => p.Prezzo),
            NumeroPagine = (int)Math.Ceiling((double)prodotti.Count() / numeroProdottiPerPagina)
        };

        // Specifica la vista "Prodotti"
        return View("Prodotti", viewModel);
    }

    // Visualizza i dettagli di un prodotto
    public IActionResult ProdottoDettaglio(int id)
    {
        var prodotti = LeggiProdottiDaJson();
        var prodotto = prodotti.Find(p => p.Id == id);

        if (prodotto == null)
        {
            return NotFound();
        }

        return View(prodotto);
    }

 public IActionResult AggiungiProdotto()
{
    var viewModel = new AggiungiProdottoViewModel
    {
        Prodotto = new Prodotto(),
        Categorie = LeggiCategorieDaJson() // Carica le categorie dal file JSON o altra fonte
    };

    return View(viewModel);
}

[HttpPost]
public IActionResult AggiungiProdotto(AggiungiProdottoViewModel viewModel)
{
    _logger.LogInformation("Valore della categoria: " + viewModel.Prodotto.Categoria);
     if (!ModelState.IsValid)
    {
        // Log degli errori di validazione
        foreach (var modelState in ModelState.Values)
        {
            foreach (var error in modelState.Errors)
            {
                _logger.LogError(error.ErrorMessage);
            }
        }

        var prodotti = LeggiProdottiDaJson();
        viewModel.Prodotto.Id = prodotti.Count > 0 ? prodotti.Max(p => p.Id) + 1 : 1;

        // Logica di salvataggio
        prodotti.Add(viewModel.Prodotto);
        SalvaProdottiSuJson(prodotti);

        return RedirectToAction("Index");
    }

    // In caso di errore, ricarica le categorie e ritorna la vista
    viewModel.Categorie = LeggiCategorieDaJson();
    return View(viewModel);
}

    // Azione GET per visualizzare il form di modifica del prodotto
    public IActionResult ModificaProdotto(int id)
    {
        var prodotti = LeggiProdottiDaJson();
        var prodotto = prodotti.Find(p => p.Id == id);

        if (prodotto == null)
        {
            return NotFound();
        }

        var viewModel = new ModificaProdottoViewModel
        {
            Prodotto = prodotto,
            Categorie = LeggiCategorieDaJson()
        };

        return View(viewModel);
    }

  [HttpPost]
public IActionResult ModificaProdotto(Prodotto prodottoAggiornato)
{
    _logger.LogInformation("Attempting to modify product with ID: {Id}", prodottoAggiornato.Id);

    if (ModelState.IsValid)
    {
        var prodotti = LeggiProdottiDaJson();
        var prodotto = prodotti.Find(p => p.Id == prodottoAggiornato.Id);

        if (prodotto != null)
        {
            _logger.LogInformation("Product found, updating product details.");

            prodotto.Nome = prodottoAggiornato.Nome;
            prodotto.Prezzo = prodottoAggiornato.Prezzo;
            prodotto.Dettaglio = prodottoAggiornato.Dettaglio;
            prodotto.Immagine = prodottoAggiornato.Immagine;
            prodotto.Quantita = prodottoAggiornato.Quantita;
            prodotto.Categoria = prodottoAggiornato.Categoria;

            SalvaProdottiSuJson(prodotti); // Save the modified products list
            _logger.LogInformation("Product updated successfully and saved to JSON.");
        }
        else
        {
            _logger.LogWarning("Product with ID {Id} not found.", prodottoAggiornato.Id);
        }

        return RedirectToAction("Index");
    }

    _logger.LogWarning("Model state is invalid. Returning to view with errors.");
    var viewModel = new ModificaProdottoViewModel
    {
        Prodotto = prodottoAggiornato,
        Categorie = LeggiCategorieDaJson()
    };

    return View(viewModel);
}



    // Azione GET per visualizzare la conferma della cancellazione di un prodotto
    public IActionResult CancellaProdotto(int id)
    {
        var prodotti = LeggiProdottiDaJson();
        var prodotto = prodotti.Find(p => p.Id == id);

        if (prodotto == null)
        {
            return NotFound();
        }

        return View(prodotto);
    }

    // Azione POST per confermare la cancellazione del prodotto
    [HttpPost, ActionName("CancellaProdotto")]
    public IActionResult ConfermaCancellazione(int id)
    {
        var prodotti = LeggiProdottiDaJson();
        var prodotto = prodotti.Find(p => p.Id == id);

        if (prodotto != null)
        {
            prodotti.Remove(prodotto); // Rimuovi il prodotto dalla lista
            SalvaProdottiSuJson(prodotti); // Salva il file JSON aggiornato
        }

        return RedirectToAction("Index");
    }
}
