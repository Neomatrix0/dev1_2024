using Spectre.Console;
AnsiConsole.Write(
    new FigletText("Hello")
        .LeftJustified()
        .Color(Color.Red));

string path = @"prova.txt";
bool  nessunNomeIniziaConC = true;
string[]lines = File.ReadAllLines(path); 

string []parole = new string[lines.Length];

for(int i =0; i < lines.Length; i++){
    //Console.WriteLine(line);
    parole[i] = lines[i];
}




string path2 = @"test2.txt";   


File.Create(path2).Close();

foreach(var parola in parole){
    if(parola.StartsWith("C")){
    File.AppendAllText(path2, parola + "\n");  
    nessunNomeIniziaConC  =false;

}


}

if(nessunNomeIniziaConC){       
    Console.WriteLine("Nessun nome inizia con la lettera a");

}