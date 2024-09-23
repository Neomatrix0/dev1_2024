using System.Data.SQLite;
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
        Console.WriteLine("2. Vedi dipendente");
        Console.WriteLine("3. Esci");
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