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

// random

Random random = new Random();

// finchè count > 0 stampa nomi rimasti
while (nomi.Count > 0)
{
    

    // indice prende numero casuale nel limite della lunghezza della lista 

    int indice = random.Next(nomi.Count);

    Console.WriteLine($"Il nome sorteggiato che verra rimosso è {nomi[indice]}");

    // rimuove il nome dalla lista

    nomi.RemoveAt(indice);

    Console.WriteLine("Rimangono i seguenti partecipanti:");

    // ciclo nomi rimanenti senza il nome rimosso

    foreach (string nome in nomi)
    {
        Console.WriteLine($"{nome}");

    }

    // quando tutti i nomi sono stati rimossi stampa questo messaggio

    if(nomi.Count == 0){
        Console.WriteLine("Non ci sono più partecipanti");
    }


}









// versione insegnante
/*
List<string> nomi = new List<string>();
nomi.Add("Mario");
nomi.Add("Giovanni");
nomi.Add("Luigi");



Random random = new Random();
int indice = random.Next(nomi.Count);

Console.Write($"{nomi[indice]}");



//versione alternativa inserendo più nomi in ocntmeporanea invece di uno alla volta

//nomi.AddRange(new string[]{"Mario,Giovanni,Luigi"});

//oppure

List<string> names = new List<string> {"Mario,Giovanni,Luigi"};

//Random random = new Random();
int indice = random.Next(names.Count);

Console.Write($"{names[indice]}");


*/