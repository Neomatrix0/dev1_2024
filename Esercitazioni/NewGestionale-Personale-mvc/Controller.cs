using System.Data.SQLite;
using Spectre.Console;

class Controller
{
    private Database _db; // Riferimento al modello
    private View _view; // Riferimento alla vista

    public Controller(Database db, View view)
    {
        _db = db; // Inizializzazione del riferimento al modello
        _view = view; // Inizializzazione del riferimento alla vista
    }

    public void MainMenu()
    {
        while (true)
        {
          //  _view.ShowMainMenu(); // Visualizzazione del menu principale
           // var input = _view.GetInput(); // Lettura dell'input dell'utente
            var input = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("GESTIONALE DIPENDENTI")
            .PageSize(8)
            .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
            .AddChoices(new[] {
                "Aggiungi Dipendente", "Mostra Dipendenti", "Rimuovi Dipendente",
                "Cerca Dipendente", "Modifica Dipendente","Ordina stipendi","Aggiungi indicatori", "Esci",
            }));

        

            if (input == "Aggiungi Dipendente")
            {
                AggiungiDipendente(); // Aggiunta di un utente
            }
            else if (input == "Mostra Dipendenti")
            {
                MostraDipendenti(); // Visualizzazione degli utenti
            }
            else if (input == "Rimuovi Dipendente")
            {
                RimuoviDipendente();
            }
              else if (input == "Cerca Dipendente")
        {
            CercaDipendente(); // Cerca un dipendente tramite email
        }
          else if (input == "Modifica Dipendente")
        {
            ModificaDipendente(); // Cerca un dipendente tramite email
        }
        else if(input == "Ordina stipendi"){
            OrdinaStipendi();
        }
        else if( input == "Aggiungi indicatori"){
            AggiungiIndicatoriDipendente();
        }
            else if (input == "Esci")
            {
                break; // Uscita dal programma
            }
        }
    }

    private void AggiungiDipendente()
    {
        Console.WriteLine("Inserisci il nome:"); // Richiesta del nome dell'utente
        var nome = _view.GetInput(); // Lettura del nome dell'utente
         Console.WriteLine("Inserisci il cognome:"); 
        var cognome = _view.GetInput();
        Console.WriteLine("Inserisci la data di nascita DD/MM/YYYY:"); 
        var dataDiNascitaString = _view.GetInput();
         Console.WriteLine("Inserisci la mail aziendale:");
        var mail = _view.GetInput();

        var mansioni = _db.MostraMansioni();
    foreach (var mansione in mansioni)
    {
        // Stampa ogni mansione con il suo ID e altri dettagli
        Console.WriteLine($"ID: {mansione.Id}, Titolo: {mansione.Titolo}, Stipendio: {mansione.Stipendio}");
    }

         Console.WriteLine("Scegli tra le mansioni disponibili per id:");
        var mansioneInput = _view.GetInput();
         if (int.TryParse(mansioneInput, out int mansioneId))
    {
        var mansioneid = Console.ReadLine();

        if (DateTime.TryParseExact(dataDiNascitaString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataDiNascita))
    {
        _db.AggiungiDipendente(nome, cognome, dataDiNascita,mail,mansioneId);
        Console.WriteLine("Dipendente aggiunto con successo."); // Aggiunta del dipendente al database
    }
    else
    {
        Console.WriteLine("Formato data di nascita non valido. Riprova.");
    }
   
    }else{
        Console.WriteLine("ID mansione non valido. Riprova.");
    }
    }

    private void RimuoviDipendente(){
         Console.WriteLine("Elenco dei dipendenti:");
        var dipendentiConId = _db.GetDipendentiConId();
        foreach(var dipendente in dipendentiConId){
            Console.WriteLine(dipendente);
        }
        Console.WriteLine("Inserisci l'ID del dipendente da rimuovere:");
       try
    {
        // Usa Convert.ToInt32 per convertire l'input in un intero
        var dipendenteId = Convert.ToInt32(Console.ReadLine());

        // Prova a rimuovere il dipendente
        bool successo = _db.RimuoviDipendente(dipendenteId);
        if (successo)
        {
            Console.WriteLine("Dipendente rimosso con successo.");
        }
        else
        {
            Console.WriteLine("Dipendente non trovato o ID non valido.");
        }
    }
    catch (FormatException)
    {
        // Gestisce l'errore se l'input non è un numero valido
        Console.WriteLine("ID non valido. Inserisci un numero.");
    }
   
}

