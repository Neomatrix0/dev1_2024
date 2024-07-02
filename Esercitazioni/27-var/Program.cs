// esempi di var

var numeri = new List<int> { 1, 2, 3, 4,5};

foreach ( var numero in numeri){
    Console.WriteLine(numero);
}



// utilizziamo var perchè non sappiamo il tipo di dato che contiene la lista
// se fosse una lista di stringhe avremmo dovuto scrivere List<string> numeri = new List<string> {"1","2","3"};
//oppure List<int> numeri = new List <int> {1,2,3}
// invece utilizzando var il compilatore capisce da solo il tipo di dato
//inoltre possiamo usare var anche per i dati anonimi
//ad esempio var persona = new {Nome = "Mario", Cognome = "Rossi"};
// qui il tipo di dato è anonimo perchè non dichiarato esplicitamente
// ma il compilatore capisce che persona è un oggetto con 2 proprietà Nome e Cognome di tipo stringa
// quindi possiamo scrivere persona.Nome o persona.Cognome
// possiamo utilizzare var anche per tipi generici
//ad esempio var numeri = new List<int> {1,2,3,4,5};
