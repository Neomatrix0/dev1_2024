﻿// pulizia console

Console.Clear();

        // creazione oggetto random 

        Random random = new Random();

        // creazione lista di punteggio

        List<int> totalPoints = new List<int>(); 

        // array per contenere frequenza numeri
        int[] frequency = new int[6]; 

        // condizione per continuazione gioco
        bool continuePlaying = true;
        
        while (continuePlaying)
        {
            Console.WriteLine("Quanti dadi vuoi lanciare?");

            // numero di dadi che l'utente sceglie di lanciare

            int answer = Convert.ToInt32(Console.ReadLine());

            //Creazione array results che sarà della dimensione del numero di dadi scelto(answer) e conterrà i i singoli valori

            int[] results = new int[answer];
            int sum = 0;
            for (int i = 0; i < answer; i++)
            {
                // i valori nell'array results saranno i valori random di ogni singolo dado tirato il primo turno
                results[i] = random.Next(1, 7);
                sum += results[i];
                Console.WriteLine($"dado {i + 1}: {results[i]}");

                // aggiorna la frequenza del risultato ottenuto

                frequency[results[i] - 1]++;
            }
           totalPoints.Add(sum);
            Console.WriteLine("");
            Console.WriteLine($"Somma totale: {sum}\n");
            Console.WriteLine("");
            Console.WriteLine("Punti totali dai turni precedenti:"); 
            foreach (int point in totalPoints)
            {
                Console.WriteLine(point);
            } 
            Console.WriteLine("");
            Console.WriteLine("Frequenza di ogni numero:");
            for (int i = 0; i < frequency.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {frequency[i]}");
            }

            // media del punteggio
            
            double average = totalPoints.Average();
            Console.WriteLine("");
            Console.WriteLine($"\nMedia punti: {average}");

            // usa il metodo .Max() per prendere il valore maggiore
            int maxFrequency = frequency.Max();

            // lista contenente i valori più frequenti
            List<int> mostFrequentNumbers = new List<int>();

            // ciclo nell' array frequency
            for (int i = 0; i < frequency.Length; i++)
            {
                if (frequency[i] == maxFrequency)           // se il valore nell'array frequency è == al valore massimo dentro frequency
                {
                    mostFrequentNumbers.Add(i + 1);         // aggiungi elemento massimo in lista mostFrequentNumbers
                }
            }

            // stampa risultati
            Console.WriteLine($"Numero più frequente:   {string.Join(", ", mostFrequentNumbers)}");
            
            Console.WriteLine("\nVuoi giocare ancora? (s/n)");

            // input di risposta dell'utente
            string response = Console.ReadLine()!;

            // se la risposta è diversa da s il gioco si chiude
            if (response.ToLower() != "s")
            {
                continuePlaying = false;
            } 
        }

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