using Microsoft.EntityFrameworkCore;

class InventoryService
{

    
    private IDatabase _db; // Riferimento al database

    public InventoryService(IDatabase db)
    {
        _db = db; // Inizializza il database
    }

    // Metodo per aggiungere un nuovo prodotto
      public void AddProduct(string name,int categoryId)
    {

         var product = new Product
        {
            Name = name,
            CategoryId = categoryId // Associa il prodotto alla categoria
        };

        _db.Product.Add(product); // Aggiunge un utente al database
        _db.SaveChanges(); // Salva le modifiche
    }

      public List<Category> GetCategories()
    {
        return _db.Category.ToList();
    }

    public void AddCategory(string name)
    {
        var category = new Category{
            Name = name
        };
        
        _db.Category.Add(category);
        _db.SaveChanges(); 
    }
}
