using Microsoft.EntityFrameworkCore;

 class Category
{
    public int CategoryId { get; set; } // Chiave primaria della categoria
    public string Name { get; set; } // Nome della categoria

    // Collezione di prodotti associati alla categoria
    public Product Product { get; set; } // Navigazione verso i prodotti
}
