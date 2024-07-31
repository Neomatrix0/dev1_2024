// Lettura elenco di file json

using Newtonsoft.Json;

string cartella = @".\json-folder";

string[] files = Directory.GetFiles(cartella, "*.json"); // legge tutti i file json nella cartella

if(files.Length == 0){                                      // se non ci sono file json nella cartella
    Console.WriteLine("Non ci sono file json nella cartella");
    return; // Esce dal programma
}

Console.WriteLine("Elenco dei file json:");
for(int i =0; i < files.Length; i++){
    Console.WriteLine($"{i+ 1}- {Path.GetFileName(files[i])}");  // stampa il nome del file con il numero di indice
}

Console.WriteLine("Quale file vuoi leggere? (Inserisci il numero corrispondente):");
if(int.TryParse(Console.ReadLine(), out int scelta) && scelta >0 && scelta <= files.Length ){ // tenta di convertire l'input in un numero intero e verifica che sia compreso tra 1 e il numero di file
    string fileScelto = files[scelta -1];  // assegna il file scelto in base all'indice
    string json = File.ReadAllText(fileScelto);   // legge il ocntenuto del file
    dynamic obj = JsonConvert.DeserializeObject(json);   //  deserializza il contenuto di un oggetto dinamico
    Console.WriteLine(JsonConvert.SerializeObject(obj, Formatting.Indented));   // stampa il ocntenuto formattato 
}else{
    Console.WriteLine("Scelta non valida");
}

