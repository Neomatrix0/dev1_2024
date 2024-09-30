using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        var db = new Database(); // Crea un'istanza del database
        var inventoryService = new InventoryService(db); // Crea un'istanza del servizio
        var view = new View(); // Crea un'istanza della vista
        var controller = new Controller(inventoryService, view); // Crea un'istanza del controller
        controller.MainMenu(); // Avvia il menu principale
    }
}