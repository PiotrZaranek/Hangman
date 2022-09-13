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
    // Okno Walki

    public partial class MainWindow : Window
    {
        byte[] existfights = new byte[4];
        StreamReader sr1;
        StreamReader sr2;
        StreamReader sr3;
        StreamReader sr4;
        BrushConverter bc = new BrushConverter();
        short userChoiceFight = 0;
        Uri CheckboxFrame = new Uri("Graphic/Chcekboxframe.png", UriKind.Relative);
        Uri CheckboxChceked = new Uri("Graphic/ChcekboxChceked.png", UriKind.Relative);

        private void BackFightClick(object sender, RoutedEventArgs e)
        {
            PreviousGridAnimation(Fight, Menu);
            ClickSoundPlay();
            sr1.Close();
            sr2.Close();
            sr3.Close();
            sr4.Close();
        }

        void ChcekSaveFightAndResartControls()
        {
            PlayBtn.IsEnabled = false;
            DelBtn.IsEnabled = false;
            CreateBtn.IsEnabled = false;
            Save1.Background = (Brush)bc.ConvertFrom("#2F6DB8");
            Save2.Background = (Brush)bc.ConvertFrom("#2F6DB8");
            Save3.Background = (Brush)bc.ConvertFrom("#2F6DB8");
            Save4.Background = (Brush)bc.ConvertFrom("#2F6DB8");
            userChoiceFight = 0;

            sr1 = new StreamReader(@"..\..\Saves\Save1.txt");
            sr2 = new StreamReader(@"..\..\Saves\Save2.txt");
            sr3 = new StreamReader(@"..\..\Saves\Save3.txt");
            sr4 = new StreamReader(@"..\..\Saves\Save4.txt");

            if (sr1.ReadLine() == "0")
            {
                existfights[0] = 0;
                Save1.Content = "--Empty--";
            }
            else
            {
                existfights[0] = 1;
                Save1.Content = sr1.ReadLine();
                Save1.Content += " vs ";
                Save1.Content += sr1.ReadLine();                            
            }

            if (sr2.ReadLine() == "0")
            {
                existfights[1] = 0;
                Save2.Content = "--Empty--";
            }
            else
            {
                existfights[1] = 1;
                Save2.Content = sr2.ReadLine();
                Save2.Content += " vs ";
                Save2.Content += sr2.ReadLine();
            }
            
            if (sr3.ReadLine() == "0")
            {
                existfights[2] = 0;
                Save3.Content = "--Empty--";
            }
            else
            {
                existfights[2] = 1;
                Save3.Content = sr3.ReadLine();
                Save3.Content += " vs ";
                Save3.Content += sr3.ReadLine();
            }

            if (sr4.ReadLine() == "0")
            {
                existfights[3] = 0;
                Save4.Content = "--Empty--";
            }
            else
            {
                existfights[3] = 1;
                Save4.Content = sr4.ReadLine();
                Save4.Content += " vs ";
                Save4.Content += sr4.ReadLine();
            }

            sr1.Close();
            sr2.Close();
            sr3.Close();
            sr4.Close();
        }

        private void ClickFirstFight(object sender, RoutedEventArgs e)
        {
            string path = @"..\..\Saves\Save1.txt";
            string name = "Save1.txt";
            ClickSoundPlay();
            userChoiceFight = 1;
            ClickFightButton(path, name, existfights[0], Save1, Save4, Save2, Save3);
        }
        private void ClickSecondFight(object sender, RoutedEventArgs e)
        {
            string path = @"..\..\Saves\Save2.txt";
            string name = "Save2.txt";
            ClickSoundPlay();
            userChoiceFight = 2;
            ClickFightButton(path, name, existfights[1], Save2, Save1, Save4, Save3);
        }
        private void ClickThirdFight(object sender, RoutedEventArgs e)
        {
            string path = @"..\..\Saves\Save3.txt";
            string name = "Save3.txt";
            ClickSoundPlay();
            userChoiceFight = 3;
            ClickFightButton(path, name, existfights[2], Save3, Save1, Save2, Save4);
        }
        private void ClickFourthFight(object sender, RoutedEventArgs e)
        {
            string path = @"..\..\Saves\Save4.txt";
            string name = "Save4.txt";
            ClickSoundPlay();
            userChoiceFight = 4;
            ClickFightButton(path, name, existfights[3], Save4, Save1, Save2, Save3);
        }
       
        private void ShowCreate(object sender, RoutedEventArgs e)
        {
            NextGridAnimation(Fight, Create);
            ClickSoundPlay();
            Slider.Value = 11;
            PlayerOneName.Text = "Player1";
            PlayerTwoName.Text = "Player2";
            ImgCC.Source = new BitmapImage(CheckboxChceked);
            ImgRC.Source = new BitmapImage(CheckboxFrame);
            ImgEasy.Source = new BitmapImage(CheckboxFrame);
            ImgNorm.Source = new BitmapImage(CheckboxFrame);
            ImgHard.Source = new BitmapImage(CheckboxFrame);
            BtnCreate.IsEnabled = true;
            Create_LevelClue.Opacity = 0.3;
            customClue = 1;
            randomClue = 0;
            randomEasyClue = 0;
            randomNormClue = 0;
            randomHardClue = 0;
            PlayerOneName.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            PlayerTwoName.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            HideFastWarnigCreate(WarningCreate);
            sr1.Close();
            sr2.Close();
            sr3.Close();
            sr4.Close();
        }

        private void ClickDeleteButton(object sender, RoutedEventArgs e)
        {
            HideGridAndShowDelete();
            ClickSoundPlay();
        }

        private void ClickPlayButton(object sender, RoutedEventArgs e)
        {            
            switch (userChoiceFight)
            {
                case 1:
                    {
                        ReadInformationFromFile(@"..\..\Saves\Save1.txt");
                        break;
                    }
                case 2:
                    {
                        ReadInformationFromFile(@"..\..\Saves\Save2.txt");
                        break;
                    }
                case 3:
                    {
                        ReadInformationFromFile(@"..\..\Saves\Save3.txt");
                        break;
                    }
                case 4:
                    {
                        ReadInformationFromFile(@"..\..\Saves\Save4.txt");
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Hangman run into a critical problem!", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                        Close();
                        break;
                    }                    
            }

            NextGridAnimation(Fight, BeforeFight);
            ClickSoundPlay();


        }

        void ClickFightButton(string path, string fileName, byte numberFile, Button A, Button b, Button c, Button d)
        {

            if (!File.Exists(path))
            {
                MessageBox.Show("Hangman didn't found file " + fileName, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }

            PlayBtn.IsEnabled = false;
            DelBtn.IsEnabled = false;
            CreateBtn.IsEnabled = false;

            if (numberFile == 0)
            {
                CreateBtn.IsEnabled = true;
            }
            else
            {
                PlayBtn.IsEnabled = true;
                DelBtn.IsEnabled = true;
            }

            A.Background = (Brush)bc.ConvertFrom("#1F6174");
            b.Background = (Brush)bc.ConvertFrom("#2F6DB8");
            c.Background = (Brush)bc.ConvertFrom("#2F6DB8");
            d.Background = (Brush)bc.ConvertFrom("#2F6DB8");
        }

        void ReadInformationFromFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            sr.ReadLine();
            PlayerOneNameBF.Text = sr.ReadLine();
            PlayerTwoNameBF.Text = sr.ReadLine();
            PlayerOneScore.Text = sr.ReadLine();
            PlayerTwoScore.Text = sr.ReadLine();
            ScoreOfWinBF.Text = sr.ReadLine();

            ChceckSettingFight("C1", CustomClueImg);
            ChceckSettingFight("R1", RandomClueImg);
            ChceckSettingFight("E1", EasyClueImg);
            ChceckSettingFight("N1", NormalClueImg);
            ChceckSettingFight("H1", HardClueImg);

            sr.Close();

            void ChceckSettingFight(string fileLine, Image img)
            {
                if (sr.ReadLine() == fileLine)
                {
                    img.Source = new BitmapImage(CheckboxChceked);
                }
                else
                {
                    img.Source = new BitmapImage(CheckboxFrame);
                }
            }

        }
    }
}