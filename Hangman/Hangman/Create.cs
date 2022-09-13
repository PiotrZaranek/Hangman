using System;
using System.IO;
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

namespace Hangman
{
    // Okno Create    

    public partial class MainWindow : Window
    {
        byte customClue = 0;
        byte randomClue = 0;
        byte randomEasyClue = 0;
        byte randomNormClue = 0;
        byte randomHardClue = 0;
        bool goodOne = true;
        bool goodTwo = true;

        private void ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ScoreOfWin.Text = Math.Round(Slider.Value).ToString();
        }

        private void BackCreateClick(object sender, RoutedEventArgs e)
        {
            PreviousGridAnimation(Create, Fight);
            ClickSoundPlay();
        }

        private void ClickCustomClue(object sender, RoutedEventArgs e)
        {
            if (customClue == 0)
            {
                ImgCC.Source = new BitmapImage(CheckboxChceked);
                customClue = 1;
                WritingSoundPlay();
            }
            else if (customClue == 1 && randomClue == 1)
            {
                ImgCC.Source = new BitmapImage(CheckboxFrame);
                customClue = 0;
            }
        }

        private void ClickRandomClue(object sender, RoutedEventArgs e)
        {
            if (randomClue == 0)
            {
                ImgRC.Source = new BitmapImage(CheckboxChceked);
                randomClue = 1;
                WritingSoundPlay();
                Create_LevelClue.Opacity = 1;
                randomEasyClue = 1;
                BtnEasy.IsEnabled = true;
                BtnNorm.IsEnabled = true;
                BtnHard.IsEnabled = true;
                ImgEasy.Source = new BitmapImage(CheckboxChceked);
            }
            else if (randomClue == 1 && customClue == 1)
            {
                ImgRC.Source = new BitmapImage(CheckboxFrame);
                randomClue = 0;
                Create_LevelClue.Opacity = 0.3;
                randomEasyClue = 0;
                randomNormClue = 0;
                randomHardClue = 0;
                BtnEasy.IsEnabled = false;
                BtnNorm.IsEnabled = false;
                BtnHard.IsEnabled = false;
                ImgEasy.Source = new BitmapImage(CheckboxFrame);
                ImgNorm.Source = new BitmapImage(CheckboxFrame);
                ImgHard.Source = new BitmapImage(CheckboxFrame);
            }
        }

        private void ClickRandomEasy(object sender, RoutedEventArgs e)
        {
            randomEasyClue = Create_ChceckBox(randomEasyClue, randomNormClue, randomHardClue, ImgEasy);
        }

        private void ClickRandomNorm(object sender, RoutedEventArgs e)
        {
            randomNormClue = Create_ChceckBox(randomNormClue, randomEasyClue, randomHardClue, ImgNorm); ;
        }

        private void ClickRandomHard(object sender, RoutedEventArgs e)
        {
            randomHardClue = Create_ChceckBox(randomHardClue, randomEasyClue, randomNormClue, ImgHard);
        }

        private void ClickCreate(object sender, RoutedEventArgs e)
        {
            SaveFightToFile(userChoiceFight, 0);
            ChcekSaveFightAndResartControls();
            PreviousGridAnimation(Create, Fight);
            ClickSoundPlay();
        }

