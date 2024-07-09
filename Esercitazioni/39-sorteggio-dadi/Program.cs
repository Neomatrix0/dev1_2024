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
            Console.WriteLine($"Somma totale: {sum}");
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
            Console.WriteLine($"Media punti: {average}");

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
            Console.WriteLine("Numero(i) più frequente(i): " + string.Join(", ", mostFrequentNumbers));
            Console.WriteLine("");
            Console.WriteLine("Vuoi giocare ancora? (s/n)");

            // input di risposta dell'utente
            string response = Console.ReadLine()!;

            // se la risposta è diversa da s il gioco si chiude
            if (response != "s")
            {
                continuePlaying = false;
            } 
        }