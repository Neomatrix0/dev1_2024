using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;


public class ProdottiController : Controller
{


    private readonly ILogger<ProdottiController> _logger;
    private readonly ProdottiService _prodottiService;

    // Costruttore che riceve sia il logger che il servizio ProdottiService
    public ProdottiController(ILogger<ProdottiController> logger, ProdottiService prodottiService)
    {
        _logger = logger;
        _prodottiService = prodottiService;
    }

    public IActionResult Index(int? minPrezzo, int? maxPrezzo, int pageIndex = 1)
    {
        // Filtra i prodotti in base ai valori di prezzo minimo e massimo
        var prodottiFiltrati = _prodottiService.FiltraProdotti(minPrezzo, maxPrezzo);
        // Definisce quanti prodotti visualizzare per pagina
        int numeroProdottiPerPagina = 6;
        // Esegue la paginazione dei prodotti filtrati
        var prodottiPaginati = _prodottiService.PaginazioneProdotti(prodottiFiltrati, pageIndex, numeroProdottiPerPagina);
        // Crea il ViewModel per passare i prodotti e i parametri di paginazione alla vista
        var viewModel = new ProdottiViewModel
        {
            Prodotti = prodottiPaginati,
            MinPrezzo = minPrezzo ?? 0,
            MaxPrezzo = maxPrezzo ?? prodottiFiltrati.Max(p => p.Prezzo),
            NumeroPagine = (int)Math.Ceiling((double)prodottiFiltrati.Count / numeroProdottiPerPagina)
        };

        return View("Prodotti", viewModel);
    }



    // Action per visualizzare i dettagli di un singolo prodotto
    public IActionResult ProdottoDettaglio(int id)
    {
        //  Usa il metodo Find per cercare il prodotto corrispondente all'ID specificato nella lista di prodotti
        var prodotti = _prodottiService.LeggiProdottiDaJson();
        //La lambda p => p.Id == id è una funzione anonima che riceve un parametro p che rappresenta un prodotto e restituisce true se l'ID del prodotto corrisponde all'ID cercato altrimenti restituisce false
        var prodotto = prodotti.Find(p => p.Id == id);

        // ritorna errore se il prodotto non esiste
        if (prodotto == null)
        {
            return NotFound();
        }
        // se il prodtto non è null ritorna la view con i dettagli del prodotto
        return View(prodotto);
    }

    // Action per visualizzare il form di aggiunta prodotto (GET)
     [Authorize(Roles = "Admin")] // Solo gli utenti con ruolo "Admin" possono accedere
    public IActionResult AggiungiProdotto()
    {
        // Crea un ViewModel che include un nuovo prodotto e la lista delle categorie da caricare dal json
        var viewModel = new AggiungiProdottoViewModel
        {
            // Oggetto prodotto vuoto da popolare con i dati del form
            Prodotto = new Prodotto(),
            // Carica la lista delle categorie dal file categorie.json
            Categorie = _prodottiService.LeggiCategorieDaJson() // Carica le categorie dal file JSON 
        };

        return View(viewModel);
    }



