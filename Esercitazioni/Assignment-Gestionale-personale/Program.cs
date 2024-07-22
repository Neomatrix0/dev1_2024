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

                    ValutazionePerformance();
                    break;
                case 8:

                    SortStipendio();
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
            Console.WriteLine("Inserisci nome, cognome, data di nascita DD/MM/YYYY,mansione, stipendio,voto performance da 1 a 100 ,giorni di assenze,separate da virgola");

            // accetta l'input dei dati da console
            string? inserimento = Console.ReadLine();

            // permette l'inserimento di più valori divisi dalla virgola

            string[] dati = inserimento.Split(',');

            //  creazione di un oggetto dipendente contenente i dati richiesti dall'applicazione

            var dipendente = new
            {
                Nome = dati[0].Trim(),
                Cognome = dati[1].Trim(),
                DataDiNascita = DateTime.Parse(dati[2].Trim()),
                Mansione = dati[3].Trim(),
                Stipendio = Convert.ToDecimal(dati[4].Trim()),
                Performance = Convert.ToInt32(dati[5].Trim()),
                Assenze = Convert.ToInt32(dati[6].Trim())
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
            Console.WriteLine("Lista dipendenti completa con tutti i dati:\n");

            // stampa i dati di tutti i dipendenti presi dai json

            foreach (var file in files)
            {

                StampaDati(file);

            }
        }
        else
        {
            Console.WriteLine("Nessun dipendente nel database.");
        }
    }

    // metodo per cercare il dipendente
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

            StampaDati(filePath);
        }
        else
        {
            Console.WriteLine("Dipendente non trovato");
        }
    }
    //cerca dipendente per nome e cognome e poi modifica le caratteristiche del dipendente a scelta
    static void ModificaDipendente()
    {
        Console.WriteLine("Inserisci nome e cognome del dipendente che vuoi modificare separati da virgola");
        var inserisciNome = Console.ReadLine();
        var nomi = inserisciNome.Split(',');

        // il dipendente va cercato per nome,cognome

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
            //Nota: vedere se si può usare una funzione per ridurre il codice
            Console.WriteLine("Inserisci i nuovi dati del dipendente (nome, cognome, data di nascita DD/MM/YYYY,mansione, stipendio,performance,assenze) separati da virgola");
            string? inserimento = Console.ReadLine();
            string[] dati = inserimento.Split(',');

            var dipendente = new
            {
                Nome = dati[0].Trim(),
                Cognome = dati[1].Trim(),
                DataDiNascita = DateTime.Parse(dati[2].Trim()),
                Mansione = dati[3].Trim(),
                Stipendio = Convert.ToDecimal(dati[4].Trim()),
                Performance = Convert.ToInt32(dati[5].Trim()),
                Assenze = Convert.ToInt32(dati[6].Trim())
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

    //metodo per ordinare gli stipendi dal più alto al più basso e vedere alcuni  dati del dipendente

    static void SortStipendio()
    {

        var files = Directory.GetFiles(directoryPath, "*.json");

        List<dynamic> dipendenti = new List<dynamic>();

        foreach (var file in files)
        {

            string jsonRead = File.ReadAllText(file);
            var dipendente = JsonConvert.DeserializeObject<dynamic>(jsonRead);
            dipendenti.Add(dipendente);
        }

        // algoritmo bubblesort modificato per ordinare il dato dello stipendio in ordine discendente 
        for (int i = 0; i < dipendenti.Count - 1; i++)
        {
            for (int j = 0; j < dipendenti.Count - i - 1; j++)
            {
                if (dipendenti[j].Stipendio < dipendenti[j + 1].Stipendio)
                {
                    var temp = dipendenti[j];
                    dipendenti[j] = dipendenti[j + 1];
                    dipendenti[j + 1] = temp;
                }


            }
        }



        Console.WriteLine("Dipendenti ordinati per stipendio in ordine discendente:\n");

        foreach (var dipendente in dipendenti)
        {
            Console.WriteLine($"Nome: {dipendente.Nome}");
            Console.WriteLine($"Cognome: {dipendente.Cognome}");
            Console.WriteLine($"Stipendio: {dipendente.Stipendio}");
            Console.WriteLine($"Performance: {dipendente.Performance}");
            Console.WriteLine();
        }
    }




    // metodo per leggere i dati dal json e stamparli
    static void StampaDati(string filePath)
    {
        // legge il contenuto del file json
        string jsonRead = File.ReadAllText(filePath);
        // deserializza la stringa JSON in un oggetto di tipo dynamic
        var dipendente = JsonConvert.DeserializeObject<dynamic>(jsonRead);
        Console.WriteLine($"\nNome: {dipendente.Nome}");
        Console.WriteLine($"Cognome: {dipendente.Cognome}");
        Console.WriteLine($"Data di nascita: {dipendente.DataDiNascita}");
        Console.WriteLine($"Mansione: {dipendente.Mansione}");
        Console.WriteLine($"Stipendio: {dipendente.Stipendio}");
        Console.WriteLine($"Performance: {dipendente.Performance}");
        Console.WriteLine($"Giorni di assenza: {dipendente.Assenze}");

    }


    static void TassoDiAssenteismo()
    {
        Console.WriteLine("Di seguito l'elenco con il tasso di assenteismo per ogni dipendente su 250 giorni lavorativi equivalente ad 1 anno\n");
        int giorniLavorativiTotali = 250;

        var files = Directory.GetFiles(directoryPath, "*.json");
        List<dynamic> dipendenti = new List<dynamic>();

        foreach (var file in files)
        {

            string jsonRead = File.ReadAllText(file);
            var dipendente = JsonConvert.DeserializeObject<dynamic>(jsonRead);
            dipendenti.Add(dipendente);
        }



        foreach (var dipendente in dipendenti)

        {
            int assenze = dipendente.Assenze;
            double tassoAssenteismo = ((double)assenze / giorniLavorativiTotali) * 100;
            Console.WriteLine($"{dipendente.Nome} {dipendente.Cognome} = {tassoAssenteismo}%\n");

        }


        // Tasso di assenteismo = [(giorni di assenza non giustificate) / (giorni totali di lavoro)] x 100.


    }

   /* static void ReadJson(string files){
        string files = Directory.GetFiles(directoryPath, "*.json");
        List<dynamic> dipendenti = new List<dynamic>();

        foreach (var file in files)
        {

            string jsonRead = File.ReadAllText(file);
            var dipendente = JsonConvert.DeserializeObject<dynamic>(jsonRead);
            dipendenti.Add(dipendente);
        }

    } */


    static void ValutazionePerformance()
    {
        var files = Directory.GetFiles(directoryPath, "*.json");
        List<dynamic> dipendenti = new List<dynamic>();

        foreach (var file in files)
        {

            string jsonRead = File.ReadAllText(file);
            var dipendente = JsonConvert.DeserializeObject<dynamic>(jsonRead);
            dipendenti.Add(dipendente); 
           // ReadJson();
        }

        Console.WriteLine("Divide i dipendendenti in 2 gruppi in base al rendimento");

        
        
             for (int i = 0; i < dipendenti.Count - 1; i++)
        {
            for (int j = 0; j < dipendenti.Count - i - 1; j++)
            {
                if (dipendenti[j].Performance < dipendenti[j + 1].Performance)
                {
                    var temp = dipendenti[j];
                    dipendenti[j] = dipendenti[j + 1];
                    dipendenti[j + 1] = temp;
                }

            }
            
        }
            //dipendenti.Performance.Sort();
            //dipendenti.Performance.Reverse();

            int split = dipendenti.Count / 2;
            List<dynamic> squadra1 = dipendenti.GetRange(0, split);
            List<dynamic> squadra2 = dipendenti.GetRange(split, dipendenti.Count - split);


            Console.WriteLine("Gruppo con le performance più alte:");
            foreach (var impiegato in squadra1)
            {
                Console.WriteLine($"{impiegato.Nome} {impiegato.Cognome}, {impiegato.Performance}");
                
            }

            Console.WriteLine("Gruppo con le performance più basse:");
            foreach (var impiegato in squadra2)
            {
                Console.WriteLine($"{impiegato.Nome} {impiegato.Cognome}, {impiegato.Performance}");
                
            }
        }

    }















/* static void ValutazionePerformance(){
         Console.WriteLine("Di seguito verranno mostrate le performance dei 10%  di tutti i dipendenti con le vautazioni migliori e il 10% con le valutazioni peggiori");
             var files = Directory.GetFiles(directoryPath, "*.json");  //
               string jsonRead = File.ReadAllText(filePath);
               var dipendente = JsonConvert.DeserializeObject<dynamic>(jsonRead);
                int percentage; 
             List<int> punteggi = new List<int>(); 

         // verifica se c'è almeno un file per eseguire il codice
         if (files.Length > 0)
         {
             Console.WriteLine("Lista dipendenti:\n");
             // stampa i dati di tutti i dipendenti presi dai json



             foreach (var file in files)
             {
                


         }

             }




     } */

