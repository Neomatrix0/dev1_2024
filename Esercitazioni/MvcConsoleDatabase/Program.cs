﻿using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        var db = new Database(); //crea istanza del database
        var view = new View(db); //crea istanza della vista
        var controller = new Controller(db, view);  //crea un istanza del controller
        controller.MainMenu();  //avvia menu principale

    }
}

class User
{
    public int Id { get; set; }  //chiave primaria
    public string Name { get; set; }  //nome utente

    public bool IsActive { get; set; }  // stato user se attivo o disattivo
}

class Transactions
{
    public int Id { get; set; }
    public User User { get; set; }
    public Subscription Subscription { get; set; }
    public DateTime TransactionDate { get; set; }



}

class Subscription
{
    public int Id { get; set; }  // chiave primaria
    public string Name { get; set; }  // nome dell'abbonamento
    public decimal Price { get; set; }  // prezzo dell'abbonamento
}

class Database : DbContext
{
    public DbSet<User> Users { get; set; }  //tabella degli utenti
    public DbSet<Subscription> Subscription { get; set; }
    public DbSet<Transactions> Transactions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source =database.db");  //usa un database sqlite
    }

}

class View
{
    private Database _db;
    public View(Database db)
    {
        _db = db; // inizializza il database
    }

// ShowMainMenu mostra il menu principale con le scelte possibili
    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi users attivi");
        Console.WriteLine("3. Modifica users");
        Console.WriteLine("4. Elimina users");
        Console.WriteLine("5. Esci");
        Console.WriteLine("6. Disattiva utente");
        Console.WriteLine("7. Aggiungi subscription");
        Console.WriteLine("8. Mostra subscription");
        Console.WriteLine("9. Aggiorna subscription");
        Console.WriteLine("10. Mostra transazioni");
        Console.WriteLine("11. Aggiungi transazioni");

    }
    //metodo showusers che prende una lista utenti e li mostra
    public void ShowUsers(List<User> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine(user.Name);  // mostra il nome dell'utente
        }
    }

    //metodo GetInput che legge l'input dell'utente
    public string GetInput()
    {
        return Console.ReadLine();      // legge l'input dell'utente
    }


    // Visulizzazione sottoscrizioni

    public void ShowSubscriptions(List<Subscription> subscriptions)
    {
        foreach (var sub in subscriptions)
        {
            Console.WriteLine($"Subscription ID: {sub.Id}, Name: {sub.Name}, Price: {sub.Price:C}");
        }
    }

    


    

}
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
                ShowUsers();

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
                break;

            }
            else if (input == "6")
            {
                StatusUser();
                break;

            }
            else if (input == "7")
            {
                AddSubscription();
                break;

            }
            else if (input == "8")
            {
                ShowSubscriptions();
                break;
            }
            else if (input == "9")
            {
                UpdateSubscription();
                break;
            }
            else if (input == "10")
            {
                ShowTransactions();
                break;
            }
            else if (input == "11")
            {
                AddTransaction();
                break;
            }
        }
    }

    private void AddUser()
    {
        Console.WriteLine("Enter user name:");
        var name = _view.GetInput();
        Console.WriteLine("Is user active? (yes/no)");
        var isActiveInput = _view.GetInput().ToLower();
        bool isActive = isActiveInput == "yes";
        _db.Users.Add(new User { Name = name, IsActive = isActive });

        _db.SaveChanges(); // Salva modifiche
    }


// ShowUsers mostra tutti gli utenti attivi
    private void ShowUsers()
    {
        List<User> activeUsers = new List<User>();  // crea una lista per gli utenti attivi

        foreach (var user in _db.Users)
        {
            if (user.IsActive)
            {            // se vogliamo anche users non attivi  || !user.IsActive
                activeUsers.Add(user);
            }
        }

        _view.ShowUsers(activeUsers);
    }

// metodo per mostrare sottoscrizioni
    private void ShowSubscriptions()
    {
        var subscriptions = _db.Subscription.ToList();
        _view.ShowSubscriptions(subscriptions); // Chiamata alla vista
    }

