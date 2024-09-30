using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _86_RazorApp.Pages;

public class ProdottiModel : PageModel
{
    private readonly ILogger<ProdottiModel> _logger;

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }

    public IEnumerable<Prodotto> Prodotti { get; set; } 

    public void OnGet()
    {
        Prodotti = new List<Prodotto>
        {
            new Prodotto { Nome = "prodotto 1", Prezzo = 100,Immagine = "img/shoes.jpg",Dettaglio ="Dettaglio1" },
            new Prodotto { Nome = "prodotto 2", Prezzo = 200,Immagine = "img/img2.webp",Dettaglio ="Dettaglio2" },
            new Prodotto { Nome = "prodotto 3", Prezzo = 300,Immagine = "img/apple.jpg",Dettaglio ="Dettaglio3" },
        };
    }
}