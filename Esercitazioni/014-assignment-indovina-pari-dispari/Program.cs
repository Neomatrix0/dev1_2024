
Random random = new Random();

Console.Write("Scegli Pari o Dispari (P/D): ");
string scelta = Console.ReadLine().ToUpper();

Console.Write("Inserisci un numero: ");
int numeroUtente = int.Parse(Console.ReadLine());

int numeroComputer = random.Next(1, 11);
Console.WriteLine($"Il computer ha scelto: {numeroComputer}");

int somma = numeroUtente + numeroComputer;
bool isPari = somma % 2 == 0;

if ((isPari && scelta == "P") || (!isPari && scelta == "D"))
{
    Console.WriteLine($"La somma è {somma}. Hai vinto!");
}
else
{
    Console.WriteLine($"La somma è {somma}. Hai perso!");
}



/*


Random random = new Random();

int numeroComputer = random.Next(1, 11);

Console.WriteLine("Scegli pari o dispari (p/d): ");


string scelta = Console.ReadLine().ToUpper();


Console.WriteLine("Scegli un numero da 1 a 10");

int numeroScelto = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"il numero casuale è {numeroComputer} ");

int somma = numeroScelto + numeroComputer;


if ((somma % 2 == 0 && scelta == "P") || (somma != 2 && scelta == "D")) {

    Console.WriteLine($"La somma del numero casuale e del tuo numero è {somma}.Hai vinto!");
}else if(somma % 2 != 0 && scelta == "P")
{
    Console.WriteLine($"La somma del numero casuale e del tuo numero è {somma}.Hai perso!");
}; */