    [HttpPost]
       [Authorize(Roles = "Admin")]
    public IActionResult AggiungiProdotto(AggiungiProdottoViewModel viewModel)
    {
        // Logga il valore della categoria selezionata nel form
        _logger.LogInformation("Valore della categoria: " + viewModel.Prodotto.Categoria);

        // Se il ModelState non è valido (errore di validazione)logga errori
        if (!ModelState.IsValid)
        {
            // Cicla attraverso gli errori di validazione nel ModelState e logga ogni errore
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }
            }


        }

        // Se il ModelState è valido, si procede a caricare la lista dei prodotti dal file JSON
        var prodotti = _prodottiService.LeggiProdottiDaJson();

        // Genera un nuovo ID per il prodotto: se esistono già dei prodotti imposta l'ID al massimo attuale +1, altrimenti lo imposta a 1
        viewModel.Prodotto.Id = prodotti.Count > 0 ? prodotti.Max(p => p.Id) + 1 : 1;

        // Logica di salvataggio
        prodotti.Add(viewModel.Prodotto);
        _prodottiService.SalvaProdottiSuJson(prodotti);

        return RedirectToAction("Index");  // Redirige alla lista dei prodotti dopo l'aggiunta
    }


    // Azione GET per visualizzare il form di modifica del prodotto
    [Authorize(Roles = "Admin")]
    public IActionResult ModificaProdotto(int id)
    {
        var prodotti = _prodottiService.LeggiProdottiDaJson();

        // Cerca il prodotto specifico utilizzando l'ID fornito

        // Il metodo FirstOrDefault() itera attraverso la lista prodotti.
        // Per ogni elemento p nella lista controlla se la proprietà Id del prodotto (p.Id) corrisponde all'ID specificato (id)
        // Appena trova un prodotto che soddisfa questa condizione lo restituisce
        // Se nessun prodotto nella lista ha un ID uguale a id il metodo restituisce null
        var prodotto = prodotti.FirstOrDefault(p => p.Id == id);

        if (prodotto == null)
        {
            return NotFound(); // Restituisce un errore se il prodotto non esiste
        }
        // Crea un nuovo oggetto ModificaProdottoViewModel che include il prodotto  e le categorie da selezionare
        var viewModel = new ModificaProdottoViewModel
        {
            Prodotto = prodotto,
            Categorie = _prodottiService.LeggiCategorieDaJson()

        };

        return View(viewModel);
    }


    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult ModificaProdotto(ModificaProdottoViewModel viewModel)
    {
        // Logga la categoria selezionata nel form per trovare degli errori
        _logger.LogInformation("Categoria selezionata: " + viewModel.Prodotto.Categoria);
        // Logga il prezzo ricevuto nel form di modifica per test
        _logger.LogInformation("Prezzo ricevuto: " + viewModel.Prodotto.Prezzo);



        // Legge i prodotti dal file JSON

        var prodotti = _prodottiService.LeggiProdottiDaJson();

        // Trova il prodotto da modificare in base all'ID fornito dal viewModel
        //Quindi  cerca nel file JSON il prodotto con lo stesso ID di quello inviato dal form di modifica 
        // (rappresentato da viewModel.Prodotto.Id). Se trova una corrispondenza restituisce il prodotto altrimenti restituisce null.
        var prodottoDaModificare = prodotti.FirstOrDefault(p => p.Id == viewModel.Prodotto.Id);

        if (prodottoDaModificare != null)
        {
            _logger.LogInformation("Modifica del prodotto con ID: {Id}", viewModel.Prodotto.Id);

            // Aggiorna le proprietà del prodotto con i nuovi valori immessi nel form di modifica
            prodottoDaModificare.Nome = viewModel.Prodotto.Nome;
            prodottoDaModificare.Prezzo = viewModel.Prodotto.Prezzo;
            prodottoDaModificare.Dettaglio = viewModel.Prodotto.Dettaglio;
            prodottoDaModificare.Immagine = viewModel.Prodotto.Immagine;
            prodottoDaModificare.Quantita = viewModel.Prodotto.Quantita;
            prodottoDaModificare.Categoria = viewModel.Prodotto.Categoria;

            // Salva i prodotti aggiornati nel json
            _prodottiService.SalvaProdottiSuJson(prodotti);

            _logger.LogInformation("Prodotto con ID: {Id} modificato con successo.", viewModel.Prodotto.Id);

            // Reindirizza l'utente all'azione Index (lista dei prodotti) dopo la modifica
            return RedirectToAction("Index");
        }

        // Se il prodotto non esiste, restituisce 404
        _logger.LogWarning("Prodotto con ID: {Id} non trovato.", viewModel.Prodotto.Id);
        return NotFound();
    }




    // Azione GET per visualizzare la conferma della cancellazione di un prodotto
   // Il parametro "id" rappresenta l'ID del prodotto da cancellare
   [Authorize(Roles = "Admin")]
    public IActionResult CancellaProdotto(int id)
    {
        // Chiama il servizio per cercare il prodotto corrispondente all'ID passato
        var prodotto = _prodottiService.TrovaProdottoPerId(id);

        if (prodotto == null)
        {
            return NotFound();
        }

        // Se il prodotto viene trovato visualizza una vista di conferma cancellazione
    // mostrando i dettagli del prodotto che si sta cercando di cancellare
        return View(prodotto);
    }

    // Azione POST per confermare la cancellazione del prodotto
    // [ActionName("CancellaProdotto")] specifica che questo metodo deve essere associato all'azione "CancellaProdotto"
    [HttpPost, ActionName("CancellaProdotto")]

    [Authorize(Roles = "Admin")]
    public IActionResult ConfermaCancellazione(int id)
    {
        // Chiama il servizio per eseguire la cancellazione del prodotto corrispondente all'ID passato
        _prodottiService.CancellaProdotto(id);
        return RedirectToAction("Index");
    }
}
