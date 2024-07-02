// dizionario dei colori


Dictionary<string, string> colori = new Dictionary<string, string>();
colori.Add("rosso", "#FF0000");
colori.Add("verde", "#00FF00");
colori.Add("blue", "#0000FF");

// ciclo che stampa chiavi e valori KeyValuePair rappresenta la coppia di valori

foreach(KeyValuePair<string, string> colore in colori){
    Console.WriteLine($"Il colore {colore.Key} ha il codice {colore.Value}");
}

