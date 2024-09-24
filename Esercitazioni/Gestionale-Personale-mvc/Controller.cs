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
            .PageSize(6)
            .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
            .AddChoices(new[] {
                "Aggiungi Dipendente", "Mostra Dipendenti", "Rimuovi Dipendente",
                "Cerca Dipendente", "Modifica Dipendente","Ordina stipendi", "Esci",
            }));

        

            if (input == "Aggiungi Dipendente")
            {
                AggiungiDipendente(); // Aggiunta di un utente
            }
            else if (input == "Mostra Dipendenti")
            {
                MostraDipendenti(); // Visualizzazione dei dipendenti
            }
            else if (input == "Rimuovi Dipendente")
            {
                RimuoviDipendente(); //rimuovi dipendente
            }
              else if (input == "Cerca Dipendente")
        {
            CercaDipendente(); // Cerca un dipendente tramite email
        }
          else if (input == "Modifica Dipendente")
        {
            ModificaDipendente(); // Modifica
        }
        else if(input == "Ordina stipendi"){
            OrdinaStipendi();
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

            var mansioni=_db.MostraMansioni();
            foreach(var mansione in mansioni){
                Console.WriteLine(mansione);
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

private void OrdinaStipendi(){

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
            .PageSize(8)
            .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
            .AddChoices(new[] {
                "Cambia nome", "Cambia cognome", "Cambia data di nascita formato DD/MM/YYYY",
                "Cambia mansione", "Cambia stipendio", "Cambia punteggio performance", "Cambia giorni di assenze", "Cambia mail", "Esci",
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

            case "Cambia punteggio performance":
                Console.WriteLine("Inserisci il nuovo punteggio performance:");
                campoDaModificare = "performance";
                nuovoValore = Console.ReadLine().Trim();
                break;

            case "Cambia giorni di assenze":
                Console.WriteLine("Inserisci il numero di giorni di assenze:");
                campoDaModificare = "assenze";
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