class Controller
{
    private Database _db;
    private View _view;

    public Controller(Database db, View view)
    {
        _db = db;
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
                AddUser();
            }
            else if (input == "2")
            {
                ShowUser();
            }
            else if (input == "3")
            {
                UpdateUser();
            }
            else if (input == "4")
            {
                DeleteUser();
            }
            else if (input == "5")
            {
                SearchUserByName();
            }
            else if (input == "6")
            {
                try
                {
                    _db.CloseConnection();
                    Console.WriteLine("Connection closed successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while closing the connection: {ex.Message}");
                }

                // _db.CloseConnection();
                break;
            }
            else
            {
                Console.WriteLine("Error: Invalid option. Try again.");
            }
            Thread.Sleep(1000);
        }
    }
    /*fallo anche per id*/
    private void DeleteUser()
    {
        Console.WriteLine("User name u want to delete:");
        var name = _view.GetInput();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Error: Name cannot be empty or null.");

            return;
        }

        _db.DeleteUser(name);
        Console.WriteLine($"{name} deleted");

    }
    private void UpdateUser()
    {
        Console.WriteLine("Old name:");
        var oldName = _view.GetInput();
       
        if (string.IsNullOrWhiteSpace(oldName))
        {
            Console.WriteLine("Error: Names cannot be empty or null.");
            return;
        }
        Console.WriteLine("What do you want to update?");
    Console.WriteLine("1. Name");
    Console.WriteLine("2. Active status");
    Console.WriteLine("3. Both name and active status");
    var choice = _view.GetInput();  
switch (choice){
    case "1":     // update nome
     Console.WriteLine("New name:");
        var newName = _view.GetInput();
         if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("Error: New name cannot be empty or null.");
                return;
            }
              _db.UpdateUser(oldName, newName, null);  // Passa null per non aggiornare lo stato attivo
            Console.WriteLine($"{oldName} updated to {newName}.");
            break;


            case "2":
              Console.WriteLine("Is the user active? (Y/N):");
         var activeInput  = _view.GetInput();
         bool isActive = activeInput.ToUpper()=="Y";
        _db.UpdateUser(oldName, null,isActive);
        Console.WriteLine($"{oldName} updated  status is {isActive}");
        break;

        default:
        Console.WriteLine("Error: Invalid option. Try again.");
            break;

}
       
    }
    private void AddUser()
    {
        Console.WriteLine("Enter user name:");
        var name = _view.GetInput();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Error: Names cannot be empty or null.");
            return;
        }
        Console.WriteLine("Is the user active? (Y/N):");
        var activeInput = _view.GetInput();
        bool isActive = activeInput.ToUpper() == "Y";
        _db.AddUser(name,isActive);
        Console.WriteLine($"{name} added to the database");
    }
    private void ShowUser()
    {
        var users = _db.GetUsers();
        _view.ShowUsers(users);
    }

    private void SearchUserByName()
    {
        Console.WriteLine("Insert name:");
        var name = _view.GetInput();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Error: Names cannot be empty or null.");
            return;
        }
        _view.ShowUsers(_db.SearchUserByName(name));
    }
}