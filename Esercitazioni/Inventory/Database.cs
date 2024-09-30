using Microsoft.EntityFrameworkCore;

interface IDatabase
{
    DbSet<Product> Product { get; set; } // Tabella dei prodotti
    DbSet<Category> Category { get; set; } // Tabella categorie
    DbSet<Quantity> Quantity { get; set; } // Tabella quantità

    void SaveChanges(); // Salva le modifiche
}

class Database : DbContext, IDatabase
{
    public DbSet<Product> Product { get; set; } // Implementa la tabella dei prodotti
    public DbSet<Category> Category { get; set; } // Implementa la tabella categorie
    public DbSet<Quantity> Quantity { get; set; } // Implementa la tabella quantità
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=database.db"); // Usa un database SQLite
    }

    public void SaveChanges()
    {
        base.SaveChanges(); // Salva le modifiche
    }
}