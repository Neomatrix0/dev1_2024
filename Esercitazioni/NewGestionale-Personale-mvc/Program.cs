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

        
    }
}