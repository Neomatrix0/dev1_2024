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
    public IEnumerable<Prodotto> Prodotti { get; set; } //lista prodotti
    public int numeroPagine{ get; set; }    //aggiunta di una proprietà per il numero di pagine

    

// Metodo OnGet eseguito quando la pagina viene richiesta tramite GET
// minPrezzo e maxPrezzo sono parametri opzionali che filtrano i prodotti per prezzo
    public void OnGet(decimal? minPrezzo,decimal? maxPrezzo, int? pageIndex)  // aggiunta di argomenti per filtrare i prodotti per prezzo 
    {
        //var allProdotti = new List<Prodotto>
        var tuttiProdotti   = new List<Prodotto>
        {
            new Prodotto {Id =1, Nome = "prodotto 1", Prezzo = 100,Immagine = "img/shoes.jpg",Dettaglio ="Dettaglio1" },
            new Prodotto {Id =2, Nome = "prodotto 2", Prezzo = 200,Immagine = "img/img2.webp",Dettaglio ="Dettaglio2" },
            new Prodotto {Id =3, Nome = "prodotto 3", Prezzo = 300,Immagine = "img/apple.jpg",Dettaglio ="Dettaglio3" },
             new Prodotto {Id =4, Nome = "prodotto 4", Prezzo = 400,Immagine = "img/shoes.jpg",Dettaglio ="Dettaglio4" },
            new Prodotto {Id =5, Nome = "prodotto 5", Prezzo = 500,Immagine = "img/img2.webp",Dettaglio ="Dettaglio5" },
            new Prodotto {Id =6, Nome = "prodotto 6", Prezzo = 600,Immagine = "img/apple.jpg",Dettaglio ="Dettaglio6" },
             new Prodotto {Id =7, Nome = "prodotto 7", Prezzo = 700,Immagine = "img/shoes.jpg",Dettaglio ="Dettaglio7" },
            new Prodotto {Id =8, Nome = "prodotto 8", Prezzo = 800,Immagine = "img/img2.webp",Dettaglio ="Dettaglio8" },
            new Prodotto {Id =9, Nome = "prodotto 9", Prezzo = 900,Immagine = "img/apple.jpg",Dettaglio ="Dettaglio9" },
             new Prodotto {Id =10, Nome = "prodotto 10", Prezzo = 1000,Immagine = "img/books.jfif",Dettaglio ="Dettaglio10" },
            new Prodotto {Id =11, Nome = "prodotto 11", Prezzo = 10000,Immagine = "img/img2.webp",Dettaglio ="Dettaglio11" },
              new Prodotto {Id =12, Nome = "prodotto 12", Prezzo = 1100,Immagine = "img/img2.webp",Dettaglio ="Dettaglio12" },
               new Prodotto {Id =13, Nome = "prodotto 13", Prezzo = 1000,Immagine = "img/books.jfif",Dettaglio ="Dettaglio13" },
            new Prodotto {Id =14, Nome = "prodotto 14", Prezzo = 10000,Immagine = "img/img2.webp",Dettaglio ="Dettaglio14" },
              new Prodotto {Id =15, Nome = "prodotto 15", Prezzo = 1200,Immagine = "img/img2.webp",Dettaglio ="Dettaglio15" },
                new Prodotto {Id =16, Nome = "prodotto 16", Prezzo = 1300,Immagine = "img/img2.webp",Dettaglio ="Dettaglio16" },
            
            
        };

    

     //metodo giusto
// Dichiarazione della lista di prodotti filtrati, inizialmente vuota
var prodottiFiltrati = new List<Prodotto>();



// Ciclo attraverso tutti i prodotti per applicare i filtri
foreach (var prodotto in tuttiProdotti)
{
    bool aggiungi = true;  // Variabile di controllo per determinare se il prodotto deve essere aggiunto

    // Filtra per prezzo minimo se minPrezzo è specificato
    if (minPrezzo.HasValue)
    {
        if (prodotto.Prezzo < minPrezzo.Value)
        {
            aggiungi = false;  // Se il prezzo è inferiore al minPrezzo, non aggiungere il prodotto
        }
    }

    // Filtra per prezzo massimo se maxPrezzo è specificato
    if (maxPrezzo.HasValue)
    {
        if (prodotto.Prezzo > maxPrezzo.Value)
        {
            aggiungi = false;  // Se il prezzo è superiore al maxPrezzo, non aggiungere il prodotto
        }
    }

    // Se il prodotto soddisfa entrambi i filtri, aggiungilo alla lista filtrata
    if (aggiungi)
    {
        prodottiFiltrati.Add(prodotto);  // Aggiungi il prodotto alla lista dei prodotti filtrati
    }
}

// Assegna la lista filtrata alla proprietà Prodotti
Prodotti = prodottiFiltrati;

numeroPagine = (int)Math.Ceiling(Prodotti.Count()/6.0);    //calcola il numero di pagine
    //Math.ceiling arrotond ail numero di pagine all'intero più vicino
    //Prodotti.Count() restiuisce il numero di prodotti
    // 6.0 è il numero di prodotit per pagina


    Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1)*6).Take(6);  //esegue la paginazione
    //skip salta i primi((pageIndex ?? 1) - 1)*6) prodotti
    //Take prende i successivi 6 prodotti


    /*

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
            Prodotti = prodottiFiltrati; */
        }  
}