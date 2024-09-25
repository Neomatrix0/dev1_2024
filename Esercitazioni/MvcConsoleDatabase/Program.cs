using Microsoft.EntityFrameworkCore;

class Program{
    static void Main(string[] args){
    var db = new Database(); //crea istanza del database
    var view = new View(db); //crea istanza della vista
    var controller = new Controller(db,view);  //crea un istanza del controller
    controller.MainMenu();  //avvia menu principale

}
}

class User{
    public int Id { get; set; }  //chiave primaria
    public string Name { get; set; }  //nome utente
}

class Database : DbContext{
    public DbSet<User> Users { get; set; }  //tabella degli utenti
    protected override void OnConfiguring(DbContextOptionsBuilder options){
        options.UseSqlite("Data Source =database.db");  //usa un database sqlite
    }
 /*    public Database()
    {
        Database.EnsureCreated();  // Ensure the database and tables are created
    }*/
}

class View{
    private Database _db;
    public View(Database db){
        _db = db; // inizializza il database
    }

    public void ShowMainMenu(){
           Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi users");
        Console.WriteLine("3. Modifica users");
        Console.WriteLine("4. Elimina users");
        Console.WriteLine("5. Esci");
       
    }
//metodo showusers che prende una lista utenti e li mostra
    public void ShowUsers(List<User>users){
        foreach(var user in users){
            Console.WriteLine(user.Name);  // mostra il nome dell'utente
        }
    }

    //metodo GetInput che legge l'input dell'utente
    public string GetInput(){
        return Console.ReadLine();      // legge l'input dell'utente
    }
}
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
                var input = _view.GetInput();
                if(input == "1"){
                    AddUser();

                }else if(input == "2"){
                    ShowUsers();

                }else if(input == "3"){
                    UpdateUser();

                }else if(input == "4"){
                    DeleteUser();

                }
                else if(input == "5"){
                   break;

                }
            }
        }

        private void AddUser(){
            Console.WriteLine("Enter user name:");
            var name = _view.GetInput();  // Legge l'input del nome dell'utente
            _db.Users.Add(new User{Name =name}); //Aggiunge un utente al database
            _db.SaveChanges(); // Salva modifiche
        }


        private void ShowUsers(){
            var users = _db.Users.ToList();     // prende tutti gli utenti dal database
            _view.ShowUsers(users);     //mostra gli utenti
        }

/*
 private void UpdateUser(){
            Console.WriteLine("Enter user name:");
            var oldName = _view.GetInput();
            Console.WriteLine("Enter ne wuser name");
            var newName = _view.GetInput();
            si può usare una lambda per abbreviare il codice
            var user = _dbUsersFirstOrrDefault(u=> u.Name == oldName);


*/

// versione senza lambda 
        private void UpdateUser(){
            Console.WriteLine("Enter user name:");
            var oldName = _view.GetInput();
            Console.WriteLine("Enter ne wuser name");
            var newName = _view.GetInput();

            User user = null;       //inizializza utente a null
            foreach(var u in _db.Users){
                if(u.Name == oldName){
                    if(u.Name == oldName){
                        user =u;        //trova utente con il nome specificato
                        break;          //esce dal ciclo una volta trovato l'utente
                    }
                }
                if(user != null){
                    user.Name = newName;  //modifica nome utente
                    _db.SaveChanges();   // Salva modifiche
                }
            }

        }

// metodo DeleteUser che elimina un utente
        private void DeleteUser(){
            Console.WriteLine("Enter user name");
            var name = _view.GetInput();

            User userToDelete = null;
            foreach(var user in _db.Users){
                if(user.Name == name){
                    userToDelete = user;
                    break;  //esce dal ciclo una volta trovato l'utente
                }
            }

            if(userToDelete != null){
                _db.Users.Remove(userToDelete); // rimuove l'utente
                _db.SaveChanges(); // Salva le modifiche
            }
        }

    }


//dotnet add package Microsoft.EntityFrameworkCore.Design
//dotnet tool install --global dotnet-ef
// Comandi per la migrazione obbligatori
//dotnet ef migrations add InitialCreate
//dotnet ef database update
