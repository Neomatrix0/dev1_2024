﻿
// FeezBuzz

// esegue l'app 5 volte

for(int i = 1; i<= 5; i++){

 //genera numero random da 1 a 100   
    

Random random = new Random();

int numeroComputer = random.Next(1, 101);

//int numeroComputer = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"Numero casuale è {numeroComputer}");

//Condizioni se il numero estratto è divisibile per 3 e 5 esce FeezBuzz

if ((numeroComputer % 3 == 0) && (numeroComputer % 5 == 0))
{
    Console.WriteLine("FeezBuzz");
}
else if ((numeroComputer % 5 == 0))                    //se divisibile per 5 
{
    Console.WriteLine("Buzz");
}
else if ((numeroComputer % 3 == 0))                    // se divisibile per 3 
{
    Console.WriteLine("Feez");
}
else
{
    Console.WriteLine($"{numeroComputer} non è divisibile per i numeri richiesti");         //Se non è divisibile per 3 o per 5
}


}
