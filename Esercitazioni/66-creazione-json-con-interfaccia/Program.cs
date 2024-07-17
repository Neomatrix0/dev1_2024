using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {
        string path = @"test.json";
        File.Create(path).Close();
        File.AppendAllText(path, "[\n");

        while(true){

            Console.WriteLine("Inserisci nome e prezzo");
            string nome = Console.ReadLine();
            string prezzo = Console.ReadLine();

            //File.AppendAllText(path, JsonConvert.SerializeObject(new {nome, prezzo})+ ",\n");  // scrive la riga nel file
            //di seguito il metodo alternativo riga 19
            //serializza l'oggetto con indentazione
            string jsonString = JsonConvert.SerializeObject(new {nome,prezzo},Formatting.Indented);
            File.AppendAllText(path, jsonString + ",\n");
            Console.WriteLine("Vuoi inserire un altro prodotto?(s/n)");
            string risposta = Console.ReadLine();
            if(risposta == "n"){
                break;
            }
        }

        // togli ultima virgola dall'ultimo oggetto

        string file = File.ReadAllText(path);
        file = file.Remove(file.Length -2,1);   // gli argomenti -2 -1 indicano rispettivamente la posizione e il numero di caratteri da rimuovere dalla stringa
        File.WriteAllText(path,file);
        File.AppendAllText(path,"]");       // scrive la riga


        }
    }














        /*if(!File.Exists(path)){
            File.Create(path).Close();
            File.AppendAllText(path, "[\n");
        }

        while(true){
            Console.WriteLine("Inserisci nome:");
            string nome = Console.ReadLine().Trim();

            Console.WriteLine("Inserisci prezzo:");

            if(decimal.TryParse(Console.ReadLine(),out decimal prezzo))
        }
*/









    