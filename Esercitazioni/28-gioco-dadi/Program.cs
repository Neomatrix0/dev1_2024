// dice game
Console.WriteLine("Lancio dei dadi");


Random random = new Random();

int scoreGiocatore1 = 100;

int scorePC = 100;
bool prosecuzione = true;

do
{
    Console.Clear();

    // primo lancio giocatore 1
    int primoLancioGiocatore1 = random.Next(1, 7);

    // secondo lancio giocatore 1

    int secondoLancioGiocatore1 = random.Next(1, 7);

    // somma dei 2 lanci del giocatore 1
    int sommaLanciGiocatore1 = primoLancioGiocatore1 + secondoLancioGiocatore1;

    Console.WriteLine($"\nIl giocatore 1 ha sorteggiato: {sommaLanciGiocatore1}");

    // primo lancio pc
    int primoLancioPC = random.Next(1, 7);

    // secondo lancio pc

    int secondoLancioPC = random.Next(1, 7);

    // somma lanci pc
    int sommaLancioPC = primoLancioPC + secondoLancioPC;

    Console.WriteLine($"Il pc ha sorteggiato: {sommaLancioPC}");

    // se giocatore 1 ha fatto un punteggio > del PC.il punteggio del pc verrà diminuito della differenza dei punteggi

    if (sommaLanciGiocatore1 > sommaLancioPC)
    {
        int differenza = sommaLanciGiocatore1 - sommaLancioPC;
        scorePC = scorePC - differenza;
        Console.WriteLine($"score PC= {scorePC}");
        Console.WriteLine($"score Giocatore1= {scoreGiocatore1}");

        Console.WriteLine("\nPremi un tasto per proseguire il turno\n");
        Console.ReadKey();

        // se pc raggiunge lo 0 ha perso e il gioco finisce

        if (scorePC <= 0)
        {
            Console.WriteLine($"\nPC ha perso");
            prosecuzione = false;
        }

        // se lanci del pc sono > dei lanci del giocatore 1,  l giocatore1 vedrà diminuito il proprio punteggio della differenza tra i risultati
    }
    else if (sommaLanciGiocatore1 < sommaLancioPC)
    {
        int differenza2 = sommaLancioPC - sommaLanciGiocatore1;
        scoreGiocatore1 = scoreGiocatore1 - differenza2;
        Console.WriteLine($"score giocatore 1= {scoreGiocatore1}");
        Console.WriteLine($"score PC= {scorePC}");
        Console.WriteLine("Premi un tasto per proseguire il turno");
        Console.ReadKey();

        // se il punteggio di giocatore 1 è < di 0 giocatore 1 ha perso
        if (scoreGiocatore1 <= 0)
        {
            Console.WriteLine($"\nGiocatore1 hai perso");
            prosecuzione = false;
        }
    }

    // parità

    else
    {
        Console.WriteLine("parità");

    }

} while (prosecuzione);       // condizione di prosecuzione del ciclo



