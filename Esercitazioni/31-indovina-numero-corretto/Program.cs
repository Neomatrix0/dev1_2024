// Guess the proper number

Random random = new Random();

// declare variables

int maxNumber = 100;
int minNumber = 1;
int counter = 0;
string userSuggest;
bool guessed = false;


Console.WriteLine($"PC:Welcome,please think a number...");

// loop for tries

while (counter < 5 && !guessed)
{
    // increase counter for each loop

    counter++;   

    // range 1-100 for random numbers               

    int guessNumber = random.Next(minNumber, maxNumber + 1);

// Computer try to guess number

    Console.WriteLine($"PC:I chose the number {guessNumber}.Press a button to continue...");

    Console.ReadKey();          // press a button

    Console.WriteLine("PC: Please suggest me if my number is lower type + if is higher type - otherwise c");

    // user input for choice

    userSuggest = Console.ReadLine().Trim().ToLower();

    switch (userSuggest)
    {


        case "c":
            Console.WriteLine($"Congratulations you won.The game is over you guessed the number in {counter - 1} tries");       // win case
            //counter = 5;
            guessed = true;
            break;

        case "+":
            minNumber = guessNumber + 1;        // type + update range for an higher number


            break;

        case "-":

            maxNumber = guessNumber - 1;        // type - update range for a lower number


            break;

        default:
            Console.WriteLine("Digit a correct answer between + - c");   // in case of wrong number

            break;
 



    }

 
}




 /* If(guessed == false){

Console.WriteLine("You lost");
break;
}else{
    Console.WriteLine("Congratulations you won");
}  */


