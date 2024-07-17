// lettura file json
using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {

        string path = @"test.json";             //  in questo caso il file è nella stessa cartella del programma 
        string json = File.ReadAllText(path);   // legge il file
        dynamic obj = JsonConvert.DeserializeObject(json)!;

        string path2 = @"test.csv";
        File.Create(path2).Close();

        // aggiunta intestazione su csv
        File.AppendAllText(path2, "nome,cognome,eta,via,citta\n");

        // copia i dati dal json li mette anche sul csv

        for (int i = 0; i < obj.Count; i++)
        {
            File.AppendAllText(path2, $"{obj[i].nome},{obj[i].cognome},{obj[i].eta},{obj[i].indirizzo.via},{obj[i].indirizzo.citta}\n");
        }


    }
}