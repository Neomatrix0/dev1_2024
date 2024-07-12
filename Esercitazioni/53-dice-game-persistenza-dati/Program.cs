using Spectre.Console;

// da finire modificare lista add per punteggi

int puntiUmano = 100; // Entrambi i giocatori iniziano con 100 punti
int puntiPc = 100;

List<int> scoresPc = new List<int>();
List<int> scoresUmano = new List<int>();

DateTime now = DateTime.Now;
int currentHour = now.Hour;
int currentMinute = now.Minute;
Random random = new Random();

string path = @"registro.txt";
string path2 = @"registroVittorie.txt";

string[] lines = File.ReadAllLines(path);          // legge tutte le righe del file

// crea un array di stringhe con la lunghezza del numero di righe del file





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

    AnsiConsole.Markup($"\n[green]Umano lancia i dadi: {dado1Umano} e {dado2Umano}[/] [bold yellow](Totale: {sommaUmano})[/]\n");
    AnsiConsole.Markup($"[blue]PC lancia i dadi: {dado1Pc} e {dado2Pc}[/] [bold yellow]   (Totale: {sommaPc})[/]\n");



    // Calcola la differenza e aggiorna i punteggi
    if (sommaUmano > sommaPc)
    {
        puntiPc -= sommaUmano - sommaPc;
        AnsiConsole.Markup($"\n[underline red]Il PC perde {sommaUmano - sommaPc} punti.[/]\n ");

    }
    else if (sommaPc > sommaUmano)
    {
        puntiUmano -= sommaPc - sommaUmano;
        AnsiConsole.Markup($"\n[underline red]L'umano perde {sommaPc - sommaUmano} punti.[/]\n");
    }
    else
    {
        AnsiConsole.Markup("[bold red]Parità in questo turno.[/]");
    }

    AnsiConsole.Write(new BarChart()
.Width(60)
.Label("[green bold underline]Risultati[/]")
.CenterLabel()
.AddItem("[bold blue]Punteggio PC[/]", puntiPc, Color.Blue)
.AddItem("[bold green]Punteggio Umano[/]", puntiUmano, Color.Green));

    AnsiConsole.Markup($"\n[bold green]Punti Umano: {puntiUmano} [/] [bold blue]Punti PC: {puntiPc}[/]\n");
    AnsiConsole.Markup("[bold]Premi un tasto per il prossimo turno...[/]");
    Console.ReadKey();
}

File.AppendAllText(path, $"Punti PC: {puntiPc}\nPunti Umano: {puntiUmano}\n Orario: {currentHour}:{currentMinute}\n");






if (puntiUmano <= 0)
{
    AnsiConsole.Markup("[bold red]L'umano ha perso![/]");
    AnsiConsole.Markup($"[bold white]\nLa partita è finita alle: {currentHour}:{currentMinute}[/]");
    scoresPc.Add(puntiPc);
}
else
{
    AnsiConsole.Markup("[bold red]Il PC ha perso![/]");
    AnsiConsole.Markup($"[bold white]\nLa partita è finita alle: {currentHour}:{currentMinute}[/]");
    scoresUmano.Add(puntiUmano);

}


foreach(int punti in scoresPc){
    Console.WriteLine($"punti pc: {punti}");
}

foreach(int punti in scoresUmano){
    Console.WriteLine($"punti umano: {punti}");
} 


// darà il punteggio più alto di tutti quelli salvati nella lista
if (scoresPc.Count > 0){

scoresPc.Reverse();


    int maxPcScore = scoresPc[0];
    
    //Console.WriteLine($"\nPunteggio max PC: {scoresPc.Max()}");
    File.AppendAllText(path2, $"Il punteggio massimo del pc è {maxPcScore}\n");
}

if (scoresUmano.Count > 0)
{
    scoresUmano.Reverse();
   // scoresUmano.Max();
   int maxUmanoScore = scoresUmano[0];
    Console.WriteLine($"\nPunteggio max Umano: {maxUmanoScore}");
    File.AppendAllText(path2, $"Il punteggio massimo dell'umano è {maxUmanoScore}\n");
}






