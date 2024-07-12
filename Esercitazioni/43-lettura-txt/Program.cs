// File txt


string path =@"test.txt";                   // in questo caso il file è nella stessa cartella del programma
string[] lines = File.ReadAllLines(path);  // legge tutte le righe del file
foreach(string line in lines){
    Console.WriteLine(line);            // stampa riga
}

