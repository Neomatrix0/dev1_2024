// See https://aka.ms/new-console-template for more information

string path = @"nomi.txt";
string[] lines = File.ReadAllLines(path);
lines[lines.Length -2] = "Ciao";       // modifica la penultima riga aggiungendo Ciao
File.WriteAllLines(path, lines);   

// lines[^2] = "Ciao";  // utilizzo dell'accento cirocnflesso fa la stessa cosa della riga 5

