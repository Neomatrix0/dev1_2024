Console.WriteLine("Quanti dadi vuoi lanciare?");

// input numero dati

int numDadi = Convert.ToInt32(Console.ReadLine());

int[] risultati = new int[numDadi];

Random random = new Random();

List<int> punteggioFinale = new List<int>();
int[] frequenza = new int[6];

bool prosecuzione = true;

while (prosecuzione)
{
    // Lancio dei dadi
    int somma = 0;
    for (int i = 0; i < numDadi; i++)
    {
        risultati[i] = random.Next(1, 7);
        somma += risultati[i];
        Console.WriteLine($"Dado {i + 1}: {risultati[i]}");
        frequenza[risultati[i] - 1]++;
    }

    punteggioFinale.Add(somma);
    Console.WriteLine($"Questo è la somma dei valori usciti al primo turno {somma}");

    foreach (var punteggio in punteggioFinale)
    {
        Console.WriteLine($"Questo è il punteggio {punteggio} corrente");
    }

    for (int i = 0; i < frequenza.Length; i++)
    {
        Console.WriteLine($"{i + 1}: numero di frequenza-> {frequenza[i]}");
    }

    Console.WriteLine("Di seguito i risultati");

    foreach (int result in risultati)
    {
        Console.WriteLine("La somma dei risultati è " + result);
    }

    double media = Queryable.Average(risultati.AsQueryable());
    Console.WriteLine($"La media dei risultati è {media}");

    int maxFrequenza = frequenza.Max();
    // lista contenente i valori più frequenti
    List<int> numeriFrequenti = new List<int>();

    for (int i = 0; i < frequenza.Length; i++)
    {
        if (frequenza[i] == maxFrequenza)
        {

            numeriFrequenti.Add(i + 1);

        }


    }

    Console.WriteLine("I numeri più frequenti " + string.Join(", ", numeriFrequenti));

    Console.WriteLine("Vuoi uscire s oppure n?");
    string decisione = Console.ReadLine();

    if (decisione != "n")
    {
        prosecuzione = false;
    }
}





// simple version

/*

﻿Console.WriteLine("Quanti dadi vuoi lanciare?");

int numDadi = int.Parse(Console.ReadLine());
int[] risultati = new int[numDadi];
int facce = 6;
int somma = 0;

Random random = new Random();

// Lancio dei dadi

for (int i = 0; i < numDadi; i++)
{
    risultati[i] = random.Next(1, 7);
    somma += risultati[i];
    Console.WriteLine($"Dado {i + 1}: {risultati[i]}");
}

Console.WriteLine($"Somma totale: {somma}");

// Salvataggio e analisi dei risultati
int[] frequenze = new int[facce]; // Inizializza un array di 6 elementi a 0

for (int i = 0; i < numDadi; i++)
{
    frequenze[risultati[i] - 1]++; // Incrementa la frequenza del numero ottenuto
}

for (int i = 0; i < facce ; i++)
{
    Console.WriteLine($"Frequenza del numero {i + 1}: {frequenze[i]}"); // Stampa la frequenza di ciascun numero
}

*/