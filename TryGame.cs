// Program name   : GuessingGame
// Program purpose: Guess a number by player which matches with randomly generated number
// Author         : Abu Enayet Siddique
// Date Modified  : 2022-07-22  0552

using System;
using System.Collections;

public class TryGame
{
    //Variables
    ArrayList allGuesses = new ArrayList();
    Random random = new Random();
    bool playGame = true;
    int guessNumber;
    int userGuess;
    int noOfGuesses;
    string playAgain;
    int points;


    public TryGame()
    {   
        
        try
        {
            PlayGame();
        }
        //handle exception if user enter string
        catch (FormatException){
            Console.WriteLine("Invalid Character entered. Try Again!");
        }
    }

    public void PlayGame()
    {
        //Game loop
        while (playGame)
        {
            guessNumber = random.Next(1, 100);
            userGuess = 0;
            noOfGuesses = 0;
            playAgain = "";

            while (userGuess != guessNumber)
            {
                Console.Write("Guess the number between 1-100  : ");
                userGuess = Convert.ToInt32(Console.ReadLine());
                ++noOfGuesses;

                //if user put the correct number (win condition)
                if (userGuess == guessNumber)
                {
                    Console.WriteLine("\t Your guess is corrent!");
                    Console.WriteLine("\t You gussed it by " + noOfGuesses + " Times");
                    Console.Write("would you like to play again? (Y/N): ");
                    playAgain = Console.ReadLine();
                    playAgain = playAgain.ToUpper();

                    //further play (user want to play again or not)
                    if (playAgain == "Y")
                    {
                        playGame = true;
                    }

                    if (playAgain == "N")
                    {
                        playGame = false;
                    }

                    //points calcualtion
                    switch (noOfGuesses)
                    {
                        case 1:
                            points = 100;
                            break;
                        case 2:
                            points = 80;
                            break;
                        case 3:
                            points = 60;
                            break;
                        case 4:
                            points = 50;
                            break;
                        case 5:
                            points = 40;
                            break;
                        case 6:
                            points = 20;
                            break;
                        default:
                            points = 0;
                            break;
                    }

                    allGuesses.Add(noOfGuesses + " Guesses- You got " + points + " points");
                }

                //if user enter lower number then the actual(generated) number
                else if (userGuess < guessNumber)
                {
                    Console.WriteLine(userGuess + " is not correct, guess a higher number!");
                }

                //if user enter higher number then the actual(generated) number
                else
                {
                    Console.WriteLine(userGuess + " is not correct, guess a lower number!");
                }

                //if user tried more than 6 times
                if (noOfGuesses >= 7)
                {
                    Console.WriteLine("You lose. Try again.");
                    return;
                }
            }

            //clear the previous played view
            Console.Clear();
        }

        //End game output
        Console.WriteLine("End of Game. Thanks for playing!");
        History();
    }

    //history display
    public void History()
    {
        Console.WriteLine("History");
        if(allGuesses.Capacity == 0)
        {
            Console.WriteLine("There is no history");
        }
        for (int i = 0; i < allGuesses.Count; ++i)
        {
            Console.WriteLine("Game " + i + " : " + allGuesses[i]);
        }
    }

}
