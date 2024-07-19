using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string path = @"test.json";
        // verifica se il file esiste, altrimenti lo crea e inizializza il formato JSON
        if (!File.Exists(path))
        {
            File.Create(path).Close();
            File.AppendAllText(path, "[\n");
        }

        while (true) // ciclo infinito per permettere all'utente di inserire più prodotti finchè non decide di smettere di inserire prodotti
        {
            Console.WriteLine("Inserisci nome:");
            string nome = Console.ReadLine().Trim(); // legge il nome e rimuove gli spazi bianchi il metodo trim rimuove gli spazi bianchi all'inizio e alla fine della stringa

            Console.WriteLine("Inserisci prezzo:");
            if (decimal.TryParse(Console.ReadLine(), out decimal prezzo)) // legge il prezzo e verifica se è un numero valido out restituisce il valore della variabile prezzo
            {
                File.AppendAllText(path, JsonConvert.SerializeObject(new { nome, prezzo = prezzo.ToString() }) + ",\n"); // scrive la riga nel file prezzo = prezzo.ToString() converte il prezzo in stringa in modo da poterlo scrivere nel file JSON
                
                Console.WriteLine("Vuoi inserire un altro prodotto? (s/n)");
                if (Console.ReadLine().Trim().ToLower() != "s") // legge la risposta e verifica se è uguale a "s" o "S" e se non è così esce dal ciclo il metodo tolower converte la stringa in minuscolo in modo che l'utente possa inserire "s" o "S" per continuare ad inserire prodotti
                {
                    break; // esce dal ciclo se l'utente non vuole inserire un altro prodotto
                }
            }
            else
            {
                Console.WriteLine("Prezzo non valido. Riprova.");
            }
        }

        FinalizzaFileJSON(path); // funzione per finalizzare il file JSON
    }

    static void FinalizzaFileJSON(string path) // funzione per finalizzare il file JSON aggiunge la parentesi quadra chiusa per chiudere il formato JSON il parametro path è il percorso del file JSON
    {
        string file = File.ReadAllText(path).TrimEnd('\n', ','); // legge il file e rimuove l'ultima virgola e a capo dalla stringa cioè il metodo trimend ha come parametri i caratteri da rimuovere dalla fine della stringa
        File.WriteAllText(path, file + "\n]"); // scrive la riga nel file ed aggiunge la parentesi quadra chiusa per chiudere il formato JSON
    }
}