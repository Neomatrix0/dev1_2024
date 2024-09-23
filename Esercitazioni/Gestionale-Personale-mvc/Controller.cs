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
                break; // Uscita dal programma
            }
        }
    }

    private void AggiungiDipendente()
    {
        Console.WriteLine("Digita il nome:"); // Richiesta del nome dell'utente
        var nome = _view.GetInput(); // Lettura del nome dell'utente
         Console.WriteLine("Digita il cognome:"); // Richiesta del nome dell'utente
        var cognome = _view.GetInput();
        Console.WriteLine("Digita la data di nascita DD/MM/YYYY:"); // Richiesta del nome dell'utente
        var dataDiNascitaString = _view.GetInput();
         Console.WriteLine("Digita la mail aziendale:");
        var mail = _view.GetInput();
        if (DateTime.TryParseExact(dataDiNascitaString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataDiNascita))
    {
        _db.AggiungiDipendente(nome, cognome, dataDiNascita,mail); // Aggiunta del dipendente al database
    }
    else
    {
        Console.WriteLine("Formato data non valido. Riprova.");
    }
    //    _db.AggiungiDipendente(nome,cognome,dataDiNascita); // Aggiunta dell'utente al database
    }

    private void MostraDipendenti()
    {
        var users = _db.GetUsers(); // Lettura degli utenti dal database
        _view.MostraDipendenti(users); // Visualizzazione degli utenti
    }
}