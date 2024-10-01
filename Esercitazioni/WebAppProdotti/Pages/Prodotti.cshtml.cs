using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebAppProdotti.Pages
{
    public class ProdottiModel : PageModel
    {
        private readonly ILogger<ProdottiModel> _logger;

        public ProdottiModel(ILogger<ProdottiModel> logger)
        {
            _logger = logger;
            _logger.LogInformation("Prodotti Caricati");
        }

        // Proprietà per memorizzare l'elenco dei prodotti da visualizzare nella pagina
        public IEnumerable<Prodotto> Prodotti { get; set; } // lista prodotti
        public int numeroPagine { get; set; } // proprietà per il numero di pagine

        // Metodo OnGet eseguito quando la pagina viene richiesta tramite GET
        // minPrezzo e maxPrezzo sono parametri opzionali che filtrano i prodotti per prezzo
        public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)
        {
            try
            {
                // Carica i prodotti dal file JSON
                string jsonFilePath = "wwwroot/json/prodotti.json";
                var json = System.IO.File.ReadAllText(jsonFilePath);
                var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

                if (tuttiProdotti == null)
                {
                    Prodotti = new List<Prodotto>();
                    _logger.LogError("Prodotti non trovati nel file JSON.");
                    return;
                }

                // Dichiarazione della lista di prodotti filtrati
                var prodottiFiltrati = new List<Prodotto>();

                // Ciclo attraverso tutti i prodotti per applicare i filtri
                foreach (var prodotto in tuttiProdotti)
                {
                    bool aggiungi = true; // Variabile di controllo per determinare se il prodotto deve essere aggiunto

                    // Filtra per prezzo minimo se minPrezzo è specificato
                    if (minPrezzo.HasValue && prodotto.Prezzo < minPrezzo.Value)
                    {
                        aggiungi = false;
                    }

                    // Filtra per prezzo massimo se maxPrezzo è specificato
                    if (maxPrezzo.HasValue && prodotto.Prezzo > maxPrezzo.Value)
                    {
                        aggiungi = false;
                    }

                    // Se il prodotto soddisfa i criteri di filtro, aggiungilo alla lista
                    if (aggiungi)
                    {
                        prodottiFiltrati.Add(prodotto);
                    }
                }

                // Calcola il numero di pagine
                numeroPagine = (int)Math.Ceiling(prodottiFiltrati.Count() / 6.0);

                // Paginazione: prendi i prodotti per la pagina richiesta
                Prodotti = prodottiFiltrati.Skip(((pageIndex ?? 1) - 1) * 6).Take(6);
            }
            catch (FileNotFoundException)
            {
                _logger.LogError("File JSON non trovato.");
                Prodotti = new List<Prodotto>(); // Lista vuota in caso di errore
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errore durante il caricamento dei prodotti: {ex.Message}");
                Prodotti = new List<Prodotto>(); // Lista vuota in caso di errore
            }
        }
    }

   
    
}
