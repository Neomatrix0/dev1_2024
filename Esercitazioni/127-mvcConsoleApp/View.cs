class View{
    private Database _db;

    public View(Database db) {
        _db = db;
    }

    public void ShowMainMenu(){
        Console.WriteLine("1. aggiungi user");
        Console.WriteLine("2. Visualizza users");
        Console.WriteLine("3. Modifica user");
        Console.WriteLine("4. Elimina user");
        Console.WriteLine("5. cerca user/s by name");
        Console.WriteLine("6. esci");
    }

    public void ShowUsers(List<User> users){
        Console.WriteLine("************************************");
        foreach (var user in users) {
            Console.WriteLine($"id -> {user.Id}\nName -> {user.Name}");
            Console.WriteLine("************************************");
        }
    }

    public string GetInput(){
        return Console.ReadLine();
    }
}