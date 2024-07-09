﻿Random random = new Random();
int counter =10;
int myNumber;
int maxNumber = 100;
int minNumber = 1;
int pcNumber;

Console.WriteLine("Choose a number and the pc will try to figure it out");


 myNumber= Convert.ToInt32(Console.ReadLine());

// condition to keep the loop

while(counter >0){

// clean console

Console.Clear();

Console.WriteLine("This is the user number: " + myNumber);

// pause for one second

Thread.Sleep(1000);

// range minimum and max value

pcNumber = random.Next(minNumber, maxNumber+1);

Console.WriteLine($"This is the number chosen by PC:  {pcNumber}");

// win condition

if(pcNumber == myNumber){
    Console.WriteLine($"it's {myNumber} so PC has won.");

// exit the loop

                                               
    Thread.Sleep(1000);
    break;

// if guessed number is lower than useer number

}else if(pcNumber < myNumber){
    Console.WriteLine($"it's {pcNumber} still too low. Try an higher number");
    
// try an higher number
    
    minNumber = pcNumber +1;
    
    Thread.Sleep(1000);


}else{
    Console.WriteLine($"it's {pcNumber} still too high.");

    // try a lower number

    maxNumber = pcNumber -1;
    
    Thread.Sleep(1000);
    
}

// counts and reduce by one for each loop

counter--;
Thread.Sleep(1000);

// if the pc didn't guess the number print this message

}
if(counter == 0){
    Console.WriteLine($"Pc couldn't guess the {myNumber} within 10 tries.");
}

