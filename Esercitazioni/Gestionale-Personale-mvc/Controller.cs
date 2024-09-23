using System.Data.SQLite;

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
            _view.ShowMainMenu(); // Visualizzazione del menu principale
            var input = _view.GetInput(); // Lettura dell'input dell'utente
            if (input == "1")
            {
                AggiungiDipendente(); // Aggiunta di un utente
            }
            else if (input == "2")
            {
                MostraDipendenti(); // Visualizzazione degli utenti
            }
            else if (input == "3")
            {
                RimuoviDipendente();
            }
            else if (input == "7")
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
        Console.WriteLine("Inserisci l'ID del dipendente da rimuovere:");
         if (int.TryParse(dipendenteIdString, out int dipendenteId))
        {
            bool successo = _db.RimuoviDipendente(dipendenteId);
            if (successo)
            {
                Console.WriteLine("Dipendente rimosso con successo.");
            }
            else
            {
                Console.WriteLine("Dipendente non trovato.");
            }
        }
        else
        {
            Console.WriteLine("ID non valido. Riprova.");
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
}