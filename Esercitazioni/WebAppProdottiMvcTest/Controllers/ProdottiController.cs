using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json; // Assicurati di avere il pacchetto Newtonsoft.Json
 // Assicurati di usare il tuo namespace corretto



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

   /*     // Action per visualizzare la lista dei prodotti
        public IActionResult Index()
        {
            var prodotti = LeggiProdottiDaJson();
            return View(prodotti); // Passiamo la lista alla vista Index
        } */

        public IActionResult Index(int? minPrezzo, int? maxPrezzo, int pageIndex = 1)
{
    var prodotti = LeggiProdottiDaJson(); // Carica i prodotti da JSON

    // Filtro dei prodotti
    if (minPrezzo.HasValue)
    {
        prodotti = prodotti.Where(p => p.Prezzo >= minPrezzo.Value).ToList();
    }
    if (maxPrezzo.HasValue)
    {
        prodotti = prodotti.Where(p => p.Prezzo <= maxPrezzo.Value).ToList();
    }

    // Imposta la paginazione (logica paginazione semplificata)
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

public IActionResult ProdottoDettaglio(int id)
{
    var prodotti = LeggiProdottiDaJson(); // Carica i prodotti dal file JSON
    var prodotto = prodotti.Find(p => p.Id == id); // Trova il prodotto per ID
    
    if (prodotto == null)
    {
        return NotFound();
    }
    
    return View(prodotto); // Passa il prodotto alla vista
}


        // Visualizza il form per aggiungere un nuovo prodotto
        public IActionResult AggiungiProdotto()
        {
            ViewBag.Categorie = LeggiCategorieDaJson(); // Passa le categorie alla vista
            return View();
        }

        // Azione per processare l'inserimento di un nuovo prodotto
        [HttpPost]
        public IActionResult AggiungiProdotto(Prodotto nuovoProdotto)
        {
            if (ModelState.IsValid)
            {
                var prodotti = LeggiProdottiDaJson();
                nuovoProdotto.Id = prodotti.Max(p => p.Id) + 1; // Genera un nuovo ID
                prodotti.Add(nuovoProdotto);
                SalvaProdottiSuJson(prodotti); // Salva il nuovo prodotto nel file JSON
                return RedirectToAction("Index");
            }
            ViewBag.Categorie = LeggiCategorieDaJson(); // Ricarica le categorie in caso di errore
            return View(nuovoProdotto);
        }

        // Visualizza il form per modificare un prodotto esistente
        public IActionResult ModificaProdotto(int id)
        {
            var prodotti = LeggiProdottiDaJson();
            var prodotto = prodotti.Find(p => p.Id == id);
            if (prodotto == null)
            {
                return NotFound();
            }
            ViewBag.Categorie = LeggiCategorieDaJson(); // Passa le categorie alla vista
            return View(prodotto);
        }

        // Azione per processare la modifica di un prodotto
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
            ViewBag.Categorie = LeggiCategorieDaJson();
            return View(prodottoAggiornato);
        }

        // Visualizza i dettagli di un prodotto
 /*       public IActionResult ProdottoDettaglio(int id)
        {
            var prodotti = LeggiProdottiDaJson();
            var prodotto = prodotti.Find(p => p.Id == id);
            if (prodotto == null)
            {
                return NotFound();
            }
            return View(prodotto); // Passiamo il prodotto alla vista Dettagli
        } */

        // Visualizza il form per cancellare un prodotto
        public IActionResult CancellaProdotto(int id)
        {
            var prodotti = LeggiProdottiDaJson();
            var prodotto = prodotti.Find(p => p.Id == id);
            if (prodotto == null)
            {
                return NotFound();
            }
            return View(prodotto); // Conferma cancellazione
        }

        // Azione per processare la cancellazione di un prodotto
        [HttpPost, ActionName("CancellaProdotto")]
        public IActionResult ConfermaCancellazione(int id)
        {
            var prodotti = LeggiProdottiDaJson();
            var prodotto = prodotti.Find(p => p.Id == id);
            if (prodotto != null)
            {
                prodotti.Remove(prodotto); // Rimuove il prodotto dalla lista
                SalvaProdottiSuJson(prodotti); // Aggiorna il file JSON
            }
            return RedirectToAction("Index");
        }
    }

