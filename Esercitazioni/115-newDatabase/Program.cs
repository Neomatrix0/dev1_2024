//dotnet add package System.Data.SQLite

using System.Data.SQLite;

class Program{
    static void Main(string[] args){
        string path = @"database.db";
        if (!File.Exists(path)){
            SQLiteConnection.CreateFile(path);
            SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;version=3;");
            connection.Open();
            string sql = @"
                        CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                        CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL,
                        quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER,
                        foreign key (id_categoria) REFERENCES categorie(id));
                        INSERT INTO categorie (nome) VALUES ('c1');
                        INSERT INTO categorie (nome) VALUES ('c2');
                        INSERT INTO categorie (nome) VALUES ('c3');
                        INSERT INTO prodotti (nome,prezzo,quantita,id_categoria) VALUES ('p1',1,10,1);
                        INSERT INTO prodotti (nome,prezzo,quantita,id_categoria) VALUES ('p2',2,20,2);
                        INSERT INTO prodotti (nome,prezzo,quantita,id_categoria) VALUES ('p3',3,30,3);
                        ";
            SQLiteCommand command = new SQLiteCommand(sql, connection); 
            command.ExecuteNonQuery();
            connection.Close();
        }

        while(true){
            Console.Clear();
            Console.WriteLine("1 - Inserisci Prodotto: ");
            Console.WriteLine("2 - Visualizza Prodotti: ");
            Console.WriteLine("3 - Visualizza Categorie: ");
            Console.WriteLine("4 - Modifica nome Prodotto: ");
            Console.WriteLine("5 - Modifica prezzo Prodotto: ");
            Console.WriteLine("6 - Modifica quantità Prodotto: ");
            Console.WriteLine("7 - Visualizza Prodotto più caro: ");
            Console.WriteLine("8 - Visualizzare un prodotto: ");
            Console.WriteLine("9 - Inserisci categoria: ");
            Console.WriteLine("10 - Elimina categoria: ");
            Console.WriteLine("11 - Elimina Prodotto: ");
            Console.WriteLine("12 - Esci: ");
            Console.WriteLine("Scegli un opzione");
            int scelta = Convert.ToInt32(Console.ReadLine());
            switch(scelta){
                case 1:
                    InserisciProdottoCategoria();
                    break;
                case 2: 
                    VisualizzaProdotti();
                    break;
                case 3:
                    VisualizzaCategorie(); 
                    break;
                case 4: case 5:case 6:
                    ModificaProdotto(scelta);
                    break;
                case 7:
                    VisualizzaProdottoPiuCaro();
                    break;
                case 8:
                    ;
                    break;
                case 9:
                    Inserisci(scelta);
                    break;    
                case 10: case 11:
                    Elimina(scelta);
                    break;
                case 12:
                    return;
            }
        }
    }
    static void Inserisci(int code){
        Console.Clear();
        if(code==1){
            Console.WriteLine("Inserisci il nome del prodotto");
            string name = Console.ReadLine();
            Console.WriteLine("Inserisci il prezzo del prodotto");
            string prezzo = Console.ReadLine();
            Console.WriteLine("Inserisci la quantita del prodotto");
            string quantita = Console.ReadLine();
            Console.WriteLine("Inserisci l'ID della categoria del prodotto");
            string idCategoria = Console.ReadLine();
            SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;version=3;");
            connection.Open();
            string sql = $"INSERT INTO prodotti (nome, prezzo, quantita,id_categoria) VALUES ('{name}',{prezzo},{quantita},{idCategoria})";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }else{
            Console.WriteLine("Inserisci il nome della categoria");
            string name = Console.ReadLine();
            SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;version=3;");
            connection.Open();
            string sql = $"INSERT INTO categorie (nome) VALUES ('{name}')";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

    }

   static void VisualizzaProdotti()
{
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;version=3;");
    connection.Open();
    string sql = "SELECT prodotti.id, prodotti.nome AS nome_prodotto, prodotti.prezzo, prodotti.quantita, categorie.nome AS nome_categoria FROM prodotti LEFT JOIN categorie ON prodotti.id_categoria = categorie.id;";
    
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    SQLiteDataReader reader = command.ExecuteReader();
    Console.Clear();
    while (reader.Read())
    {
        Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome_prodotto"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, categoria: {reader["nome_categoria"]}");
    }
    Console.ReadKey();
    connection.Close();
}

    static void VisualizzaCategorie(){
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;version=3;");
        connection.Open();
        string sql = $"SELECT * FROM categorie";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        Console.Clear();
        while(reader.Read()){
            Console.WriteLine($"id: {reader["id"]} -- nome: {reader["nome"]}");
        }
        connection.Close();
    }
    static void Elimina(int code){
        Console.Clear();
        if(code==10){
            Console.WriteLine("Inserisci il nome del prodotto");
            string name = Console.ReadLine();
            SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;version=3;");
            connection.Open();
            string sql = $"DELETE FROM prodotti WHERE nome='{name}'";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }else{
            Console.WriteLine("Inserisci il nome della categoria");
            string name = Console.ReadLine();
            SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;version=3;");
            connection.Open();
            string sql = $"DELETE FROM categorie WHERE nome='{name}'";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        Console.ReadKey();
    }

    static void ModificaProdotto(int code){
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;version=3;");
        string name;
        string newName;
        string sql = "";
        SQLiteCommand command;
        Console.Clear();
        Console.WriteLine("Inserisci il nome del prodotto da modificare");
        name = Console.ReadLine();
        switch(code){
            case 3:
                Console.WriteLine("Inserisci il nuovo nome");
                newName = Console.ReadLine();
                sql = $"UPDATE prodotti SET nome='{newName}' WHERE nome='{name}'";
            break;
            case 4:
                Console.WriteLine("Inserisci il nuovo prezzo");
                newName = Console.ReadLine();
                sql = $"UPDATE prodotti SET prezzo={newName} WHERE nome='{name}'";
         
            break;
            case 5:
                Console.WriteLine("Inserisci la nuova quantità");
                newName = Console.ReadLine();
                sql = $"UPDATE prodotti SET quantita={newName} WHERE nome='{name}'";
             
            break;
        }
        connection.Open();
        command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
        Console.ReadKey();
    }

    static void VisualizzaProdottoPiuCaro(){
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;version=3;");
        string sql = $"SELECT * FROM prodotti ORDER BY prezzo DESC LIMIT 1";
        connection.Open();
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        Console.Clear();
        while(reader.Read()){
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}");
        }
        connection.Close();
        Console.ReadKey();
    }

    static void InserisciProdottoCategoria(){
        Console.Clear();
        Console.WriteLine("Inserisci il nome del prodotto");
        string name = Console.ReadLine();
        Console.WriteLine("Inserisci il prezzo del prodotto");
        string prezzo = Console.ReadLine();
        Console.WriteLine("Inserisci la quantita del prodotto");
        string quantita = Console.ReadLine();
        Console.Clear();
        VisualizzaCategorie();
        Console.WriteLine("Inserisci la categoria del prodotto in base agli id disponibili: ");
        string idCategoria = Console.ReadLine();
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;version=3;");
        connection.Open();
        string sql = $"INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('{name}',{prezzo},{quantita},{idCategoria})";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
        Console.ReadKey();
    }
}