using Newtonsoft.Json;
using Spectre.Console;
using System.Data.SQLite;

class Program
{

    // crea cartella dipendenti dove verranno messi i file json per ogni dipendente
    static string directoryPath = @"dipendenti/";
    static void Main(string[] args)

    {
        // Creazione del database e delle tabelle, solo se non esistono
        string pathDb = @"database.db";

        if (!File.Exists(pathDb))
        {
            // Crea il file del database se non esiste
            SQLiteConnection.CreateFile(pathDb);


            SQLiteConnection connection = new SQLiteConnection($"Data Source={pathDb};Version=3;");

            connection.Open();

            // Creazione delle tabelle
            string sql = @"
                CREATE TABLE IF NOT EXISTS mansione (
                    id INTEGER PRIMARY KEY AUTOINCREMENT, 
                    titolo TEXT UNIQUE
                );

                CREATE TABLE IF NOT EXISTS dipendente (
                    id INTEGER PRIMARY KEY AUTOINCREMENT, 
                    nome TEXT UNIQUE, 
                    cognome TEXT UNIQUE, 
                    datanascita DATE, 
                    mail TEXT UNIQUE,
                    idMansione INTEGER,
                    idProvenienza INTEGER,
                    FOREIGN KEY (idMansione) REFERENCES mansione(id),
                    FOREIGN KEY (idProvenienza) REFERENCES provenienza(id)
                );

                CREATE TABLE IF NOT EXISTS provenienza (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    provincia TEXT
                );

                -- Inserisci mansioni solo se non esistono
                INSERT OR IGNORE INTO mansione (titolo) VALUES ('impiegato');
                INSERT OR IGNORE INTO mansione (titolo) VALUES ('manager');
                INSERT OR IGNORE INTO mansione (titolo) VALUES ('tecnico');

                -- Inserisci dipendenti di esempio solo se non esistono
                INSERT OR IGNORE INTO dipendente (nome, cognome, datanascita, mail, idMansione,idProvenienza) 
                VALUES ('giacomo', 'berti', '1990-10-21', 'giacomo.berti@gmail.com', 1,1);
                INSERT OR IGNORE INTO dipendente (nome, cognome, datanascita, mail, idMansione,idProvenienza) 
                VALUES ('elena', 'carpi', '1960-10-21', 'elena.carpi@gmail.com', 2,2);

                -- Inserisci provenienze solo se non esistono
                INSERT OR IGNORE INTO provenienza (provincia) VALUES ('genova');
            ";

            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        // Se la cartella per i file JSON non esiste, la crea
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        Console.WriteLine("Benvenuto nel programma di gestione del personale.");


        // se la cartella non esiste la crea

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        Console.WriteLine("Benvenuto nel programma di gestione del personale.");

        // variabile per il menu di spectre console
        var opzione = "";

        do
        {
            Console.Clear();

            // creazione del menu con spectre console
            opzione = AnsiConsole.Prompt(
         new SelectionPrompt<string>()
        .Title("GESTIONALE UTENTI DATABASE")
        .PageSize(9)
        .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
        .AddChoices(new[] {
       /*     "Inserisci dipendente","Visualizza dipendenti","Cerca dipendente",
            "Modifica dipendente","Rimuovi dipendente","Tasso di assenteismo","Valutazione performance","Ordina stipendi","Rapporto stipendio fatturato",*/"Visualizza utenti db","Inserisci utente","Elimina utente",
            "Inserisci nuova provincia di provenienza","Elimina provenienza","Inserisci nuovo tipo di mansione","Visualizzazione totale utenti db","Cerca utente","Modifica utente","Esci",
        }));

            // scelta del tipo di azione da svolgere

            switch (opzione)
            {
                case "Inserisci dipendente":
                    InserisciDipendente();
                    break;
                case "Visualizza dipendenti":
                    VisualizzaDipendenti();
                    break;
                case "Cerca dipendente":
                    CercaDipendente();
                    break;
                case "Modifica dipendente":
                    ModificaDipendente();
                    break;
                case "Rimuovi dipendente":
                    RimuoviDipendente();
                    break;
                case "Tasso di assenteismo":
                    TassoDiAssenteismo();
                    break;
                case "Valutazione performance":

                    ValutazionePerformance();
                    break;
                case "Ordina stipendi":

                    SortStipendio();
                    break;
                case "Rapporto stipendio fatturato":

                    IncidenzaPercentuale();
                    break;
                case "Visualizza utenti db":

                    VisualizzaUtenti();
                    break;
                case "Inserisci utente":
                    InserisciUtente();
                    break;

                case "Elimina utente":
                    EliminaUtente();
                    break;
                    case "Inserisci nuova provincia di provenienza":
                    InserisciProvenienza();
                    break;
                    case "Elimina provenienza":
                    EliminaProvenienza();
                    break;
                     case "Inserisci nuovo tipo di mansione":
                    InserisciMansione();
                    break;
                      case "Visualizzazione totale utenti db":
                    VisualizzaTutto();
                    break;
                       case "Cerca utente":
                    CercaUtente();
                    break;
                        case "Modifica utente":
                   ModificaUtente();
                    break;
                case "Esci":
                    Console.WriteLine("Il programma verrà chiuso. Attendere prego.");
                    break;
                default:
                    Console.WriteLine("Errore di scelta: Prego riprovare");
                    break;
            }

            // se viene scelta l'opzione 9 il programma si chiude altrimenti prosegue

            if (opzione != "Esci")
            {
                Console.WriteLine("\nPremere un tasto per proseguire");
                Console.ReadKey();
            }

        } while (opzione != "Esci");
    }

    // funzione per inserire i dati del dipendente e creare il relativo json

    static void InserisciDipendente()
    {
        do
        {
            try
            {

                Console.WriteLine("Inserisci nome, cognome, data di nascita DD/MM/YYYY,mansione, stipendio,voto performance da 1 a 100 ,giorni di assenze,email,separate da virgola\n");

                // accetta l'input dei dati da console
                string? inserimento = Console.ReadLine();

                // permette l'inserimento di più valori divisi dalla virgola

                string[] dati = inserimento.Split(',');

                if (dati.Length != 8)
                {
                    throw new FormatException("L'input deve contenere esattamente otto valori separati da virgola");
                }

                // formattazione data di nascita
                //ParseExact permette di specificare esattamente come vogliamo il formato  della data converte da stringa a oggetto Datetime

                DateTime dataDiNascita = DateTime.ParseExact(dati[2].Trim(), "dd/MM/yyyy", null);

                //viene riconvertito in stringa
                string dataDiNascitaFormatted = dataDiNascita.ToString("dd/MM/yyyy");

                //  creazione di un oggetto dipendente contenente i dati richiesti dall'applicazione
                var dipendente = new
                {
                    Nome = dati[0].Trim(),
                    Cognome = dati[1].Trim(),
                    DataDiNascita = dataDiNascitaFormatted, //DateTime.Parse(dati[2].Trim()),
                    Mansione = dati[3].Trim(),
                    Stipendio = Convert.ToDecimal(dati[4].Trim()),
                    Performance = Convert.ToInt32(dati[5].Trim()),
                    Assenze = Convert.ToInt32(dati[6].Trim()),
                    Mail = dati[7].Trim(),
                    TimeStamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")
                };

                // serializza l'oggetto in una stringa Json e lo indenta per renderlo più leggibile

                string jsonString = JsonConvert.SerializeObject(dipendente, Formatting.Indented);

                // Path.Combine concatena il path della cartella dipendenti al path dei file json di ogni dipendente
                string filePath = Path.Combine(directoryPath, $"{dipendente.Nome}_{dipendente.Cognome}_{dipendente.TimeStamp}.json");

                //scrive il file

                File.WriteAllText(filePath, jsonString);
            }

            catch (Exception e)
            {
                Console.WriteLine($"ERRORE INSERIMENTO DATI: {e.Message}");     // messaggio eccezione
                Console.WriteLine($"CODICE ERRORE:{e.HResult}");                //codice numerico eccezione
                return;
            }


            // se si svuole terminare l'immissione della registrazione del dipendente basta digitare n

            Console.WriteLine("Vuoi inserire un altro dipendente? (s/n)");
            string? risposta = Console.ReadLine().Trim().ToLower();

            if (risposta == "n")
            {
                break;
            }
        } while (true);


    }
    // funzione per visualizzare tutti i dipendenti con le relative caratteristiche
    static void VisualizzaDipendenti()
    {
        // analizza tutti i file con estensione .json dentro la directoryPath(cartella dipendenti)
        var files = Directory.GetFiles(directoryPath, "*.json");  //

        // verifica se c'è almeno un file per eseguire il codice
        if (files.Length > 0)
        {
            Console.WriteLine("Lista dipendenti completa con tutti i dati:\n");

            // creazione tabella dipendenti


            var table = CreaColonne(new string[] { "Nome", "Cognome", "Data di nascita", "Mansione", "Stipendio annuale", "Performance", "Giorni di assenza", "Email aziendale" });


            // aggiunge nella tabella i dati di tutti i dipendenti presi dai json

            foreach (var file in files)
            {


                var dipendente = LeggiJson(file);


                table.AddRow($"{dipendente.Nome}", $"{dipendente.Cognome}", $"{dipendente.DataDiNascita}", $"{dipendente.Mansione}", $"{dipendente.Stipendio}", $"{dipendente.Performance}", $"{dipendente.Assenze}", $"{dipendente.Mail}");


            }
            var final = files.AsEnumerable().OrderBy(x => x[0]);
            AnsiConsole.Write(table);
        }
        else
        {
            Console.WriteLine("Nessun dipendente nel database.");
        }
    }

    //Visualizza dipendenti per db

    static void VisualizzaUtenti()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione di nuovo perché è stata chiusa alla fine del while in modo da poter visualizzare i dati aggiornati
        connection.Open();
        string sql = "SELECT nome, cognome, strftime('%d/%m/%Y', datanascita) AS data_formattata, mail, idMansione FROM dipendente"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti
        SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
        SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al database e salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
        while (reader.Read())
        {
               Console.WriteLine($"nome: {reader["nome"]}, cognome: {reader["cognome"]}, datanascita: {reader["data_formattata"]}, mail: {reader["mail"]}, idMansione: {reader["idMansione"]}");
            //Console.WriteLine($"nome: {reader["nome"]}, cognome: {reader["cognome"]},datanascita: {reader["datanascita"]},mail: {reader["mail"]} , idMansione:{reader["idMansione"]}");
        }
        connection.Close(); // chiude la connessione al database se non è già chiusa
    }

