// Examples of Spectre console
using Spectre.Console;



/*
//using Spectre.Console;  // importa il namespace della libreria Spectre.Console


AnsiConsole.WriteLine();
AnsiConsole.Write(new Calendar(2020, 10)
     .RoundedBorder()
     .HighlightStyle(Style.Parse("red"))
     .HeaderStyle(Style.Parse("yellow"))
     .AddCalendarEvent("An event", 2020, 9, 22)
     .AddCalendarEvent("Another event", 2020, 10, 2)
     .AddCalendarEvent("A third event", 2020, 10, 13));

// comando dotnet installazione dentro cartella progetto specifico
// dotnet add package Spectre.Console




*/


AnsiConsole.Clear();


// creare una scritta colorata

AnsiConsole.Write(new Markup("[bold yellow]Hello[/] [bold red]World!\n[/]"));


AnsiConsole.Write(new Markup("[28]Hello[/] [blue]World!\n[/]"));  



// esempio di testo formattato

AnsiConsole.Markup("[underline red]Hello[/] [10]World![/]");

AnsiConsole.Markup("[30]Hello[/] [10]World![/]");

AnsiConsole.WriteLine();

var continua = AnsiConsole.Confirm("Vuoi continuare?");

// esempio di tabella

var table = new Table();
table.AddColumn("Nome corso");
table.AddColumn("Anno");
table.AddRow("Corso di informatica","2024");
AnsiConsole.Render(table);

var rule = new Rule("[red]Hello[/]");
rule.Justification = Justify.Left; // Justify.center, Justify.right
AnsiConsole.Write(rule);

// esempio di prompt

var nome = AnsiConsole.Prompt(new TextPrompt<string>("Inserisci il tuo nome:"));

// esempio di panel

var panel = new Panel("Questo è un testo all'interno di un pannello");

panel.Border = BoxBorder.Rounded;
AnsiConsole.Render(panel);

// esempio di progress bar


