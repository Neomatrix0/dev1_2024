double[]numeri = {3.14159,2.71828,1.61803};
for(int i =0; i <numeri.Length;i++){
    numeri[i] = Math.Round(numeri[i],2);
    Console.WriteLine($"Numero arrotondato: {numeri[i]}");
}


// arrotondamento weccesso e difetto


double[]numeri = {3.14159,2.71828,1.61803};
for(int i =0; i <numeri.Length;i++){
    double arrotondatoPerEccesso = Math.Ceiling(numeri[i]);
    double arrotondatoPerDifetto = Math.Floor(numeri[i]);
    Console.WriteLine($"Numero arrotondato per eccesso: {arrotondatoPerEccesso}");
    Console.WriteLine($"Numero arrotondato per difetto: {arrotondatoPerDifetto}");


}

// arrotondamento MidPointRounding

double[]numeri = {3.5,4.5,5.5}; // esempi odi array di numeri
for(int i =0; i <numeri.Length;i++){
    double arrotondatoPerDifetto = Math.Round(numeri[i],MidpointRounding.ToEven); // arrotondamento per difetto
    double arrotondatoPerEccesso = Math.Round(numeri[i],MidpointRounding.AwayFromZero); // arrotonda per eccesso
    
    Console.WriteLine($"Numero arrotondato per difetto: {arrotondatoPerDifetto}");
    Console.WriteLine($"Numero arrotondato per eccesso: {arrotondatoPerEccesso}");


}

