﻿using Spectre.Console;

int puntiUmano = 100; // Entrambi i giocatori iniziano con 100 punti
int puntiPc = 100;
Random random = new Random();

while (puntiUmano > 0 && puntiPc > 0)

// ogni turno, ciascuno lancia due dadi

{
    // Lancio dadi umano
    int dado1Umano = random.Next(1, 7);
    int dado2Umano = random.Next(1, 7);
    int sommaUmano = dado1Umano + dado2Umano;

    // Lancio dadi computer
    int dado1Pc = random.Next(1, 7);
    int dado2Pc = random.Next(1, 7);
    int sommaPc = dado1Pc + dado2Pc;

    Console.WriteLine($"Umano lancia i dadi: {dado1Umano} e {dado2Umano} (Totale: {sommaUmano})");
    Console.WriteLine($"PC lancia i dadi: {dado1Pc} e {dado2Pc} (Totale: {sommaPc})");



    // Calcola la differenza e aggiorna i punteggi
    if (sommaUmano > sommaPc)
    {
        puntiPc -= sommaUmano - sommaPc;
        AnsiConsole.Markup($"[underline red]Il PC perde {sommaUmano - sommaPc} punti.[/]\n ");
        
    }
    else if (sommaPc > sommaUmano)
    {
        puntiUmano -= sommaPc - sommaUmano;
        AnsiConsole.Markup($"[underline red]L'umano perde {sommaPc - sommaUmano} punti.[/]\n");
    }
    else
    {
        Console.WriteLine("Parità in questo turno.");
    }

    AnsiConsole.Write(new BarChart()
.Width(60)
.Label("[green bold underline]Risultati[/]")
.CenterLabel()
.AddItem("[bold blue]Punteggio PC[/]", puntiPc, Color.Blue)
.AddItem("[bold green]Punteggio Umano[/]", puntiUmano, Color.Green));

    AnsiConsole.Markup($"[bold green]Punti Umano: {puntiUmano} [/] [bold blue]Punti PC: {puntiPc}[/]\n");
    AnsiConsole.Markup("[bold]Premi un tasto per il prossimo turno...[/]");
    Console.ReadKey();
}



if (puntiUmano <= 0)
{
    AnsiConsole.Markup("[red]L'umano ha perso![/]");
}
else
{
    AnsiConsole.Markup("[red]Il PC ha perso![/]");
}






