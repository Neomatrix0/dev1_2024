﻿Console.Clear();
        Random random = new Random();
        List<int> totalPoints = new List<int>(); 
        int[] frequency = new int[6]; 
        bool continuePlaying = true;
        
        while (continuePlaying)
        {
            Console.WriteLine("Quanti dadi vuoi lanciare?");
            int answer = Convert.ToInt32(Console.ReadLine());
            int[] results = new int[answer];
            int sum = 0;
            for (int i = 0; i < answer; i++)
            {
                results[i] = random.Next(1, 7);
                sum += results[i];
                Console.WriteLine($"dado {i + 1}: {results[i]}");
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
            double average = totalPoints.Average();
            Console.WriteLine("");
            Console.WriteLine($"Media punti: {average}");

            int maxFrequency = frequency.Max();
            List<int> mostFrequentNumbers = new List<int>();
            for (int i = 0; i < frequency.Length; i++)
            {
                if (frequency[i] == maxFrequency)
                {
                    mostFrequentNumbers.Add(i + 1); 
                }
            }
            Console.WriteLine("Numero(i) più frequente(i): " + string.Join(", ", mostFrequentNumbers));
            Console.WriteLine("");
            Console.WriteLine("Vuoi giocare ancora? (s/n)");
            string response = Console.ReadLine()!;
            if (response != "s")
            {
                continuePlaying = false;
            }
        }