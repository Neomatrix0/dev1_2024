// Calcolatore numeri random con 5 tentativi

// inizializzo contatore

int conteggio = 5;


Random random = new Random();

// intervallo generazione numeri random

int numeroCasuale = random.Next(1, 101);

//ciclo while per richiedere fino a un massimo di  5 volte l'inserimento del numero 

while (conteggio > 0)
{
    conteggio--;

// inizializzo variabile per conteggiare il numero di tentativi

    int tentativi =5 - conteggio;



    Console.WriteLine("Prego inserisca un numero per indovinare quello sorteggiato");

    // converte input in intero

    int numeroScelto = Convert.ToInt32(Console.ReadLine());

    // se il numero è giusto

    if (numeroScelto == numeroCasuale)
    {

        Console.WriteLine($"Complimenti hai indovinato il numero sorteggiato {numeroCasuale} in {tentativi} tentativi");
        break;

    }
    else if (numeroScelto > numeroCasuale)                      // suggerimento se il numero scelto è più grande del numero estratto
    {
        Console.WriteLine("Il numero scelto è troppo alto");


    }
    else
    {

        Console.WriteLine("Il numero scelto è troppo basso");   // suggerimento se il numero scelto è inferiore al numero estratto
    }
}
Console.WriteLine($"Il numero sorteggiato casualmente è {numeroCasuale}");      // informa circa il valore estratto



// versione dell'insegnante

/*
Random random = new Random();



int numeroSegreto = random.Next(1, 101);

int tentativi = 0;

while ( tentativi < 5)

{
    Console.write("Inserisci un numero: ");

    int tentativo = int.Parse(Console.ReadLine());

    if(tentativo < numeroSegreto){

    Console.WriteLine("Troppo basso");

    }
    else if (tentativo > numeroSegreto)
    {
    Console.WriteLine("Troppo alto");
    }
    else{
        Console.WriteLine("Congratulazioni hai indovinato il numero segreto.");
        return;
    }

    tentativi++;

}

Console.WriteLine("Hai esaurito i tentativi!Il numero segreto era  " + numeroSegreto);


*/