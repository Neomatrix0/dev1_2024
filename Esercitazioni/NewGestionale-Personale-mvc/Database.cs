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
        "CREATE TABLE IF NOT EXISTS dipendente (id INTEGER PRIMARY KEY, nome TEXT, cognome TEXT, dataDiNascita DATE, mail TEXT,  mansioneId INTEGER,indicatoriId INTEGER,  FOREIGN KEY(mansioneId) REFERENCES mansione(id),FOREIGN KEY(indicatoriId) REFERENCES indicatori(id)) ;", 
        _connection);
    command1.ExecuteNonQuery(); // Esecuzione del comando

    // Creazione della tabella mansione
    var command2 = new SQLiteCommand(
        "CREATE TABLE IF NOT EXISTS mansione (id INTEGER PRIMARY KEY AUTOINCREMENT, titolo TEXT UNIQUE,stipendio REAL);", 
        _connection);
    command2.ExecuteNonQuery(); // Esecuzione del comando

    var command3 = new SQLiteCommand(
        "CREATE TABLE IF NOT EXISTS indicatori (id INTEGER PRIMARY KEY AUTOINCREMENT, fatturato REAL,presenze INTEGER);", 
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
        var command = new SQLiteCommand("INSERT INTO mansione(titolo,stipendio) VALUES (@titolo,@stipendio);SELECT last_insert_rowid()",_connection);
        command.Parameters.AddWithValue("@titolo",mansione.Titolo);
         command.Parameters.AddWithValue("@stipendio",mansione.Stipendio);

          // command.ExecuteNonQuery(); 
           return Convert.ToInt32(command.ExecuteScalar());
           

    }

    public void AggiungiIndicatori(int dipendenteId, double fatturato, int presenze)
{
    // Creare un nuovo record nella tabella `indicatori`
    var commandIndicatori = new SQLiteCommand("INSERT INTO indicatori (fatturato, presenze) VALUES (@fatturato, @presenze); SELECT last_insert_rowid();", _connection);
    commandIndicatori.Parameters.AddWithValue("@fatturato", fatturato);
    commandIndicatori.Parameters.AddWithValue("@presenze", presenze);
    int indicatoriId = Convert.ToInt32(commandIndicatori.ExecuteScalar());

    // Aggiorna il dipendente con il nuovo `indicatoriId`
    var commandDipendente = new SQLiteCommand("UPDATE dipendente SET indicatoriId = @indicatoriId WHERE id = @dipendenteId", _connection);
    commandDipendente.Parameters.AddWithValue("@indicatoriId", indicatoriId);
    commandDipendente.Parameters.AddWithValue("@dipendenteId", dipendenteId);
    commandDipendente.ExecuteNonQuery(); // Esegui l'aggiornamento
}




