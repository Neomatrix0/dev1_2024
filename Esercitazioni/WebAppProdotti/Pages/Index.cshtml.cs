using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace WebAppProdotti.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
public List<Prodotto> RandomProdotti { get; set; } = new List<Prodotto>();
    public void OnGet()
    {
        // Carica i prodotti dal file JSON

          var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
            var tuttiProdotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);

            // Seleziona 3 prodotti casuali
              if (tuttiProdotti != null && tuttiProdotti.Count > 0)
            {
                Random random = new Random();

                  
            for (int i = 0; i < 3; i++)
            {
                int randomIndex = random.Next(tuttiProdotti.Count);
                RandomProdotti.Add(tuttiProdotti[randomIndex]);}

               
            //Take prende i primi 3 elementi della lista
          //  RandomProdotti = tuttiProdotti.OrderBy(x => random.Next()).Take(3).ToList();
            }
            }
    }

