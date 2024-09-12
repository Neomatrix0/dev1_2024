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
                            CREATE TABLE produttore(id INTEGER PRIMARY KEY AUTOINCREMENT,nome TEXT UNIQUE,provenienza TEXT);
                            CREATE TABLE genere (id INTEGER PRIMARY KEY AUTOINCREMENT, tipo TEXT UNIQUE);
                            CREATE TABLE film (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, regista TEXT,
                            data_uscita DATE,id_genere INTEGER,id_produttore INTEGER, 
                            FOREIGN KEY (id_genere) REFERENCES genere(id)),
                            FOREIGN KEY(id_produttore) REFERENCES produttore(id));

                            INSERT INTO genere (tipo) VALUES ('action');
                            INSERT INTO genere (tipo) VALUES ('horror');
                            INSERT INTO genere (tipo) VALUES ('drammatico');
                            INSERT INTO genere (tipo) VALUES ('giallo');
                            INSERT INTO genere (tipo) VALUES ('storico');
                            INSERT INTO genere (tipo) VALUES ('commedia');
                            INSERT INTO genere (tipo) VALUES ('noir');

                            INSERT INTO produttore(nome,provenienza)VALUES('Warner Bros','usa');
                            INSERT INTO produttore(nome,provenienza)VALUES('Universal Pictures','usa');

                            INSERT INTO film(nome,regista, data_uscita,id_genere,id_produttore) VALUES ('Mulholland Drive','David Lynch', 2002-02-15, 1, 1);
                            INSERT INTO film(nome,regista, data_uscita,id_genere,id_produttore) VALUES ('Arancia meccanica','Stanley Kubrick', 1972-09-07, 2, 2);
                            ";
                            

            SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database se non esiste
            command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database se non esiste
            connection.Close(); // chiude la connessione al database se non è già chiusa
        }
        while (true)
        {
            Console.WriteLine("1 - visualizzare tutti i film");
            Console.WriteLine("2 - inserire un film");
            Console.WriteLine("3 - cerca un singolo film");
            Console.WriteLine("4 - modificare un film");
            Console.WriteLine("5 - eliminare un film");
            Console.WriteLine("6 - uscire");
            Console.WriteLine("scegli un'opzione");
            string scelta = Console.ReadLine()!;
            if (scelta == "1")
            {
                
            }
            else if (scelta == "2")
            {
                
            }
            else if (scelta == "3")
            {
                
            }
            else if (scelta == "4")
            {
               
            }
            else if (scelta == "5")
            {
               
            }
            else if (scelta == "6")
            {
                
            }
            else if (scelta == "7")
            {
               
            }
            else if (scelta == "8")
            {
               
            }
            else if (scelta == "9")
            {
                
            }
            else if (scelta == "10")
            {
               
            }
            else if (scelta == "11")
            {
               
            }
            else if (scelta == "12")
            {
            
            }
            else if (scelta == "13")
            {
                
            }
            else if (scelta == "14")
            {
               
            }
            else if (scelta == "15")
            {
                break;
            }
            else
            {
                Console.WriteLine("scelta non valida");
            }

        }

    }
}