class Program{
       static void Main(string[] args){
        string path = @"negozio.db";
        if (!File.Exists(path)){
            SQLiteConnection.CreateFile(path);
            SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;version=3;");
            connection.Open();
            string sql = @"
                        CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                        CREATE TABLE vendite (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL,
                        quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER,
                        foreign key (id_categoria) REFERENCES categorie(id));
                        INSERT INTO categorie (nome) VALUES ('scarpe');
                        INSERT INTO categorie (nome) VALUES ('magliette');
                        INSERT INTO categorie (nome) VALUES ('');
                        INSERT INTO prodotti (nome,prezzo,quantita,id_categoria) VALUES ('p1',1000,10,1);
                        INSERT INTO prodotti (nome,prezzo,quantita,id_categoria) VALUES ('p2',2200,2,2);
                        INSERT INTO prodotti (nome,prezzo,quantita,id_categoria) VALUES ('p3',300,30,3);
                        ";
            SQLiteCommand command = new SQLiteCommand(sql, connection); 
            command.ExecuteNonQuery();
            connection.Close();
        }
       }
}