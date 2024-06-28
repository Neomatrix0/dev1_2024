// Assignment Strutture dati


List<string> nomi = new List<string>();

nomi.Add("Mattia");
nomi.Add("Serghei");
nomi.Add("Daniele");
nomi.Add("Matteo");
nomi.Add("Allison");
nomi.Add("Sharon");
nomi.Add("Silvio");
nomi.Add("Ginevra");

// lista da riempire con i nomi rimossi dalla prima lista

List<string> listaSorteggiati = new List<string>();

// random va messo fuori dal ciclo per non creare più volte l'oggetto

Random random = new Random();

// finchè count > 0 stampa nomi rimasti

while (nomi.Count > 0)
{


    // indice prende numero casuale nel limite della lunghezza della lista 

    int indice = random.Next(nomi.Count);



    // assegna stringa sorteggiato al quale assegniamo corrispettivo lista nomi tramite l'indice generato a random

    string sorteggiato = nomi[indice];


    



    Console.WriteLine($"Il nome sorteggiato che verra rimosso è {sorteggiato}");

    // tolgo gli elementi dalla prima lista e li aggiungo sull'altra
    nomi.RemoveAt(indice);

    listaSorteggiati.Add(sorteggiato);


    Console.WriteLine("Elenco partecipanti");

    foreach (string nome in nomi)
    {
        Console.WriteLine(nome);
    }


    Console.WriteLine("Elenco sorteggiati");

    foreach (string nome in listaSorteggiati)
    {
        Console.WriteLine(nome);
    }

}

