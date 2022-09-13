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
    // Okno Usuwania Walki

    public partial class MainWindow : Window
    {
        private void ClickYesButton(object sender, RoutedEventArgs e)
        {
            ShowGridAndHideDelete();
            ClickSoundPlay();

            StreamWriter sw;

            switch (userChoiceFight)
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

        private void ClickNoButton(object sender, RoutedEventArgs e)
        {
            ShowGridAndHideDelete();
            ClickSoundPlay();
        }
    }
}
