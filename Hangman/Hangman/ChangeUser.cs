using System;
using System.Collections.Generic;
using System.IO;
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

namespace Hangman
{
    // Okno Między rundami

    public partial class MainWindow : Window
    {
        int playerOneScore;
        int playerTwoScore;
        int playerTurn;
        int scoreToWin;
        int randomDifficultClue = 0;
        string playerOneName;
        string playerTwoName;

        private void ClickOkChangeUserCustomClueWriter(object sender, RoutedEventArgs e)
        {
            if (CategoryCU.Text.Length < 2 || ClueCU.Text.Length < 2)
            {
                if(CategoryCU.Text.Length < 2)
                {
                    CategoryCU.Background = Brushes.DarkRed;
                }
                if(ClueCU.Text.Length < 2)
                {
                    ClueCU.Background = Brushes.DarkRed;
                }                
            }    
            else
            {
                Word.Text = "";
                word = ClueCU.Text;
                clueWord = null;
                countLetter = null;
                hit = 0;
                countWrongHit = 0;
                ifFight = 1;
                Fight_GUI.Visibility = Visibility.Visible;
                GameBackButton.Visibility = Visibility.Hidden;
                Category.Text = CategoryCU.Text;
                CategoryCU.Text = "";
                ClueCU.Text = "";
                NextGridAnimation(ChangeUser, Game);
                ClickSoundPlay();
                HideBackgroundImg(BackImg);
                AddNameAndScoreToFightGUI();
                Restart();
                ClueCodding();                
            }       
        }

        private void ClickDrawClueChangeUser(object sender, RoutedEventArgs e)
        {
            Word.Text = "";
            word = "";
            clueWord = null;
            countLetter = null;
            hit = 0;
            countWrongHit = 0;
            ifFight = 1;
            Fight_GUI.Visibility = Visibility.Visible;
            GameBackButton.Visibility = Visibility.Hidden;
            NextGridAnimation(ChangeUser, Game);
            ClickSoundPlay();
            WhereFromClue(randomDifficultClue);
            HideBackgroundImg(BackImg);
            AddNameAndScoreToFightGUI();
            Restart();            
        }

        private void ClickExitAndSaveChangeUser(object sender, RoutedEventArgs e)
        {            
            Fight_GUI.Visibility = Visibility.Hidden;
            GameBackButton.Visibility = Visibility.Visible;
            PreviousGridAnimation(ChangeUser, Fight);
            ClickSoundPlay();
            SaveFightToFile(userChoiceFight, 1);
            ClearFight();
            StartPlayMaintheme();
        }

        //Sprawdzenie CategoryCU
        private void CheckLetterUpCategory(object sender, KeyEventArgs e)
        {
            CheckCategoryAndClue(CategoryCU);
        }
        private void CheckLetterDownCategory(object sender, KeyEventArgs e)
        {
            CheckCategoryAndClue(CategoryCU);
        }
        private void CategoryCUGotFocus(object sender, RoutedEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            CategoryCU.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
        }

        //Sprawdzenie ClueCU
        private void CheckLetterUpClue(object sender, KeyEventArgs e)
        {
            CheckCategoryAndClue(ClueCU);
        }
        private void CheckLetterDownClue(object sender, KeyEventArgs e)
        {
            CheckCategoryAndClue(ClueCU);
        }       
        private void ClueCUGotFocus(object sender, RoutedEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            ClueCU.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
        }

