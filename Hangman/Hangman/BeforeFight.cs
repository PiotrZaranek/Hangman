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
    // Okno Przed walką

    public partial class MainWindow : Window
    {
        private void ClickOKBeforeFightBtn(object sender, RoutedEventArgs e)
        {
            LoadDataFormSave(userChoiceFight);
            NextGridAnimation(BeforeFight, ChangeUser);
            StopPlayMaintheme();
            ClickSoundPlay();
        }

        private void ClickBackBeforeFightBtn(object sender, RoutedEventArgs e)
        {
            PreviousGridAnimation(BeforeFight, Fight);
            ClickSoundPlay();
        }       
    }
}