    static void InserisciUtente()
    {
       SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
       connection.Open();

    
    string sqlMansioni = "SELECT * FROM mansione";
    SQLiteCommand commandMansioni = new SQLiteCommand(sqlMansioni, connection);
    SQLiteDataReader readerMansioni = commandMansioni.ExecuteReader();

    Console.WriteLine("Mansioni disponibili:");
    while (readerMansioni.Read())
    {
        // Mostra ID e titolo della mansione
        Console.WriteLine($"ID: {readerMansioni["id"]}, Mansione: {readerMansioni["titolo"]}");
    }
    readerMansioni.Close();

    // Mostra le provenienze disponibili
    string sqlProvenienze = "SELECT * FROM provenienza";
    SQLiteCommand commandProvenienze = new SQLiteCommand(sqlProvenienze, connection);
    SQLiteDataReader readerProvenienze = commandProvenienze.ExecuteReader();

    Console.WriteLine("Provenienze disponibili:");
     while (readerProvenienze.Read())
    {
        Console.WriteLine($"ID: {readerProvenienze["id"]}, Provincia: {readerProvenienze["provincia"]}");
    }
    readerProvenienze.Close();


        Console.WriteLine("inserisci il nome");
        string nome = Console.ReadLine()!;
        Console.WriteLine("inserisci il cognome");
        string cognome = Console.ReadLine()!;
        Console.WriteLine("inserisci la data di nascita in formato YYYY-MM-DD");
        string datanascita = Console.ReadLine()!;
       //string datanascita = DateTime.Parse(Console.ReadLine()!);
        Console.WriteLine("inserisci la mail");
        string mail = Console.ReadLine()!;
        Console.WriteLine("Inserisci l'id mansione");
        int idMansione = Convert.ToInt32(Console.ReadLine()!.Trim());
         Console.WriteLine("Inserisci l'ID della provenienza:");
         int idProvenienza = Convert.ToInt32(Console.ReadLine()!.Trim());

       // SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
       // connection.Open();
        string sql = $"INSERT INTO dipendente (nome, cognome, datanascita, mail, idMansione,idProvenienza) VALUES ('{nome}', '{cognome}',strftime('%Y-%m-%d', '{datanascita}'), '{mail}',{idMansione},{idProvenienza})"; // crea il comando sql che inserisce un prodotto
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
        Console.WriteLine($"{nome} {cognome} inserito con successo nel database");
    }

