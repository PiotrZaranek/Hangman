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
    // Okno Menu główniego

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartPlayMaintheme();
            ChceckUserSettings();
            SetTextBoxLenght();
        }
   
        private void GrajClick(object sender, RoutedEventArgs e)
        {
            NextGridAnimation(Menu, DifficultyLevel);
            ClickSoundPlay();   
        }

        private void FightClick(object sender, RoutedEventArgs e)
        {
            ChcekSaveFightAndResartControls();
            NextGridAnimation(Menu, Fight);
            ClickSoundPlay();
        }

        private void Koniec_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OptionsClick(object sender, RoutedEventArgs e)
        {
            NextGridAnimation(Menu, Options);
            ClickSoundPlay();
        }
    }
}
