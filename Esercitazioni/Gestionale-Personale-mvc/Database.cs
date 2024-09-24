using System.Data.SQLite;
using Spectre.Console;
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
        "CREATE TABLE IF NOT EXISTS dipendente (id INTEGER PRIMARY KEY, nome TEXT, cognome TEXT, dataDiNascita DATE, mail TEXT,  mansioneId INTEGER,statisticheId INTEGER,  FOREIGN KEY(mansioneId) REFERENCES mansione(id),FOREIGN KEY(statisticheId) REFERENCES statistiche(id)) ;", 
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

    public void AggiungiDipendente(string nome,string cognome,DateTime dataDiNascita,string mail,int mansioneId,Statistiche statistiche)
    {
        var command = new SQLiteCommand($"INSERT INTO dipendente (nome,cognome,dataDiNascita,mail,mansioneId,@statisticheId) VALUES (@nome,@cognome,@dataDiNascita,@mail,@mansioneId,@statisticheId)", _connection); // Creazione di un comando per inserire un nuovo utente
       command.Parameters.AddWithValue("@nome", nome);
       command.Parameters.AddWithValue("@cognome", cognome);
       command.Parameters.AddWithValue("@dataDiNascita", dataDiNascita.ToString("yyyy-MM-dd"));
       command.Parameters.AddWithValue("@mail", mail);
        command.Parameters.AddWithValue("@mansioneId", mansioneId);
        command.Parameters.AddWithValue("@statisticheId", statisticheId);
        command.ExecuteNonQuery(); // Esecuzione del comando
    }

    public int AggiungiMansione(Mansione mansione){
        var command = new SQLiteCommand("INSERT INTO mansione(titolo,stipendio) VALUES (@titolo,@stipendio);SELECT last_insert_rowid()",_connection);
        command.Parameters.AddWithValue("@titolo",mansione.Titolo);
         command.Parameters.AddWithValue("@stipendio",mansione.Stipendio);

          // command.ExecuteNonQuery(); 
           return Convert.ToInt32(command.ExecuteScalar());
           

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
        checkCommand.Parameters.AddWithValue("@titolo", mansione.Titolo);
        var count = Convert.ToInt32(checkCommand.ExecuteScalar());

         if (count == 0)
            {
                AggiungiMansione(mansione);
            }

    }
    }

    public bool RimuoviDipendente(int dipendenteId){
        var command = new SQLiteCommand("DELETE from dipendente WHERE id= @id", _connection); 
        command.Parameters.AddWithValue("@id", dipendenteId);// continuare
        int affectedRows = command.ExecuteNonQuery(); // Restituisce il numero di righe interessate
    return affectedRows > 0;
    
    }

    public List<string> GetDipendentiConId()
{
    var command = new SQLiteCommand("SELECT id, nome, cognome FROM dipendente", _connection);
    var reader = command.ExecuteReader();
    var dipendenti = new List<string>();

    while (reader.Read())
    {
        string info = $"ID: {reader.GetInt32(0)}, Nome: {reader.GetString(1)}, Cognome: {reader.GetString(2)}";
        dipendenti.Add(info);
    }

    return dipendenti;
}

public List<Dipendente> GetUsers()
{
    var command = new SQLiteCommand(
        "SELECT dipendente.nome, dipendente.cognome, strftime('%d/%m/%Y', dataDiNascita) AS data_formattata, dipendente.mail, mansione.titolo, mansione.stipendio, statistiche.performance, statistiche.assenze " +
        "FROM dipendente " +
        "JOIN mansione ON dipendente.mansioneId = mansione.id " +
        "LEFT JOIN statistiche ON dipendente.statisticheId = statistiche.id;",  // Modificato per prendere le statistiche dal dipendente
        _connection);

    var reader = command.ExecuteReader(); 
    var dipendenti = new List<Dipendente>();

    while (reader.Read())
    {
        // Lettura delle statistiche
        var statistiche = new Statistiche(
            reader.IsDBNull(6) ? 0 : reader.GetInt32(6),  // Performance
            reader.IsDBNull(7) ? 0 : reader.GetInt32(7)   // Assenze
        );

        // Creazione del dipendente
        var dipendente = new Dipendente(
            reader.GetString(0), // Nome
            reader.GetString(1), // Cognome
            reader.GetString(2), // Data di nascita
            reader.GetString(4), // Mansione
            reader.GetString(3), // Mail
            reader.GetDouble(5), // Stipendio
            statistiche          // Oggetto Statistiche
        );

        dipendenti.Add(dipendente);
    }

    return dipendenti;
}



