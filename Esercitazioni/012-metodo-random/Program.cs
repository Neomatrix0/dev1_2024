// metodo random

Random random = new Random();       //new è un costruttore 

Console.WriteLine("Inserisci il primo numero dell'intervallo");

// converte la stringa di input in int

int primoNumero = int.Parse(Console.ReadLine());

Console.WriteLine("Inserisci il secondo numero dell'intervallo");

int secondoNumero = int.Parse(Console.ReadLine());

// genera numero random nell'intervallo scelto

int numeroCasuale = random.Next(primoNumero, secondoNumero);

Console.WriteLine($"Il numero casuale è {numeroCasuale}");

