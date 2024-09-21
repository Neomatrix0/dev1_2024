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
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT,mail TEXT, active BOOLEAN)", _connection);
        command.ExecuteNonQuery();  // Esecuzione del comando
    }

    public void AddUser(string name,string mail,bool active)
    {
        var command = new SQLiteCommand($"INSERT INTO users (name,mail,active) VALUES (@name,@mail,@active)", _connection);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@mail", mail);
         command.Parameters.AddWithValue("@active", active ? 1 : 0); // converte il valore booleano true o false in 1 o 0 compatibile con sqlite
        command.ExecuteNonQuery();  // Esecuzione del comando
    }

    public List<User> SearchUserByName(string name){
        var command = new SQLiteCommand($"SELECT id, name,active,mail FROM users WHERE name = @name", _connection);
        command.Parameters.AddWithValue("@name", name);
        var reader = command.ExecuteReader();
        var users = new List<User>(); 
        while (reader.Read())
        {
            User tmp = new User(reader.GetInt32(0),reader.GetString(1),reader.GetBoolean(2),reader.GetString(3));
            users.Add(tmp);
        }
        return users; 
    }

    public List<User> GetUsers()
    {
        var command = new SQLiteCommand("SELECT id, name,mail,active FROM users", _connection); // Creazione di un comando per leggere gli utenti
        var reader = command.ExecuteReader();   // Esecuzione del comando e creazione di un oggetto per leggere i risultati
        var users = new List<User>(); // Creazione di una lista per memorizzare i nomi degli utenti
        while (reader.Read())
        {
            bool isActive = reader.GetInt32(3) == 1;
        User tmp = new User(reader.GetInt32(0), reader.GetString(1), isActive, reader.GetString(2));
        users.Add(tmp);
        }
        return users;   // Restituzione della lista
    }

    public void UpdateUser(string oldName, string newName,bool newActive)
    {
        var command = new SQLiteCommand($"UPDATE users SET name = @newName,active = @newActive  WHERE name = '{oldName}'", _connection);//WHERE id= @id
        command.Parameters.AddWithValue("@newName",newName);
        command.Parameters.AddWithValue("@oldName",oldName);
       
          command.Parameters.AddWithValue("@newActive", newActive ? 1 : 0);
        //command.Parameters.AddWithValue("@id",id);
        command.ExecuteNonQuery(); 
    }

    public void DeleteUser(string name)
    {
        var command = new SQLiteCommand($"DELETE FROM users WHERE name = '{name}'", _connection);
        command.ExecuteNonQuery(); 
    }

    public User GetUserById(int id){
        var command = new SQLiteCommand("SELECT id,name,active,mail FROM users WHERE id= @id", _connection);
        command.Parameters.AddWithValue("@id", id);
         var reader = command.ExecuteReader();
          if (reader.Read())
    {
           return new User(reader.GetInt32(0), reader.GetString(1), reader.GetBoolean(2),reader.GetString(3));
    }
    return null;
    }

    public void DeleteUserById(int id){
         var command = new SQLiteCommand($"DELETE FROM users WHERE id = @id", _connection);
         command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery(); 
    }

    public void CloseConnection(){
        if(_connection.State != System.Data.ConnectionState.Closed){
            _connection.Close();
        }
    }
}