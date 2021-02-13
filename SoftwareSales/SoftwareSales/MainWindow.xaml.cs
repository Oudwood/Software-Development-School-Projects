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

namespace SoftwareSales
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

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            string Sales = SalesInput.Text;
            int Amount = int.Parse(Sales);
            decimal Price = Amount * 99;
            try
            {
                if (Amount <= 19 && Amount>=10)
                {
                    DiscountOutput.Content = "20%";
                    TotalOutput.Content = Decimal.Multiply(Price, 0.8m).ToString("C");
                }
                else if (Amount>=20 && Amount<=49)
                {
                    DiscountOutput.Content = "30%";
                    TotalOutput.Content = Decimal.Multiply(Price, 0.7m).ToString("C");
                }
                else if (Amount>=50 && Amount<=99)
                {
                    DiscountOutput.Content = "40%";
                    TotalOutput.Content = Decimal.Multiply(Price, 0.6m).ToString("C");
                }
                else if (Amount>=100)
                {
                    DiscountOutput.Content = "50%";
                    TotalOutput.Content = Decimal.Multiply(Price, 0.5m).ToString("C");
                }
                else
                {
                    DiscountOutput.Content = "Buy MORE :(";
                    TotalOutput.Content = Price.ToString("C");
                }
            }
            catch
            {
                DiscountOutput.Content = "Put A VALID Number Bruh!";
            }
        }
    }
}
