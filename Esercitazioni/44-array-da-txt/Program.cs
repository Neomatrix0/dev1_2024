// See https://aka.ms/new-console-template for more information


string path =@"test.txt";                   // in questo caso il file è nella stessa cartella del programma
string[] lines = File.ReadAllLines(path);  // legge tutte le righe del file

string[]  nomi = new string[lines.Length];      // crea un array di stringhe con la lunghezza del numero di righe del file

for(int i =0; i < lines.Length; i++){
    nomi[i] = lines[i];                     // assegna ad ogni elemento dell'array di stringhe il valore della riga corrispondente
}


foreach(string nome in nomi){
    Console.WriteLine(nome);            // stampa riga
}

