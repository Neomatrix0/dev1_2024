using System.Data.SQLite;
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        var db = new Database(); // Model
        var view = new View(db); // View
        var controller = new Controller(db, view); // Controller
        controller.MainMenu(); // Menu principale dell'app

        Statistiche statistiche = new Statistiche(10, 2);

            Dipendente dipendente = new Dipendente("Mario","Rossi","10/10/1960","impiegato","mario.rossi@gmail.com",25000,statistiche);

 //   Console.WriteLine($"Nome: {dipendente.Nome}, Cognome: {dipendente.Cognome}, Data Nascita: {dipendente.DataNascita}, Mail: {dipendente.Mail}, Mansione: {dipendente.Mansione}, Stipendio: {dipendente.Stipendio}");
        
    }
}