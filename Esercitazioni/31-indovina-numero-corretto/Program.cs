using Spectre.Console;

Console.Clear();
// Guess the proper number

Random random = new Random();

// declare variables

int maxNumber = 100;
int minNumber = 1;
int counter = 0;
string userSuggest;
bool guessed = false;


//Console.WriteLine($"PC:Welcome,please think a number...");

AnsiConsole.MarkupLine("[bold yellow]Think of a number between 1 and 100, I'm gonna try and guess it.[/]");

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


/* versione per spectre console

﻿using Spectre.Console;


Console.Clear();
Random random = new Random();
        int lowerBound = 1;
        int upperBound = 100;
        int computerGuess;
        int guesses = 0;

        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[bold yellow]Think of a number between 1 and 100, I'm gonna try and guess it.[/]");
        Thread.Sleep(2000);
        bool gameIsRunning = true;

        while (gameIsRunning)
        {
            AnsiConsole.Clear();
            computerGuess = random.Next(lowerBound, upperBound + 1);
            
            // Displaying the computer's guess in a box
            var panel = new Panel($"[bold yellow]Is your number {computerGuess}?[/]")
                .Border(BoxBorder.Double)
                .Header("[bold green]Guess[/]");
            AnsiConsole.Write(panel);
            
            guesses++;

            string answer = AnsiConsole.Ask<string>("[bold]Enter [green]'yes'[/] or [red]'no'[/]:[/]");

            if (answer.ToLower() == "yes")
            {
                AnsiConsole.MarkupLine("[bold green]HAHA! I won![/]");
                AnsiConsole.MarkupLine($"[bold blue]It took me {guesses} guesses[/]");
                gameIsRunning = false;
            }
            else if (answer.ToLower() == "no")
            {
                string answer2 = AnsiConsole.Ask<string>($"[bold]Is it [royalblue1]higher[/] or [steelblue1_1]lower[/] than {computerGuess}?[/]");

                if (answer2.ToLower() == "higher")
                {
                    lowerBound = computerGuess + 1;
                }
                else if (answer2.ToLower() == "lower")
                {
                    upperBound = computerGuess - 1;
                }
            }
        }

        */