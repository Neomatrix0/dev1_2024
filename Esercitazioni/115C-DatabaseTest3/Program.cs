﻿using System.Data.SQLite;

class Program
{
    static void Main(string[] args)
    {
        string path = @"database.db"; 
        if (!File.Exists(path)) 
        {
            SQLiteConnection.CreateFile(path); 
            SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;");
            connection.Open(); 
            string sql = @"
                        CREATE TABLE categorie (
                            id INTEGER PRIMARY KEY AUTOINCREMENT, 
                            nome TEXT UNIQUE
                        );
                        
                        CREATE TABLE prodotti (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            nome TEXT UNIQUE, 
                            prezzo REAL, 
                            quantita INTEGER CHECK (quantita >= 0), 
                            id_categoria INTEGER,
                            FOREIGN KEY (id_categoria) REFERENCES categorie(id)
                        );
                        
                        INSERT INTO categorie (nome) VALUES ('gdr');
                        INSERT INTO categorie (nome) VALUES ('rpg');
                        INSERT INTO categorie (nome) VALUES ('action');
                        
                        INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('Skyrim', 50, 10, 1);
                        INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('gta', 60, 10, 2);
                        ";

            SQLiteCommand command = new SQLiteCommand(sql, connection); 
            command.ExecuteNonQuery();
            connection.Close(); 
        }

        while (true)
        {

            Console.WriteLine("1 - Inserisci prodotto");
            Console.WriteLine("2 - Visualizza prodotti");
            Console.WriteLine("3 - Elimina prodotto");
            Console.WriteLine("4 - Modifica prezzo prodotto");
            Console.WriteLine("5 - Inserisci categoria");
            Console.WriteLine("6 - Elimina categoria");
            Console.WriteLine("7 - Visualizza categorie");
            Console.WriteLine("8 - Inserisci prodotto con categoria");
            Console.WriteLine("9 - Ordina prezzo in modo discendente");
            Console.WriteLine("10 - Ordina prezzo in modo crescente");
             Console.WriteLine("0 - Esci");
            Console.WriteLine("Scegli un'opzione:");
            string scelta = Console.ReadLine()!;

            if (scelta == "1")
            {
                InserisciProdotto();
            }
            else if (scelta == "2")
            {
                VisualizzaProdotti();
            }
            else if (scelta == "3")
            {
                EliminaProdotto();
            }
            else if (scelta == "4")
            {
                ModificaPrezzo();
            }
            else if (scelta == "5")
            {
                InserisciCategoria();
            }
            else if (scelta == "6")
            {
                EliminaCategoria();
            }
            else if (scelta == "7")
            {
                VisualizzaCategorie();
            }
            else if (scelta == "8")
            {
                InserisciProdottoConCategoria();
            }

            else if (scelta == "9")
            {
                OrdinaPrezzoDiscendente();
                
            }
            else if (scelta == "10")
            {
                OrdinaPrezzoAscendente();
                
            }

             else if (scelta == "0") 
    {
        Console.WriteLine("Uscita dal programma.");
        break; 
    }  else
    {
        Console.WriteLine("Opzione non valida, riprova.");
    }
        }
    }

