using System;
using System.Globalization;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            StartTheGame();
        }

        private static void StartTheGame()
        {
            var exit = false;
            var answer = "";
            var userScore = 0;
            var computerScore = 0;

            while (!exit)
            {
                // Get the user input
                var hasGivenACorrectChoice = false;
                while (!hasGivenACorrectChoice)
                    try
                    {
                        Console.Write("Choose rock, paper or scissors: ");
                        answer = Console.ReadLine();

                        if (string.Equals(answer, "Rock", StringComparison.OrdinalIgnoreCase) || string.Equals(answer, "Paper", StringComparison.OrdinalIgnoreCase) || string.Equals(answer, "Scissors", StringComparison.OrdinalIgnoreCase))
                            hasGivenACorrectChoice = true;

                        else
                            throw new ArgumentException();
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine(Environment.NewLine + "You haven't chosen rock, paper or scissors! Try again.");
                    }

                var computerChoice = GetAnAnswer();
                Console.WriteLine("The computer chose {0}.", computerChoice);
                var finalResult = Winner(answer, computerChoice);

                if (string.Equals(finalResult, "Win", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("{0} against {1}. You won!", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(answer.ToLower()), computerChoice);
                    userScore++;
                    Console.WriteLine("{0} - {1}", userScore, computerScore);
                }
                else if (string.Equals(finalResult, "Draw", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("{0} against {1}. That's a draw!", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(answer.ToLower()), computerChoice);
                    Console.WriteLine("{0} - {1}", userScore, computerScore);
                }
                else
                {
                    Console.WriteLine("{0} against {1}. You lost!", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(answer.ToLower()), computerChoice);
                    computerScore++;
                    Console.WriteLine("{0} - {1}", userScore, computerScore);
                }

                // Ask another question
                var hasEnteredACorrectChar = false;

                while (!hasEnteredACorrectChar)
                    try
                    {
                        Console.Write("Do you want to ask another question? Y/N: ");
                        var exitChar = Console.ReadLine();

                        if (string.Equals(exitChar, "Y", StringComparison.OrdinalIgnoreCase) || string.Equals(exitChar, "N", StringComparison.OrdinalIgnoreCase))
                        {
                            hasEnteredACorrectChar = true;

                            // Add 2 blank lines
                            Console.Write(Environment.NewLine + Environment.NewLine);

                            if (string.Equals(exitChar, "N", StringComparison.OrdinalIgnoreCase)) exit = true;
                        }

                        else
                        {
                            throw new ArgumentException();
                        }
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine(Environment.NewLine + "You haven't pressed Y or N! Try again.");
                    }
            }

            Console.WriteLine("Bye!");


            // Get a random answer
            static string GetAnAnswer()
            {
                // List of possible answers
                string[] answersList = {"rock", "paper", "scissors"};

                // Cast a random number
                var rnd = new Random();
                var answerIndex = rnd.Next(answersList.Length);
                var randomAnswer = answersList[answerIndex];

                return randomAnswer;
            }

            // Get the result
            static string Winner(string user, string computer)
            {
                var result = "Unknown";

                switch (user)
                {
                    case { } userVar when userVar.Equals("Rock", StringComparison.InvariantCultureIgnoreCase):
                        result = computer switch
                        {
                            // If user = rock and computer = rock
                            { } computerVar when computerVar.Equals("Rock", StringComparison.InvariantCultureIgnoreCase) => "Draw",
                            // If user = rock and computer = paper
                            { } computerVar when computerVar.Equals("Paper", StringComparison.InvariantCultureIgnoreCase) => "Lose",
                            // If user = rock and computer = scissors
                            { } computerVar when computerVar.Equals("Scissors", StringComparison.InvariantCultureIgnoreCase) => "Win",
                            _ => result
                        };

                        break;

                    case { } userVar when userVar.Equals("Paper", StringComparison.InvariantCultureIgnoreCase):
                        result = computer switch
                        {
                            // If user = paper and computer = rock
                            { } computerVar when computerVar.Equals("Rock", StringComparison.InvariantCultureIgnoreCase) => "Win",
                            // If user = paper and computer = paper
                            { } computerVar when computerVar.Equals("Paper", StringComparison.InvariantCultureIgnoreCase) => "Draw",
                            // If user = paper and computer = paper
                            { } computerVar when computerVar.Equals("Scissors", StringComparison.InvariantCultureIgnoreCase) => "Lose",
                            _ => result
                        };

                        break;

                    case { } userVar when userVar.Equals("Scissors", StringComparison.InvariantCultureIgnoreCase):
                        result = computer switch
                        {
                            // If user = scissors and computer = rock
                            { } computerVar when computerVar.Equals("Rock", StringComparison.InvariantCultureIgnoreCase) => "Lose",
                            // If user = rock and computer = paper
                            { } computerVar when computerVar.Equals("Paper", StringComparison.InvariantCultureIgnoreCase) => "Win",
                            // If user = rock and computer = scissors
                            { } computerVar when computerVar.Equals("Scissors", StringComparison.InvariantCultureIgnoreCase) => "Draw",
                            _ => result
                        };

                        break;
                }

                return result;
            }
        }
    }
}