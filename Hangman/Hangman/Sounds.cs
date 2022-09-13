using System;
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
    // Dźwięki w grze

    public partial class MainWindow : Window
    {
        Uri ClickSound;
        Uri WrongSound;
        Uri GoodSound;
        Uri WritingSound;
        Uri MainTheme;
        MediaPlayer Sounds = new MediaPlayer();
        MediaPlayer Music = new MediaPlayer();
        //SoundPlayer Music = new SoundPlayer(@"..\..\Sounds\MainTheme.wav");
        
        void ClickSoundPlay()
        {
            ClickSound = new Uri(@"..\..\Sounds\ClickSound.wav", UriKind.Relative);
            Sounds.Open(ClickSound);
            Sounds.Play();
            ClickSound = null;
        }

        void WrongSoundPlay()
        {
            WrongSound = new Uri(@"..\..\Sounds\WrongSound.wav", UriKind.Relative);
            Sounds.Open(WrongSound);
            Sounds.Play();
            WrongSound = null;
        }

        void GoodSoundPlay()
        {
            GoodSound = new Uri(@"..\..\Sounds\GoodSound.wav", UriKind.Relative);
            Sounds.Open(GoodSound);
            Sounds.Play();
            GoodSound = null;
        }

        void WritingSoundPlay()
        {
            WritingSound = new Uri(@"..\..\Sounds\WritingPen.wav", UriKind.Relative);
            Sounds.Open(WritingSound);
            Sounds.Play();
            WritingSound = null;
        }

        void StartPlayMaintheme()
        {
            MainTheme = new Uri(@"..\..\Sounds\MainTheme.wav", UriKind.Relative);
            Music.Open(MainTheme);
            Music.Play();            
        }

        void StopPlayMaintheme()
        {
            Music.Stop();            
        }
    }
}