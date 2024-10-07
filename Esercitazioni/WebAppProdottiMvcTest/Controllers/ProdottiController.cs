using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class ProdottiController : Controller
{
    private readonly string prodottiFilePath = "wwwroot/json/prodotti.json"; // Path del file prodotti
    private readonly string categorieFilePath = "wwwroot/json/categorie.json"; // Path del file categorie

    // Metodo per leggere i prodotti dal file JSON
    private List<Prodotto> LeggiProdottiDaJson()
    {
        var jsonData = System.IO.File.ReadAllText(prodottiFilePath);
        return JsonConvert.DeserializeObject<List<Prodotto>>(jsonData) ?? new List<Prodotto>();
    }

    // Metodo per salvare i prodotti nel file JSON
    private void SalvaProdottiSuJson(List<Prodotto> prodotti)
    {
        var jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        System.IO.File.WriteAllText(prodottiFilePath, jsonData);
    }

    // Metodo per leggere le categorie dal file JSON
    private List<string> LeggiCategorieDaJson()
    {
        var jsonData = System.IO.File.ReadAllText(categorieFilePath);
        return JsonConvert.DeserializeObject<List<string>>(jsonData) ?? new List<string>();
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

    // Action GET per mostrare il form
    public IActionResult AggiungiProdotto()
    {
        var viewModel = new AggiungiProdottoViewModel
        {
            Prodotto = new Prodotto(),
            Categorie = LeggiCategorieDaJson()
        };

        return View(viewModel);
    }

    // Action POST per processare il form
    [HttpPost]
    public IActionResult AggiungiProdotto(AggiungiProdottoViewModel viewModel)
    {
        if (viewModel.Codice != "1234") // Verifica del codice di sicurezza
        {
            ModelState.AddModelError("Codice", "Codice non valido.");
        }

        if (ModelState.IsValid)
        {
            var prodotti = LeggiProdottiDaJson();
            viewModel.Prodotto.Id = prodotti.Count > 0 ? prodotti.Max(p => p.Id) + 1 : 1;

            // Se l'immagine non è specificata, usa un'immagine di default
            if (string.IsNullOrWhiteSpace(viewModel.Prodotto.Immagine))
            {
                viewModel.Prodotto.Immagine = "img/default.jpg";
            }

            prodotti.Add(viewModel.Prodotto);
            SalvaProdottiSuJson(prodotti);

            return RedirectToAction("Index");
        }

        // Ricarica le categorie in caso di errore
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

    // Azione POST per salvare le modifiche al prodotto
    [HttpPost]
    public IActionResult ModificaProdotto(Prodotto prodottoAggiornato)
    {
        if (ModelState.IsValid)
        {
            var prodotti = LeggiProdottiDaJson();
            var prodotto = prodotti.Find(p => p.Id == prodottoAggiornato.Id);

            if (prodotto != null)
            {
                prodotto.Nome = prodottoAggiornato.Nome;
                prodotto.Prezzo = prodottoAggiornato.Prezzo;
                prodotto.Dettaglio = prodottoAggiornato.Dettaglio;
                prodotto.Immagine = prodottoAggiornato.Immagine;
                prodotto.Quantita = prodottoAggiornato.Quantita;
                prodotto.Categoria = prodottoAggiornato.Categoria;

                SalvaProdottiSuJson(prodotti); // Salva le modifiche nel file JSON
            }

            return RedirectToAction("Index");
        }

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
