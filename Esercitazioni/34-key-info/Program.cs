
// Ciclo che continua fino a quando non viene premuto il tasto 'N' utilizzando KeyInfo
// keyInfo  è una struttura che rappresenta le informazioni di un tasto premuto sulla tastiera.
// è case insensitive quindi 'N' e in 'n'sono considerati 2 tasti uguali
// ad esempio keyInfo.Key == ConsoleKey.N significa che se premi N o n sulla tastiera e il ciclo termina
// viene utilizzata per leggere i tasti premuti dall'utente senza mostrare i caratteri a schermo


Console.WriteLine("Premi N per continuare...");


        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.N) // se premo N
            {
                break; // Esce dal ciclo se viene premuto 'N'
            }
        }

//imposta il colore dello sfondo e del testo

Console.BackgroundColor = ConsoleColor.Blue;
Console.BackgroundColor = ConsoleColor.White;

// stampa messaggio

Console.WriteLine("Questo testo è bianco con sfondo blu");

// resetta i colori

Console.ResetColor();
Console.WriteLine("Questo tasto è stampato con i colori predefiniti");