    static void InserisciProdotto()
    {
        Console.WriteLine("Inserisci il nome del prodotto:");
        string nome = Console.ReadLine()!;
        Console.WriteLine("Inserisci il prezzo del prodotto:");
        string prezzo = Console.ReadLine()!;
        Console.WriteLine("Inserisci la quantità del prodotto:");
        string quantita = Console.ReadLine()!;
        Console.WriteLine("Inserisci l'id della categoria del prodotto:");
        string id_categoria = Console.ReadLine()!;

        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('{nome}', {prezzo}, {quantita}, {id_categoria})";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    static void VisualizzaProdotti()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = "SELECT prodotti.nome, prodotti.prezzo, prodotti.quantita, categorie.nome AS categoria FROM prodotti INNER JOIN categorie ON prodotti.id_categoria = categorie.id";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"Prodotto: {reader["nome"]}, Prezzo: {reader["prezzo"]}, Quantità: {reader["quantita"]}, Categoria: {reader["categoria"]}");
        }
        connection.Close();
    }

    static void EliminaProdotto()
    {
        Console.WriteLine("Inserisci il nome del prodotto da eliminare:");
        string nome = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"DELETE FROM prodotti WHERE nome = '{nome}'";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    static void ModificaPrezzo()
    {
        Console.WriteLine("Inserisci il nome del prodotto per cui modificare il prezzo:");
        string nome = Console.ReadLine()!;
        Console.WriteLine("Inserisci il nuovo prezzo:");
        string prezzo = Console.ReadLine()!;

        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"UPDATE prodotti SET prezzo = {prezzo} WHERE nome = '{nome}'";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

 
    static void InserisciCategoria()
    {
        Console.WriteLine("Inserisci il nome della nuova categoria:");
        string nomeCategoria = Console.ReadLine()!;

        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"INSERT INTO categorie (nome) VALUES ('{nomeCategoria}')";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        try
        {
            command.ExecuteNonQuery();
            Console.WriteLine("Categoria aggiunta con successo.");
        }
        catch (SQLiteException e)
        {
            Console.WriteLine($"Errore: {e.Message}");
        }
        connection.Close();
    }

   
    static void EliminaCategoria()
    {
        Console.WriteLine("Inserisci il nome della categoria da eliminare:");
        string nomeCategoria = Console.ReadLine()!;

        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"DELETE FROM categorie WHERE nome = '{nomeCategoria}'";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        try
        {
            command.ExecuteNonQuery();
            Console.WriteLine("Categoria eliminata con successo.");
        }
        catch (SQLiteException e)
        {
            Console.WriteLine($"Errore: {e.Message}");
        }
        connection.Close();
    }
    static void VisualizzaCategorie()
    {
            SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
    connection.Open();
    string sql = "SELECT * FROM categorie"; 
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    SQLiteDataReader reader = command.ExecuteReader();

    Console.WriteLine("Categorie disponibili:");
    while (reader.Read())
    {
        Console.WriteLine($"ID: {reader["id"]}, Nome: {reader["nome"]}");
    }

    connection.Close();
    }
    static void InserisciProdottoConCategoria()
{

    Console.WriteLine("Inserisci il nome del prodotto:");
    string nomeProdotto = Console.ReadLine()!;
    
    Console.WriteLine("Inserisci il prezzo del prodotto:");
    string prezzoProdotto = Console.ReadLine()!;
    
    Console.WriteLine("Inserisci la quantità del prodotto:");
    string quantitaProdotto = Console.ReadLine()!;
    
  
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
    connection.Open();
    string sql = "SELECT * FROM categorie";
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    SQLiteDataReader reader = command.ExecuteReader();

    Console.WriteLine("Categorie disponibili:");
    while (reader.Read())
    {
        Console.WriteLine($"ID: {reader["id"]}, Nome: {reader["nome"]}");
    }
    reader.Close();

    
    Console.WriteLine("Vuoi inserire una nuova categoria? (s/n)");
    string scelta = Console.ReadLine()!.ToLower();

    int idCategoria;

    if (scelta == "s")
    {
       
        Console.WriteLine("Inserisci il nome della nuova categoria:");
        string nomeCategoria = Console.ReadLine()!;

        
        string insertCategoriaSql = $"INSERT INTO categorie (nome) VALUES ('{nomeCategoria}')";
        SQLiteCommand insertCategoriaCommand = new SQLiteCommand(insertCategoriaSql, connection);
        insertCategoriaCommand.ExecuteNonQuery();

        
        string getIdCategoriaSql = "SELECT last_insert_rowid()";
        SQLiteCommand getIdCategoriaCommand = new SQLiteCommand(getIdCategoriaSql, connection);
        idCategoria = Convert.ToInt32(getIdCategoriaCommand.ExecuteScalar());
    }
    else
    {
     
        Console.WriteLine("Inserisci l'ID della categoria scelta:");
        idCategoria = Convert.ToInt32(Console.ReadLine());
    }

    
    string insertProdottoSql = $"INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('{nomeProdotto}', {prezzoProdotto}, {quantitaProdotto}, {idCategoria})";
    SQLiteCommand insertProdottoCommand = new SQLiteCommand(insertProdottoSql, connection);
    insertProdottoCommand.ExecuteNonQuery();

    connection.Close();
    Console.WriteLine("Prodotto inserito con successo.");
}

  static void OrdinaPrezzoAscendente(){
             Console.WriteLine("ordina prezzo in ordine crescente");
            
            
            SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
            connection.Open(); 
            string sql = $"SELECT * FROM prodotti ORDER BY prezzo ASC;" ;
            SQLiteCommand command = new SQLiteCommand(sql, connection);
             SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al db e salva i dati in reader che è un oggetto
            while(reader.Read()) {
                Console.WriteLine($"nome: {reader["nome"]}, prezzo: {reader["prezzo"]},quantita:{reader["quantita"]}");
            }
            connection.Close();

        }

  static void OrdinaPrezzoDiscendente(){
             Console.WriteLine("ordina prezzo in ordine crescente");
            
            
            SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
            connection.Open(); 
            string sql = $"SELECT * FROM prodotti ORDER BY prezzo DESC;" ;
            SQLiteCommand command = new SQLiteCommand(sql, connection);
             SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al db e salva i dati in reader che è un oggetto
            while(reader.Read()) {
                Console.WriteLine($"nome: {reader["nome"]}, prezzo: {reader["prezzo"]},quantita:{reader["quantita"]}");
            }
            connection.Close();

        }

}