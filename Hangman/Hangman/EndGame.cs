using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace Hangman
{
    // Okno Wygranej/Przegranej

    public partial class MainWindow : Window
    {
        private void ClickTryAgain(object sender, RoutedEventArgs e)
        {
            Word.Text = "";
            word = "";
            clueWord = null;
            countLetter = null;
            hit = 0;
            countWrongHit = 0;
            Restart();

            if (userChoiceDifficultyLevel == 1)
            {
                DrawWordEasy();
                ClickSoundPlay();
                PreviousGridAnimation(EndGame, Game);
            }
            else if (userChoiceDifficultyLevel == 2)
            {
                DrawWordMedium();
                ClickSoundPlay();
                PreviousGridAnimation(EndGame, Game);
            }
            else if (userChoiceDifficultyLevel == 3)
            {
                DrawWordHard();
                ClickSoundPlay();
                PreviousGridAnimation(EndGame, Game);
            }            
        }

        private void ClickDifficultyLevel(object sender, RoutedEventArgs e)
        {
            PreviousGridAnimation(EndGame, DifficultyLevel);
            ClickSoundPlay();
            ShowBackgroundImg(BackImg);
        }

        private void ClickBackToMenu(object sender, RoutedEventArgs e)
        {            
            BackToMenu();
            ShowBackgroundImg(BackImg);
            ClickSoundPlay();
            DeleteFight(userChoiceFight);
            StartPlayMaintheme();
        }

        void ChangeStyleEndGame(int a)
        {
            if(a == 0)
            {
                EndGameLevel.Visibility = Visibility.Visible;
                EndGameFight.Visibility = Visibility.Hidden;
            }
            else if(a == 1)
            {
                EndGameLevel.Visibility = Visibility.Hidden;
                EndGameFight.Visibility = Visibility.Visible;
            }
        }
        void DeleteFight(short a)
        {
            StreamWriter sw;

            switch (a)
            {
                case 1:
                    {
                        sw = new StreamWriter(@"..\..\Saves\Save1.txt");
                        sw.Write("0");
                        sw.Close();
                        ChcekSaveFightAndResartControls();
                        break;
                    }
                case 2:
                    {
                        sw = new StreamWriter(@"..\..\Saves\Save2.txt");
                        sw.Write("0");
                        sw.Close();
                        ChcekSaveFightAndResartControls();
                        break;
                    }
                case 3:
                    {
                        sw = new StreamWriter(@"..\..\Saves\Save3.txt");
                        sw.Write("0");
                        sw.Close();
                        ChcekSaveFightAndResartControls();
                        break;
                    }
                case 4:
                    {
                        sw = new StreamWriter(@"..\..\Saves\Save4.txt");
                        sw.Write("0");
                        sw.Close();
                        ChcekSaveFightAndResartControls();
                        break;
                    }
            }

        }
    }
}