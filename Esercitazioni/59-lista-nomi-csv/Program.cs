// esercizi persistenza dati utilizzando csv 
// chiede all'utente nome,cognome,età andando a capo ogni volta

string path = @"test.csv"; // in questo caso il file è nella stessa cartella del programma

File.Create(path).Close();   // crea il file


while(true){
    Console.WriteLine("Inserisci nome,cognome,età");
    string nome = Console.ReadLine();           // legge nome
    string cognome = Console.ReadLine();        // legge cognome
    string eta = Console.ReadLine();            // legge eta
    File.AppendAllText(path,nome + "," + cognome + "," + eta + "\n"); // scrive la riga nel file
    Console.WriteLine("Vuoi inserire un altro nome? (s/n)");
    string risposta = Console.ReadLine();
    if(risposta == "n"){                        // se n esce dal loop
        break;
    }
    
}