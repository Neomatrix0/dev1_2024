using Newtonsoft.Json;
//import Spectre

class Program
{

    // crea cartella dipendenti dove verranno messi i file json per ogni dipendente
    static string directoryPath = @"dipendenti/";

    static void Main(string[] args)

    {
        // se la cartella non esiste la crea

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        Console.WriteLine("Benvenuto nel programma di gestione del personale.");
        int opzione;

        do
        {
            Console.Clear();
            Console.WriteLine("1. Inserisci dipendente");
            Console.WriteLine("2. Visualizza dipendenti");
            Console.WriteLine("3. Cerca dipendente");
            Console.WriteLine("4. Modifica dipendente");
            Console.WriteLine("5. Rimuovi dipendente");
            Console.WriteLine("6. Tasso di assenteismo");
            Console.WriteLine("7. Indicatore di performance");
            Console.WriteLine("8. Ordina per stipendio");
            Console.WriteLine("9. Esci");

            // scelta del tipo di azione da svolgere

            opzione = Convert.ToInt32(Console.ReadLine());
            switch (opzione)
            {
                case 1:
                    InserisciDipendente();
                    break;
                case 2:
                    VisualizzaDipendenti();
                    break;
                case 3:
                    CercaDipendente();
                    break;
                case 4:
                    ModificaDipendente();
                    break;
                case 5:
                    RimuoviDipendente();
                    break;
                case 6:
                TassoDiAssenteismo();
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    Console.WriteLine("Il programma verrà chiuso. Attendere prego.");
                    break;
                default:
                    Console.WriteLine("Errore di scelta: Prego riprovare");
                    break;
            }

            // se viene scelta l'opzione 9 il programma sichiude

            if (opzione != 9)
            {
                Console.WriteLine("Premere un tasto per proseguire");
                Console.ReadKey();
            }

        } while (opzione != 9);
    }

    static void InserisciDipendente()
    {
        do
        {
            Console.WriteLine("Inserisci nome, cognome, età, stipendio separate da virgola");

            // accetta l'input dei dati da console
            string? inserimento = Console.ReadLine();

            // permette l'inserimento di più valori divisi dalla virgola

            string[] dati = inserimento.Split(',');

            //  creazione di un oggetto dipendente contenente i dati richiesti dall'applicazione

            var dipendente = new
            {
                Nome = dati[0].Trim(),
                Cognome = dati[1].Trim(),
                DataDiNascita = Convert.ToInt32(dati[2].Trim()),
                Stipendio = Convert.ToDecimal(dati[3].Trim())
            };

            string jsonString = JsonConvert.SerializeObject(dipendente, Formatting.Indented);

            // Path.Combine concatena il path della cartella dipendenti al path dei file json di ogni dipendente
            string filePath = Path.Combine(directoryPath, $"{dipendente.Nome}_{dipendente.Cognome}.json");
            File.WriteAllText(filePath, jsonString);

            // se si svuole terminare l'immissione della registrazione del dipendente basta digitare n

            Console.WriteLine("Vuoi inserire un altro dipendente? (s/n)");
            string? risposta = Console.ReadLine().Trim().ToLower();
            if (risposta == "n")
            {
                break;
            }
        } while (true);
    }

    // creazione dei metodi per ogni singola funzionalità
    static void VisualizzaDipendenti()
    {
        // analizza tutti i file con estensione .json dentro la directoryPath(cartella dipendenti)
        var files = Directory.GetFiles(directoryPath, "*.json");  //

        // verifica se c'è almeno un file per eseguire il codice
        if (files.Length > 0)
        {
            Console.WriteLine("Lista dipendenti:\n");
            // stampa i dati di tutti i dipendenti presi dai json

            foreach (var file in files)
            {
                // legge il contenuto completo del file json
                string jsonRead = File.ReadAllText(file);

                // deserializza la stringa JSON in un oggetto di tipo dynamic
                var dipendente = JsonConvert.DeserializeObject<dynamic>(jsonRead);
                Console.WriteLine($"Nome: {dipendente.Nome}");
                Console.WriteLine($"Cognome: {dipendente.Cognome}");
                Console.WriteLine($"Data di nascita: {dipendente.DataDiNascita}");
                Console.WriteLine($"Stipendio: {dipendente.Stipendio}\n");
            }
        }
        else
        {
            Console.WriteLine("Nessun dipendente nel database.");
        }
    }

