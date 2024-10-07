using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ProdottiController : Controller
{
    private static List<Prodotto> prodotti;
    private static List<string> categorie; // Cambia qui in List<string>

    // Constructor: Load data from JSON file when the controller is instantiated
    public ProdottiController()
    {
        // Load products
        var prodottiFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json/prodotti.json");
        if (System.IO.File.Exists(prodottiFilePath))
        {
            var jsonData = System.IO.File.ReadAllText(prodottiFilePath);
            prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(jsonData) ?? new List<Prodotto>();
        }
        else
        {
            prodotti = new List<Prodotto>();
        }

        // Load categories
        var categorieFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json/categorie.json");
        if (System.IO.File.Exists(categorieFilePath))
        {
            var jsonData = System.IO.File.ReadAllText(categorieFilePath);
            categorie = JsonConvert.DeserializeObject<List<string>>(jsonData) ?? new List<string>();
        }
        else
        {
            categorie = new List<string>(); // Initialize with an empty list if file is not found
        }
    }

    public IActionResult Privacy()
{
    return View();
}

public IActionResult Contatti()
{
    return View("~/Views/Prodotti/Contatti.cshtml"); // Percorso specifico
}

public IActionResult Prodotti()
{
    return View("~/Views/Prodotti/Prodotti.cshtml"); // Percorso specifico
}


    public IActionResult Index()
{
    return View(prodotti); // Passa una lista di prodotti
}


    public IActionResult Create()
    {
        ViewBag.Categorie = categorie; // Pass the list of categories to the view
        return View();
    }

    [HttpPost]
    public IActionResult Create(Prodotto prodotto)
    {
        if (ModelState.IsValid)
        {
            prodotto.Id = prodotti.Count + 1;
            prodotti.Add(prodotto);

            // Save updated list to JSON file
            SaveToFile();

            return RedirectToAction("Index");
        }
        return View(prodotto);
    }

    public IActionResult Edit(int id)
    {
        var prodotto = prodotti.FirstOrDefault(p => p.Id == id);
        return prodotto == null ? NotFound() : View(prodotto);
    }

    [HttpPost]
    public IActionResult Edit(Prodotto prodotto)
    {
        var existingProdotto = prodotti.FirstOrDefault(p => p.Id == prodotto.Id);
        if (existingProdotto != null && ModelState.IsValid)
        {
            existingProdotto.Nome = prodotto.Nome;
            existingProdotto.Prezzo = prodotto.Prezzo;
            existingProdotto.Dettaglio = prodotto.Dettaglio;
            existingProdotto.Immagine = prodotto.Immagine;
            existingProdotto.Quantita = prodotto.Quantita;
            existingProdotto.Categoria = prodotto.Categoria;

            // Save updated list to JSON file
            SaveToFile();

            return RedirectToAction("Index");
        }
        return View(prodotto);
    }

    public IActionResult Delete(int id)
    {
        var prodotto = prodotti.FirstOrDefault(p => p.Id == id);

        if (HttpContext.Request.Method == "POST") // Check if it's a POST request
        {
            if (prodotto != null)
            {
                prodotti.Remove(prodotto);
                SaveToFile(); // Save changes
            }
            return RedirectToAction("Index"); // Redirect after deletion
        }

        return prodotto == null ? NotFound() : View(prodotto); // Return the view if it's a GET request
    }

    public IActionResult Details(int id)
{
    var prodotto = prodotti.FirstOrDefault(p => p.Id == id);
    return prodotto == null ? NotFound() : View(prodotto); // Passa un singolo prodotto
}


    // Save the updated product list to the JSON file
    private void SaveToFile()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json/prodotti.json");
        var jsonData = JsonConvert.SerializeObject(prodotti, Formatting.Indented);
        System.IO.File.WriteAllText(filePath, jsonData);
    }
}
