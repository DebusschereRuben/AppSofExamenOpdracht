using System.Windows;
using AppSofExamenOpdracht.Pages;

namespace AppSofExamenOpdracht
{
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
            MainFrame.Navigate(new RandomPage(MainFrame));
        }
    }
}