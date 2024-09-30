 using Microsoft.EntityFrameworkCore;

 class Quantity
{
    public int QuantityId { get; set; } // Chiave primaria della quantità
    public int Amount { get; set; } // Quantità disponibile

    // Relazione uno-a-uno con Product
    public int ProductId { get; set; } // Chiave esterna per il prodotto
    public Product Product { get; set; } // Navigazione verso il prodotto
}