        void SaveFightToFile(short numberFile, short createOrSeveGame)
        {
            StreamWriter sw;

            switch (numberFile)
            {
                case 1:
                    {
                        sw = new StreamWriter(@"..\..\Saves\Save1.txt");
                        break;
                    }
                case 2:
                    {
                        sw = new StreamWriter(@"..\..\Saves\Save2.txt");
                        break;
                    }
                case 3:
                    {
                        sw = new StreamWriter(@"..\..\Saves\Save3.txt");
                        break;
                    }
                case 4:
                    {
                        sw = new StreamWriter(@"..\..\Saves\Save4.txt");
                        break;
                    }
                default:
                    {
                        sw = new StreamWriter(@"..\..\Saves\Save1.txt");
                        break;
                    }
            }

            if(createOrSeveGame == 0)
            {
                Random rand = new Random();
                sw.Write("1\n");
                sw.Write(PlayerOneName.Text + "\n");
                sw.Write(PlayerTwoName.Text + "\n");
                sw.Write("0\n");
                sw.Write("0\n");
                sw.Write(Math.Round(Slider.Value).ToString() + "\n");
                sw.Write("C" + customClue.ToString() + "\n");
                sw.Write("R" + randomClue.ToString() + "\n");
                sw.Write("E" + randomEasyClue.ToString() + "\n");
                sw.Write("N" + randomNormClue.ToString() + "\n");
                sw.Write("H" + randomHardClue.ToString() + "\n");
                sw.Write($"{rand.Next(1, 3)}");
                sw.Close();
                rand = null;
            }
            else
            {
                sw.Write("1\n");
                sw.Write(playerOneName + "\n");
                sw.Write(playerTwoName + "\n");
                sw.Write(playerOneScore.ToString() + "\n");
                sw.Write(playerTwoScore.ToString() + "\n");
                sw.Write(scoreToWin.ToString() + "\n");
                sw.Write("C" + customClue.ToString() + "\n");
                sw.Write("R" + randomClue.ToString() + "\n");
                sw.Write("E" + randomEasyClue.ToString() + "\n");
                sw.Write("N" + randomNormClue.ToString() + "\n");
                sw.Write("H" + randomHardClue.ToString() + "\n");
                sw.Write(playerTurn.ToString());
                sw.Close();
            }

            
        }

        byte Create_ChceckBox(byte chceking, byte a, byte b, Image img)
        {
            if ((a == 1 || b == 1) && chceking == 1)
            {
                img.Source = new BitmapImage(CheckboxFrame);
                chceking = 0;
                return chceking;
            }
            else if (chceking == 0)
            {
                img.Source = new BitmapImage(CheckboxChceked);
                chceking = 1;
                WritingSoundPlay();
                return chceking;
            }

            return chceking;
        }        

        private void ChceckNamePlayerOne(object sender, KeyboardFocusChangedEventArgs e)
        {            
            goodOne = ChcekingTextBoxCrete(PlayerOneName, goodOne,goodTwo);           
        }

        private void ChcekPlayerNameTwo(object sender, KeyboardFocusChangedEventArgs e)
        {
            goodTwo = ChcekingTextBoxCrete(PlayerTwoName, goodTwo,goodOne);
        }

        bool ChcekingTextBoxCrete(TextBox PlayerName, bool agreementMain, bool agreementSecond)
        {
            byte a = (byte)PlayerName.Text.Length;
            char[] namePlayer = new char[a];
            bool goodName = true;

            namePlayer = PlayerName.Text.ToCharArray();

            if (namePlayer.Length == 0)
            {
                goodName = false;
            }
            else
            {
                ChcekingLetter(',');
                ChcekingLetter('.');
                ChcekingLetter('/');
                ChcekingLetter('\\');
                ChcekingLetter('|');
                ChcekingLetter('*');
                ChcekingLetter('^');
                ChcekingLetter('!');
                ChcekingLetter('?');
                ChcekingLetter('+');
                ChcekingLetter('=');
                ChcekingLetter(' ');
            }

            if (goodName == true)
            {
                PlayerName.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
                agreementMain = true;
            }
            else
            {
                PlayerName.Background = (Brush)bc.ConvertFrom("#FFa31414");
                agreementMain = false;

            }

            if(agreementMain == true && agreementSecond == true)
            {
                if(WarningCreate.Opacity == 1)
                {
                    HideWarningCreate(WarningCreate);
                }                
                BtnCreate.IsEnabled = true;
                return agreementMain;                
            }
            else
            {
                if (WarningCreate.Opacity != 1)
                {
                    ShwoWarningCreate(WarningCreate);
                }                
                BtnCreate.IsEnabled = false;
                return agreementMain;
            }
            
            void ChcekingLetter(char mark)
            {
                for(int i = 0; i < namePlayer.Length; i ++)
                {
                    if(namePlayer[i] == mark)
                    {
                        goodName = false;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

        }

        void SetTextBoxLenght()
        {
            PlayerOneName.MaxLength = 10;
            PlayerTwoName.MaxLength = 10;
        }
    }

}