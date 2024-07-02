// registro voti

Dictionary<string, List<int>> registroClassi = new Dictionary<string, List<int>>();

registroClassi["Marco"] = new List<int> { 7, 8, 9};

registroClassi["Laura"] = new List<int> { 6, 7, 8};

// aggiunge nuovo voto a studente Marco

registroClassi["Marco"].Add(10);

foreach(var studente in registroClassi){                            // var variabile generica per accogliere diversi tipi di dati
    Console.WriteLine($"Studente: {studente.Key}, Voti: {string.Join("-",studente.Value)}");     //string.Join unisce gli elementi di una sequenza in una stringa
}



