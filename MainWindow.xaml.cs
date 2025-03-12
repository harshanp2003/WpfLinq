using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfLinq
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
        private void Calculate(object sender, RoutedEventArgs e)
        {
            string text = Input_text.Text;

            string[] inputArray = text.Split(' ');

            var numbers = inputArray
                         .Where(num => int.TryParse(num, out _)) // Filter out invalid entries
                         .Select(num => int.Parse(num))          // Parse valid strings to integers
                         .ToList();

           

            var larger = from number in numbers
                          where number > 50
                          select number;
            string result1 = "";
            foreach (var number in larger)
            {
                result1 += number + " ";
            }
            Larger.Text = "Numbers greater than 50 are: " + result1;


            numbers.Sort();
            string result2 = "";
            foreach (var number in numbers)
            {
                result2 += number + " ";
            }
            Sorted.Text= "Sorted numbers are: " + result2;



            var squared = numbers.Select(x => x * x);
            string result3 = "";
            foreach (var number in squared)
            {
                result3 += number + " ";
            }
            Squared.Text="Squared Numbers are: "+ result3;
        }
    }
}