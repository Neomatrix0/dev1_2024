//inizializzazione array numeri

int [] numeri = {5,9,1,3,4};
// per inizializzare l'array al primo valore dell'indice

int max = numeri[0];    // inizializza il massimo al primo elemento in modo che possa essere confrontato  
int min = numeri[0];    // inizializza il minimo al primo elemento in modo che possa essere confrontato

for(int i = 1; i < numeri.Length;i++){

    // metodo Max e Min per prendere valore massimo e minimo dell'array
    max = Math.Max(max, numeri[i]);     // aggiorna il massimo se il numero corrente è maggiore
    min = Math.Min(min, numeri[i]);     // aggiorna il minimo se il numero corrente è minore
}

// stampa valori

Console.WriteLine("Massimo: "+ max);
Console.WriteLine("Minimo: "+ min);