private void CercaDipendente(){
     Console.WriteLine("Cerca il dipendente usando la sua mail aziendale:");
      var cercaMail = _view.GetInput();
      var dipendente= _db.CercaDipendentePerMail(cercaMail);
      if(dipendente != null){
        Console.WriteLine("Dettagli del dipendente:");
        Console.WriteLine(dipendente.ToString());
      }else{
        // Messaggio se il dipendente non viene trovato
        Console.WriteLine("Dipendente non trovato con questa email.");
      }

}

    private void MostraDipendenti()
    {
        var dipendenti = _db.GetUsers(); // Lettura degli utenti dal database
      //  _view.MostraDipendenti(dipendenti); // Visualizzazione degli utenti
    foreach (var dipendente in dipendenti)
    {
        // Utilizza il metodo ToString della classe Dipendente per mostrare i dettagli
        Console.WriteLine(dipendente.ToString());
    }
}

private void AggiungiIndicatoriDipendente()
{
    Console.WriteLine("Elenco dei dipendenti:");
    var dipendentiConId = _db.GetUsers();
    foreach(var dipendente in dipendentiConId)
    {
        Console.WriteLine(dipendente);
    }

    Console.WriteLine("Inserisci l'ID del dipendente per aggiungere indicatori:");
    int dipendenteId = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Inserisci il fatturato del dipendente:");
    double fatturato = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Inserisci il numero di presenze del dipendente:");
    int presenze = Convert.ToInt32(Console.ReadLine());  // Definisci la variabile 'presenze'

    // Chiamata al metodo AggiungiIndicatori del Database
    _db.AggiungiIndicatori(dipendenteId, fatturato, presenze);  // Usa 'presenze' ora definita
    
    Console.WriteLine("Indicatori aggiunti con successo.");
}


// da rivedere
private void AggiornaIndicatoriDipendente()
{
    // Mostra elenco dipendenti con ID
    Console.WriteLine("Elenco dei dipendenti:");
    var dipendentiConId = _db.GetDipendentiConId(); // Ottieni la lista dei dipendenti con ID
    foreach (var dipendente in dipendentiConId)
    {
        Console.WriteLine(dipendente); // Mostra ID e nome di ogni dipendente
    }

    // Richiedi l'ID del dipendente per il quale aggiornare gli indicatori
    Console.WriteLine("Inserisci l'ID del dipendente per aggiornare gli indicatori:");
    int dipendenteId = Convert.ToInt32(Console.ReadLine()); // Legge l'ID del dipendente

    // Chiedi i nuovi valori di fatturato e presenze
    Console.WriteLine("Inserisci il nuovo fatturato del dipendente:");
    double nuovoFatturato = Convert.ToDouble(Console.ReadLine()); // Legge il nuovo fatturato

    Console.WriteLine("Inserisci il nuovo numero di presenze del dipendente:");
    int nuovePresenze = Convert.ToInt32(Console.ReadLine()); // Legge il nuovo numero di presenze

    // Chiamata al metodo AggiornaIndicatori del Database
    _db.AggiornaIndicatori(dipendenteId, nuovoFatturato, nuovePresenze);

    // Conferma che gli indicatori sono stati aggiornati
    Console.WriteLine("Indicatori aggiornati con successo.");
}

private void OrdinaStipendi()
{
    // Recupera i dipendenti dal database
    var dipendenti = _db.GetUsers(); 

    // Algoritmo bubble sort per ordinare i dipendenti in base allo stipendio in ordine discendente
    for (int i = 0; i < dipendenti.Count - 1; i++)
    {
        for (int j = 0; j < dipendenti.Count - i - 1; j++)
        {
            if (dipendenti[j].Stipendio < dipendenti[j + 1].Stipendio)
            {
                // Scambia i dipendenti se lo stipendio del primo è inferiore a quello del successivo
                var temp = dipendenti[j];
                dipendenti[j] = dipendenti[j + 1];
                dipendenti[j + 1] = temp;
            }
        }
    }

    // Mostra i dipendenti ordinati per stipendio
    Console.WriteLine("Dipendenti ordinati per stipendio (dal più alto al più basso):");
    foreach (var dipendente in dipendenti)
    {
        Console.WriteLine(dipendente.ToString()); // Utilizza il metodo ToString() di Dipendente per visualizzare i dettagli
    }
}



