// pulire terminale

Console.Clear();


// Stampare il valore di una variabile

int numero;                                   // dichiaro una variabile di tipo intero

numero = 10;                                 //inizializzo variabile

Console.WriteLine(numero);                  // stampo valore della variabile

// Stampare il valore di una variabile con un messaggio


int eta = 20;                              //dichiaro e inizializzo una variabile eta con valore 20

Console.WriteLine("L'età è " + eta);       //stampo il valore della variabile con un messaggio

// oppure con interpolazione

Console.WriteLine($"L'età è {eta}");

eta++;                                      //incrementa di 1

Console.WriteLine($"L'età è {eta}");

eta+=5;                                     //incrementa di 5

Console.WriteLine($"L'età è {eta}");

eta-=5;                                     //decrementa di 5

Console.WriteLine($"L'età è {eta}");

//stampare due variabili una stringa ed una int

string nome = "Mario";

Console.WriteLine($"Il nome è {nome} e l'età è {eta}");     // stampa variabili nome ed eta con un messaggio


