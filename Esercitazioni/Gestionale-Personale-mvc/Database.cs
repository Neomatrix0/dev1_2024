using System.Data.SQLite;
class Database
{
    private SQLiteConnection _connection; // SQLiteConnection è una classe che rappresenta una connessione a un database SQLite si definisce classe
                                          // perche è un oggetto che rappresenta il modello
                                          // Si utilizza l'underscore davanti al nome 
                                          // della variabile per indicare che è privata e non accessibile dall'esterno

    public Database()
    {
        _connection = new SQLiteConnection("Data Source=database.db"); // Creazione di una connessione al database
        _connection.Open(); // Apertura della connessione
      var command1 = new SQLiteCommand(
        "CREATE TABLE IF NOT EXISTS dipendente (id INTEGER PRIMARY KEY, nome TEXT, cognome TEXT, dataDiNascita DATE, mail TEXT) ;", 
        _connection);
    command1.ExecuteNonQuery(); // Esecuzione del comando

    // Creazione della tabella mansione
    var command2 = new SQLiteCommand(
        "CREATE TABLE IF NOT EXISTS mansione (id INTEGER PRIMARY KEY AUTOINCREMENT, titolo TEXT UNIQUE,stipendio REAL);", 
        _connection);
    command2.ExecuteNonQuery(); // Esecuzione del comando

    var command3 = new SQLiteCommand(
        "CREATE TABLE IF NOT EXISTS statistiche (id INTEGER PRIMARY KEY AUTOINCREMENT, performance INTEGER,assenze INTEGER);", 
        _connection);
    command3.ExecuteNonQuery(); // Esecuzione del comando
       // Esecuzione del comando
    }

    public void AggiungiDipendente(string nome,string cognome,DateTime dataDiNascita,string mail)
    {
        var command = new SQLiteCommand($"INSERT INTO dipendente (nome,cognome,dataDiNascita,mail) VALUES (@nome,@cognome,@dataDiNascita,@mail)", _connection); // Creazione di un comando per inserire un nuovo utente
       command.Parameters.AddWithValue("@nome", nome);
       command.Parameters.AddWithValue("@cognome", cognome);
       command.Parameters.AddWithValue("@dataDiNascita", dataDiNascita.ToString("yyyy-MM-dd"));
       command.Parameters.AddWithValue("@mail", mail);
        command.ExecuteNonQuery(); // Esecuzione del comando
    }

    public List<string> GetUsers()
    {
        var command = new SQLiteCommand("SELECT nome,cognome,strftime('%d/%m/%Y', dataDiNascita) AS data_formattata,mail FROM dipendente", _connection); // Creazione di un comando per leggere gli utenti
        var reader = command.ExecuteReader(); // Esecuzione del comando e creazione di un oggetto per leggere i risultati
        var users = new List<string>(); // Creazione di una lista per memorizzare i nomi degli utenti
        while (reader.Read())
        {
            string anagrafica = $"{reader.GetString(0)} {reader.GetString(1)} (Data di nascita: {reader.GetString(2)}) - Mail: {reader.GetString(3)}"; // Aggiunta del nome dell'utente alla lista
            users.Add(anagrafica); 
        }
        return users; // Restituzione della lista
    }
}

/*

strftime('%d/%m/%Y', dataDiNascita) AS data_formattata,*/