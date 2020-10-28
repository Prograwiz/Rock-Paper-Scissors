using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _computerScore;
        private int _userScore;
        
        // TODO: Transparent button background + add a timer between each press so that you can't spam the buttons

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RockButton_OnClick(object sender, RoutedEventArgs e)
        {
            Result(Winner("Rock", GetTheComputerChoice()));
        }

        private void PaperButton_OnClick(object sender, RoutedEventArgs e)
        {
            Result(Winner("Paper", GetTheComputerChoice()));
        }

        private void ScissorsButton_OnClick(object sender, RoutedEventArgs e)
        {
            Result(Winner("Scissors", GetTheComputerChoice()));
        }

        // Get a random answer
        private static string GetTheComputerChoice()
        {
            // List of possible answers
            string[] answersList = {"Rock", "Paper", "Scissors"};

            // Cast a random number
            var rnd = new Random();
            var answerIndex = rnd.Next(answersList.Length);
            var computerChoice = answersList[answerIndex];

            return computerChoice;
        }


        // Get the result
        private string Winner(string user, string computer)
        {
            var result = "Unknown";

            switch (user)
            {
                case { } userVar when userVar.Equals("Rock", StringComparison.InvariantCultureIgnoreCase):
                    UserChoice.Source = new BitmapImage(new Uri("pack://application:,,,/img/rock.png"));
                    switch (computer)
                    {
                        // If user = rock and computer = rock
                        case { } computerVar
                            when computerVar.Equals("Rock", StringComparison.InvariantCultureIgnoreCase):
                            ComputerChoice.Source = new BitmapImage(new Uri("pack://application:,,,/img/rock.png"));
                            result = "Draw";
                            break;
                        // If user = rock and computer = paper
                        case { } computerVar
                            when computerVar.Equals("Paper", StringComparison.InvariantCultureIgnoreCase):
                            ComputerChoice.Source = new BitmapImage(new Uri("pack://application:,,,/img/paper.png"));
                            result = "Lose";
                            break;
                        // If user = rock and computer = scissors
                        case { } computerVar
                            when computerVar.Equals("Scissors", StringComparison.InvariantCultureIgnoreCase):
                            ComputerChoice.Source = new BitmapImage(new Uri("pack://application:,,,/img/scissors.png"));
                            result = "Win";
                            break;
                    }

                    break;


                case { } userVar when userVar.Equals("Paper", StringComparison.InvariantCultureIgnoreCase):
                    UserChoice.Source = new BitmapImage(new Uri("pack://application:,,,/img/paper.png"));
                    switch (computer)
                    {
                        // If user = paper and computer = rock
                        case { } computerVar
                            when computerVar.Equals("Rock", StringComparison.InvariantCultureIgnoreCase):
                            ComputerChoice.Source = new BitmapImage(new Uri("pack://application:,,,/img/rock.png"));
                            result = "Win";
                            break;
                        // If user = paper and computer = paper
                        case { } computerVar
                            when computerVar.Equals("Paper", StringComparison.InvariantCultureIgnoreCase):
                            ComputerChoice.Source = new BitmapImage(new Uri("pack://application:,,,/img/paper.png"));
                            result = "Draw";
                            break;
                        // If user = paper and computer = scissors
                        case { } computerVar
                            when computerVar.Equals("Scissors", StringComparison.InvariantCultureIgnoreCase):
                            ComputerChoice.Source = new BitmapImage(new Uri("pack://application:,,,/img/scissors.png"));
                            result = "Lose";
                            break;
                    }

                    break;

                case { } userVar when userVar.Equals("Scissors", StringComparison.InvariantCultureIgnoreCase):
                    UserChoice.Source = new BitmapImage(new Uri("pack://application:,,,/img/scissors.png"));
                    switch (computer)
                    {
                        // If user = scissors and computer = rock
                        case { } computerVar
                            when computerVar.Equals("Rock", StringComparison.InvariantCultureIgnoreCase):
                            ComputerChoice.Source = new BitmapImage(new Uri("pack://application:,,,/img/rock.png"));
                            result = "Lose";
                            break;
                        // If user = scissors and computer = paper
                        case { } computerVar
                            when computerVar.Equals("Paper", StringComparison.InvariantCultureIgnoreCase):
                            ComputerChoice.Source = new BitmapImage(new Uri("pack://application:,,,/img/paper.png"));
                            result = "Win";
                            break;
                        // If user = scissors and computer = scissors
                        case { } computerVar
                            when computerVar.Equals("Scissors", StringComparison.InvariantCultureIgnoreCase):
                            ComputerChoice.Source = new BitmapImage(new Uri("pack://application:,,,/img/scissors.png"));
                            result = "Draw";
                            break;
                    }

                    break;
            }

            return result;
        }

        private void Result(string result)
        {
            if (string.Equals(result, "Win", StringComparison.OrdinalIgnoreCase))
            {
                ResultTextBlock.Text = "You won!";
                _userScore++;
                ScoreTextBlock.Text = $"{_userScore} - {_computerScore}";
            }
            else if (string.Equals(result, "Draw", StringComparison.OrdinalIgnoreCase))
            {
                ResultTextBlock.Text = "That's a draw!";
                ScoreTextBlock.Text = $"{_userScore} - {_computerScore}";
            }
            else
            {
                ResultTextBlock.Text = "You lost!";
                _computerScore++;
                ScoreTextBlock.Text = $"{_userScore} - {_computerScore}";
            }
        }
    }
}