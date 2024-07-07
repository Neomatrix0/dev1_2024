

        Random random = new Random();

        // Declare variables
        int maxNumber = 100;
        int minNumber = 1;
        int counter = 0;
        string userSuggest;
        bool guessed = false;
        

        Console.WriteLine($"PC: Welcome, please think of a number between {minNumber} and {maxNumber}...");

        // Loop for tries
        while (counter < 5 && !guessed)
        {
            // Increase counter for each loop
            counter++;

            // Guess the middle number
            int guessNumber = (minNumber+ maxNumber)/2;

            // Computer tries to guess the number
            Console.WriteLine($"PC: I chose the number {guessNumber}. Press a button to continue...");
            Console.ReadKey(); // press a button

            Console.WriteLine("PC: Please suggest if my number is lower, type + if it is higher, type - otherwise type c if correct.");

            // User input for choice
            userSuggest = Console.ReadLine().Trim().ToLower();

            switch (userSuggest)
            {
                case "c":
                    Console.WriteLine($"Congratulations! The game is over, you guessed the number in {counter} tries."); // win case
                    guessed = true;
                    Thread.Sleep(1000);
                    break;

                case "+":
                    // Update range for a higher number
                    minNumber = guessNumber + 1;
                    Thread.Sleep(1000);
                    break;

                case "-":
                    // Update range for a lower number
                    maxNumber = guessNumber - 1;
                    Thread.Sleep(1000);
                    
                    break;

                default:
                    Console.WriteLine("Please enter a correct answer: + for higher, - for lower, c for correct."); // in case of wrong input
                    counter--; // reduce 1
                    Thread.Sleep(1000);
                    break;
            }
        }

        // If not guessed within 5 tries
        if (!guessed)
        {
            Console.WriteLine("You lost. The game is over.");
        }
    

