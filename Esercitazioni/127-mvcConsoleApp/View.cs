class View{
    private Database _db;

    public View(Database db) {
        _db = db;
    }

    public void ShowMainMenu(){
        Console.WriteLine("1. Add user");
        Console.WriteLine("2. View users");
        Console.WriteLine("3. Modify user");
        Console.WriteLine("4. Delete user by name");
        Console.WriteLine("5. Delete user by id");
        Console.WriteLine("6. Search user/s by name");
        Console.WriteLine("7. Exit");
    }

    public void ShowUsers(List<User> users){
        Console.WriteLine("************************************");
        foreach (var user in users) {
            Console.WriteLine($"id -> {user.Id}\nName -> {user.Name}\nStatus -> {user.Active}");
            Console.WriteLine("************************************");
        }
    }

    public string GetInput(){
        return Console.ReadLine();
    }
}