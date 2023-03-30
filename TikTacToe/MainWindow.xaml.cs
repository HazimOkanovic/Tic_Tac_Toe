using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tik_Tac_Toe
{
    public partial class MainWindow : Window
    {
        private MarkType[] results;
        private bool playerTurn;
        private bool gameEnded;
        
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            results = new MarkType[9];
            
            for(var i=0; i<results.Length; i++)
            {
                results[i] = MarkType.Free;
            }

            playerTurn = true;
            
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });
            gameEnded = false;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (gameEnded)
            {
                NewGame();
                return;
            }

            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);
            
            if(results[index] != MarkType.Free)
                return;

            results[index] = playerTurn ? MarkType.Cross : MarkType.Nought;
            button.Content = playerTurn ? "X" : "0";
            
            if(playerTurn)
                button.Foreground = Brushes.Red;
            playerTurn ^= true;

            CheckForWinner();
        }

        private void CheckForWinner()
        {
            if (results[0] != MarkType.Free && (results[0] & results[1] & results[2]) == results[0])
            {
                gameEnded = true;

                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }
            
            if (results[3] != MarkType.Free && (results[3] & results[4] & results[5]) == results[3])
            {
                gameEnded = true;

                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }
            
            if (results[6] != MarkType.Free && (results[6] & results[7] & results[8]) == results[6])
            {
                gameEnded = true;

                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }
            
            if (results[0] != MarkType.Free && (results[0] & results[3] & results[6]) == results[0])
            {
                gameEnded = true;

                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }
            
            if (results[1] != MarkType.Free && (results[1] & results[4] & results[7]) == results[1])
            {
                gameEnded = true;

                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }
            
            if (results[2] != MarkType.Free && (results[2] & results[5] & results[8]) == results[2])
            {
                gameEnded = true;

                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }
            
            if (results[0] != MarkType.Free && (results[0] & results[4] & results[8]) == results[0])
            {
                gameEnded = true;

                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }
            
            if (results[2] != MarkType.Free && (results[2] & results[4] & results[6]) == results[2])
            {
                gameEnded = true;

                Button0_2.Background = Button1_1.Background = Button2_0.Background = Brushes.Green;
            }

            if (!results.Any(results => results == MarkType.Free))
            {
                gameEnded = true;
                
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                { 
                    button.Background = Brushes.Orange;
                });
            }
        }
    }
}