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

namespace FatPercentageCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SeeCalories_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string CalInputText = CaloriesInput.Text;
                string FatInputText = FatInput.Text;

                float TotalCal = float.Parse(CalInputText);
                float TotalFat = float.Parse(FatInputText);
                float TotalPerc = TotalFat * 9 / TotalCal;
                CaloriesOutput.Content = TotalFat * 9;
                PercentageOutput.Content = TotalPerc.ToString("P");

                if (CheckLowFat.IsChecked == true)
                {
                    if (TotalPerc < 0.3)
                    {
                        LowFatOutput.Content = "Yep it is Low Fat!";
                    }
                    else
                    {
                        LowFatOutput.Content = "No it is not Low Fat :(";
                    }
                }
            }
            catch
            {
                CaloriesOutput.Content = ":<";
                PercentageOutput.Content = "Put A Number Bruh!";
            }
        }
    }
}
