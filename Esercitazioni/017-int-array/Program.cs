// array int


int [] numeri = new int [3];
    numeri[0] = 10;
    numeri[1] = 20;
    numeri[2] = 30;


Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]}, {numeri[2]}.");


foreach( int numero in numeri){
    Console.WriteLine($"I numeri sono {numero}");

}