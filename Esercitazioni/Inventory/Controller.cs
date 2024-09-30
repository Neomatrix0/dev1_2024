using Microsoft.EntityFrameworkCore;


 class Controller
{
    private InventoryService _inventoryService;
    private View _view;

    public Controller(InventoryService inventoryService, View view)
    {
        _inventoryService = inventoryService;
        _view = view;
    }

    public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu();
            var input = _view.GetInput();
            if (input == "1")
            {
                // Chiama il metodo per aggiungere un prodotto
                AddProduct();
                break;
            }
            else if (input == "6")
            {
                AddCategory();
            }
            else if (input == "5")
            {
                break;
            }
        }
    }

    private void AddProduct()
    {
        Console.WriteLine("Enter product name:");
        var name = _view.GetInput(); // Legge il nome dell'utente
          var categories = _inventoryService.GetCategories();
   // _view.ShowCategories(categories);
         
      Console.WriteLine("Select category by entering the category number:");

    // Converti l'input in un intero
    var categoryInput = Convert.ToInt32(Console.ReadLine());

    // Verifica che la categoria esista attraverso un ciclo
    Category selectedCategory = null;
    foreach (var category in categories)
    {
        if (category.CategoryId == categoryInput)
        {
            selectedCategory = category;
            break;
        }
    }

    // Se la categoria è valida, aggiunge il prodotto
    if (selectedCategory != null)
    {
        _inventoryService.AddProduct(name, selectedCategory.CategoryId); // Aggiunge il prodotto con il nome e l'ID della categoria scelta
    }
    else
    {
        Console.WriteLine("Invalid category. Please select a valid category.");
    }
}

private void AddCategory()
    {
        Console.WriteLine("Enter category name:");
        var name = _view.GetInput(); // Legge il nome della categoria

        // Chiamata al servizio per aggiungere la categoria
        _inventoryService.AddCategory(name);
    
        Console.WriteLine("Category added successfully.");
    }




}