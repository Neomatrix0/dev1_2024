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