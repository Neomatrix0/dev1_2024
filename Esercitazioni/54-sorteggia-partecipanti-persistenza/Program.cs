﻿using Spectre.Console;

List<string> partecipanti = new List<string>();
string nome;
var inserimento = "";
const string path = @"lista.txt";
const string path2 = @"squadre.txt";


/*



Versione del Prof provare  a integrarla e vedere le differenze

if(File.Exists(path)){
partecipanti = new List<string>(File.ReadAllLines(path));
}

*/

if (!File.Exists(path) & !File.Exists(path2))
{
    File.Create(path).Close();
    File.Create(path2).Close();
}
do
{
    inserimento = AnsiConsole.Prompt(
         new SelectionPrompt<string>()
        .Title("GESTIONALE LISTE")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
        .AddChoices(new[] {
            "Inserisci partecipante","Visualizza partecipanti","Ordina partecipanti",
            "Cerca partecipante","Edita partecipante","Menu squadre","Esci",
        }));

    Console.Clear();

    switch (inserimento)
    {
        case "Inserisci partecipante":
            Console.Write("Nome partecipante: ");
            nome = Console.ReadLine();
            partecipanti.Add(nome);
            File.AppendAllText(path, $"\n {nome}");
            break;

        case "Visualizza partecipanti":
            Console.WriteLine("Elenco partecipanti:");
            foreach (string partecipante in partecipanti)
            {
                Console.WriteLine(partecipante);
            }
            break;

        case "Ordina partecipanti":
            Console.WriteLine("1. Ordine crescente");
            Console.WriteLine("2. Ordine decrescente");
            Console.Write("Scelta: ");
            int ordine = Convert.ToInt32(Console.ReadLine());
            if (ordine == 1)
            {
                partecipanti.Sort();
            }
            else if (ordine == 2)
            {
                partecipanti.Sort();
                partecipanti.Reverse();
            }
            else
            {
                AnsiConsole.Markup("[bold red]Scelta non valida[/]");
            }
            break;

        case "Cerca partecipante":
            Console.Write("Nome partecipante: ");
            nome = Console.ReadLine();
            if (partecipanti.Contains(nome))
            {
                AnsiConsole.Markup("[green bold]Il partecipante è presente nella lista[/]");
            }
            else
            {
                AnsiConsole.Markup("[red bold]Il partecipante non è presente nella lista[/]");
            }
            break;

        case "Edita partecipante":
            var partecipanteMenu = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Edita partecipante")
                .PageSize(3)
                .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
                .AddChoices(new[] {
                    "Elimina partecipante","Modifica partecipante","Back",
                }));

            switch (partecipanteMenu)
            {
                case "Elimina partecipante":
                    Console.Write("Nome partecipante: ");
                    nome = Console.ReadLine();
                    if (partecipanti.Contains(nome))
                    {
                        partecipanti.Remove(nome);
                        File.WriteAllLines(path, partecipanti);
                        AnsiConsole.Markup("[red green]Il partecipante è stato eliminato dalla lista[/]");
                    }
                    else
                    {
                        AnsiConsole.Markup("[red bold]Il partecipante non è presente nella lista[/]");
                    }
                    break;

                case "Modifica partecipante":
                    Console.Write("Nome partecipante: ");
                    nome = Console.ReadLine();
                    if (partecipanti.Contains(nome))
                    {
                        Console.Write("Nuovo nome: ");
                        string nuovoNome = Console.ReadLine();
                        int indice = partecipanti.IndexOf(nome);
                        partecipanti[indice] = nuovoNome;
                        File.WriteAllLines(path, partecipanti);
                        AnsiConsole.Markup("[bold green]Il partecipante è stato modificato nella lista![/]\n");


                    }
                    else
                    {
                        AnsiConsole.Markup("[bold red]Il partecipante non è presente nella lista[/]\n");
                    }
                    break;

                case "Back":
                    break;
            }
            break;

        case "Menu squadre":
            var subScelta = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("-----Menù squadre-----")
                    .PageSize(3)
                    .MoreChoicesText("[grey](Move up and down to select)[/]")
                    .AddChoices(new[] {
                        "Numero partecipanti", "Dividi partecipanti in 2 squadre", "Dividi partecipanti in 2 squadre con random","Back"
                    }));

            switch (subScelta)
            {
                case "Numero partecipanti":
                    Console.WriteLine($"Numero partecipanti: {partecipanti.Count}");
                    break;

                case "Dividi partecipanti in 2 squadre":
                    int split = partecipanti.Count / 2;
                    List<string> squadra1 = partecipanti.GetRange(0, split);
                    List<string> squadra2 = partecipanti.GetRange(split, partecipanti.Count - split);
                    Console.WriteLine("Squadra 1:");
                    foreach (string partecipante in squadra1)
                    {
                        Console.WriteLine(partecipante);
                    }
                    Console.WriteLine("Squadra 2:");
                    foreach (string partecipante in squadra2)
                    {
                        Console.WriteLine(partecipante);
                    }

                    using (StreamWriter writer = new StreamWriter(path2))
                    {
                        foreach (string partecipante in squadra1)
                        {
                            writer.WriteLine($"Squadra 1: {partecipante}");
                        }
                        foreach (string partecipante in squadra2)
                        {
                            writer.WriteLine($"Squadra 2: {partecipante}");
                        }
                    }
                    break;

                case "Dividi partecipanti in 2 squadre con random":
                    List<string> squadra1Random = new List<string>();
                    List<string> squadra2Random = new List<string>();
                    Random random = new Random();
                    while (partecipanti.Count > 0)
                    {
                        int indice = random.Next(partecipanti.Count);
                        string partecipante = partecipanti[indice];
                        partecipanti.RemoveAt(indice);
                        if (squadra1Random.Count < squadra2Random.Count)
                        {
                            squadra1Random.Add(partecipante);
                            File.AppendAllText(path2, $"\n Nuovo Membro random squadra 1: {partecipante}");
                        }
                        else
                        {
                            squadra2Random.Add(partecipante);
                            File.AppendAllText(path2, $"\n Nuovo Membro random squadra 2: {partecipante}");
                        }
                    }
                    Console.WriteLine("Squadra 1:");
                    foreach (string partecipante in squadra1Random)
                    {
                        Console.WriteLine(partecipante);
                    }
                    Console.WriteLine("Squadra 2:");
                    foreach (string partecipante in squadra2Random)
                    {
                        Console.WriteLine(partecipante);
                    }
                    partecipanti.Clear();
                    File.WriteAllLines(path, partecipanti);
                    break;

                case "Back":
                    break;

                default:
                    AnsiConsole.Markup("[bold red]Scelta non valida[/]");
                    break;
            }
            break;

        case "Esci":
            AnsiConsole.Markup("[bold yellow]Arrivederci![/]");
            break;

        default:
            AnsiConsole.Markup("[bold red]Scelta non valida[/]");
            break;
    }

    if (inserimento != "Esci")
    {
        AnsiConsole.Markup($"\n[bold white]Premi un tasto per continuare...[/]\n");
        Console.ReadKey();
        Console.Clear();
    }

} while (inserimento != "Esci");
