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

              // Converto l'input da stringa a intero
            if (int.TryParse(input, out int option))
            {
            switch(option){
                case 1:

                AddUser();
                break;

                  case 2:

                ShowUser();
                break;


                  case 3:

                UpdateUser();
                break;

                  case 4:

                DeleteUser();
                break;

                  case 5:

                DeleteUserById();
                break;

                  case 6:

                SearchUserByName();
                break;

                case 7:

                 try
                {
                    _db.CloseConnection();
                    Console.WriteLine("Connection closed successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while closing the connection: {ex.Message}");
                }

                
                return;
            
           default:
           Console.WriteLine("Error: Invalid option. Try again.");
                        break;
            
            }
            }
              else
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
            Thread.Sleep(1000);

                

            }
            }
      
    /*fallo anche per id*/

    private void DeleteUserById(){
        Console.WriteLine("Work in progress");
    }
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

         Console.WriteLine("New name:");
        var newName = _view.GetInput();
         if (string.IsNullOrWhiteSpace(newName)) {
        Console.WriteLine("Error: Name cannot be empty or null.");
        return;
    }

      Console.WriteLine("Is the user active? (Y/N):");
               var activeInput = _view.GetInput();
               bool isActive = activeInput.ToUpper() == "Y";
                _db.UpdateUser(oldName, newName, isActive);
                Console.WriteLine($"{oldName} updated to {newName} with active status: {isActive}");
               
       
    
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