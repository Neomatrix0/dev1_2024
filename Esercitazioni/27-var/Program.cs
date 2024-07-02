// See https://aka.ms/new-console-template for more information

var numeri = new List<int> { 1, 2, 3, 4,5};

foreach ( var numero in numeri){
    Console.WriteLine(numero);
}


// utilizziamo var perchè non sappiamo il tipo di dato che contiene la lista
// se fosse una lista fi stringhe avremmo dovuto scrivere List<string> numeri = new List<string> {"1","2","3"};
//oppure List<int> numeri = new List <int> {1,2,3}

//inoltre possiamo usare var anche per i dati anonimi

//ad esempio var persona = new {Nome = "Mario", Cognome = "Rossi"};
