using Spectre.Console;
Random random = new Random();

Console.Clear();
AnsiConsole.Write(
    new FigletText("Dice game")
        .LeftJustified()
        .Color(Color.Red));

AnsiConsole.Markup($"\n\n[bold] Premi un bottone per iniziare a giocare![/]\n");
Console.ReadKey();

int puntiPc = 30;
int puntiUmano =30; // Entrambi i giocatori iniziano con 100 punti

// numero partite
int counter = 3;

List<int> scoresPc = new List<int>();
List<int> scoresUmano = new List<int>();

// creazione file di testo
string path = @"registro.txt";
string path2 = @"registroVittorie.txt";
//string path3 = @"registroTop3.txt";

// se non ci fossero i file di testo li crea

if (!File.Exists(path) && !File.Exists(path2))
{
    File.Create(path).Close();
    File.Create(path2).Close();
    //File.Create(path3).Close();
}

DateTime now = DateTime.Now;
int currentHour = now.Hour;
int currentMinute = now.Minute;

for (int i = 0; i < counter; i++)
{
    puntiUmano = 100;
    puntiPc = 100;

    while (puntiUmano > 0 && puntiPc > 0)
    {
        // Lancio dadi umano
        int dado1Umano = random.Next(1, 7);
        int dado2Umano = random.Next(1, 7);
        int sommaUmano = dado1Umano + dado2Umano;

        // Lancio dadi computer
        int dado1Pc = random.Next(1, 7);
        int dado2Pc = random.Next(1, 7);
        int sommaPc = dado1Pc + dado2Pc;

    Console.Clear();

        AnsiConsole.Markup($"\n[green]Umano lancia i dadi: {dado1Umano} e {dado2Umano}[/] [bold yellow](Totale: {sommaUmano})[/]\n");
        AnsiConsole.Markup($"[blue]PC lancia i dadi: {dado1Pc} e {dado2Pc}[/] [bold yellow](Totale: {sommaPc})[/]\n");

        // Calcola la differenza e aggiorna i punteggi
        if (sommaUmano > sommaPc)
        {
            puntiPc -= sommaUmano - sommaPc;
            AnsiConsole.Markup($"\n[underline red]Il PC perde {sommaUmano - sommaPc} punti.[/]\n");
        }
        else if (sommaPc > sommaUmano)
        {
            puntiUmano -= sommaPc - sommaUmano;
            AnsiConsole.Markup($"\n[underline red]L'umano perde {sommaPc - sommaUmano} punti.[/]\n");
        }
        else
        {
            AnsiConsole.Markup("[bold red]Parità in questo turno.[/]\n");
        }

        AnsiConsole.Write(new BarChart()
            .Width(60)
            .Label("[green bold underline]Risultati[/]")
            .CenterLabel()
            .AddItem("[bold blue]Punteggio PC[/]", puntiPc, Color.Blue)
            .AddItem("[bold green]Punteggio Umano[/]", puntiUmano, Color.Green));

        AnsiConsole.Markup($"\n[bold green]Punti Umano: {puntiUmano}[/] [bold blue]Punti PC: {puntiPc}[/]\n");
        AnsiConsole.Markup("[bold]Premi un tasto per il prossimo turno...[/]");
        Console.ReadKey();
    

    // aggiunge punti e timestamp nel file registro

    
    }
    File.AppendAllText(path, $"Punti PC: {puntiPc}\nPunti Umano: {puntiUmano}\nOrario: {currentHour}:{currentMinute}\n");
    if (puntiUmano <= 0)
    {
        AnsiConsole.Markup("\n[bold red]L'umano ha perso![/]\n");
        AnsiConsole.Write(
    new FigletText("Game Over")
        .LeftJustified()
        .Color(Color.Red));
        Console.WriteLine("Premi un tasto qualsiasi per continuare");
        Console.ReadKey();
        

    }
    else
    {
        AnsiConsole.Markup("\n[bold red]Il PC ha perso![/]\n");
        AnsiConsole.Write(
    new FigletText("Game over")
        .LeftJustified()
        .Color(Color.Red));

        Console.WriteLine("Premi un tasto qualsiasi per continuare");
        Console.ReadKey();
    }

    scoresPc.Add(puntiPc);
    scoresUmano.Add(puntiUmano);
}

// Determina il punteggio massimo
int maxPcScore = scoresPc.Count > 0 ? scoresPc.Max() : 0;
int maxUmanoScore = scoresUmano.Count > 0 ? scoresUmano.Max() : 0;

// Scrivi il punteggio massimo nel file
File.WriteAllText(path2, $"Il punteggio massimo del PC è {maxPcScore}\nIl punteggio massimo dell'umano è {maxUmanoScore}\n");




AnsiConsole.Markup($"\n[bold blue]Punteggio massimo del PC: {maxPcScore}[/]");
AnsiConsole.Markup($"\n[bold green]Punteggio massimo dell'umano: {maxUmanoScore}[/]");

/*
// odina le liste le inverte e poi prende i primi 3 valori
scoresPc.Sort();
scoresPc.Reverse();
IEnumerable<int> result = scoresPc.Take(3);
 foreach (int score in result)
        {
            //Console.WriteLine($"Ultimi 3 punteggi PC: {score}");
            File.AppendAllText(path3,"\nPunteggi pc:\n" + score);
        }

scoresUmano.Sort();
scoresUmano.Reverse();

IEnumerable<int> resultUmano = scoresUmano.Take(3);
foreach (int score in resultUmano)
        {
            //Console.WriteLine($"Ultimi 3 punteggi Umano: {score}");
            File.AppendAllText(path3,"\nPunteggi Umano:\n" + score);
        }

*/

// Stampa i punteggi per scopi di debug
/*foreach (int punti in scoresPc)
{
    Console.WriteLine($"Punti PC: {punti}");
}


foreach (int punti in scoresUmano)
{
    Console.WriteLine($"Punti Umano: {punti}");
}

*/

/*

using (var sr = new StreamReader("registro.txt")){

while(!sr.EndOfStream){
var line = sr.ReadLine();
            var values = line.Split(',');
            var punteggio = int.Parse(values[0]);
            var nome = values[1];
            punteggi.Add(punteggio, nome);
        }
    }
}

}




*/