// Examples of Spectre console


using Spectre.Console;  // importa il namespace della libreria Spectre.Console


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
