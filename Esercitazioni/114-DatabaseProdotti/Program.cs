// comando di installazione del pacchetto SQLite
// dotnet add package System.Data.SQLite 

using System.Data.SQLite;

class Program{
    static void Main(string[] args){
        string path = @"database.db"; //path db
        if(!File.Exists(path)){        //se il file del db non esiste
            SQLiteConnection.CreateFile(path); // crea file database
            SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"); // crea la connessione al db
            connection.Open(); //apre connessione al database
            string sql =@"
            CREATE TABLE prodotti(id INTEGER PRIMARY KEY AUTOINCREMENT,nome TEXT UNIQUE,prezzo REAL, quantita INTEGER CHECK(quantita >=0));
            INSERT INTO prodotti(nome,prezzo,quantita) VALUES('p1',1,10);
            INSERT INTO prodotti(nome,prezzo,quantita) VALUES('p2',2,20);
            INSERT INTO prodotti(nome,prezzo,quantita) VALUES('p3',3,30);
            
            ";

            SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al db
            command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
            connection.Close(); //chiude la connessione al database
        }
        while(true){
            Console.WriteLine("1- inserisci prodotto");
            Console.WriteLine("2- visualizza prodotti");
            Console.WriteLine("3- elimina prodotto");
            Console.WriteLine("4- esci");
            Console.WriteLine("5- aggiungi categoria");
            Console.WriteLine("scegli un opzione");
            string scelta =Console.ReadLine()!;
            if(scelta == "1"){
                InserisciProdotto();
            }
            else if(scelta == "2"){
                VisualizzaProdotti();
            }
            else if(scelta == "3"){
                EliminaProdotto();
            }else if(scelta =="4"){
                break;
            }
            else if (scelta == "5"){
                InserisciCategoria();
            }

        }
    }

        static void InserisciProdotto(){
            Console.WriteLine("Inserisci il nome del prodotto");
            string nome = Console.ReadLine()!;
            Console.WriteLine("inserisci il prezzo del prodotto");
            string prezzo =Console.ReadLine()!;
            Console.WriteLine("inserisci la quantità del prodotto");
            string quantita =Console.ReadLine()!;
             Console.WriteLine("inserisci la categoria del prodotto");
            string categoria =Console.ReadLine()!;
            SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
            connection.Open(); 
            string sql = $"INSERT INTO prodotti(nome,prezzo,quantita,categoria) VALUES('{nome}','{prezzo}','{quantita}','{categoria}')" ;
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        static void VisualizzaProdotti(){
            SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al db
            connection.Open(); // apre la connessione al database
            string sql = "SELECT * FROM prodotti";
            SQLiteCommand command = new SQLiteCommand(sql,connection);
            SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al db e salva i dati in reader che è un oggetto
            while(reader.Read()) {
                Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]},quantita:{reader["quantita"]},categoria:{reader["categoria"]}");
            }
            connection.Close(); // chiude la connessione al database

        }
        static void EliminaProdotto(){
               Console.WriteLine("Inserisci il nome del prodotto");
            string nome = Console.ReadLine()!;
             SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); //crea la connessioneal db 
             connection.Open(); //apre db
             string sql =$"DELETE FROM prodotti WHERE nome= '{nome}'";
              SQLiteCommand command = new SQLiteCommand(sql,connection); // crea il comando sql da eseguire sulla connessione al database
              command.ExecuteNonQuery(); //esegue il comando sql sulla connessione al database
              connection.Close(); //chiude db



        }

        static void InserisciCategoria(){
            Console.WriteLine("Inserisci la categoria");
            string nome = Console.ReadLine()!;
            
            SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
            connection.Open(); 
            string sql = $"ALTER TABLE prodotti ADD COLUMN categoria TEXT;" ;
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();

        }

      //  static void OrdinaPrezzo()


    }