    static void VisualizzaTutto()
{
    
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
    connection.Open();

    // Query SQL per ottenere i dati dei dipendenti con le relative mansioni e provenienze
    string sql = @"
        SELECT d.nome, d.cognome, strftime('%d/%m/%Y', d.datanascita) AS data_formattata, d.mail, m.titolo AS mansione, p.provincia 
        FROM dipendente d
        JOIN mansione m ON d.idMansione = m.id
        JOIN provenienza p ON d.idProvenienza = p.id";

    SQLiteCommand command = new SQLiteCommand(sql, connection);
    SQLiteDataReader reader = command.ExecuteReader();

    // Cicla sui risultati e stampa i dati di ogni dipendente
    while (reader.Read())
    {
        
        Console.WriteLine($"Nome: {reader["nome"]}, Cognome: {reader["cognome"]}, Data di nascita: {reader["data_formattata"]}, Email: {reader["mail"]}, Provincia: {reader["provincia"]}, Mansione: {reader["mansione"]}");
    }

    
    reader.Close();
    connection.Close();
}

    static void EliminaUtente()
    {
        Console.WriteLine("inserisci il nome dell'utente da eliminare");
        string nome = Console.ReadLine()!;
        Console.WriteLine("inserisci il cognome dell'utente");
        string cognome = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        
        string sql = $"DELETE FROM dipendente WHERE nome = '{nome}' AND  cognome = '{cognome}'"; // crea il comando sql che elimina il prodotto con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
          Console.WriteLine($"{nome} {cognome} rimosso con successo dal database");
    }

