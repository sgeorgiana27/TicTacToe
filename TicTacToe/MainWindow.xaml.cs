using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Button> buttons;
        public enum Player
        {
            X, O
        }
        Player currentPlayer;
        int player1 = 0;
        int player2 = 0;
        bool ok;
        public MainWindow()
        {
            InitializeComponent();
            WhichPlayer.Text = "Player1!";
            RestartGame();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            ok = false;
            if (button.IsEnabled == true)
            {
                if (currentPlayer == Player.X)
                {
                    button.Content = "X";
                    button.Background = new SolidColorBrush(Colors.Turquoise);
                }
                else
                {
                    button.Content = "O";
                    button.Background = new SolidColorBrush(Colors.Yellow);

                }
                button.IsEnabled = false;
                buttons.Remove(button);
                ok = true;
            }
            CheckGame();

        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            currentPlayer= Player.X;
            RestartGame();
        }

        private void CheckGame()
        {
           

            if ((button1.Content == button2.Content && button2.Content == button3.Content && button1.Content.ToString() != "") ||
    (button4.Content == button5.Content && button5.Content == button6.Content && button4.Content.ToString() != "") ||
    (button7.Content == button8.Content && button8.Content == button9.Content && button7.Content.ToString() != "") ||
    (button1.Content == button4.Content && button4.Content == button7.Content && button1.Content.ToString() != "") ||
    (button2.Content == button5.Content && button5.Content == button8.Content && button2.Content.ToString() != "") ||
    (button3.Content == button6.Content && button6.Content == button9.Content && button3.Content.ToString() != "") ||
    (button1.Content == button5.Content && button5.Content == button9.Content && button1.Content.ToString() != "") ||
    (button3.Content == button5.Content && button5.Content == button7.Content && button3.Content.ToString() != ""))
            {
                if (currentPlayer == Player.X)
                {
                    player1++;
                    Player1Score.Text = player1.ToString();
                    MessageBox.Show("Player 1 won!", "Game Result", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    player2++;
                    Player2Score.Text = player2.ToString();
                    MessageBox.Show("Player 2 won!", "Game Result", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                currentPlayer = Player.X;
                RestartGame();
            }
            if (buttons.Count == 0)
            {
                MessageBox.Show("Nice game!", "Game Result", MessageBoxButton.OK, MessageBoxImage.Information);
                currentPlayer = Player.X;
                RestartGame();
            }
            if (currentPlayer == Player.X)
            {
                currentPlayer = Player.O;
                WhichPlayer.Text = "Player2!";

            }

            else
            {
                currentPlayer = Player.X;
                WhichPlayer.Text = "Player1!";
            }

        }

        private void RestartGame()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (Button button in buttons)
            {
                button.IsEnabled = true;
                button.Content = "";
                button.Background = new SolidColorBrush(Colors.LightGray);
                currentPlayer = Player.X;
                WhichPlayer.Text = "Player1!";

            }
        }
    }
}
