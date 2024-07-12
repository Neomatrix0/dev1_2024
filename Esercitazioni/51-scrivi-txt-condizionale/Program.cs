// Legge un file di testo txt contenente dei nomi e utilizza metodo random per sorteggiare un nome da stampare

// se non esiste crea un file txt con il nome sorteggiato
// se esiste aggiunge il nome sorteggiato al file

// Sorteggio e scrittura in altro file del nome random

string path = @"nomi.txt";
string[] lines = File.ReadAllLines(path);          // legge tutte le righe del file

string[] nomi = new string[lines.Length];          // crea un array di stringhe con la lunghezza del numero di righe del file

for (int i = 0; i < lines.Length; i++)
{
    nomi[i] = lines[i];                             // assegna ad ogni elemento dell'array di stringhe il valore della riga corrispondente
}



Random random = new Random();
int index = random.Next(nomi.Length);           // genera un numero casuale tra 0 e la lunghezza dell'array di stringhe
Console.WriteLine(nomi[index]);                 // stampa il nome corrispondente all'indice generato casualmente
string path2 = @"test2.txt";

if (!File.Exists(path2))
{                                                   // controlla se il file esiste

    File.Create(path2).Close();                     // crea il file

}

File.AppendAllText(path2, nomi[index] + "\n");      // scrive riga nel file