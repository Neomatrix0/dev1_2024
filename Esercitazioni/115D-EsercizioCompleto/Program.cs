using System.Data.SQLite;
// comando per installare il pacchetto System.Data.SQLite
// dotnet add package System.Data.SQLite

class Program
{
    static void Main(string[] args)
    {
        string path = @"database.db"; // il file deve essere nella stessa cartella del programma
        if (!File.Exists(path))
        {
            SQLiteConnection.CreateFile(path); // crea il file del database se non esiste
            SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"); // crea la connessione al database se non esiste utilizzando il file appena creato versiion identificata dal numero 3
            connection.Open(); // apre la connessione al database se non è già aperta
            string sql = @"
                            CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                            CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, 
                            prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER, 
                            FOREIGN KEY (id_categoria) REFERENCES categorie(id));
                            INSERT INTO categorie (nome) VALUES ('c1');
                            INSERT INTO categorie (nome) VALUES ('c2');
                            INSERT INTO categorie (nome) VALUES ('c3');
                            INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('p1', 1, 10, 1);
                            INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('p2', 2, 20, 2);";

            SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database se non esiste
            command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database se non esiste
            connection.Close(); // chiude la connessione al database se non è già chiusa
        }
        while (true)
        {
            Console.WriteLine("1 - visualizzare i prodotti");
            Console.WriteLine("2 - visualizzare i prodotti ordinati per prezzo");
            Console.WriteLine("3 - visualizzare i prodotti ordinati per quantità");
            Console.WriteLine("4 - modificare il prezzo di un prodotto");
            Console.WriteLine("5 - eliminare un prodotto");
            Console.WriteLine("6 - visualizzare il prodotto più costoso");
            Console.WriteLine("7 - visualizzare il prodotto meno costoso");
            Console.WriteLine("8 - inserire un prodotto");
            Console.WriteLine("9 - visualizzare un prodotto");
            Console.WriteLine("10 - visualizzare i prodotti di una categoria");
            Console.WriteLine("11 - inserire una categoria");
            Console.WriteLine("12 - eliminare una categoria");
            Console.WriteLine("13 - inserire un prodotto in una categoria");
            Console.WriteLine("14 - visualizzare i prodotti con la categoria");
            Console.WriteLine("15 - uscire");
            Console.WriteLine("scegli un'opzione");
            string scelta = Console.ReadLine()!;
            if (scelta == "1")
            {
                VisualizzaProdotti();
            }
            else if (scelta == "2")
            {
                VisualizzaProdottiOrdinatiPerPrezzo();
            }
            else if (scelta == "3")
            {
                VisualizzaProdottiOrdinatiPerQuantita();
            }
            else if (scelta == "4")
            {
                ModificaPrezzoProdotto();
            }
            else if (scelta == "5")
            {
                EliminaProdotto();
            }
            else if (scelta == "6")
            {
                VisualizzaProdottoPiuCostoso();
            }
            else if (scelta == "7")
            {
                VisualizzaProdottoMenoCostoso();
            }
            else if (scelta == "8")
            {
                InserisciProdotto();
            }
            else if (scelta == "9")
            {
                VisualizzaProdotto();
            }
            else if (scelta == "10")
            {
                VisualizzaProdottiCategoria();
            }
            else if (scelta == "11")
            {
                InserisciCategoria();
            }
            else if (scelta == "12")
            {
                EliminaCategoria();
            }
            else if (scelta == "13")
            {
                InserisciProdottoCategoria();
            }
            else if (scelta == "14")
            {
                VisualizzaProdottiAdvanced();
            }
            else if (scelta == "15")
            {
                break;
            }
            else
            {
                Console.WriteLine("scelta non valida");
            }
            /* oppure invece di usare if else if si può usare uno switch
            switch (scelta)
            {
                case "1":
                    VisualizzaProdotti();
                    break;
                case "2":
                    VisualizzaProdottiOrdinatiPerPrezzo();
                    break;
                case "3":
                    VisualizzaProdottiOrdinatiPerQuantita();
                    break;
                case "4":
                    ModificaPrezzoProdotto();
                    break;
                case "5":
                    EliminaProdotto();
                    break;
                case "6":
                    VisualizzaProdottoPiuCostoso();
                    break;
                case "7":
                    VisualizzaProdottoMenoCostoso();
                    break;
                case "8":
                    InserisciProdotto();
                    break;
                case "9":
                    VisualizzaProdotto();
                    break;
                case "10":
                    VisualizzaProdottiCategoria();
                    break;
                case "11":
                    InserisciCategoria();
                    break;
                case "12":
                    EliminaCategoria();
                    break;
                case "13":
                    break;
            }

            */
        }
    }

    static void VisualizzaProdotti()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione di nuovo perché è stata chiusa alla fine del while in modo da poter visualizzare i dati aggiornati
        connection.Open();
        string sql = "SELECT * FROM prodotti"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti
        SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
        SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al database e salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, id_categoria: {reader["id_categoria"]}");
        }
        connection.Close(); // chiude la connessione al database se non è già chiusa
    }

    static void VisualizzaProdottiAdvanced()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();

        // Modifica la query SQL per includere una join con la tabella categorie
        string sql = @"
    SELECT prodotti.id, prodotti.nome, prodotti.prezzo, prodotti.quantita, categorie.nome AS nome_categoria 
    FROM prodotti
    JOIN categorie ON prodotti.id_categoria = categorie.id";

        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, categoria: {reader["nome_categoria"]}");
        }

        connection.Close();
    }

    static void VisualizzaProdottiOrdinatiPerPrezzo()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = "SELECT * FROM prodotti ORDER BY prezzo"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti ordinati per prezzo
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, id_categoria: {reader["id_categoria"]}");
        }
        connection.Close();
    }

    static void VisualizzaProdottiOrdinatiPerQuantita()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = "SELECT * FROM prodotti ORDER BY quantita"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti ordinati per quantita
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, id_categoria: {reader["id_categoria"]}");
        }
        connection.Close();
    }

    static void ModificaPrezzoProdotto()
    {
        Console.WriteLine("inserisci il nome del prodotto"); // chiede il nome del prodotto da modificare
        string nome = Console.ReadLine()!; // legge il nome del prodotto da modificare
        Console.WriteLine("inserisci il nuovo prezzo"); // chiede il nuovo prezzo del prodotto da modificare
        string prezzo = Console.ReadLine()!; // legge il nuovo prezzo del prodotto da modificare
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"UPDATE prodotti SET prezzo = {prezzo} WHERE nome = '{nome}'"; // crea il comando sql che modifica il prezzo del prodotto con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database ExecuteNonQuery() viene utilizzato per eseguire comandi che non restituiscono dati, ad esempio i comandi INSERT, UPDATE, DELETE
        connection.Close();
    }

    static void EliminaProdotto()
    {
        Console.WriteLine("inserisci il nome del prodotto");
        string nome = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"DELETE FROM prodotti WHERE nome = '{nome}'"; // crea il comando sql che elimina il prodotto con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    static void VisualizzaProdottoPiuCostoso()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = "SELECT * FROM prodotti ORDER BY prezzo DESC LIMIT 1"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti ordinati per prezzo in modo decrescente e ne prende solo il primo
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, id_categoria: {reader["id_categoria"]}");
        }
        connection.Close();
    }

    static void VisualizzaProdottoMenoCostoso()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = "SELECT * FROM prodotti ORDER BY prezzo ASC LIMIT 1"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti ordinati per prezzo in modo crescente e ne prende solo il primo
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, id_categoria: {reader["id_categoria"]}");
        }
        connection.Close();
    }

    static void InserisciProdotto()
    {
        Console.WriteLine("inserisci il nome del prodotto");
        string nome = Console.ReadLine()!;
        Console.WriteLine("inserisci il prezzo del prodotto");
        string prezzo = Console.ReadLine()!;
        Console.WriteLine("inserisci la quantità del prodotto");
        string quantita = Console.ReadLine()!;
        Console.WriteLine("inserisci l'id della categoria del prodotto");
        string id_categoria = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('{nome}', {prezzo}, {quantita}, {id_categoria})"; // crea il comando sql che inserisce un prodotto
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    // inserimento di prodotto chiamando prima la categoria e poi il prodotto in modo da avere in inserimento il nome della categoria invece dell id
    static void InserisciProdottoCategoria()
    {
        //visualizza le categorie
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = "SELECT * FROM categorie";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}");
        }
        connection.Close();
        //seleziona categoria
        Console.WriteLine("inserisci l'id della categoria");
        string id_categoria = Console.ReadLine()!;
        //inserisci prodotto
        Console.WriteLine("inserisci il nome del prodotto");
        string nome = Console.ReadLine()!;
        Console.WriteLine("inserisci il prezzo del prodotto");
        string prezzo = Console.ReadLine()!;
        Console.WriteLine("inserisci la quantità del prodotto");
        string quantita = Console.ReadLine()!;
        SQLiteConnection connectionins = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connectionins.Open();
        string sqlins = $"INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('{nome}', {prezzo}, {quantita}, {id_categoria})"; // crea il comando sql che inserisce un prodotto
        SQLiteCommand commandins = new SQLiteCommand(sqlins, connectionins);
        commandins.ExecuteNonQuery();
        connectionins.Close();
    }

    static void VisualizzaProdotto()
    {
        Console.WriteLine("inserisci il nome del prodotto");
        string nome = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"SELECT * FROM prodotti WHERE nome = '{nome}'"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, id_categoria: {reader["id_categoria"]}");
        }
        connection.Close();
    }

    static void VisualizzaProdottiCategoria()
    {
        Console.WriteLine("inserisci l'id della categoria");
        string id_categoria = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"SELECT * FROM prodotti WHERE id_categoria = {id_categoria}"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti con id_categoria uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, id_categoria: {reader["id_categoria"]}");
        }
        connection.Close();
    }

    static void InserisciCategoria()
    {
        Console.WriteLine("inserisci il nome della categoria");
        string nome = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"INSERT INTO categorie (nome) VALUES ('{nome}')"; // crea il comando sql che inserisce una categoria
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    static void EliminaCategoria()
    {
        Console.WriteLine("inserisci il nome della categoria");
        string nome = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"DELETE FROM categorie WHERE nome = '{nome}'"; // crea il comando sql che elimina la categoria con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }
}