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

namespace ColorMixer
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const byte BYTE_MIN = 0;
        private const byte BYTE_MAX = 255;

        public MainWindow()
        {
            InitializeComponent();
            SetBackground();
        }
        private void Mix_Click(object sender, RoutedEventArgs e)
        {
            byte R = (LeftRed.IsChecked == true || RightRed.IsChecked == true) ? BYTE_MAX : BYTE_MIN; 
            byte G = (LeftGreen.IsChecked == true || RightGreen.IsChecked == true) ? BYTE_MAX : BYTE_MIN;
            byte B = (LeftBlue.IsChecked == true || RightBlue.IsChecked == true) ? BYTE_MAX : BYTE_MIN;

            TheGrid.Background = new SolidColorBrush(Color.FromArgb(255, R, G, B));
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            LeftRed.IsChecked = false;
            RightRed.IsChecked = false;
            LeftGreen.IsChecked = false;

            RightGreen.IsChecked = false;
            LeftBlue.IsChecked = false;
            RightBlue.IsChecked = false;

            SetBackground();
        }

        private void SetBackground()
        {
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
            myLinearGradientBrush.StartPoint = new Point(0, 0);
            myLinearGradientBrush.EndPoint = new Point(1, 1);
            myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.0));
            myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.Green, 0.5));
            myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
            TheGrid.Background = myLinearGradientBrush;
        }
    }
}