// mostra transazioni
    private void ShowTransactions()
    {
        // Recupera tutte le transazioni e converte in lista
        var transactions = _db.Transactions.ToList();


        foreach (var trans in transactions)
        {
            // Cerca l'utente associato alla transazione
            User user = null;  //usata per memorizzare l'oggetto user
            foreach (var u in _db.Users)
            { //per ogni user  trovato la variabile u contiene un oggetto user
                if (u.Id == trans.User?.Id)
                {  // Verifica che trans.User non sia null
                    user = u;  //Se l'ID dell'utente corrente u.Id corrisponde all'ID dell'utente associato alla transazione 
                               //significa che l'utente associato alla transazione è stato trovato.
                    break;
                }
            }

            // Cerca l'abbonamento associato alla transazione
            Subscription subscription = null;
            foreach (var sub in _db.Subscription)
            {
                if (sub.Id == trans.Subscription?.Id)
                {  // Verifica che trans.Subscription non sia null
                    subscription = sub;
                    break;
                }
            }

            // Mostra le informazioni della transazione solo se entrambi user e subscription sono non null
            if (user != null && subscription != null)
            {
                Console.WriteLine($"Transaction ID: {trans.Id}, User: {user.Name}, Subscription: {subscription.Name}, Date: {trans.TransactionDate}");
            }
            else
            {
                Console.WriteLine($"Transaction ID: {trans.Id} has missing user or subscription data.");
            }
        }
    }





    // metodo per aggiornare il nome e lo stato dello user

    private void UpdateUser()
    {
        Console.WriteLine("Enter the name of the user to update:");
        var oldName = _view.GetInput();

        // Trova l'utente nel database
        User user = null;
        foreach (var u in _db.Users)
        {
            if (u.Name == oldName)
            {
                user = u;  // Assegna l'utente trovato a user
                break;
            }
        }

        if (user != null)
        {

            Console.WriteLine("Enter new user name:");
            var newName = _view.GetInput();
            user.Name = newName;


            Console.WriteLine("Is the user active? (yes/no):");
            var isActiveInput = _view.GetInput().ToLower();
            bool isActive = isActiveInput == "yes";
            user.IsActive = isActive;


            _db.SaveChanges();

            Console.WriteLine($"User '{user.Name}' has been updated with status '{(user.IsActive ? "Active" : "Inactive")}'.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }


    // metodo DeleteUser che elimina un utente
    private void DeleteUser()
    {
        Console.WriteLine("Enter user name");
        var name = _view.GetInput();

        User userToDelete = null;
        foreach (var user in _db.Users)
        {
            if (user.Name == name)
            {
                userToDelete = user;
                break;  //esce dal ciclo una volta trovato l'utente
            }
        }

        if (userToDelete != null)
        {
            _db.Users.Remove(userToDelete); // rimuove l'utente
            _db.SaveChanges(); // Salva le modifiche
        }
    }
    //aggiungi sttoscrizione


    private void AddSubscription()
    {
        Console.WriteLine("Enter subscription name ( 'Premium'):");
        var name = Console.ReadLine();  // Legge il nome direttamente dalla console

        //decimal price;
        Console.WriteLine("Enter subscription price (, '9,99'):");
        var price = decimal.Parse(_view.GetInput());


        // Aggiunge il nuovo abbonamento al database
        _db.Subscription.Add(new Subscription { Name = name, Price = price });
        _db.SaveChanges();  // Salva le modifiche
        Console.WriteLine("Subscription added successfully.");
    }





    // aggiungi transazione
    private void AddTransaction()
    {

        Console.WriteLine("Enter user name for the transaction:");
        ShowUsers();  // Mostra tutti gli utenti
        var userName = _view.GetInput();

        // Cerca l'utente nel database
        User user = null; //null perchè non abbiamo ancora trovato l'utente funge da  contenitore per il futuro user
        foreach (var u in _db.Users)
        {
            if (u.Name == userName)
            {
                user = u;
                break;
            }
        }

        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        // Chiede il nome dell'abbonamento per la transazione
        Console.WriteLine("Enter subscription name for the transaction:");
        ShowSubscriptions();  // Mostra tutti gli abbonamenti
        var subscriptionName = _view.GetInput();

        // Cerca l'abbonamento nel database
        Subscription subscription = null;
        foreach (var s in _db.Subscription)
        {
            if (s.Name == subscriptionName)
            {
                subscription = s;  //subscription da null ora invece contiene il riferimento ad oggetto abbonamento
                                   //Se viene trovata una corrispondenza (il nome dell'abbonamento s.Name corrisponde a subscriptionName) questa riga assegna l'oggetto Subscription corrente s alla variabile subscription.  
                                   //subscription ora contiene un riferimento all'oggetto abbonamento trovato.


                break;
            }
        }

        if (subscription == null)
        {
            Console.WriteLine("Subscription not found.");
            return;
        }

        // Crea una nuova transazione
        var transaction = new Transactions
        {
            User = user,
            Subscription = subscription,
            TransactionDate = DateTime.Now  // Imposta la data corrente come data della transazione
        };

        // Aggiunge la transazione al database
        _db.Transactions.Add(transaction);
        _db.SaveChanges();  // Salva le modifiche nel database

        Console.WriteLine("Transaction added successfully.");
    }


    //aggiorna subscriptions

    private void UpdateSubscription()
    {
        Console.WriteLine("Enter the name of the subscription to update:");
        var oldName = _view.GetInput();  // Legge il nome dell'abbonamento

        // Trova l'abbonamento nel database
        Subscription subscription = null;
        foreach (var sub in _db.Subscription)
        {
            if (sub.Name == oldName)
            {
                subscription = sub;  // Assegna l'abbonamento trovato a subscription
                break;
            }
        }

        if (subscription != null)
        {
            // Aggiorna il nome
            Console.WriteLine("Enter new subscription name:");
            var newName = _view.GetInput();
            subscription.Name = newName;

            // Aggiorna il prezzo
            Console.WriteLine("Enter new subscription price:");

            var price = decimal.Parse(_view.GetInput());


            subscription.Price = price;

            // Salva le modifiche nel database
            _db.SaveChanges();

            Console.WriteLine($"Subscription '{subscription.Name}' has been updated with new price {subscription.Price:C}.");
        }
        else
        {
            Console.WriteLine("Subscription not found.");
        }
    }

// metodo per cambiare status dell'utente

    private void StatusUser()
    {
        Console.WriteLine("Enter the name of the user to change status:");
        var name = _view.GetInput();  // Ottieni il nome dell'utente

        // Trova l'utente nel database
        User userToChange = null;
        foreach (var user in _db.Users)
        {
            if (user.Name == name)
            {
                userToChange = user;
                break;  // esce dal ciclo quando trova l'utente
            }
        }

        if (userToChange != null)
        {
            Console.WriteLine("Is the user active? (yes/no):");
            var isActiveInput = _view.GetInput().ToLower();  // Input per sapere se l'utente è attivo o meno
            bool isActive = isActiveInput == "yes";  // Converte l'input in un valore booleano

            // Modifica lo stato attivo dell'utente
            userToChange.IsActive = isActive;
            _db.SaveChanges();  // Salva le modifiche nel database

            Console.WriteLine($"User '{userToChange.Name}' status has been updated.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    //
}




//dotnet add package Microsoft.EntityFrameworkCore.Design
//dotnet tool install --global dotnet-ef
// Comandi per la migrazione obbligatori
//dotnet ef migrations add InitialCreate
//dotnet ef database update

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

/*
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
                    user.Name = newName;
                    // Aggiorna lo stato attivo/disattivo dell'utente  //modifica nome utente
                    _db.SaveChanges();   // Salva modifiche
                }
            }

        }  */ // metodo che funziona
/*      private void ShowUsers(){
           var users = _db.Users.ToList();     // prende tutti gli utenti dal database
           _view.ShowUsers(users);     //mostra gli utenti
       }*/