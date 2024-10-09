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

    // Logger per registrare informazioni, avvisi ed errori
private readonly ILogger<ProdottiController> _logger; 
    
    // Costruttore che riceve il logger

      public ProdottiController(ILogger<ProdottiController> logger)
    {
        _logger = logger;
    }

        // Metodo per leggere i prodotti dal file JSON

    private List<Prodotto> LeggiProdottiDaJson()
    {
        // Legge il contenuto del file prodotti.json
        var jsonData = System.IO.File.ReadAllText(prodottiFilePath);
        // Deserializza il contenuto in una lista di oggetti Prodotto
        return JsonConvert.DeserializeObject<List<Prodotto>>(jsonData) ?? new List<Prodotto>();
    }

    // Metodo per salvare i prodotti nel file JSON
  private void SalvaProdottiSuJson(List<Prodotto> prodotti)
{
    try
    {
        // Serializza la lista di prodotti in formato JSON
        var jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        // Scrive il JSON nel file prodotti.json
        System.IO.File.WriteAllText(prodottiFilePath, jsonData);
        _logger.LogInformation("Product list successfully written to JSON.");
    }
    catch (Exception ex)
    {
        _logger.LogError("Error writing to JSON file: {Message}", ex.Message);
    }
}



    
   /* private List<string> LeggiCategorieDaJson()
    {
        var jsonData = System.IO.File.ReadAllText(categorieFilePath);
        return JsonConvert.DeserializeObject<List<string>>(jsonData) ?? new List<string>();
    }*/

    // Metodo per leggere le categorie dal file JSON

    private List<string> LeggiCategorieDaJson()
{
    try
    {
        var jsonData = System.IO.File.ReadAllText(categorieFilePath);
        _logger.LogInformation("Categorie JSON loaded: " + jsonData); // Log per il JSON data
        // Deserializza il JSON in una lista di stringhe (categorie)
        return JsonConvert.DeserializeObject<List<string>>(jsonData) ?? new List<string>();
    }
    catch (Exception ex)
    {
        _logger.LogError("Error reading categorie.json: " + ex.Message);
        return new List<string>(); // Ritorna una lista vuota se c'è un errore
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

        // Paginazione mostra 6 prodotti per pagina
        int numeroProdottiPerPagina = 6;
        var prodottiPaginati = prodotti.Skip((pageIndex - 1) * numeroProdottiPerPagina).Take(numeroProdottiPerPagina);

// Crea un ViewModel con i prodotti filtrati e i dettagli per la paginazione
        var viewModel = new ProdottiViewModel
        {
            Prodotti = prodottiPaginati,
            MinPrezzo = minPrezzo ?? 0,
            MaxPrezzo = maxPrezzo ?? prodotti.Max(p => p.Prezzo),
            NumeroPagine = (int)Math.Ceiling((double)prodotti.Count() / numeroProdottiPerPagina)
        };

        // Ritorna la vista "Prodotti" con il ViewModel
        return View("Prodotti", viewModel);
    }

    // Action per visualizzare i dettagli di un singolo prodotto
    public IActionResult ProdottoDettaglio(int id)
    {
        // Cerca il prodotto per ID nella lista di prodotti
        var prodotti = LeggiProdottiDaJson();
        var prodotto = prodotti.Find(p => p.Id == id);

        // ritorna errore se il prodotto non esiste
        if (prodotto == null)
        {
            return NotFound();
        }
        // Ritorna la view con i dettagli del prodotto
        return View(prodotto);
    }

// Action per visualizzare il form di aggiunta prodotto (GET)
 public IActionResult AggiungiProdotto()
{
     // Crea un ViewModel che include un nuovo prodotto e la lista delle categorie
    var viewModel = new AggiungiProdottoViewModel
    {
        Prodotto = new Prodotto(),
        Categorie = LeggiCategorieDaJson() // Carica le categorie dal file JSON 
    };

    return View(viewModel);
}

// Action per processare l'aggiunta di un nuovo prodotto (POST)

[HttpPost]
public IActionResult AggiungiProdotto(AggiungiProdottoViewModel viewModel)
{
    _logger.LogInformation("Valore della categoria: " + viewModel.Prodotto.Categoria);

    // Se il ModelState non è valido (errore di validazione)
     if (!ModelState.IsValid)
    {
        // Log che registra  errori di validazione
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

    // In caso di errore, ricarica le categorie e ritorna la view
    viewModel.Categorie = LeggiCategorieDaJson();
    return View(viewModel);
}

    // Azione GET per visualizzare il form di modifica del prodotto
    public IActionResult ModificaProdotto(int id)
{
    var prodotti = LeggiProdottiDaJson();
    var prodotto = prodotti.FirstOrDefault(p => p.Id == id); // trova il prodotto per ID

    if (prodotto == null)
    {
        return NotFound(); // Restituisce un errore se il prodotto non esiste
    }

    var viewModel = new ModificaProdottoViewModel
    {
        Prodotto = prodotto,
        Categorie = LeggiCategorieDaJson() 
      
    };

    return View(viewModel);
}


[HttpPost]
public IActionResult ModificaProdotto(ModificaProdottoViewModel viewModel)
{
    _logger.LogInformation("Categoria selezionata: " + viewModel.Prodotto.Categoria);
    _logger.LogInformation("Prezzo ricevuto: " + viewModel.Prodotto.Prezzo);

/*    if (!ModelState.IsValid)
    {
        // Log degli errori di validazione
        foreach (var modelState in ModelState.Values)
        {
            foreach (var error in modelState.Errors)
            {
                _logger.LogError(error.ErrorMessage);
            }
        }

        // In caso di errore, ricarica le categorie e ritorna la vista
        viewModel.Categorie = LeggiCategorieDaJson();  // Ricarica le categorie dal file JSON
        return View(viewModel);
    }
*/
    // Se il ModelState è valido (nessun errore), procedi con la modifica del prodotto
    var prodotti = LeggiProdottiDaJson();
    var prodottoDaModificare = prodotti.FirstOrDefault(p => p.Id == viewModel.Prodotto.Id);

    if (prodottoDaModificare != null)
    {
        _logger.LogInformation("Modifica del prodotto con ID: {Id}", viewModel.Prodotto.Id);

        // Aggiorna le proprietà del prodotto
        prodottoDaModificare.Nome = viewModel.Prodotto.Nome;
        prodottoDaModificare.Prezzo = viewModel.Prodotto.Prezzo;
        prodottoDaModificare.Dettaglio = viewModel.Prodotto.Dettaglio;
        prodottoDaModificare.Immagine = viewModel.Prodotto.Immagine;
        prodottoDaModificare.Quantita = viewModel.Prodotto.Quantita;
        prodottoDaModificare.Categoria = viewModel.Prodotto.Categoria;

        // Salva i prodotti aggiornati
        SalvaProdottiSuJson(prodotti);

        _logger.LogInformation("Prodotto con ID: {Id} modificato con successo.", viewModel.Prodotto.Id);

        // Reindirizza l'utente all'azione Index (lista dei prodotti) dopo la modifica
        return RedirectToAction("Index");
    }

    // Se il prodotto non esiste, restituisce 404
    _logger.LogWarning("Prodotto con ID: {Id} non trovato.", viewModel.Prodotto.Id);
    return NotFound();
}



// azione POST per inviare dati al server del metodo modificaprodotto
/*
[HttpPost]
public IActionResult ModificaProdotto(ModificaProdottoViewModel viewModel)
{
    // Log dell'informazione per tracciare la categoria selezionata dall'utente
    _logger.LogInformation("Categoria selezionata: " + viewModel.Prodotto.Categoria);

// Verifica se il modello è valido, controlla eventuali errori di validazione
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

       // Se ci sono errori ritorna la stessa vista per permettere all'utente di correggerli
        return View(viewModel);
    }

    // Se il ModelState è valido (nessun errore), procedi con la modifica del prodotto
    var prodotti = LeggiProdottiDaJson();
    var prodottoDaModificare = prodotti.FirstOrDefault(p => p.Id == viewModel.Prodotto.Id);
      // Trova il prodotto corrispondente all'ID passato dal viewModel

// Se il prodotto è stato trovato aggiorna le sue proprietà
    if (prodottoDaModificare != null)
    {
        _logger.LogInformation("Modifica del prodotto con ID: {Id}", viewModel.Prodotto.Id);

         // Aggiorna le proprietà del prodotto con i valori provenienti dal form di modifica
        prodottoDaModificare.Nome = viewModel.Prodotto.Nome;
        prodottoDaModificare.Prezzo = viewModel.Prodotto.Prezzo;
        prodottoDaModificare.Dettaglio = viewModel.Prodotto.Dettaglio;
        prodottoDaModificare.Immagine = viewModel.Prodotto.Immagine;
        prodottoDaModificare.Quantita = viewModel.Prodotto.Quantita;
        prodottoDaModificare.Categoria = viewModel.Prodotto.Categoria;

        // Salva i prodotti aggiornati
        SalvaProdottiSuJson(prodotti);

        _logger.LogInformation("Prodotto con ID: {Id} modificato con successo.", viewModel.Prodotto.Id);

         // Reindirizza l'utente all'azione Index (lista dei prodotti) dopo la modifica
        return RedirectToAction("Index");
    }
    
    _logger.LogWarning("Prodotto con ID: {Id} non trovato.", viewModel.Prodotto.Id);
    return NotFound(); // Se il prodotto non esiste, restituisce 404
}
*/




    // Azione GET per visualizzare la conferma della cancellazione di un prodotto
    public IActionResult CancellaProdotto(int id)
    {
        var prodotti = LeggiProdottiDaJson();
        var prodotto = prodotti.Find(p => p.Id == id); // Cerca il prodotto per ID

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
         // Trova il prodotto con l'ID specificato
        var prodotto = prodotti.Find(p => p.Id == id);

        if (prodotto != null)
        {
            prodotti.Remove(prodotto); // Rimuovi il prodotto dalla lista
            SalvaProdottiSuJson(prodotti); // Salva il file JSON aggiornato
        }

        return RedirectToAction("Index");
    }
}
