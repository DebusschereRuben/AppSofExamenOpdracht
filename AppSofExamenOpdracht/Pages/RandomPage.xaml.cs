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
        public RandomPage()
        {
            InitializeComponent();
        }

        private async void Btn_Random_Click(object sender, RoutedEventArgs e)
        {
            using HttpClient client = new();

            var cocktail = await ProcessCocktailAsync(client);

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

        private void btn_CocktailDetails_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
