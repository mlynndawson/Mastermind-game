using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastermindGame
{
    class MainMenu
    {
        public void Main()
        {
            while (true)
            {
                Console.WriteLine(@"    ____________");
                Console.WriteLine(@"   /============\");
                Console.WriteLine(@"  / ____________ \");
                Console.WriteLine(@"  | ____________ |");
                Console.WriteLine(@"  | | -        | |");
                Console.WriteLine(@"  | |          | |");
                Console.WriteLine(@"  | | _________| | _____________________");
                Console.WriteLine(@"  \= ___________ /                       )");
                Console.WriteLine(@"  / [-----------] \                     / ");
                Console.WriteLine(@" / ::::::::::::::: \                =D-'");
                Console.WriteLine(@"(___________________)");


                Console.WriteLine("#######Let's play a game, shall we?#######");
                Console.WriteLine("");
                Console.WriteLine("(Y) - YES! Let's play");
                Console.WriteLine("(N) - NO, not today");
                
                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case ("y"):
                        Console.Clear();
                        PlayGame();
                        break;

                    case ("n"):
                        Console.WriteLine("Please come back and play a game later!");
                        return;

                    default:
                        Console.WriteLine("Invalid entry. Please try again.");
                        break;
                }
            }
        }

        private static void PlayGame()
        {
            Console.WriteLine("*********************Read my mind**********************");
            Console.WriteLine("");
            Console.WriteLine($"RULES: Guess a 4-digit number. Each digit ranges from 1-6. " +
                $" For every correct number but wrong position a minus(-) will be returned." +
                $"A correct digit in the right location will be marked a plus(+)," +
                $"and nothing for incorrect digits. Plus signs will return first in the results");
            int[] guessArr = new int[4];
            int checkDigits = 0;
            string location = "";
            int guessAttempts = 10;
            bool gameComplete = false;
            int[] answerArr = GetRandomNums();

            while (gameComplete == false)
            {
                Console.WriteLine($"Guesses remaining: {guessAttempts}");
                guessAttempts--;

                guessArr = GetGuess();
                checkDigits = CheckDigits(guessArr,answerArr);

                if(checkDigits == 4)
                {
                    Console.WriteLine("WOW!!! You WON, you can read my mind!");
                    Console.WriteLine();
                    gameComplete = true;
                }
                else if(checkDigits < 4)
                {
                    location = SimilarAnswer(guessArr, answerArr);
                    Console.WriteLine($"Maybe you can ALMOST read my mind: {location}");
                    Console.WriteLine();
                }

                if (guessAttempts == 0)
                {
                    Console.WriteLine("You LOSE!!! Sorry you could not read my mind. Please try play again");
                    Console.Write("The correct number is: ");
                    for (int i = 0; i < answerArr.Length; i++)
                    {
                        Console.Write($"{answerArr[i]}");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    gameComplete = true;
                }
            }
        }

        /// <summary>
        /// Generates random numbers 
        /// </summary>
        /// <returns>array of integers</returns>
        public static int[] GetRandomNums()
        {
            int[] answerNum = new int[4];

            Random random = new Random();
            for (int i = 0; i < answerNum.Length; i++)
            {
                answerNum[i] = random.Next(1,6);
            }
            Console.WriteLine();
            return answerNum;
        }

        /// <summary>
        /// Asks user for their guess
        /// </summary>
        /// <returns>array with guess</returns>
        public static int[] GetGuess()
        {
            int number = 0;
            int[] userGuess = new int[4];
            for (int i = 0; i < userGuess.Length; i++)
            {
                Console.Write("Digit {0}: ", (i + 1));
                while (!int.TryParse(Console.ReadLine(), out number) || number < 1 || number > 6)
                    Console.WriteLine("Invalid number!");
                userGuess[i] = number;
            }
            Console.WriteLine();
            Console.Write("Your guess: ");
            for (int i = 0; i < userGuess.Length; i++)
            {
                Console.Write(userGuess[i] + " ");
            }
            Console.WriteLine();
            return userGuess;
        }

        /// <summary>
        /// Checks for how similar the array user guess is to the answer
        /// </summary>
        /// <param name="guessArr"></param>
        /// <param name="randomNumbers"></param>
        /// <returns></returns>
        private static int CheckDigits(int[] guessArr, int[] answerArr)
        {
            int resultsCount = 0;

            for (int i = 0; i < answerArr.Length; i++)
            {
                if (guessArr[i] == answerArr[i])
                {
                    resultsCount++;
                }    
            }
            return resultsCount;
        }

        /// <summary>
        /// Provides indications of how similar the user input is to the answer
        /// </summary>
        /// <param name="guessArr"></param>
        /// <param name="randomNumbers"></param>
        /// <returns>string of - or +</returns>
        private static string SimilarAnswer(int[] guessArr, int[] answerArr)
        {
            string similarArr = "";
            string plus = "";
            string minus = "";

            for (int i = 0; i < answerArr.Length; i++)
            {
                if (guessArr[i] == answerArr[i])
                {
                    plus += "[+]";
                }
                else if (answerArr.Contains(guessArr[i]))
                {
                    minus += "[-]";
                }
            }
            return similarArr = plus + minus;
        }
    }
}
