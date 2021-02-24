//By Shan

using NetTopologySuite.Mathematics;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PennNoVMSAD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string SAVED = "Your file has been saved!";
        private const string BACK_TO_ASK = "Please put the days you have worked";
        private const string FILENAME = "output.text";
        private string DATE = DateTime.Now.ToString("MMMM dd, yyyy H:mm:ss");
        private const int PAY_COEFFICIENT = 2;
        private string OutputFile;
        private StringBuilder FileContent = new StringBuilder();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckPay_Click(object sender, RoutedEventArgs e)
        {
            string DIString = DaysInput.Text;
            int DaysNum = int.Parse(DIString);
            decimal TotalPay = Calc();

            DaysOutput.Items.Add(DaysNum.ToString());
            PayOutput.Items.Add(TotalPay.ToString("C"));
            DaysAsk.Content = BACK_TO_ASK;

            OutputFile = DaysNum.ToString() + " : " + TotalPay.ToString("C") + Environment.NewLine;
            FileContent.AppendLine(OutputFile);
        }

        private void SavePay_Click(object sender, RoutedEventArgs e)
        {
            //TO DO: Add date instead of hello
            string FilewithDate = DATE + Environment.NewLine+ FileContent.ToString();
            File.AppendAllText(FILENAME, FilewithDate);
            DaysAsk.Content = SAVED;
        }

        private decimal Calc()
        {
            decimal DailyPay = 0.01m;
            decimal TotalPay = 0m;
            string DIString = DaysInput.Text;
            int DaysNum = int.Parse(DIString);
            if (DaysNum.Equals(0))
            {
                TotalPay = 0;
            }
            for (int x = 1; x <= DaysNum; x++)
            {
                TotalPay += DailyPay;
                DailyPay *= PAY_COEFFICIENT;
            }
            return TotalPay;
        }

        private void ClearPay_Click(object sender, RoutedEventArgs e)
        {
            DaysOutput.Items.Clear();
            PayOutput.Items.Clear();
        }

        private void CheckIfNumber(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            e.Handled = !double.TryParse(textBox.Text + e.Text, out _);
        }
    }
}