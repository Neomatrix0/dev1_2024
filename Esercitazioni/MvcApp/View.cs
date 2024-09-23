class View
{
    private Database _db; // Riferimento al modello

    public View(Database db)
    {
        _db = db; // Inizializzazione del riferimento al modello
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("1. Add item");
        Console.WriteLine("2. Read items");
        Console.WriteLine("3. exit");
    }

    public void ShowItems(List<string>products)
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products available.");
        }
        else
        {
            Console.WriteLine("Products:");
        foreach (var product in products)
        {
            Console.WriteLine(product); 
        }
    } }

    public string GetInput()
    {
        return Console.ReadLine(); // Lettura dell'input dell'utente
    }
}