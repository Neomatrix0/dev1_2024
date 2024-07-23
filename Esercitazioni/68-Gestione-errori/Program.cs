// Gestione eccezioni


try{
    string contenuto = File.ReadAllText("file.txt");
    Console.WriteLine(contenuto);
}

catch(Exception e){
    Console.WriteLine("Il file non esiste");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    return;
}