class Program
{
    static void Main()
    {
        StampaMessaggio("Ciao Mondo!");

        int risultato = Somma(3, 4);
        Console.WriteLine($"La somma è: {risultato}");
    }

    // Metodo Void
    public static void StampaMessaggio(string messaggio)
    {
        Console.WriteLine(messaggio);
    }


    // Metodo con ritorno di valore

    public static int Somma(int a, int b)
    {
        return a + b;
    }
}

// In questo programma , StampaMessaggio è un metodo void che stampa un messaggio sulla console,
//mentre Somma è un metodo che restituisce la somma di 2 parametri