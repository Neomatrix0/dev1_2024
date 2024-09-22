
using System.Data.SQLite;
class Database
{
  private SQLiteConnection _connection;

public Database(){
     _connection = new SQLiteConnection("Data Source=database.db"); // Creazione di una connessione al database
        _connection.Open(); // Apertura della connessione
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS products (id INTEGER PRIMARY KEY, productName TEXT,category TEXT,quantity INTEGER)", _connection); // Creazione della tabella users
        command.ExecuteNonQuery(); // Esecuzione del comando
    }

    public void AddItem(string name,string category,int quantity){
         var command = new SQLiteCommand($"INSERT INTO products (productName,category,quantity) VALUES (@productName. @category,@quantity)", _connection);
        command.Parameters.AddWithValue("@productName",productName);
         command.Parameters.AddWithValue("@category",category);
          command.Parameters.AddWithValue("@quantity",quantity);
          command.ExecuteNonQuery();
    }

    public List<string> GetItems(){
        var command = new SQLiteCommand("SELECT productName FROM products", _connection);
        var reader = command.ExecuteReader(); // Esecuzione del comando e creazione di un oggetto per leggere i risultati
        var items= new List<string>();
            while (reader.Read())
        {
            products.Add(reader.GetString(0)); // Aggiunta del nome dell'utente alla lista
                                            // utilizzo (0) perche il nome è il primo campo 
        }
        return products; // Restituzione della lis
    }

     public void CloseConnection(){
        if(_connection.State != System.Data.ConnectionState.Closed){
            _connection.Close();
        }
     }

}


