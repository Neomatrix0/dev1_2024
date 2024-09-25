using System.Data.SQLite;
using Spectre.Console;
class View
{
    private Database _db; // Riferimento al modello Database

// Costruttore della classe View che riceve un oggetto 'Database' come argomento e lo assegna al campo privato _db.
    public View(Database db)
    {
        _db = db; // Inizializzazione del riferimento al modello Database
    }

// Metodo per mostrare il menu principale all'utente
  /*  public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi dipendente");
        Console.WriteLine("2. Vedi tutti i dipendenti");
        Console.WriteLine("3. Rimuovi dipendente");
        Console.WriteLine("4. Cerca dipendente per mail");
        Console.WriteLine("5. Modifica dipendente");
        Console.WriteLine("6. Aggiungi indicatori dipendente");
        Console.WriteLine("7. Esci");
    }
*/
  // Metodo per mostrare la lista dei dipendenti (come stringhe) ricevuta in input
    public void MostraDipendenti(List<string> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine(user); // Visualizzazione dei nomi dei dipendenti
        }
    }

// Metodo per raccogliere input dell'utente da console
    public string GetInput()
    {
        return Console.ReadLine();  // Ritorna il testo inserito dall'utente nella console
    }
}