public Dipendente CercaDipendentePerMail(string email)
{
    var command = new SQLiteCommand(
        @"SELECT dipendente.nome, 
                 dipendente.cognome, 
                 strftime('%d/%m/%Y', dataDiNascita) AS data_formattata, 
                 dipendente.mail, 
                 mansione.titolo, 
                 mansione.stipendio, 
                 statistiche.performance, 
                 statistiche.assenze 
          FROM dipendente
          JOIN mansione ON dipendente.mansioneId = mansione.id
          LEFT JOIN statistiche ON mansione.statisticheId = statistiche.id 
          WHERE dipendente.mail = @mail;", 
        _connection);

    command.Parameters.AddWithValue("@mail", email);
    var reader = command.ExecuteReader();

    if (reader.Read())
    {
        var statistiche = new Statistiche(
            reader.IsDBNull(6) ? 0 : reader.GetInt32(6),  // Performance
            reader.IsDBNull(7) ? 0 : reader.GetInt32(7)   // Assenze
        );

        var dipendente = new Dipendente(
            reader.GetString(0),  // Nome
            reader.GetString(1),  // Cognome
            reader.GetString(2),  // Data di Nascita
            reader.GetString(4),  // Mansione
            reader.GetString(3),  // Mail
            reader.GetDouble(5),  // Stipendio
            statistiche           // Statistiche
        );

        return dipendente;
    }

    return null;
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

 public bool ModificaDipendente(int dipendenteId, string campoDaModificare, string nuovoValore)
{
    try
    {
        // Prepara la query di aggiornamento
        string query = $"UPDATE dipendente SET {campoDaModificare} = @nuovoValore WHERE id = @id";

        using (var command = new SQLiteCommand(query, _connection))
        {
            command.Parameters.AddWithValue("@nuovoValore", nuovoValore);
            command.Parameters.AddWithValue("@id", dipendenteId);

            // Esegui l'aggiornamento e controlla il numero di righe modificate
            int rowsAffected = command.ExecuteNonQuery();
            
            // Restituisci true se almeno una riga è stata modificata
            return rowsAffected > 0;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Errore durante la modifica del dipendente: " + ex.Message);
        return false;
    }
}

public int AggiungiStatistiche(Statistiche statistiche){
    var command = new SQLiteCommand("INSERT INTO statistiche (performance, assenze) VALUES (@performance, @assenze); SELECT last_insert_rowid();",_connection);
     command.Parameters.AddWithValue("@performance", statistiche.performance);
            command.Parameters.AddWithValue("@assenze", statistiche.assenze);
            return Convert.ToInt32(command.ExecuteScalar()); // Restituisce l'ID della statistica appena aggiunta
}

public bool ModificaStatistiche(int dipendenteId, string campo, string nuovoValore)
{
    try
    {
        // Trova l'ID delle statistiche per il dipendente
        var command = new SQLiteCommand("SELECT statisticheId FROM dipendente WHERE id = @id", _connection);
        command.Parameters.AddWithValue("@id", dipendenteId);
        var statisticheId = Convert.ToInt32(command.ExecuteScalar());

        // Aggiorna il campo nelle statistiche
        var updateCommand = new SQLiteCommand($"UPDATE statistiche SET {campo} = @nuovoValore WHERE id = @id", _connection);
        updateCommand.Parameters.AddWithValue("@nuovoValore", nuovoValore);
        updateCommand.Parameters.AddWithValue("@id", statisticheId);

        int rowsAffected = updateCommand.ExecuteNonQuery();
        return rowsAffected > 0;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Errore durante la modifica delle statistiche: " + ex.Message);
        return false;
    }
}




}

