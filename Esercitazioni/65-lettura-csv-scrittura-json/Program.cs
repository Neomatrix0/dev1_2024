using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.csv";
        string[] lines = File.ReadAllLines(path); // legge tutte le righe del file

        string[][] prodotti = new string[lines.Length][]; // crea un array di array di stringhe con la lunghezza del numero di righe del file
        for (int i = 1; i < lines.Length; i++)
        {
            prodotti[i] = lines[i].Split(',');  //assegna ad ogni elemento dell'array di array di stringhe il valore della riga corrispondente divisa in un array di stringhe ed utilizza la virgola come separatore
        }
        for (int i = 1; i < prodotti.Length; i++)
        {
            string path2 = prodotti[i][0] + ".json";    //crea i files utilizzando la chiave come nome
            File.Create(path2).Close();                 // crea il file
            File.AppendAllText(path2, JsonConvert.SerializeObject(new { nome = prodotti[i][0], prezzo = prodotti[i][1] })); //scrive la riga nel file
        }
    }
}