﻿List<int> numeri = new List<int>();

numeri.Add(10);
numeri.Add(20);
numeri.Add(30);
numeri.Add(40);
numeri.Add(50);
numeri.Add(60);
numeri.Add(70);
numeri.Add(80);
numeri.Add(90);

Random random= new Random();
int indice = random.Next(0, 9);

while (true){
    Console.WriteLine("Indovina il numero sorteggiato");
Console.WriteLine(indice);
int numero = int.Parse(Console.ReadLine()!);

if (numero == numeri[indice])
{
    Console.WriteLine("Hai indovinato");
    break;
}
else
{
    
    if (numero > numeri[indice])
    {
    Console.WriteLine("Non hai indovinato");
    Console.WriteLine("il numero è piu basso");
    
    }
    else if (numero < numeri[indice])
    {
    Console.WriteLine("Non hai indovinato");
    Console.WriteLine("il numero è piu alto");
    
    }
    }
}
