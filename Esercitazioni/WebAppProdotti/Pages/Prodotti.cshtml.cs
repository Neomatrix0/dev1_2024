using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppProdotti.Pages;

public class ProdottiModel : PageModel
{
    private readonly ILogger<ProdottiModel> _logger;

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
        _logger.LogInformation("Prodotti Caricati");
    }

        // Proprietà per memorizzare l'elenco dei prodotti da visualizzare nella pagina
    public IEnumerable<Prodotto> Prodotti { get; set; } 

// Metodo OnGet eseguito quando la pagina viene richiesta tramite GET
// minPrezzo e maxPrezzo sono parametri opzionali che filtrano i prodotti per prezzo
    public void OnGet(decimal? minPrezzo,decimal? maxPrezzo)  // aggiunta di argomenti per filtrare i prodotti per prezzo 
    {
        //var allProdotti = new List<Prodotto>
        var tuttiProdotti   = new List<Prodotto>
        {
            new Prodotto {Id =1, Nome = "prodotto 1", Prezzo = 100,Immagine = "img/shoes.jpg",Dettaglio ="Dettaglio1" },
            new Prodotto {Id =2, Nome = "prodotto 2", Prezzo = 200,Immagine = "img/img2.webp",Dettaglio ="Dettaglio2" },
            new Prodotto {Id =3, Nome = "prodotto 3", Prezzo = 300,Immagine = "img/apple.jpg",Dettaglio ="Dettaglio3" },
        };

        /*

        

        var prodottiFiltrati = new List<Prodotto>();

        foreach(var prodotto in allProdotti){
        bool aggiungi = true;
        
        }
        if(minPrezzo.HasValue){
        if(prodotto.Prezzo < minPrezzo.Value){
        aggiungi =false;
        }
        }

        if(maxPrezzo.HasValue){
        if(prodotto.Prezzo > maxprezzo.Value){
        aggiungi = false
        }
        }

        if(aggiungi){
        prodottiFiltrati.Add(prodotto);})
        }
        }
        Prodotti = prodottiFiltrati;
    } */

     // viene assegnata a una copia di riferimento della lista tuttiProdotti
     //Creando la variabile prodottiFiltrati, possiamo modificare l'elenco dei prodotti senza alterare l'elenco originale di tuttiProdotti.
     //  Questo è utile se vogliamo conservare l'elenco originale di prodotti non filtrati e modificarne una versione separata
            var prodottiFiltrati = tuttiProdotti;

            // Filtra per prezzo minimo se specificato
            if (minPrezzo.HasValue)
            {
                 // Applica un filtro sui prodotti filtrati esistenti,
                // mantenendo solo i prodotti con prezzo maggiore o uguale a minPrezzo
                // Filtro sui prodotti il cui prezzo è maggiore o uguale a minPrezzo poi converte in lista
                prodottiFiltrati = prodottiFiltrati.Where(p => p.Prezzo >= minPrezzo.Value).ToList();
            }

             // Filtra per prezzo massimo se il parametro maxPrezzo è stato specificato
            if (maxPrezzo.HasValue)
            {
                // Applica un filtro sui prodotti filtrati esistenti,
                // mantenendo solo i prodotti con prezzo minore o uguale a maxPrezzo poi converte in lista
                prodottiFiltrati = prodottiFiltrati.Where(p => p.Prezzo <= maxPrezzo.Value).ToList();
            }

            // Assegna la lista filtrata alla proprietà Prodotti, 
            // che verrà utilizzata per visualizzare i prodotti nella pagina Razor
            Prodotti = prodottiFiltrati;
        }
}