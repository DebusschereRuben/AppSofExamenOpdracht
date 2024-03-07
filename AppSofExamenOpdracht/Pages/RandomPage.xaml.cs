using AppSofExamenOpdracht.Classes;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AppSofExamenOpdracht.Pages
{
    public partial class RandomPage : Page
    {
        Cocktail currentCocktail;
        private Frame _mainFrame;
        public RandomPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private async void Btn_Random_Click(object sender, RoutedEventArgs e)
        {
            using HttpClient client = new();

            var cocktail = await ProcessCocktailAsync(client);
            currentCocktail = cocktail;

            loadCocktailsDetails(cocktail);
        }

        private async Task<Cocktail> ProcessCocktailAsync(HttpClient client)
        {
            var JSON = await client.GetStringAsync("https://www.thecocktaildb.com/api/json/v1/1/random.php");
            var drinks = JsonSerializer.Deserialize<Drinks>(JSON);
            var cocktail = drinks.Cocktails[0];

            return cocktail;
        }

        private async void loadCocktailsDetails(Cocktail cocktail)
        {
            Uri cocktailUri = new Uri(cocktail.Image);
            img_cocktail.Source = new BitmapImage(cocktailUri);

            lbl_name.Content = cocktail.Name;
        }

        private async void btn_CocktailDetails_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new CocktailDetailsPage(currentCocktail));
        }
    }
}
