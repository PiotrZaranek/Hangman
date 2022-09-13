using System;
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
using System.Windows.Media.Animation;

namespace Hangman
{
    // Animacje w grze

    public partial class MainWindow : Window
    {
        ThicknessAnimation hideLeft = new ThicknessAnimation(new Thickness(-1310, 0, 1310, 0), new Duration(TimeSpan.FromSeconds(1)));
        ThicknessAnimation hideRight = new ThicknessAnimation(new Thickness(1310, 0, -1310, 0), new Duration(TimeSpan.FromSeconds(1)));
        ThicknessAnimation hideRightBTM = new ThicknessAnimation(new Thickness(1310, 0, -1310, 0), new Duration(TimeSpan.FromSeconds(1)));
        ThicknessAnimation showRight = new ThicknessAnimation(new Thickness(1310, 0, -1310, 0) ,new Thickness(0, 0, 0, 0), new Duration(TimeSpan.FromSeconds(1)));
        ThicknessAnimation showLeft = new ThicknessAnimation(new Thickness(-1310, 0, 1310, 0) , new Thickness(0, 0, 0, 0), new Duration(TimeSpan.FromSeconds(1)));
        DoubleAnimation hideImg = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(1)));
        DoubleAnimation hideImgFast = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromMilliseconds(10)));
        DoubleAnimation showImg = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(1)));
        DoubleAnimation hideGrid = new DoubleAnimation(1, 0.3, new Duration(TimeSpan.FromSeconds(1)));
        DoubleAnimation showGrid = new DoubleAnimation(0.3, 1, new Duration(TimeSpan.FromSeconds(1)));

        void NextGridAnimation(Grid HideGrid, Grid ShowGrid)
        {
            hideLeft.EasingFunction = new QuarticEase();
            showRight.EasingFunction = new QuarticEase();
            HideGrid.BeginAnimation(MarginProperty, hideLeft);
            ShowGrid.BeginAnimation(MarginProperty, showRight);
        }

        void PreviousGridAnimation(Grid HideGrid, Grid ShowGrid)
        {
            hideRight.EasingFunction = new QuarticEase();
            showLeft.EasingFunction = new QuarticEase();
            HideGrid.BeginAnimation(MarginProperty, hideRight);
            ShowGrid.BeginAnimation(MarginProperty, showLeft);
        }

        void HideBackgroundImg(Image img)
        {
            hideImg.EasingFunction = new QuarticEase();
            img.BeginAnimation(OpacityProperty, hideImg);
        }

        void ShowBackgroundImg(Image img)
        {
            showImg.EasingFunction = new QuarticEase();
            img.BeginAnimation(OpacityProperty, showImg);
        }

        void BackToMenu()
        {
            hideRight.EasingFunction = new QuarticEase();
            showLeft.EasingFunction = new QuarticEase();
            EndGame.BeginAnimation(MarginProperty, hideRight);            
            Menu.BeginAnimation(MarginProperty, showLeft);
        }

        void HideGridAndShowDelete()
        {
            hideGrid.EasingFunction = new QuarticEase();
            showRight.EasingFunction = new QuarticEase();
            Fight.BeginAnimation(OpacityProperty, hideGrid);
            Delete.BeginAnimation(MarginProperty, showRight);
        }

        void ShowGridAndHideDelete()
        {
            showGrid.EasingFunction = new QuarticEase();
            hideRight.EasingFunction = new QuarticEase();
            Fight.BeginAnimation(OpacityProperty, showGrid);
            Delete.BeginAnimation(MarginProperty, hideRight);
        }

        void ShwoWarningCreate(TextBlock show)
        {
            showImg.EasingFunction = new QuadraticEase();
            show.BeginAnimation(OpacityProperty, showImg);
        }

        void HideWarningCreate(TextBlock hide)
        {
            hideImg.EasingFunction = new QuadraticEase();
            hide.BeginAnimation(OpacityProperty, hideImg);
        }

        void HideFastWarnigCreate(TextBlock hide)
        {
            hideImgFast.EasingFunction = new QuadraticEase();
            hide.BeginAnimation(OpacityProperty, hideImgFast);
        }
    }
}
