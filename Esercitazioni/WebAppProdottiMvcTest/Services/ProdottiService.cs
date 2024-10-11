 using Newtonsoft.Json;
 public class ProdottiService{
 
  private readonly ILogger<ProdottiService> _logger;
        private readonly string prodottiFilePath = "wwwroot/json/prodotti.json"; // Path del file prodotti
        private readonly string categorieFilePath = "wwwroot/json/categorie.json"; // Path del file categorie

        public ProdottiService(ILogger<ProdottiService> logger)
        {
            _logger = logger;
        }

 public List<Prodotto> LeggiProdottiDaJson()
    {
        // Legge il contenuto del file prodotti.json
        var jsonData = System.IO.File.ReadAllText(prodottiFilePath);
        // Deserializza il contenuto in una lista di oggetti Prodotto
        return JsonConvert.DeserializeObject<List<Prodotto>>(jsonData) ?? new List<Prodotto>();
    }

    // Metodo per salvare i prodotti nel file JSON
  public void SalvaProdottiSuJson(List<Prodotto> prodotti)
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



    // Metodo per leggere le categorie dal file JSON

    public List<string> LeggiCategorieDaJson()
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

// Metodo per rimuovere un prodotto
    public Prodotto TrovaProdottoPerId(int id)
    {
        var prodotti = LeggiProdottiDaJson();
        return prodotti.FirstOrDefault(p => p.Id == id);
    }

  // Azione per visualizzare la conferma della cancellazione di un prodotto
    public void  CancellaProdotto(int id)
    {
        var prodotti = LeggiProdottiDaJson();
        var prodotto = prodotti.Find(p => p.Id == id); // Cerca il prodotto per ID

      if (prodotto != null)
        {
            prodotti.Remove(prodotto);
            SalvaProdottiSuJson(prodotti);
        }
      
    }  




 }     