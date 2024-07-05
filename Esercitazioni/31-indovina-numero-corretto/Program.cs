// Guess the proper number

﻿Random random = new Random();

 

int maxNumber = 100;
int minNumber = 1;
int counter = 0;
string  userSuggest;


while(counter <5){
    counter++;

int guessNumber = random.Next(minNumber, maxNumber+1);


Console.WriteLine($"PC:I chose the number {guessNumber}.Press a button to continue...");

Console.ReadKey();

Console.WriteLine("PC: Please suggest me if my number is lower type + if is higher type - otherwise c");

userSuggest = Console.ReadLine().Trim().ToLower();

switch(userSuggest){


    case "c":
    Console.WriteLine($"Congratulations you won.The game is over you guessed the number in {counter-1} tries");
    counter =5;
    break;

    case  "+":
    minNumber = guessNumber +1;
   

    break;

    case "-":

    maxNumber = guessNumber - 1;


    break;

    default:
    Console.WriteLine("Digit a correct answer between + - c");

    break;

    



}

}

