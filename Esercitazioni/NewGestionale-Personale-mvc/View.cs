using System.Data.SQLite;
using Spectre.Console;
class View
{
    private Database _db; // Riferimento al modello

    public View(Database db)
    {
        _db = db; // Inizializzazione del riferimento al modello
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi dipendente");
        Console.WriteLine("2. Vedi tutti i dipendenti");
        Console.WriteLine("3. Rimuovi dipendente");
        Console.WriteLine("4. Cerca dipendente per mail");
        Console.WriteLine("5. Modifica dipendente");
        Console.WriteLine("7. Esci");
    }

    public void MostraDipendenti(List<string> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine(user); // Visualizzazione dei nomi degli utenti
        }
    }

    public string GetInput()
    {
        return Console.ReadLine(); // Lettura dell'input dell'utente
    }
}