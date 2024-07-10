﻿int []numeroDadi = new int[5];
int punteggio =0;

Random random = new Random();


//int indice = random.Next(1,7);


for(int i =0; i < numeroDadi.Length; i++){
    numeroDadi[i] = random.Next(1,7);
    Console.WriteLine($"Il dado {i+1} ha valore {numeroDadi[i]}");
}


Console.WriteLine("Quali dadi vuoi ritirare da 1 a 5?");

int scelta = Convert.ToInt32(Console.ReadLine());

// rilancia dado

if(scelta >= 1 && scelta <= 5){

    numeroDadi[scelta -1] = random.Next(1,7);
    Console.WriteLine($"Il nuovo valore del dado {scelta} è {numeroDadi[scelta -1]} ");

    /* for (int i = 0; i < numeroDadi.Length; i++)
        {
            
            for (int j= i +1; j < numeroDadi.Length; j++)
            {

                if (numeroDadi[i] == numeroDadi[j])
                Console.WriteLine(numeroDadi[j]);
                    punteggio +=1;
                    
            }
            
        }  
        Console.WriteLine(punteggio); */

    if(numeroDadi.Contains(numeroDadi[scelta-1])){
        punteggio+=1;
        Console.WriteLine($"Il punteggio è {punteggio}");

    }

}else{
    Console.WriteLine("Puoi scegliere solo dadi da 1 a 5");

}

















/*// Yahtzee versione originale

Console.WriteLine("This is Yahtzee game. We launch 5 dices.");

Random random = new Random();
int[] dices = new int[5];
int score;
bool keepLoop = true;

while (keepLoop)
{
    // Reset score at the start of each loop
    score = 0;

    // Roll the dices
    for (int index = 0; index < dices.Length; index++)
    {
        dices[index] = random.Next(1, 7);
    }

    Console.WriteLine("Below the results of the five rolled dices:");
    foreach (int result in dices)
    {
        Console.Write($"{result} ");
    }


    // Calculate the score based on duplicate values

    for (int i = 0; i < dices.Length; i++)
    {
        for (int j = i + 1; j < dices.Length; j++)         // compare the first element with the next one 
        {
            if (dices[i] == dices[j])                   //add point if it finds duplicate values
            {
                score++;
            }
        }
    }

    Console.WriteLine($"\nYou got {score} points!");
    Console.WriteLine("Do you want to roll a dice again to get an extra point? Type 'yes' or 'no'");

    string choice = Console.ReadLine().ToLower().Trim();

    if (choice == "yes")
    {
        Console.WriteLine("Which dice do you want to roll again (1-5)?");

        // convert string input in int

        int extraDice = Convert.ToInt32(Console.ReadLine());

        // range 1-5 to limit the number of the dices to choose 
        if (extraDice >= 1 && extraDice <= 5)
        {
            dices[extraDice - 1] = random.Next(1, 7);    //note the array index start from 0 so to take the proper array element we must subtract 1 
            Console.WriteLine($"The result of the extra roll is: {dices[extraDice - 1]}");

            // Recalculate the score after the extra roll
            int newScore = 0;
            for (int i = 0; i < dices.Length; i++)
            {
                for (int j = i + 1; j < dices.Length; j++)
                {
                    if (dices[i] == dices[j])
                    {
                        newScore++;
                    }
                }
            }

         
            if (newScore > score)
            {
                Console.WriteLine($"You got an extra point! Now the score is {newScore}");
                score = newScore; // Update the score
            }
            else
            {
                Console.WriteLine("You didn't get the extra point.");
            }

            Thread.Sleep(1000);
        }
        else
        {
            Console.WriteLine("Invalid dice number. Please choose a number between 1 and 5.");
        }
    }
    else if (choice == "no")
    {
        Console.WriteLine("You didn't get the extra point.");
        Thread.Sleep(1000);
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice. Please type 'yes' or 'no'.");
    }

    keepLoop = false; // Exit the loop after one reroll opportunity
}

Console.WriteLine("Game over.Bye!");
Thread.Sleep(1000);




*/







/* versione 2 giocatori  da testare correggere

Console.WriteLine("This is Yahtzee game. We launch 5 dices.");
        Random random = new Random();
        int[] dices = new int[5];
        int scorePlayer1 = 0, scorePlayer2 = 0;
        bool keepLoop = true;
        int currentPlayer = 1;

        while (keepLoop)
        {
            // Reset dice rolls
            for (int index = 0; index < dices.Length; index++)
            {
                dices[index] = random.Next(1, 7);
            }

            Console.WriteLine($"Player {currentPlayer}'s turn:");
            Console.WriteLine("Below the results of the five rolled dices:");
            foreach (int result in dices)
            {
                Console.Write($"{result} ");
            }
            Console.WriteLine();

            // Calculate the score based on duplicate values
            int score = 0;
            for (int i = 0; i < dices.Length; i++)
            {
                for (int j = i + 1; j < dices.Length; j++)
                {
                    if (dices[i] == dices[j])
                    {
                        score++;
                    }
                }
            }

            Console.WriteLine($"\nPlayer {currentPlayer} got {score} points!");
            Console.WriteLine("Do you want to roll a dice again to get an extra point? Type 'yes' or 'no'");
            string choice = Console.ReadLine().ToLower().Trim();

            if (choice == "yes")
            {
                Console.WriteLine("Which dice do you want to roll again (1-5)?");
                int extraDice = Convert.ToInt32(Console.ReadLine());
                if (extraDice >= 1 && extraDice <= 5)
                {
                    dices[extraDice - 1] = random.Next(1, 7);
                    Console.WriteLine($"The result of the extra roll is: {dices[extraDice - 1]}");

                    // Recalculate the score after the extra roll
                    newScore = 0;
                    for (int i = 0; i < dices.Length; i++)
                    {
                        for (int j = i + 1; j < dices.Length; j++)
                        {
                            if (dices[i] == dices[j])
                            {
                                newScore++;
                            }
                        }
                    }

                   
                    if (newScore > score )
                    {
                        Console.WriteLine($"Player {currentPlayer} got an extra point! Now the score is {newScore}");
                        score=newScore;
                    }
                    else
                    {
                        Console.WriteLine("Player didn't get the extra point.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid dice number. Please choose a number between 1 and 5.");
                }
            }
            else if (choice == "no")
            {
                Console.WriteLine("Player didn't get the extra point.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please type 'yes' or 'no'.");
            }

            // Update the player's score
            if (currentPlayer == 1)
            {
                scorePlayer1 = score;
                currentPlayer = 2; // Switch to player 2
            }
            else
            {
                scorePlayer2 = score;
                keepLoop = false; // End the game after player 2's turn
            }

            Thread.Sleep(1000);
        }

        // Display final scores
        Console.WriteLine($"\nGame over. Final scores:");
        Console.WriteLine($"Player 1: {scorePlayer1} points");
        Console.WriteLine($"Player 2: {scorePlayer2} points");
        Console.WriteLine("Goodbye!");
        Thread.Sleep(1000);
    */