public void AggiornaIndicatori(int dipendenteId, double nuovoFatturato, int nuovePresenze)
{
    // Aggiorna il record nella tabella `indicatori` collegato al dipendente
    var command = new SQLiteCommand("UPDATE indicatori SET fatturato = @fatturato, presenze = @presenze WHERE id = (SELECT indicatoriId FROM dipendente WHERE id = @dipendenteId)", _connection);
    command.Parameters.AddWithValue("@fatturato", nuovoFatturato);
    command.Parameters.AddWithValue("@presenze", nuovePresenze);
    command.Parameters.AddWithValue("@dipendenteId", dipendenteId);
    command.ExecuteNonQuery(); // Esegui l'aggiornamento
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
/*
public List<Dipendente> GetDipendentiConId()
{
    var command = new SQLiteCommand("SELECT id, nome, cognome, strftime('%d/%m/%Y', dataDiNascita), mail FROM dipendente", _connection);
    var reader = command.ExecuteReader();
    var dipendenti = new List<Dipendente>();

    while (reader.Read())
    {
        // Crea un nuovo oggetto Dipendente per ogni riga letta
        var dipendente = new Dipendente(
            reader.GetString(1),   // Nome
            reader.GetString(2),   // Cognome
            reader.GetString(3),   // Data di Nascita
            reader.GetString(4),   // Mail
            null                   // Mansione (null per ora)
        );

        dipendente.Id = reader.GetInt32(0);  // Imposta l'ID del dipendente

        // Aggiungi il dipendente alla lista
        dipendenti.Add(dipendente);
    }

    return dipendenti;
}
*/

public List<Dipendente> GetUsers()
{
    var command = new SQLiteCommand(
        "SELECT dipendente.nome, dipendente.cognome, strftime('%d/%m/%Y', dataDiNascita) AS data_formattata, dipendente.mail, mansione.titolo, mansione.stipendio, indicatori.fatturato, indicatori.presenze " +
        "FROM dipendente " +
        "JOIN mansione ON dipendente.mansioneId = mansione.id " +
        "LEFT JOIN indicatori ON dipendente.indicatoriId = indicatori.id;", 
        _connection);

    var reader = command.ExecuteReader(); 
    var dipendenti = new List<Dipendente>();

    while (reader.Read())
    {
        // Leggi il titolo e lo stipendio dalla mansione
        var mansione = new Mansione(reader.GetString(4), reader.GetDouble(5));

        // Gestione dei dati nullable per fatturato (double) e presenze (int)
        double fatturato = reader.IsDBNull(6) ? 0.0 : reader.GetDouble(6);  // Usa 0.0 come valore di default se NULL
        int presenze = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);          // Usa 0 come valore di default se NULL

        // Crea un oggetto Statistiche
        var statistiche = new Statistiche(fatturato, presenze);

        // Crea il dipendente
        var dipendente = new Dipendente(
            reader.GetString(0), // Nome
            reader.GetString(1), // Cognome
            reader.GetString(2), // Data di nascita
            reader.GetString(3), // Mail
            mansione,            // Mansione
            statistiche          // Statistiche
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
                 indicatori.fatturato, 
                 indicatori.presenze
          FROM dipendente
          JOIN mansione ON dipendente.mansioneId = mansione.id
          LEFT JOIN indicatori ON dipendente.indicatoriId = indicatori.id 
          WHERE dipendente.mail = @mail;", 
        _connection);

    command.Parameters.AddWithValue("@mail", email);
    var reader = command.ExecuteReader();

    if (reader.Read())
    {
        // Creazione dell'oggetto Mansione con i campi corretti
        var mansione = new Mansione(reader.GetString(4), reader.GetDouble(5));

        // Gestione dei campi indicatori con controlli per i valori NULL
        double fatturato = reader.IsDBNull(6) ? 0.0 : reader.GetDouble(6); // Usa GetDouble per i valori reali
        int presenze = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);        // Usa GetInt32 per valori interi

        // Creazione dell'oggetto Statistiche con fatturato e presenze
        var statistiche = new Statistiche(fatturato, presenze);

        // Creazione dell'oggetto Dipendente
        var dipendente = new Dipendente(
            reader.GetString(0),  // Nome
            reader.GetString(1),  // Cognome
            reader.GetString(2),  // Data di Nascita
            reader.GetString(3),  // Mail
            mansione,             // Mansione
            statistiche           // Statistiche
        );

        return dipendente;
    }

    // Restituisci null se il dipendente non viene trovato
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
        string query = "";
        object indicatoriId = null;  // Dichiarazione esterna di indicatoriId

        // Verifica se stai modificando "fatturato" o "presenze", che appartengono alla tabella `indicatori`
        if (campoDaModificare == "fatturato" || campoDaModificare == "presenze")
        {
            // Prima controlla se l'`indicatoriId` esiste
            var checkCommand = new SQLiteCommand("SELECT indicatoriId FROM dipendente WHERE id = @id", _connection);
            checkCommand.Parameters.AddWithValue("@id", dipendenteId);
            indicatoriId = checkCommand.ExecuteScalar();

            if (indicatoriId == null || indicatoriId == DBNull.Value)
            {
                Console.WriteLine("Errore: Il dipendente non ha un ID indicatori associato.");
                return false;
            }

            // Aggiorna la tabella `indicatori`
            query = $"UPDATE indicatori SET {campoDaModificare} = @nuovoValore WHERE id = @indicatoriId";
        }
        else
        {
            // Aggiorna la tabella `dipendente` per altri campi
            query = $"UPDATE dipendente SET {campoDaModificare} = @nuovoValore WHERE id = @id";
        }

        using (var command = new SQLiteCommand(query, _connection))
        {
            command.Parameters.AddWithValue("@nuovoValore", nuovoValore);
            command.Parameters.AddWithValue("@id", dipendenteId);

            // Aggiungi il parametro indicatoriId solo se necessario
            if (campoDaModificare == "fatturato" || campoDaModificare == "presenze")
            {
                command.Parameters.AddWithValue("@indicatoriId", indicatoriId);
            }

            int rowsAffected = command.ExecuteNonQuery(); // Esegui l'aggiornamento

            if (rowsAffected > 0)
            {
                Console.WriteLine("Aggiornamento riuscito.");
                return true;
            }
            else
            {
                Console.WriteLine("Nessuna riga modificata.");
                return false;
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Errore durante la modifica del dipendente: " + ex.Message);
        return false;
    }
}





}

