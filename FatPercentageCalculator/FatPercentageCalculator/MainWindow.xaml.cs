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
        enum Choices
        {
            Cal,
            Perc
        }
        VM vm = new VM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }
        //private void Food_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    try
        //    {
        //        ListBox Selection = (ListBox)sender;
        //        if (Selection != null)
        //        {
        //            ListBoxItem lbi = Selection.SelectedItem as ListBoxItem;
        //            Choices index = (Choices)Selection.SelectedIndex;
        //            bool LowFat = CheckLowFat.IsChecked == true;

        //            string message = "";
        //            string CalInputText = CaloriesInput.Text;
        //            string FatInputText = FatInput.Text;

        //            float TotalCal = float.Parse(CalInputText);
        //            float TotalFat = float.Parse(FatInputText);
        //            float CalFromFat = TotalFat * 9;
        //            float TotalPerc = TotalFat * 9 / TotalCal;

        //            string LowFatComment = TotalPerc < 0.3 ? " (Low Fat)" : " (Not Low Fat)";

        //            switch (index)
        //            {
        //                case Choices.Cal:
        //                    message = $"The number of carlories from fat is {CalFromFat.ToString()}.";
        //                    break;
        //                case Choices.Perc:
        //                    message = $"The percentage of calories that come from fat is {TotalPerc.ToString("P")}.";
        //                    break;
        //                default:
        //                    message = "";
        //                    break;
        //            }
        //            message += LowFat ? LowFatComment : " :)";
        //            Result.Content = message;
        //        }
        //    }
        //    catch
        //    {
        //        Result.Content = "Put A Number Bruh :<";
        //    }
    }
}