       static void CercaUtente()
{
    Console.WriteLine("Inserisci il nome dell'utente da cercare:");
    string nome = Console.ReadLine()!;

    Console.WriteLine("Inserisci il cognome dell'utente da cercare:");
    string cognome = Console.ReadLine()!;

    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
    connection.Open();

    // Query SQL corretta per cercare il dipendente
    string sql = $@"
        SELECT d.nome, d.cognome, strftime('%d/%m/%Y', d.datanascita) AS data_formattata, d.mail, 
               m.titolo AS mansione, p.provincia
        FROM dipendente d
        JOIN mansione m ON d.idMansione = m.id
        JOIN provenienza p ON d.idProvenienza = p.id
        WHERE d.nome = '{nome}' AND d.cognome = '{cognome}'";

    SQLiteCommand command = new SQLiteCommand(sql, connection);
    SQLiteDataReader reader = command.ExecuteReader();

    // Verifica se ci sono risultati
    if (reader.HasRows)
    {
        while (reader.Read())
        {
            Console.WriteLine($"Nome: {reader["nome"]}, Cognome: {reader["cognome"]}, Data di nascita: {reader["data_formattata"]}, Email: {reader["mail"]}, Mansione: {reader["mansione"]}, Provincia: {reader["provincia"]}");
        }
    }
    else
    {
        Console.WriteLine("Nessun dipendente trovato con il nome e cognome specificati.");
    }

    reader.Close();
    connection.Close();
}


static void InserisciProvenienza()
    {
        Console.WriteLine("inserisci il nome della provincia di provenienza");
        string nome = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"INSERT INTO provenienza (provincia) VALUES ('{nome}')"; // crea il comando sql che inserisce una categoria
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    static void EliminaProvenienza()
    {
        Console.WriteLine("inserisci il nome della provincia");
        string nome = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"DELETE FROM provenienza WHERE provincia = '{nome}'"; // crea il comando sql che elimina la categoria con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    static void InserisciMansione()
    {
        Console.WriteLine("inserisci il nome della mansione da inserire nel database");
        string nome = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"INSERT INTO mansione (titolo) VALUES ('{nome}')"; // crea il comando sql che inserisce una categoria
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    static void ModificaUtente(){
        Console.WriteLine("Scegli il campo da modificare");
        Console.WriteLine("1 - modifica nome");
        Console.WriteLine("2 - modifica cognome");
        Console.WriteLine("3 - cambia mansione");
        Console.WriteLine("4 - cambia mail");
        Console.WriteLine("5 - cambia provenienza");
        int scelta = Convert.ToInt32(Console.ReadLine()!.Trim());  
        switch (scelta) {

            case 1:
            ModificaNomeUtente();
            break;

            case 2:
            ModificaCognomeUtente();
            break;
            case 3:

            ModificaMansioneUtente();

            break;
            case 4:
             ModificaMailUtente();

            break;
            case 5:
             ModificaProvenienzaUtente();

            break;
        }

    }

          static void ModificaMansioneUtente()
    {
          SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
    connection.Open();

          string sqlMansioni = "SELECT * FROM mansione";
    SQLiteCommand commandMansioni = new SQLiteCommand(sqlMansioni, connection);
    SQLiteDataReader reader = commandMansioni.ExecuteReader();

    Console.WriteLine("Id Mansioni disponibili:");
     while (reader.Read())
    {
        Console.WriteLine($"ID: {reader["id"]}, Mansione: {reader["titolo"]}");
    }
    reader.Close();

        Console.WriteLine("inserisci il nome dell'utente di cui cambiare mansione"); 
        string nome = Console.ReadLine()!;
        Console.WriteLine("inserisci il cognome dell'utente di cui cambiare mansione");
        string cognome = Console.ReadLine()!;
        Console.WriteLine("inserisci l'id della nuova mansione scegliendo tra quelli disponibili"); 
        int mansioneId= Convert.ToInt32(Console.ReadLine())!; 
      
        string sql = $"UPDATE dipendente SET idMansione = {mansioneId}  WHERE nome = '{nome}' AND cognome = '{cognome}'"; // crea il comando sql che modifica il prezzo del prodotto con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database ExecuteNonQuery() viene utilizzato per eseguire comandi che non restituiscono dati, ad esempio i comandi INSERT, UPDATE, DELETE
        connection.Close();
        Console.WriteLine($"L'utente {nome} {cognome} ha cambiato mansione con successo");
    }

    static void ModificaNomeUtente(){
        Console.WriteLine("inserisci il nome dell'utente che vuoi modificare"); 
        string nome = Console.ReadLine()!;
        Console.WriteLine("inserisci il cognome dell'utente");
        string cognome = Console.ReadLine()!;
         Console.WriteLine("inserisci il nuovo nome dell'utente"); 
        string nuovoNome = Console.ReadLine()!;
         SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"UPDATE dipendente SET nome = '{nuovoNome}' WHERE nome = '{nome}' AND cognome = '{cognome}'"; // crea il comando sql che modifica il prezzo del prodotto con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database ExecuteNonQuery() viene utilizzato per eseguire comandi che non restituiscono dati, ad esempio i comandi INSERT, UPDATE, DELETE
        connection.Close();

        Console.WriteLine($"Utente {nome} {cognome} ha cambiato il nome in {nuovoNome} con successo");


    }

      static void ModificaCognomeUtente(){
        Console.WriteLine("inserisci il nome dell'utente che vuoi modificare"); 
        string nome = Console.ReadLine()!;
        Console.WriteLine("inserisci il cognome dell'utente");
        string cognome = Console.ReadLine()!;
         Console.WriteLine("inserisci il nuovo cognome dell'utente"); 
        string nuovoCognome = Console.ReadLine()!;
         SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"UPDATE dipendente SET cognome = '{nuovoCognome}' WHERE nome = '{nome}' AND cognome = '{cognome}'"; // crea il comando sql che modifica il prezzo del prodotto con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database ExecuteNonQuery() viene utilizzato per eseguire comandi che non restituiscono dati, ad esempio i comandi INSERT, UPDATE, DELETE
        connection.Close();

        Console.WriteLine($"Utente {nome} {cognome} ha cambiato il cognome in {nuovoCognome} con successo");


    }

       static void ModificaMailUtente(){
        Console.WriteLine("inserisci il nome dell'utente per cui vuoi modificare la mail"); 
        string nome = Console.ReadLine()!;
        Console.WriteLine("inserisci il cognome dell'utente");
        string cognome = Console.ReadLine()!;
         Console.WriteLine("inserisci la nuova mail aziendale dell'utente"); 
        string nuovaMail = Console.ReadLine()!;
         SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"UPDATE dipendente SET mail = '{nuovaMail}' WHERE nome = '{nome}' AND cognome = '{cognome}'"; // crea il comando sql che modifica il prezzo del prodotto con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database ExecuteNonQuery() viene utilizzato per eseguire comandi che non restituiscono dati, ad esempio i comandi INSERT, UPDATE, DELETE
        connection.Close();

        Console.WriteLine($"Utente {nome} {cognome} ha cambiato la mail in {nuovaMail} con successo");


    }

 static void ModificaProvenienzaUtente(){
       
          SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
    connection.Open();

          string sqlMansioni = "SELECT * FROM provenienza";
    SQLiteCommand commandMansioni = new SQLiteCommand(sqlMansioni, connection);
    SQLiteDataReader reader = commandMansioni.ExecuteReader();

    Console.WriteLine("Id città disponibili:");
     while (reader.Read())
    {
        Console.WriteLine($"ID: {reader["id"]}, Provincia: {reader["provincia"]}");
    }
    reader.Close();

        Console.WriteLine("inserisci il nome dell'utente di cui cambiare la città di provenienza"); 
        string nome = Console.ReadLine()!;
        Console.WriteLine("inserisci il cognome dell'utente");
        string cognome = Console.ReadLine()!;
        Console.WriteLine("inserisci l'id della nuova provenienza scegliendo tra quelli disponibili"); 
        int provenienzaId= Convert.ToInt32(Console.ReadLine())!; 
      
        string sql = $"UPDATE dipendente SET idProvenienza = {provenienzaId}  WHERE nome = '{nome}' AND cognome = '{cognome}'"; // crea il comando sql che modifica il prezzo del prodotto con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database ExecuteNonQuery() viene utilizzato per eseguire comandi che non restituiscono dati, ad esempio i comandi INSERT, UPDATE, DELETE
        connection.Close();
        Console.WriteLine($"L'utente {nome} {cognome} ha cambiato provenienza con successo");
    }



 

    // metodo per cercare il dipendente inserendo nome,cognome
    static void CercaDipendente()
    {
        try
        {
            Console.Clear();
            // cerca i file JSON corrispondenti al nome e cognome forniti dall'utente e ne ritorna il path 
            string filePath = RicercaJson(out string nome, out string cognome);

            if (filePath != null)
            {
                var table = CreaTabella(filePath);
                AnsiConsole.Write(table);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Errore non trattato: {e.Message}");
            Console.WriteLine($"CODICE ERRORE: {e.HResult}");
        }
    }

    //cerca dipendente per nome,cognome e poi modifica le caratteristiche del dipendente a scelta

    static void ModificaDipendente()
    {
        try
        {
            string filePath = RicercaJson(out string nome, out string cognome);

            if (filePath != null)
            {
                var lavoratore = LeggiJson(filePath);
                var inserimento = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("MODIFICA DIPENDENTE")
                    .PageSize(8)
                    .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
                    .AddChoices(new[] {
                    "Cambia nome","Cambia cognome","Cambia data di nascita formato DD/MM/YYYY",
                    "Cambia mansione","Cambia stipendio","Cambia punteggio performance","Cambia giorni di assenze","Cambia mail","Esci",
                    }));

                switch (inserimento)
                {
                    case "Cambia nome":
                        Console.WriteLine("Inserici il nuovo nome");
                        lavoratore.Nome = Console.ReadLine().Trim();
                        break;
                    case "Cambia cognome":
                        Console.WriteLine("Inserici il nuovo cognome");
                        lavoratore.Cognome = Console.ReadLine().Trim();
                        break;
                    case "Cambia data di nascita formato DD/MM/YYYY":
                        Console.WriteLine("Inserisci nuova data di nascita");
                        lavoratore.DataDiNascita = DateTime.ParseExact(Console.ReadLine().Trim(), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
                        break;
                    case "Cambia mansione":
                        Console.WriteLine("Inserisci nuova mansione");
                        lavoratore.Mansione = Console.ReadLine().Trim();
                        break;
                    case "Cambia stipendio":
                        Console.WriteLine("Inserisci nuovo stipendio");
                        lavoratore.Stipendio = Convert.ToDecimal(Console.ReadLine());
                        break;
                    case "Cambia punteggio performance":
                        Console.WriteLine("Inserisci nuovo punteggio performance");
                        lavoratore.Performance = Convert.ToInt32(Console.ReadLine());
                        break;
                    case "Cambia giorni di assenze":
                        Console.WriteLine("Modifica giorni di assenze");
                        lavoratore.Assenze = Convert.ToInt32(Console.ReadLine());
                        break;
                    case "Cambia mail":
                        Console.WriteLine("Inserisci il nuovo indirizzo email aziendale");
                        lavoratore.Mail = Console.ReadLine().Trim();
                        break;
                    case "Esci":
                        Console.WriteLine("\nL'applicazione si sta per chiudere\n");
                        return;
                    default:
                        Console.WriteLine("\nScelta errata. Prego scegliere tra le opzioni disponibili 1-8\n");
                        return;
                }

                string newFilePath = Path.Combine(directoryPath, $"{lavoratore.Nome}_{lavoratore.Cognome}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.json");
                string jsonString = JsonConvert.SerializeObject(lavoratore, Formatting.Indented);

                File.Delete(filePath);
                File.WriteAllText(newFilePath, jsonString);

                Console.WriteLine("Dipendente aggiornato con successo.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Errore non trattato: {e.Message}");
            Console.WriteLine($"CODICE ERRORE: {e.HResult}");
        }
    }


    // metodo per rimuovere il dipendente e il relativo file json inserendo nome,cognome nella console
    static void RimuoviDipendente()
    {
        try
        {
            string filePath = RicercaJson(out string nome, out string cognome);

            if (filePath != null)
            {
                File.Delete(filePath);
                Console.WriteLine("Dipendente rimosso con successo.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Errore durante la rimozione del dipendente: {e.Message}");
            Console.WriteLine($"CODICE ERRORE: {e.HResult}");
        }
    }


    //metodo per ordinare gli stipendi dal più alto al più basso e vedere alcuni  dati del dipendente

    static void SortStipendio()
    {
        var dipendenti = GetDipendenti();

        // algoritmo bubblesort modificato per ordinare il dato dello stipendio in ordine discendente 
        for (int i = 0; i < dipendenti.Count - 1; i++)
        {
            for (int j = 0; j < dipendenti.Count - i - 1; j++)
            {
                if (dipendenti[j].Stipendio < dipendenti[j + 1].Stipendio)
                {
                    var temp = dipendenti[j];
                    dipendenti[j] = dipendenti[j + 1];
                    dipendenti[j + 1] = temp;
                }


            }
        }

        var table = CreaColonne(new string[] { "Dipendente", "Stipendio", "Performance" });

        Console.WriteLine("\nDipendenti ordinati per stipendio in ordine discendente:\n");

        foreach (var dipendente in dipendenti)
        {
            table.AddRow($"{dipendente.Nome} {dipendente.Cognome}", $"{dipendente.Stipendio}", $"{dipendente.Performance}");

        }

        AnsiConsole.Write(table);
    }


    // metodo che calcola il tasso di assenteismo su un totale di 250 giorni lavorativi l'anno
    static void TassoDiAssenteismo()
    {
        Console.WriteLine("\nDi seguito l'elenco con il tasso di assenteismo per ogni dipendente su 250 giorni lavorativi equivalente ad 1 anno\n");
        int giorniLavorativiTotali = 250;

        try
        {
            var dipendenti = GetDipendenti();


            // tabella 

            var table = CreaColonne(new string[] { "Dipendente", "Tasso di assenteismo" });


            // reverse- modificato la funzione sort in modo da  ordinare i dipendenti dal tasso di assenteismo più alto al più basso

            dipendenti.Sort((y, x) => x.Assenze.CompareTo(y.Assenze));

            foreach (var dipendente in dipendenti)

            {
                int assenze = dipendente.Assenze;


                double assenteismo = ((double)assenze / giorniLavorativiTotali) * 100;     // calcolo del tasso di assenteismo
                double tassoAssenteismo = Math.Round(assenteismo, 2);

                table.AddRow($"{dipendente.Nome} {dipendente.Cognome}", $"{tassoAssenteismo}%");


            }

            AnsiConsole.Write(table);

            // Tasso di assenteismo = [(giorni di assenza non giustificate) / (giorni totali di lavoro)] x 100.


        }
        catch (Exception e)
        {
            Console.WriteLine($"Errore generale: {e.Message}");
        }

    }

    //metodo che  legge il file json e lo deserializza
    static dynamic LeggiJson(string filePath)
    {

        string jsonRead = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<dynamic>(jsonRead);
    }

    // metodo per ordinare i dipendenti in base alle performance dividendoli in 2 gruppi in base al punteggio 
    static void ValutazionePerformance()
    {
        var dipendenti = GetDipendenti();

        Console.WriteLine("\nDivide i dipendendenti in 2 gruppi in base al rendimento");

        // ordina dipendenti per performance

        for (int i = 0; i < dipendenti.Count - 1; i++)
        {
            for (int j = 0; j < dipendenti.Count - i - 1; j++)
            {
                if (dipendenti[j].Performance < dipendenti[j + 1].Performance)
                {
                    var temp = dipendenti[j];
                    dipendenti[j] = dipendenti[j + 1];
                    dipendenti[j + 1] = temp;
                }

            }

        }

        // divide i dipendenti in 2 gruppi.Nel primo vengono inseriti quelli con le performance migliori

        int split = dipendenti.Count / 2;
        List<dynamic> squadra1 = dipendenti.GetRange(0, split);
        List<dynamic> squadra2 = dipendenti.GetRange(split, dipendenti.Count - split);

        // aggiunto tabella dipendenti con performance migliori


        var table = CreaColonne(new string[] { "Dipendente", "Performance" });

        // aggiunto tabella dipendenti con performance inferiori

        var table2 = CreaColonne(new string[] { "Dipendente", "Performance" });

        // aggiunto tabella dipendenti con performance inferiori gli ultimi 15%


        var table3 = CreaColonne(new string[] { "Dipendente", "Performance" });


        // aggiunge nella tabella i dati del dipendente mettendo in evidenza le performance
        // in squadra1 vengono messi i migliori

        foreach (var impiegato in squadra1)
        {
            table.AddRow($"{impiegato.Nome} {impiegato.Cognome}", $"{impiegato.Performance}");

        }

        foreach (var impiegato in squadra2)
        {
            table2.AddRow($"{impiegato.Nome} {impiegato.Cognome}", $"{impiegato.Performance}");


        }

        Console.WriteLine("\nGruppo con le performance più alte:\n");

        AnsiConsole.Write(table);
        Console.WriteLine("\nGruppo con le performance più basse:\n");
        AnsiConsole.Write(table2);

        // ordina i valori

        squadra2.Sort((x, y) => x.Performance.CompareTo(y.Performance));

        // formula per trovare il 15% dei risultati più bassi

        int index = (15 * squadra2.Count) / 100;

        // Se il 15% è 0.5 o più, arrotonda per eccesso a 1
        if (index == 0 && squadra2.Count > 0)
        {
            index = 1;
        }

        // stampa il 15% dei risultati peggiori

        for (int i = 0; i < index; i++)
        {
            var membro = squadra2[i];
            table3.AddRow($"{membro.Nome} {membro.Cognome}", $"Performance: {membro.Performance}\n");
        }

        Console.WriteLine("\nDi seguito il 15% delle performance peggiori\n");
        AnsiConsole.Write(table3);

    }

    // funzione che calcola l'incidenza percentuale dello stipendio in rapporto al fatturato
    static void IncidenzaPercentuale()
    {
        string fileTxt = "fatturato.txt";

        double fatturato;

        if (!File.Exists(fileTxt))
        {
            Console.WriteLine("Inserisci fatturato");
            fatturato = Convert.ToDouble(Console.ReadLine());
            File.WriteAllText(fileTxt, fatturato.ToString());


        }
        else
        {
            string[] lines = File.ReadAllLines(fileTxt);
            if (lines.Length == 0)
            {
                // Se il file è vuoto o il contenuto non è valido, chiede il fatturato all'utente
                Console.WriteLine("Inserisci fatturato");
                //converte fatturato in decimale
                fatturato = Convert.ToDouble(Console.ReadLine());
                //scrive valori sul file txt convertendolo in stringa
                File.WriteAllText(fileTxt, fatturato.ToString());
            }
            else
            {
                fatturato = Convert.ToDouble(lines[0]);     // converte in double per i calcoli
            }
        }


        var dipendenti = GetDipendenti();

        // creazione tabella 

        var table = CreaColonne(new string[] { "Nome", "Cognome", "Data di nascita", "Mansione", "Stipendio", "Incidenza stipendio lordo sul fatturato", "Performance", "Giorni di assenze" });

        dipendenti.Sort((y, x) => x.Stipendio.CompareTo(y.Stipendio));

        foreach (var dipendente in dipendenti)

        {
            double stipendio = Convert.ToDouble(dipendente.Stipendio);

            //formula Incidenza percentuale : (Cifra Inferiore / Cifra Superiore) X 100

            double costoPersonale = (stipendio / fatturato) * 100;     // calcolo del tasso d'incidenza
            double costoPercentuale = Math.Round(costoPersonale, 2);   // limite 2 cifre decimali

            //Console.WriteLine($"{dipendente.Nome} {dipendente.Cognome} {dipendente.Stipendio} {costoPercentuale}% {dipendente.Performance}");
            table.AddRow($"{dipendente.Nome}", $"{dipendente.Cognome}", $"{dipendente.DataDiNascita}", $"{dipendente.Mansione}", $"{dipendente.Stipendio}", $"{costoPercentuale}%", $"{dipendente.Performance}", $"{dipendente.Assenze}");

        }
        AnsiConsole.Write(table);
    }



    // metodo che consente di aggiungere alla lista dinamica i dipendenti dei file json
    static List<dynamic> GetDipendenti()
    {
        // prende in considerazione tutti i file di estensione .json

        var files = Directory.GetFiles(directoryPath, "*.json");
        // creazione di una lista di tipo dynamic permette poi di manipolare gli oggetti deserializzati da JSON 
        List<dynamic> dipendenti = new List<dynamic>();
        //cicla dentro la directory dipendenti scorrendo tutti i file e aggiungendo i dipendenti alla lista

        foreach (var file in files)
        {
            var dipendente = LeggiJson(file);
            dipendenti.Add(dipendente);
        }

        return dipendenti;
    }
    // metodo per creare la tabella con spectre console in modo da visualizzare tutti i dati del dipendente
    static dynamic CreaTabella(string filePath)
    {
        var dipendente = LeggiJson(filePath);

        var table = CreaColonne(new string[] { "Nome", "Cognome", "Data di nascita", "Mansione", "Stipendio annuale", "Performance", "Giorni di assenza", "Email aziendale" });

        table.AddRow($"{dipendente.Nome}", $"{dipendente.Cognome}", $"{dipendente.DataDiNascita}", $"{dipendente.Mansione}", $"{dipendente.Stipendio}", $"{dipendente.Performance}", $"{dipendente.Assenze}", $"{dipendente.Mail}");

        return table;
    }

    // metodo per creare le colonne delle tabelle con Spectre console
    static Table CreaColonne(string[] colonne)
    {
        var table = new Table().Border(TableBorder.Square);

        foreach (string colonna in colonne)
        {
            table.AddColumn(new TableColumn(colonna).Centered());

        }
        return table;
    }



    static string RicercaJson(out string nome, out string cognome)
    {
        // Prompt nome cognome
        GetNomeCognome(out nome, out cognome);

        // pattern di ricerca per il file json
        string searchPattern = $"{nome}_{cognome}_*.json";

        // prende files corrispondenti dalla directory
        var matchingFiles = Directory.GetFiles(directoryPath, searchPattern);

        // Controlla corrispondenza pattern del file
        if (matchingFiles.Length == 0)
        {
            Console.WriteLine("Dipendente non trovato");
            return null;
        }

        // Select(Path.GetFileName) estrae i nomi di ogni file json dal path e poi li converte in una lista per poi usarli nel menu
        var fileNames = matchingFiles.Select(Path.GetFileName).ToList();

        // Menu di scelta del file per l'utente
        var selectedFile = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Seleziona il file del dipendente:")
            .PageSize(10)
            .AddChoices(fileNames)); // contiene i nomi dei file json trovati nella directory che corrispondono al pattern di ricerca.

        // Ritorna path completo del file scelto.Questo percorso può poi essere utilizzato dal programma per leggere, modificare o cancellare il file.
        return Path.Combine(directoryPath, selectedFile);
    }


    //metodo per inserire l'input da console nome,cognome
    static void GetNomeCognome(out string nome, out string cognome)
    {
        // while utilizzato per ripetere la richiesta di input fino a quando l'utente inserisce dati validi.

        while (true)
        {
            Console.WriteLine("\nInserisci nome e cognome del dipendente separati da virgola");
            var inserisciNome = Console.ReadLine();
            var nomi = inserisciNome.Split(',');

            if (nomi.Length == 2)
            {
                nome = nomi[0].Trim();
                cognome = nomi[1].Trim();
                return;
            }
            else
            {
                Console.WriteLine("L'input deve contenere esattamente due valori separati da virgola: nome e cognome.");
            }
        }
    }

}