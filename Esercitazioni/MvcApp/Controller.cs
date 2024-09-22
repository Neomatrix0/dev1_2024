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

    private void AddItems(){
        Console.WriteLine("Enter product name:"); 
        var product = _view.GetInput();
         _db.AddItems(product);
    }
     private void ShowItems()
    {
        var products = _db.GetItems(); // Lettura degli utenti dal database
        _view.ShowItems(products); // Visualizzazione degli utenti
    }
        }

    