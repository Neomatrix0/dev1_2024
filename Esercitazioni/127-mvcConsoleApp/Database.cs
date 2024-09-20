using System.Data.SQLite;
class Database
{
    // SQLiteConnection è una classe che rappresenta una connessione a un database SQLite
    // Perchè è un oggetto che rappresenta il modello
    // Si utilizza l'underscore davanti al nome della variabile per indicare che è privata e non accessibile dall'esterno
    private SQLiteConnection _connection;

    public Database()
    {
        _connection = new SQLiteConnection("Data Source=database.db");  // Creazione di una connessione al database
        _connection.Open(); // Apertura della connessione
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT)", _connection);
        command.ExecuteNonQuery();  // Esecuzione del comando
    }

    public void AddUser(string name)
    {
        var command = new SQLiteCommand($"INSERT INTO users (name) VALUES ('{name}')", _connection);
        command.ExecuteNonQuery();  // Esecuzione del comando
    }

    public List<User> SearchUserByName(string name){
        var command = new SQLiteCommand($"SELECT id, name FROM users WHERE name = '{name}'", _connection);
        var reader = command.ExecuteReader();
        var users = new List<User>(); 
        while (reader.Read())
        {
            User tmp = new User(reader.GetInt32(0),reader.GetString(1));
            users.Add(tmp);
        }
        return users; 
    }

    public List<User> GetUsers()
    {
        var command = new SQLiteCommand("SELECT id, name FROM users", _connection); // Creazione di un comando per leggere gli utenti
        var reader = command.ExecuteReader();   // Esecuzione del comando e creazione di un oggetto per leggere i risultati
        var users = new List<User>(); // Creazione di una lista per memorizzare i nomi degli utenti
        while (reader.Read())
        {
            User tmp = new User(reader.GetInt32(0),reader.GetString(1));
            users.Add(tmp); // Aggiunta del nome dell'utente alla lista
        }
        return users;   // Restituzione della lista
    }

    public void UpdateUser(string oldName, string newName)
    {
        var command = new SQLiteCommand($"UPDATE users SET name = '{newName}' WHERE name = '{oldName}'", _connection);
        command.ExecuteNonQuery(); 
    }

    public void DeleteUser(string name)
    {
        var command = new SQLiteCommand($"DELETE FROM users WHERE name = '{name}'", _connection);
        command.ExecuteNonQuery(); 
    }
}