using System;
using System.Windows;
using System.Text;
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
    // Okno wyboru poziomu trudności gry

    public partial class MainWindow : Window
    {

        short userChoiceDifficultyLevel = 0;

        private void ClickWstecz(object sender, RoutedEventArgs e)
        {
            PreviousGridAnimation(DifficultyLevel, Menu);
            ClickSoundPlay();
        }

        private void ClickEasy(object sender, RoutedEventArgs e)
        {
            Word.Text = "";
            word = "";
            clueWord = null;
            countLetter = null;
            hit = 0;
            countWrongHit = 0;
            ifFight = 0;
            NextGridAnimation(DifficultyLevel, Game);
            ClickSoundPlay();
            StopPlayMaintheme();
            DrawWordEasy();
            HideBackgroundImg(BackImg);            
            Restart();
            ChangeStyleEndGame(ifFight);
            userChoiceDifficultyLevel = 1;
        }

        private void MediumClick(object sender, RoutedEventArgs e)
        {
            Word.Text = "";
            word = "";
            clueWord = null;
            countLetter = null;
            hit = 0;
            countWrongHit = 0;
            ifFight = 0;
            NextGridAnimation(DifficultyLevel, Game);
            ClickSoundPlay();
            StopPlayMaintheme();
            DrawWordMedium();
            HideBackgroundImg(BackImg);
            Restart();
            ChangeStyleEndGame(ifFight);
            userChoiceDifficultyLevel = 2;
        }

        private void HardClick(object sender, RoutedEventArgs e)
        {
            Word.Text = "";
            word = "";
            clueWord = null;
            countLetter = null;
            hit = 0;
            countWrongHit = 0;
            ifFight = 0;
            NextGridAnimation(DifficultyLevel, Game);
            ClickSoundPlay();
            StopPlayMaintheme();
            DrawWordHard();
            HideBackgroundImg(BackImg);
            Restart();
            ChangeStyleEndGame(ifFight);
            userChoiceDifficultyLevel = 3;
        }

        void Restart()
        {
            BrushConverter bc = new BrushConverter();
            
            A.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            B.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            OL.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            C.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            CI.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            D.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            E.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            EL.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            F.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            G.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            H.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            I.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            J.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            K.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            L.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            LY.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            M.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            N.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            ON.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            O.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            UO.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            P.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            Q.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            R.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            S.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            SI.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            T.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            U.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            V.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            W.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            X.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            Y.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            Z.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            ZE.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");
            ZI.Background = (Brush)bc.ConvertFrom("#FF2F6DB8");

            HideBackgroundImg(WrongHit);
                       
        }
    }
}