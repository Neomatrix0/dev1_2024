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
        Console.WriteLine("New name:");
        var newName = _view.GetInput();
        if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName))
        {
            Console.WriteLine("Error: Names cannot be empty or null.");
            return;
        }
        _db.UpdateUser(oldName, newName);
        Console.WriteLine($"{oldName} updated in {newName}");
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
        _db.AddUser(name);
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