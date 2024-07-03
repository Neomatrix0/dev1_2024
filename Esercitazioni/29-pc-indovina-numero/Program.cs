// VERSIONE DA CORREGGERE
/*

Random random = new Random();
int counter =10;
int myNumber;
int maxNumber = 100;
int minNumber = 1;
Console.WriteLine("Choose a number and the pc will try to figure it out");
 myNumber= Convert.ToInt32(Console.ReadLine());


while(counter >0){
Console.Clear();

Console.WriteLine("This is my number: " + myNumber);
Thread.Sleep(1000);



int pcNumber = random.Next(minNumber, maxNumber)+1;
//int findNumber = (maxNumber + minNumber)/2;

//int tryLowNum = random.Next(1,pcNumber);

//int tryGreaterNum = random.Next(pcNumber,101);

Console.WriteLine("This is pc number: " + pcNumber);

if(pcNumber == myNumber){
    Console.WriteLine($"it's {myNumber} so PC has won.");
    
    counter =0;
    Thread.Sleep(1000);

}else if(pcNumber < myNumber){
    Console.WriteLine($"it's {pcNumber} still too low. Try an higher number");
    //tryLowNum;
    
    //random.next(pcNumber,11);
    Console.WriteLine($"Pc: I try a greater number:\n{pcNumber+1}");
    Thread.Sleep(1000);


}else{
    Console.WriteLine($"it's {pcNumber} still too high.");

    Console.WriteLine($"Pc try a lower number:\n{pcNumber-1}");
    Thread.Sleep(1000);
    
}

counter--;
Thread.Sleep(1000);

}

//Console.WriteLine($"Il numero sorteggiato casualmente è {numeroCasuale}");   
*/