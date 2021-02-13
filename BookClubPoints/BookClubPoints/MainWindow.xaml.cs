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

namespace BookClubPoints
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

        private void Result(object sender, RoutedEventArgs e)
        {
            try 
            {
                string BooksInputText = BooksInput.Text;
                int BooksInPutR = int.Parse(BooksInputText);
                if (BooksInPutR == 1)
                {
                    PointsOutPut.Content = "You have 5 Points!";
                }
                else if (BooksInPutR == 2)
                {
                    PointsOutPut.Content = "You have 15 Points!";
                }
                else if (BooksInPutR == 3)
                {
                    PointsOutPut.Content = "You have 30 Points!";
                }
                else if (BooksInPutR >= 4)
                {
                    PointsOutPut.Content = "You have 60 Points!";
                }
                else 
                {
                    PointsOutPut.Content = "Sorry, 0 Points:( ";
                }
            }
            catch
            {
                PointsOutPut.Content = "Put A Valid Number Bruh :( ";
            }

        }
    }
}
