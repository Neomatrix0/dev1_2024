using System.Data.SQLite;
class Controller{
    private Database _db;
    private View _view;

    public Controller(Database db,View view){
        _db = db;
        _view = view;

    }

    public void MainMenu(){
        while(true){
            _view.ShowMainMenu(); 
             var input = _view.GetInput(); // Lettura dell'input dell'utente
            if (input == "1")
            {
                AddItem(); // Aggiunta di un utente
            }
            else if (input == "2")
            {
                ShowItems(); // Visualizzazione degli utenti
            }
            else if (input == "3")
            {
                break; // Uscita dal programma
            }
        }
    }

    private void AddItem(){
        Console.WriteLine("Enter product name:");
        var productName = _view.GetInput();

        Console.WriteLine("Enter product category:");
        var category = _view.GetInput();

        Console.WriteLine("Enter product quantity:");
        var quantityInput = _view.GetInput();
        
        if (int.TryParse(quantityInput, out int quantity)) // Validate quantity input
        {
            _db.AddItem(productName, category, quantity); // Pass all required arguments
            Console.WriteLine("Product added successfully!");
        }
        else
        {
            Console.WriteLine("Invalid quantity. Please enter a valid number.");
        }
    }

    
     private void ShowItems()
    {
        var products = _db.GetItems(); // Lettura dei prodotti dal database
        _view.ShowItems(products); // Visualizzazione dei prodotti
    }
        }

    