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

namespace RockPaperScissorsGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int clickCount = 0;
        int drawsCount = 0;
        private void Scissors_Click(object sender, RoutedEventArgs e)
        {
            PaperBorderPlayer.Background = Brushes.Transparent;
            ScissorsBorderPlayer.Background = Brushes.Transparent;
            RockBorderPlayer.Background = Brushes.Transparent;
            PaperBorderBot.Background = Brushes.Transparent;
            ScissorsBorderBot.Background = Brushes.Transparent;
            RockBorderBot.Background = Brushes.Transparent;
            clickCountDisplay.Text = ++clickCount + "";

            int response = new Random().Next(1, 4);
            switch (response)
            {
                case 1: // rock
                    ScissorsBorderPlayer.Background = Brushes.Red;
                    RockBorderBot.Background = Brushes.Green;
                    int botPoints = int.Parse(BotPointsDisplay.Text);
                    BotPointsDisplay.Text = ++botPoints + "";
                    break;
                case 2: // paper
                    ScissorsBorderPlayer.Background = Brushes.Green;
                    PaperBorderBot.Background = Brushes.Red;
                    int playerPoints = int.Parse(PlayerPointsDisplay.Text);
                    PlayerPointsDisplay.Text = ++playerPoints + "";
                    break;
                case 3: // scissors
                    ScissorsBorderBot.Background = Brushes.Yellow;
                    ScissorsBorderPlayer.Background = Brushes.Yellow;
                    drawsDisplay.Text = ++drawsCount + "";
                    break;
            }
        }

        private void Paper_Click(object sender, RoutedEventArgs e)
        {
            PaperBorderPlayer.Background = Brushes.Transparent;
            ScissorsBorderPlayer.Background = Brushes.Transparent;
            RockBorderPlayer.Background = Brushes.Transparent;
            PaperBorderBot.Background = Brushes.Transparent;
            ScissorsBorderBot.Background = Brushes.Transparent;
            RockBorderBot.Background = Brushes.Transparent;
            clickCountDisplay.Text = ++clickCount + "";
            int response = new Random().Next(1, 4);
            switch (response)
            {
                case 1: // rock
                    PaperBorderPlayer.Background = Brushes.Green;
                    RockBorderBot.Background = Brushes.Red;
                    int playerPoints = int.Parse(PlayerPointsDisplay.Text);
                    PlayerPointsDisplay.Text = ++playerPoints + "";
                    break;

                case 2: // paper
                    PaperBorderPlayer.Background = Brushes.Yellow;
                    PaperBorderBot.Background = Brushes.Yellow;
                    drawsDisplay.Text = ++drawsCount + "";
                    break;

                case 3: // scissors
                    PaperBorderPlayer.Background = Brushes.Red;
                    ScissorsBorderBot.Background = Brushes.Green;
                    int botPoints = int.Parse(BotPointsDisplay.Text);
                    BotPointsDisplay.Text = ++botPoints + "";
                    break;
            }
        }
        private void Rock_Click(object sender, RoutedEventArgs e)
        {
            PaperBorderPlayer.Background = Brushes.Transparent;
            ScissorsBorderPlayer.Background = Brushes.Transparent;
            RockBorderPlayer.Background = Brushes.Transparent;
            PaperBorderBot.Background = Brushes.Transparent;
            ScissorsBorderBot.Background = Brushes.Transparent;
            RockBorderBot.Background = Brushes.Transparent;
            clickCountDisplay.Text = ++clickCount + "";
            int response = new Random().Next(1, 4);
            switch (response)
            {
                case 1: // rock
                    RockBorderPlayer.Background = Brushes.Yellow;
                    RockBorderBot.Background = Brushes.Yellow;
                    drawsDisplay.Text = ++drawsCount + "";
                    break;

                case 2: // paper
                    RockBorderPlayer.Background = Brushes.Red;
                    PaperBorderBot.Background = Brushes.Green;
                    int botPoints = int.Parse(BotPointsDisplay.Text);
                    BotPointsDisplay.Text = ++botPoints + "";
                    break;

                case 3:  // scissors
                    RockBorderPlayer.Background = Brushes.Green;
                    ScissorsBorderBot.Background = Brushes.Red;
                    int playerPoints = int.Parse(PlayerPointsDisplay.Text);
                    PlayerPointsDisplay.Text = ++playerPoints + "";
                    break;
            }
        }
    }
}