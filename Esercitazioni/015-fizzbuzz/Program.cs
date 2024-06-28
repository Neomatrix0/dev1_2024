
// FeezBuzz

// esegue l'app 10 volte

for(int i = 1; i<= 10; i++){

 //genera numero random da 1 a 100   




Random random = new Random();

int numeroComputer = random.Next(1, 101);

//int numeroComputer = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"Numero casuale è {numeroComputer}");

//Condizioni se il numero estratto è divisibile per 3 e 5 esce FeezBuzz

if ((numeroComputer % 3 == 0) && (numeroComputer % 5 == 0))
{
    Console.WriteLine("FizzBuzz");
}
else if ((numeroComputer % 5 == 0))                    //se divisibile per 5 
{
    Console.WriteLine("Buzz");
}
else if ((numeroComputer % 3 == 0))                    // se divisibile per 3 
{
    Console.WriteLine("Fizz");
}
else
{
    Console.WriteLine($"{numeroComputer} non è divisibile per i numeri richiesti");         //Se non è divisibile per 3 o per 5
}


}

// versione insegnante

/*

﻿for (int i = 1; i <= 100; i++)
        {
            Console.Write($"numero: {i} ");
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine("");
            }
            Thread.Sleep(300); // utilizzo il metodo sleep per rallentare il ciclo
        }

        */