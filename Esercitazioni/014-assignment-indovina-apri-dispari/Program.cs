// generazione numeri random da 1 a 100

Random random = new Random();

// intervallo generazione numeri random

int numeroCasuale = random.Next(1, 101);

// calcolo numero pari

bool pari = numeroCasuale % 2 == 0;

Console.WriteLine("Inserisci se il numero che verrà sorteggiato sarà pari o se dispari.");

// inserisci se pari o dispari

string indovinaPari = Console.ReadLine();

// condizioni se l'utente sceglie pari e il numero è pari apparirà un messaggio altrimenti se dispari ne apparirà un altro

if( pari == true && indovinaPari == "pari"){
    Console.WriteLine($"Hai indovinato!Il numero estratto {numeroCasuale} è pari");

}else if(pari == false && indovinaPari == "dispari"){
Console.WriteLine($"Hai indovinato Il numero estratto {numeroCasuale} è dispari");
}

else{
    Console.WriteLine($"Non hai indovinato. Il numero estratto è {numeroCasuale} non è {indovinaPari}");         //se l'utente non ha indovinato verrà indicato il numero estratto e il risultato
}

/*  versione insegnante
Random random = new Random();

int numeroComputer = random.Next(1,11)

Console.WriteLine("Scegli pari o dispari (p/d): ");

string scelta = Console.ReadLine();

if(numeroComputer %2 == 0 && scelta == "p")||(numeroComputer % 2 != 0 && scelta == "d"){
 Console.WriteLine($"Il computer ha scelto {numeroComputer}.Hai vinto!");
}else{
    Console.WriteLine($"Il computer ha scelto {numeroComputer}.Hai perso!");
}







*/