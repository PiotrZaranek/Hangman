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
    // Okno Gry

    public partial class MainWindow : Window
    {
        byte ifFight;
        string word = "";
        char[] clueWord;
        int[] countLetter;
        Random randomNumberLine = new Random();
        short hit = 0;
        short countWrongHit = 0;

        private void ClickBackGame(object sender, RoutedEventArgs e)
        {        
            PreviousGridAnimation(Game, DifficultyLevel);
            ClickSoundPlay();
            StartPlayMaintheme();
            ShowBackgroundImg(BackImg);
        }

        //Losuje z plik tektowego hasło do odgadnięcia, zmienia wypisuje zasłonięte hasło na ekran Game
        //Dla Easy
        void DrawWordEasy()
        {
            Random category = new Random();
            int categoryNumber = category.Next(1, 6);
                
            string path = "";                      
                    
            if (categoryNumber == 1)
            {
                if (!File.Exists(@"..\..\Words\EasyWords\Animals.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Animals.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\EasyWords\Animals.txt";
                Category.Text = "Zwierzęta";               
            }
            else if(categoryNumber == 2)
            {
                if (!File.Exists(@"..\..\Words\EasyWords\Food.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Food.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\EasyWords\Food.txt";
                Category.Text = "Jedzenie";
            }
            else if (categoryNumber == 3)
            {
                if (!File.Exists(@"..\..\Words\EasyWords\Geography.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Geography.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\EasyWords\Geography.txt";
                Category.Text = "Geogrfia";
            }
            else if (categoryNumber == 4)
            {
                if (!File.Exists(@"..\..\Words\EasyWords\Math.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Math.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\EasyWords\Math.txt";
                Category.Text = "Matematyka";
            }
            else if (categoryNumber == 5)
            {
                if (!File.Exists(@"..\..\Words\EasyWords\Thing.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Thing.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\EasyWords\Thing.txt";
                Category.Text = "Rzecz";
            }

            StreamReader sr = File.OpenText(path);
            
            for (int i = 0; i < randomNumberLine.Next(1, 21); i++)
            {
                word = sr.ReadLine();
            }

            sr.Close();

            clueWord = word.ToCharArray();
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
        //Dla Medium
        void DrawWordMedium()
        {
            Random category = new Random();
            int categoryNumber = category.Next(1, 11);             
            string path = "";

            if (categoryNumber == 1)
            {
                if (!File.Exists(@"..\..\Words\MediumWords\Animals.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Animals.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\MediumWords\Animals.txt";
                Category.Text = "Zwierzęta";
            }
            else if (categoryNumber == 2)
            {
                if (!File.Exists(@"..\..\Words\MediumWords\Chemistry.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Chemistry.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\MediumWords\Chemistry.txt";
                Category.Text = "Chemia";
            }
            else if (categoryNumber == 3)
            {
                if (!File.Exists(@"..\..\Words\MediumWords\Ductum.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Ductum.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\MediumWords\Ductum.txt";
                Category.Text = "Powiedzenie";
            }
            else if (categoryNumber == 4)
            {
                if (!File.Exists(@"..\..\Words\MediumWords\Food.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Food.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\MediumWords\Food.txt";
                Category.Text = "Jedzenie";
            }
            else if (categoryNumber == 5)
            {
                if (!File.Exists(@"..\..\Words\MediumWords\Job.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Job.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\MediumWords\Job.txt";
                Category.Text = "Zawód";
            }
            else if (categoryNumber == 6)
            {
                if (!File.Exists(@"..\..\Words\MediumWords\Math.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Math.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\MediumWords\Math.txt";
                Category.Text = "Matematyka";
            }
            else if (categoryNumber == 7)
            {
                if (!File.Exists(@"..\..\Words\MediumWords\Monument.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Monument.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\MediumWords\Monument.txt";
                Category.Text = "Zabytek";
            }
            else if (categoryNumber == 8)
            {
                if (!File.Exists(@"..\..\Words\MediumWords\Physics.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Physics.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\MediumWords\Physics.txt";
                Category.Text = "Fizyka";
            }
            else if (categoryNumber == 9)
            {
                if (!File.Exists(@"..\..\Words\MediumWords\Sport.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Sport.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\MediumWords\Sport.txt";
                Category.Text = "Sport";
            }
            else if (categoryNumber == 10)
            {
                if (!File.Exists(@"..\..\Words\MediumWords\Thing.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Thing.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\MediumWords\Thing.txt";
                Category.Text = "Rzecz";
            }

            StreamReader sr = File.OpenText(path);

            for (int i = 0; i < randomNumberLine.Next(1, 11); i++)
            {
                word = sr.ReadLine();
            }

            sr.Close();

            clueWord = word.ToCharArray();
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
        //Dla Hard
        void DrawWordHard()
        {
            Random category = new Random();
            int categoryNumber = category.Next(1, 9);
            string path = "";

            if (categoryNumber == 1)
            {
                if (!File.Exists(@"..\..\Words\HardWords\Brand.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Brand.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\HardWords\Brand.txt";
                Category.Text = "Marki";
            }
            else if (categoryNumber == 2)
            {
                if (!File.Exists(@"..\..\Words\HardWords\Car brand.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Car brand.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\HardWords\Car brand.txt";
                Category.Text = "Marki samochodów";
            }
            else if (categoryNumber == 3)
            {
                if (!File.Exists(@"..\..\Words\HardWords\Dictum.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Dictum.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\HardWords\Dictum.txt";
                Category.Text = "Powiedzenie";
            }
            else if (categoryNumber == 4)
            {
                if (!File.Exists(@"..\..\Words\HardWords\Game.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Game.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\HardWords\Game.txt";
                Category.Text = "Gry";
            }
            else if (categoryNumber == 5)
            {
                if (!File.Exists(@"..\..\Words\HardWords\History.txt"))
                {
                    MessageBox.Show("Hangman didn't found file History.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\HardWords\History.txt";
                Category.Text = "Historia";
            }
            else if (categoryNumber == 6)
            {
                if (!File.Exists(@"..\..\Words\HardWords\Idiom.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Idiom.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\HardWords\Idiom.txt";
                Category.Text = "Frazeologizmy";
            }
            else if (categoryNumber == 7)
            {
                if (!File.Exists(@"..\..\Words\HardWords\Musician.txt"))
                {
                    MessageBox.Show("Hangman didn't found file Musician.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\HardWords\Musician.txt";
                Category.Text = "Muzycy";
            }
            else if (categoryNumber == 8)
            {
                if (!File.Exists(@"..\..\Words\HardWords\People.txt"))
                {
                    MessageBox.Show("Hangman didn't found file People.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                path = @"..\..\Words\HardWords\People.txt";
                Category.Text = "Postać";
            }

            StreamReader sr = File.OpenText(path);

            for (int i = 0; i < randomNumberLine.Next(1, 11); i++)
            {
                word = sr.ReadLine();
            }

            sr.Close();

            clueWord = word.ToCharArray();
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
        
        private void ClickA(object sender, RoutedEventArgs e)
        {
            HitLetter(A,'A','A');            
        }

        private void ClickOL(object sender, RoutedEventArgs e)
        {
            HitLetter(OL, '1', 'Ą');
        }

        private void ClickB(object sender, RoutedEventArgs e)
        {
            HitLetter(B, 'B', 'B');
        }

        private void ClickC(object sender, RoutedEventArgs e)
        {
            HitLetter(C, 'C', 'C');
        }

        private void ClickCI(object sender, RoutedEventArgs e)
        {
            HitLetter(CI, '2', 'Ć');
        }

        private void ClickD(object sender, RoutedEventArgs e)
        {
            HitLetter(D, 'D', 'D');
        }

        private void ClickE(object sender, RoutedEventArgs e)
        {
            HitLetter(E, 'E', 'E');
        }

        private void ClickEL(object sender, RoutedEventArgs e)
        {
            HitLetter(EL, '3', 'Ę');
        }

        private void ClickF(object sender, RoutedEventArgs e)
        {
            HitLetter(F, 'F', 'F');
        }

        private void ClickG(object sender, RoutedEventArgs e)
        {
            HitLetter(G, 'G', 'G');
        }

        private void ClickH(object sender, RoutedEventArgs e)
        {
            HitLetter(H, 'H', 'H');
        }

        private void ClickI(object sender, RoutedEventArgs e)
        {
            HitLetter(I, 'I', 'I');
        }

        private void ClickJ(object sender, RoutedEventArgs e)
        {
            HitLetter(J, 'J', 'J');
        }

        private void ClickK(object sender, RoutedEventArgs e)
        {
            HitLetter(K, 'K', 'K');
        }

        private void ClickL(object sender, RoutedEventArgs e)
        {
            HitLetter(L, 'L', 'L');
        }

        private void ClickLY(object sender, RoutedEventArgs e)
        {
            HitLetter(LY, '4', 'Ł');
        }

        private void ClickM(object sender, RoutedEventArgs e)
        {
            HitLetter(M, 'M', 'M');
        }

        private void ClickN(object sender, RoutedEventArgs e)
        {
            HitLetter(N, 'N', 'N');
        }

        private void ClickON(object sender, RoutedEventArgs e)
        {
            HitLetter(ON, '5', 'Ń');
        }

        private void ClickO(object sender, RoutedEventArgs e)
        {
            HitLetter(O, 'O', 'O');
        }

        private void ClickUO(object sender, RoutedEventArgs e)
        {
            HitLetter(UO, '6', 'Ó');
        }

        private void ClickP(object sender, RoutedEventArgs e)
        {
            HitLetter(P, 'P', 'P');
        }

        private void ClickQ(object sender, RoutedEventArgs e)
        {
            HitLetter(Q, 'Q', 'Q');
        }

        private void ClickR(object sender, RoutedEventArgs e)
        {
            HitLetter(R, 'R', 'R');
        }

        private void ClickS(object sender, RoutedEventArgs e)
        {
            HitLetter(S, 'S', 'S');
        }

        private void ClickSI(object sender, RoutedEventArgs e)
        {
            HitLetter(SI, '7', 'Ś');
        }
                        
        private void ClickT(object sender, RoutedEventArgs e)
        {
            HitLetter(T, 'T', 'T');
        }

        private void ClickU(object sender, RoutedEventArgs e)
        {
            HitLetter(U, 'U', 'U');
        }

        private void ClickV(object sender, RoutedEventArgs e)
        {
            HitLetter(V, 'V', 'V');
        }

        private void ClickW(object sender, RoutedEventArgs e)
        {
            HitLetter(W, 'W', 'W');
        }

        private void ClickX(object sender, RoutedEventArgs e)
        {
            HitLetter(X, 'X', 'X');
        }

        private void ClickY(object sender, RoutedEventArgs e)
        {
            HitLetter(Y, 'Y', 'Y');
        }

        private void ClickZ(object sender, RoutedEventArgs e)
        {
            HitLetter(Z, 'Z', 'Z');
        }

        private void ClickZE(object sender, RoutedEventArgs e)
        {
            HitLetter(ZE, '8', 'Ż');
        }

        private void ClickZI(object sender, RoutedEventArgs e)
        {
            HitLetter(ZI, '9', 'Ź');
        }

        void HitLetter(Button letterBtn, char mark, char letter)
        {
            Word.Text = "";
            for (int i = 0; i < clueWord.Length; i++)
            {
                if (clueWord[i] == ' ')
                {
                    Word.Text += " ";
                }
                else if (clueWord[i] != mark && countLetter[i] == 0)
                {
                    Word.Text += "-";
                }
                else if (clueWord[i] != mark && countLetter[i] == 1)
                {
                    Word.Text += clueWord[i];
                }
                else if (clueWord[i] == mark)
                {
                    Word.Text += letter;
                    clueWord[i] = letter;
                    countLetter[i] = 1;
                    hit++;
                }
            }

            if (hit > 0)
            {
                letterBtn.Background = Brushes.Green;
                GoodSoundPlay();
            }
            else
            {
                letterBtn.Background = Brushes.DarkRed;
                countWrongHit++;
                WrongSoundPlay();
            }

            CheckWinLose();
            DrawHangman();

            hit = 0;
        }

        void CheckWinLose()
        {
            int checkWin = 0;

            for (int i = 0; i < clueWord.Length; i++)
            {                
                if (countLetter[i] == 1)
                {
                    checkWin++;
                }
                else
                {
                    continue;
                }
            }

            if(ifFight == 0)
            {
                if (checkWin == clueWord.Length)
                {
                    Uri img = new Uri(@"Graphic\WinImg.png", UriKind.Relative);
                    BitmapImage imgWin = new BitmapImage(img);
                    LoseWinImg.Source = imgWin;
                    LoseWinText.Text = "You Win!";
                    LoseWinText.Foreground = Brushes.DarkGreen;
                    NextGridAnimation(Game, EndGame);
                }

                if (countWrongHit == 10)
                {
                    Uri img = new Uri(@"Graphic\LoseImg.png", UriKind.Relative);
                    BitmapImage imgWin = new BitmapImage(img);
                    LoseWinImg.Source = imgWin;
                    LoseWinText.Text = "You Lose!";
                    LoseWinText.Foreground = Brushes.DarkRed;
                    NextGridAnimation(Game, EndGame);
                }
            }
            else
            {
                if (checkWin == clueWord.Length)
                {
                    NextGridAnimation(Game, ChangeUser);
                    ShowBackgroundImg(BackImg);
                    ChangeTurnAndAddScore();
                }
                if (countWrongHit == 10)
                {
                    NextGridAnimation(Game, ChangeUser);
                    ShowBackgroundImg(BackImg);
                    ChangeTurnAndAddScore();
                }
            }
            
        }

        void DrawHangman()
        {
            switch(countWrongHit)
            {
                case 1:
                    {
                        Uri img = new Uri(@"Graphic\WrongHit\1WrongHit.png", UriKind.Relative);
                        BitmapImage imgWH = new BitmapImage(img);
                        ShowBackgroundImg(WrongHit);
                        WrongHit.Source = imgWH;
                        WrongHit.Opacity = 1;
                        return;
                    }
                case 2:
                    {
                        Uri imgWH = new Uri(@"Graphic\WrongHit\2WrongHit.png", UriKind.Relative);
                        BitmapImage img = new BitmapImage(imgWH);
                        WrongHit.Source = img;
                        return;
                    }
                case 3:
                    {
                        Uri imgWH = new Uri(@"Graphic\WrongHit\3WrongHit.png", UriKind.Relative);
                        BitmapImage img = new BitmapImage(imgWH);
                        WrongHit.Source = img;
                        return;
                    }
                case 4:
                    {
                        Uri imgWH = new Uri(@"Graphic\WrongHit\4WrongHit.png", UriKind.Relative);
                        BitmapImage img = new BitmapImage(imgWH);
                        WrongHit.Source = img;
                        return;
                    }
                case 5:
                    {
                        Uri imgWH = new Uri(@"Graphic\WrongHit\5WrongHit.png", UriKind.Relative);
                        BitmapImage img = new BitmapImage(imgWH);
                        WrongHit.Source = img;
                        return;
                    }
                case 6:
                    {
                        Uri imgWH = new Uri(@"Graphic\WrongHit\6WrongHit.png", UriKind.Relative);
                        BitmapImage img = new BitmapImage(imgWH);
                        WrongHit.Source = img;
                        return;
                    }
                case 7:
                    {
                        Uri imgWH = new Uri(@"Graphic\WrongHit\7WrongHit.png", UriKind.Relative);
                        BitmapImage img = new BitmapImage(imgWH);
                        WrongHit.Source = img;
                        return;
                    }
                case 8:
                    {
                        Uri imgWH = new Uri(@"Graphic\WrongHit\8WrongHit.png", UriKind.Relative);
                        BitmapImage img = new BitmapImage(imgWH);
                        WrongHit.Source = img;
                        return;
                    }
                case 9:
                    {
                        Uri imgWH = new Uri(@"Graphic\WrongHit\9WrongHit.png", UriKind.Relative);
                        BitmapImage img = new BitmapImage(imgWH);
                        WrongHit.Source = img;
                        return;
                    }
                case 10:
                    {
                        Uri imgWH = new Uri(@"Graphic\WrongHit\10WrongHit.png", UriKind.Relative);
                        BitmapImage img = new BitmapImage(imgWH);
                        WrongHit.Source = img;
                        return;
                    }
            }
        }

    }
}