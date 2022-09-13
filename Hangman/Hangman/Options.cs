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
    // Okno Ustawień

    public partial class MainWindow : Window
    {
        

        private void BackOptionsClick(object sender, RoutedEventArgs e)
        {
            PreviousGridAnimation(Options, Menu);
            ClickSoundPlay();
            ChceckUserSettings();
        }

        private void MusicValueChaged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {            
            Music.Volume = Slider_Music.Value;
            Music_Volume.Text = Math.Round(Slider_Music.Value * 100).ToString();
        }

        private void SoundsValueChaged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Sounds.Volume = Slider_Sounds.Value;
            Sounds_Volume.Text = Math.Round(Slider_Sounds.Value * 100).ToString();
        }

        private void SaveAndBackClick(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(@"..\..\Settings\Settings.txt"))
            {
                MessageBox.Show(@"Hangman didn't found file Setting\Settings.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }

            StreamWriter sw = new StreamWriter(@"..\..\Settings\Settings.txt");
            sw.WriteLine(Math.Round(Slider_Music.Value, 2).ToString());
            sw.Write(Math.Round(Slider_Sounds.Value, 2).ToString());
            sw.Close();

            ClickSoundPlay();
            PreviousGridAnimation(Options, Menu);
        }        

        void ChceckUserSettings()
        {
            if (!File.Exists(@"..\..\Settings\Settings.txt"))
            {
                MessageBox.Show(@"Hangman didn't found file Setting\Settings.txt", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }            

            StreamReader sr = new StreamReader(@"..\..\Settings\Settings.txt");
            string value = sr.ReadLine();
            Slider_Music.Value = Double.Parse(value);
            Music.Volume = Double.Parse(value);
            Music_Volume.Text = (Double.Parse(value) * 100).ToString();

            value = sr.ReadLine();
            Slider_Sounds.Value = Double.Parse(value);
            Sounds.Volume = Double.Parse(value);
            Sounds_Volume.Text = (Double.Parse(value) * 100).ToString();
            sr.Close();
        }
    }

}