    static void CercaDipendente()
    {
        Console.WriteLine("Inserisci nome e cognome del dipendente che vuoi cercare separati da virgola");
        var inserisciNome = Console.ReadLine();
        // permette l'inserimento di molteplici input separati dalla virgola
        var nomi = inserisciNome.Split(',');

        // il dipendente deve essere cercato inserendo nome,cognome

        if (nomi.Length != 2)
        {
            Console.WriteLine("Nomi non validi");
            return;
        }

        string nome = nomi[0].Trim();
        string cognome = nomi[1].Trim();

        // nome e cognome di ogni dipendente diventerenno il rispettivo nome dei file json 
        string filePath = Path.Combine(directoryPath, $"{nome}_{cognome}.json");

        // verifica se un file json esiste

        if (File.Exists(filePath))
        {
            string jsonRead = File.ReadAllText(filePath);
            var dipendente = JsonConvert.DeserializeObject<dynamic>(jsonRead);
            // stampa i dati presi dal json
            Console.WriteLine($"\nNome: {dipendente.Nome}");
            Console.WriteLine($"Cognome: {dipendente.Cognome}");
            Console.WriteLine($"Data di nascita: {dipendente.DataDiNascita}");
            Console.WriteLine($"Stipendio: {dipendente.Stipendio}\n");
        }
        else
        {
            Console.WriteLine("Dipendente non trovato");
        }
    }

    static void ModificaDipendente()
    {
        Console.WriteLine("Inserisci nome e cognome del dipendente che vuoi modificare separati da virgola");
        var inserisciNome = Console.ReadLine();
        var nomi = inserisciNome.Split(',');

        if (nomi.Length != 2)
        {
            Console.WriteLine("Nomi non validi");
            return;
        }

        // Trim() rimuove gli spazi vuoti

        string nome = nomi[0].Trim();
        string cognome = nomi[1].Trim();
        string filePath = Path.Combine(directoryPath, $"{nome}_{cognome}.json");

        if (File.Exists(filePath))
        {
            Console.WriteLine("Inserisci i nuovi dati del dipendente (nome, cognome, età, stipendio) separati da virgola");
            string? inserimento = Console.ReadLine();
            string[] dati = inserimento.Split(',');

            var dipendente = new
            {
                Nome = dati[0].Trim(),
                Cognome = dati[1].Trim(),
                DataDiNascita = Convert.ToInt32(dati[2].Trim()),
                Stipendio = Convert.ToDecimal(dati[3].Trim())
            };

            string jsonString = JsonConvert.SerializeObject(dipendente, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine("Dipendente aggiornato con successo.");
        }
        else
        {
            Console.WriteLine("Dipendente non trovato");
        }
    }

    static void RimuoviDipendente()
    {
        Console.WriteLine("Inserisci nome e cognome del dipendente che vuoi rimuovere separati da virgola");
        var inserisciNome = Console.ReadLine();
        var nomi = inserisciNome.Split(',');

        if (nomi.Length != 2)
        {
            Console.WriteLine("Nomi non validi");
            return;
        }

        string nome = nomi[0].Trim();
        string cognome = nomi[1].Trim();
        string filePath = Path.Combine(directoryPath, $"{nome}_{cognome}.json");

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Console.WriteLine("Dipendente rimosso con successo.");
        }
        else
        {
            Console.WriteLine("Dipendente non trovato");
        }
    }

    static void TassoDiAssenteismo(){
        Console.WriteLine("Inserisci nome e cognome del dipendente di cui vuoi calcolare il tasso di assenteismo");



       // Tasso di assenteismo = [(giorni di assenza non giustificate) / (giorni totali di lavoro)] x 100.


    } 
}
