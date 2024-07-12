// See https://aka.ms/new-console-template for more information

// Programma che legge un file di testo  contenente nomi  e utilizza il random per sorteggiare un nome da stampare
//se il file non esiste crea un file txt con il nome sorteggiato
// se il file esiste agginge il nome sorteggiato al file
// se il nome è già presente nel file non lo aggiunge stampando un messaggio

string path = @"studenti.txt";
string[] lines = File.ReadAllLines(path);      

string[] nomi = new string[lines.Length];      

for (int i = 0; i < lines.Length; i++)
{
    nomi[i] = lines[i];                        
}



Random random = new Random();
int index = random.Next(nomi.Length);          
Console.WriteLine(nomi[index]);

string path2 = @"test2.txt";

if (!File.Exists(path2))
{                                                   // controlla se il file esiste

    File.Create(path2).Close();
                        

}

if(!File.ReadAllLines(path2).Contains(nomi[index])){
    File.AppendAllText(path2, nomi[index] + "\n");

}
else{
    Console.WriteLine("Nome già nel file");

}








