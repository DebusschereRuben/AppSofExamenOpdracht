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
using AppSofExamenOpdracht.Pages;

namespace AppSofExamenOpdracht
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new CocktailsPage());
        }

        private void Go_to_Cocktails(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CocktailsPage());
        }

        private void Go_to_Meals(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate (new MealsPage());
        }

        private void Go_to_Random(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RandomPage());
        }

    }
}