        void LoadDataFormSave(short fileNumber)
        {
            string path = @"..\..\Saves\" + "save" + fileNumber.ToString() + ".txt";

            if (!File.Exists(path))
            {
                MessageBox.Show("Hangman didn't found file" + path, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }

            StreamReader sr = File.OpenText(path);

            string[] date = new string[12];

            //Pobranie wartości z pliku
            for(int i = 0; i < 12; i++)
            {
                date[i] = sr.ReadLine();
            }

            scoreToWin = Int32.Parse(date[5]);
            ScoreToWin.Text = date[5];

            //Przypisanie nazw graczy
            playerOneName = date[1];
            playerTwoName = date[2];
        
            //Przypysanie wyników graczy
            playerOneScore = Int32.Parse(date[3]);
            playerTwoScore = Int32.Parse(date[4]);

            //Sprawdzenie kogo tura
            if (date[11] == "1")
            {
                PlayerNameChangeUser.Text = "Now " + date[1] + " turn!";
                playerTurn = Int32.Parse(date[11]);
            }
            else
            {
                PlayerNameChangeUser.Text = "Now " + date[2] + " turn!";
            }

            //Sprawdzenie czy własne hasła
            if (date[6] == "C0")
            {
                customClue = 0;
                CustomClueWriter.IsEnabled = false;
                CustomClueWriter.Opacity = 0.5;
            }
            else
            {
                customClue = 1;
                CustomClueWriter.IsEnabled = true;
                CustomClueWriter.Opacity = 1;
            }

            //Sprawdzenie czy hasła losowe oraz jakiej trudności hasła
            if (date[7] == "R0")
            {
                randomClue = 0;
                randomEasyClue = 0;
                randomNormClue = 0;
                randomHardClue = 0;
                DrawClueChangeUser.IsEnabled = false;
                DrawClueChangeUser.Opacity = 0.5;
            }
            else
            {
                randomClue = 1;
                DrawClueChangeUser.IsEnabled = true;
                DrawClueChangeUser.Opacity = 1;

                if (date[8] == "E1")
                {
                    randomEasyClue = 1;
                    randomDifficultClue += 1;
                }
                if (date[9] == "N1")
                {
                    randomNormClue = 1;
                    randomDifficultClue += 2;
                }
                if (date[10] == "H1")
                {
                    randomHardClue = 1;
                    randomDifficultClue += 4;
                }
            }
            
        }
        void AddNameAndScoreToFightGUI()
        {
            Player1Name.Text = playerOneName;
            Player2Name.Text = playerTwoName;
            Player1Score.Text = playerOneScore.ToString();
            Player2Score.Text = playerTwoScore.ToString();
        }
        void ChangeTurnAndAddScore()
        {
            if(playerTurn == 1)
            {
                playerOneScore = playerOneScore + (10 - countWrongHit);
                WhoWin(playerOneScore, scoreToWin, playerOneName, playerTwoScore);
                Player1Score.Text = playerOneScore.ToString();
                playerTurn = 2;
                PlayerNameChangeUser.Text = "Now " + playerTwoName + " turn!";
            }
            else if(playerTurn == 2)
            {
                playerTwoScore = playerTwoScore + (10 - countWrongHit);
                WhoWin(playerTwoScore, scoreToWin, playerTwoName, playerOneScore);
                Player2Score.Text = playerTwoScore.ToString();
                playerTurn = 1;
                PlayerNameChangeUser.Text = "Now " + playerOneName + " turn!";
            }
        }
        void WhoWin(int a, int b, string c, int d)
        {
            if(a >= b)
            {
                Fight_GUI.Visibility = Visibility.Hidden;
                GameBackButton.Visibility = Visibility.Visible;
                ChangeStyleEndGame(ifFight);
                NextGridAnimation(ChangeUser, EndGame);
                PlayerWinName.Text = c + " Win!";
                ResaultFight.Text = a.ToString() + " - " + d.ToString();
            }
        }
        void WhereFromClue(int a)
        {
            Random difficult = new Random();

            switch (a)
            {
                case 1:
                    {
                        DrawWordEasy();
                        break;
                    }
                case 2:
                    {
                        DrawWordMedium();
                        break;
                    }
                case 3:
                    {
                        int difficultNumber = difficult.Next(1,3);
                        if(difficultNumber == 1)
                        {
                            DrawWordEasy();
                        }
                        else
                        {
                            DrawWordMedium();
                        }
                        break;
                    }
                case 4:                    
                    {
                        DrawWordHard();
                        break;
                    }
                case 5:
                    {
                        int difficultNumber = difficult.Next(1, 3);
                        if (difficultNumber == 1)
                        {
                            DrawWordEasy();
                        }
                        else
                        {
                            DrawWordHard();
                        }
                        break;
                    }
                case 6:
                    {
                        int difficultNumber = difficult.Next(1, 3);
                        if (difficultNumber == 1)
                        {
                            DrawWordMedium();
                        }
                        else
                        {
                            DrawWordHard();
                        }
                        break;
                    }
                case 7:
                    {
                        int difficultNumber = difficult.Next(1, 4);
                        if (difficultNumber == 1)
                        {
                            DrawWordEasy();
                        }
                        else if(difficultNumber == 2)
                        {
                            DrawWordMedium();
                        }
                        else
                        {
                            DrawWordHard();
                        }
                        break;
                    }
            }
        }             
        void CheckCategoryAndClue(TextBox a)
        {
            if (a.Text != "")
            {
                char b = a.Text.Last();
                // Od A do B
                if ((int)b > 64 && (int)b < 91)
                {
                    a.SelectionStart = a.Text.Length;                    
                }
                //Space
                else if ((int)b == 32)
                {
                    a.SelectionStart = a.Text.Length;
                }
                //Ą
                else if ((int)b == 260)
                {
                    a.SelectionStart = a.Text.Length;
                }
                //Ć
                else if ((int)b == 262)
                {
                    a.SelectionStart = a.Text.Length;
                }
                //Ę
                else if ((int)b == 280)
                {
                    a.SelectionStart = a.Text.Length;
                }
                //Ł
                else if ((int)b == 321)
                {
                    a.SelectionStart = a.Text.Length;
                }
                //Ń
                else if ((int)b == 323)
                {
                    a.SelectionStart = a.Text.Length;
                }
                //Ó
                else if ((int)b == 211)
                {
                    a.SelectionStart = a.Text.Length;
                }
                //Ś
                else if ((int)b == 346)
                {
                    a.SelectionStart = a.Text.Length;
                }
                //Ż
                else if ((int)b == 379)
                {
                    a.SelectionStart = a.Text.Length;
                }
                //Ź
                else if ((int)b == 377)
                {
                    a.SelectionStart = a.Text.Length;
                }
                else
                {
                    a.SelectionStart = a.Text.Length;
                    a.Text = a.Text.Remove(a.Text.Length - 1);
                    a.SelectionStart = a.Text.Length;                
                }
            }
        }
        void ClueCodding()
        {
            clueWord = word.ToCharArray();
            for (int i = 0; i < clueWord.Length; i++)
            {
                if (clueWord[i] == 'Ą')
                {
                    clueWord[i] = '1';
                }
                else if (clueWord[i] == 'Ć')
                {
                    clueWord[i] = '2';
                }
                else if (clueWord[i] == 'Ę')
                {
                    clueWord[i] = '3';
                }
                else if (clueWord[i] == 'Ł')
                {
                    clueWord[i] = '4';
                }
                else if (clueWord[i] == 'Ń')
                {
                    clueWord[i] = '5';
                }
                else if (clueWord[i] == 'Ó')
                {
                    clueWord[i] = '6';
                }
                else if (clueWord[i] == 'Ś')
                {
                    clueWord[i] = '7';
                }
                else if (clueWord[i] == 'Ż')
                {
                    clueWord[i] = '8';
                }
                else if (clueWord[i] == 'Ź')
                {
                    clueWord[i] = '9';
                }
            }

            countLetter = new int[clueWord.Length];

            for (int i = 0; i < clueWord.Length; i++)
            {
                if (clueWord[i] == ' ')
                {
                    Word.Text += " ";
                    countLetter[i] = 1;
                }
                else
                {
                    Word.Text += "-";
                    countLetter[i] = 0;
                }
            }
        }

        void ClearFight()
        {
            playerOneScore = 0;
            playerTwoScore = 0;
            playerTurn = 0;
            scoreToWin = 0;
            randomDifficultClue = 0;
            playerOneName = null;
            playerOneName = null;
            customClue = 0;
            randomClue = 0;
            randomEasyClue = 0;
            randomNormClue = 0;
            randomHardClue = 0;
        }
    }
}