private void ModificaDipendente()
{
    try
    {
        Console.WriteLine("Elenco dei dipendenti:");
        var dipendentiConId = _db.GetDipendentiConId();
        
        // Mostra l'elenco dei dipendenti con ID
        foreach (var dipendente in dipendentiConId)
        {
            Console.WriteLine(dipendente);
        }

        // Richiedi l'ID del dipendente
        Console.WriteLine("Inserisci l'ID del dipendente da modificare:");
        int dipendenteId = Convert.ToInt32(_view.GetInput());

        // Menu di selezione per i campi da modificare
        var inserimento = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("MODIFICA DIPENDENTE")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
            .AddChoices(new[] {
                "Cambia nome", "Cambia cognome", "Cambia data di nascita formato DD/MM/YYYY",
                "Cambia mansione", "Cambia stipendio", "Cambia fatturato", "Cambia giorni di presenza", "Cambia mail","Aggiorna indicatori", "Esci",
            }));

        string campoDaModificare = "";
        string nuovoValore = "";

        // Switch case per la modifica del campo selezionato
        switch (inserimento)
        {
            case "Cambia nome":
                Console.WriteLine("Inserisci il nuovo nome");
                campoDaModificare = "nome";
                nuovoValore = Console.ReadLine().Trim();
                break;

            case "Cambia cognome":
                Console.WriteLine("Inserisci il nuovo cognome");
                campoDaModificare = "cognome";
                nuovoValore = Console.ReadLine().Trim();
                break;

            case "Cambia data di nascita formato DD/MM/YYYY":
                Console.WriteLine("Inserisci nuova data di nascita");
                DateTime dataDiNascita = DateTime.ParseExact(Console.ReadLine().Trim(), "dd/MM/yyyy", null);
                campoDaModificare = "dataDiNascita";
                nuovoValore = dataDiNascita.ToString("yyyy-MM-dd");  // Formattazione per SQLite
                break;

            case "Cambia mansione":
                Console.WriteLine("Inserisci la nuova mansione (ID):");
                int mansioneId = Convert.ToInt32(Console.ReadLine().Trim());
                campoDaModificare = "mansioneId";
                nuovoValore = mansioneId.ToString();
                break;

            case "Cambia stipendio":
                Console.WriteLine("Inserisci il nuovo stipendio:");
                campoDaModificare = "stipendio";
                nuovoValore = Console.ReadLine().Trim();
                break;

            case "Cambia fatturato":
                Console.WriteLine("Inserisci il nuovo fatturato:");
                campoDaModificare = "fatturato";
                nuovoValore = Console.ReadLine().Trim();
                break;

            case "Cambia giorni di presenza":
                Console.WriteLine("Inserisci il numero di giorni di presenze:");
                campoDaModificare = "presenze";
                nuovoValore = Console.ReadLine().Trim();
                break;

            case "Cambia mail":
                Console.WriteLine("Inserisci il nuovo indirizzo email aziendale:");
                campoDaModificare = "mail";
                nuovoValore = Console.ReadLine().Trim();
                break;

                

            case "Esci":
                Console.WriteLine("\nL'applicazione si sta per chiudere\n");
                return;

            default:
                Console.WriteLine("\nScelta errata. Prego scegliere tra le opzioni disponibili\n");
                return;
        }

        // Modifica il campo nel database
        bool successo = _db.ModificaDipendente(dipendenteId, campoDaModificare, nuovoValore);

        if (successo)
        {
            Console.WriteLine($"{campoDaModificare} aggiornato con successo per il dipendente con ID {dipendenteId}.");
        }
        else
        {
            Console.WriteLine("Errore durante la modifica del dipendente. Verifica l'ID o il campo inserito.");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Errore non trattato: {e.Message}");
        Console.WriteLine($"CODICE ERRORE: {e.HResult}");
    }
}




}