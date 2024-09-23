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
        "CREATE TABLE IF NOT EXISTS dipendente (id INTEGER PRIMARY KEY, nome TEXT, cognome TEXT, dataDiNascita DATE, mail TEXT,  mansioneId INTEGER,FOREIGN KEY(mansioneId) REFERENCES mansione(id)) ;", 
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
       AggiungiMansioniPredefinite();
    }

    public void AggiungiDipendente(string nome,string cognome,DateTime dataDiNascita,string mail,int mansioneId)
    {
        var command = new SQLiteCommand($"INSERT INTO dipendente (nome,cognome,dataDiNascita,mail,mansioneId) VALUES (@nome,@cognome,@dataDiNascita,@mail,@mansioneId)", _connection); // Creazione di un comando per inserire un nuovo utente
       command.Parameters.AddWithValue("@nome", nome);
       command.Parameters.AddWithValue("@cognome", cognome);
       command.Parameters.AddWithValue("@dataDiNascita", dataDiNascita.ToString("yyyy-MM-dd"));
       command.Parameters.AddWithValue("@mail", mail);
        command.Parameters.AddWithValue("@mansioneId", mansioneId);
        command.ExecuteNonQuery(); // Esecuzione del comando
    }

    public int AggiungiMansione(Mansione mansione){
        var command = new SQLiteCommand("INSERT INTO mansione(titolo,stipendio) VALUES (@titolo,@stipendio)",_connection);
        command.Parameters.AddWithValue("@titolo",mansione.Titolo);
         command.Parameters.AddWithValue("@stipendio",mansione.Stipendio);

           command.ExecuteNonQuery(); 
           

    }

    private void AggiungiMansioniPredefinite(){

        var mansioni = new List <Mansione>{
            new Mansione("impiegato",20000),
             new Mansione("programmatore",25000),
              new Mansione("dirigente",70000),
              new Mansione("receptionist",15000),
               new Mansione("general manager",120000),
                new Mansione("ceo",4000000)
        };   
         foreach (var mansione in mansioni)
    {

        
        var checkCommand = new SQLiteCommand("SELECT COUNT(*) FROM mansione WHERE titolo = @titolo", _connection);
        checkCommand.Parameters.AddWithValue("@titolo", Mansione.Titolo);
        var count = Convert.ToInt32(checkCommand.ExecuteScalar());

         if (count == 0)
            {
                AggiungiMansione(mansione);
            }

    }
    }

    public List<string> GetUsers()
    {
        var command = new SQLiteCommand("SELECT dipendente.nome,dipendente.cognome,strftime('%d/%m/%Y', dataDiNascita) AS data_formattata,dipendente.mail,mansione.titolo FROM dipendente JOIN MANSIONE mansione ON dipendente.mansioneId =mansione.id;", _connection); // Creazione di un comando per leggere gli utenti
        var reader = command.ExecuteReader(); // Esecuzione del comando e creazione di un oggetto per leggere i risultati
        var users = new List<string>(); // Creazione di una lista per memorizzare i nomi degli utenti
        while (reader.Read())
        {
            string anagrafica = $"{reader.GetString(0)} {reader.GetString(1)} (Data di nascita: {reader.GetString(2)}) - Mail: {reader.GetString(3)} - Mansione: {reader.GetString(4)}"; // Aggiunta dati utente alla lista
            users.Add(anagrafica); 
        }
        return users; // Restituzione della lista
    }

    public List<Mansione>MostraMansioni(){
        var command = new SQLiteCommand("SELECT id, titolo, stipendio FROM mansione;",_connection);
        var reader = command.ExecuteReader(); // Esecuzione del comando e creazione di un oggetto per leggere i risultati
        var mansioni = new List<Mansione>(); // Creazione di una lista per memorizzare i nomi degli utenti
        while (reader.Read())
        {
            // Creazione di un oggetto Mansione e aggiunta alla lista
            var mansione =  new Mansione(reader.GetInt32(0),reader.GetString(1), reader.GetDouble(2)); // Aggiunta dati utente alla lista
            mansioni.Add(mansione); 
        }
        return mansioni; 
    }
}

/*

strftime('%d/%m/%Y', dataDiNascita) AS data_formattata,*/