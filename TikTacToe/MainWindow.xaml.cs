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
        }
    }
}