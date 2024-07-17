// lettura file json
using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {

        string path = @"test.json";             //  in questo caso il file è nella stessa cartella del programma 
        string json = File.ReadAllText(path);   // legge il file
        dynamic obj = JsonConvert.DeserializeObject(json)!;  //contenitore più tipi di dati deserializza il file
        Console.WriteLine($"nome: {obj.nome} cognome: {obj.cognome} eta: {obj.eta}");           // stampa il livello 0
        Console.WriteLine($"via: {obj.indirizzo.via} citta: {obj.indirizzo.citta}");           // stampa il livello 1

    }
}