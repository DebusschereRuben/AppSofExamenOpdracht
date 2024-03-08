using AppSofExamenOpdracht.Classes;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
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

            loadCocktailPreview(cocktail);
        }

        private async Task<Cocktail> ProcessCocktailAsync(HttpClient client)
        {
            var JSON = await client.GetStringAsync("https://www.thecocktaildb.com/api/json/v1/1/random.php");
            var drinks = JsonSerializer.Deserialize<Drinks>(JSON);
            var cocktail = drinks.Cocktails[0];

            //ingredients list
            var dResponse = JsonSerializer.Deserialize<Dictionary<string, List<Dictionary<string, object>>>>(JSON);
            var dDrinks = dResponse["drinks"];
            var dCocktail =dDrinks[0];
            cocktail.ingredients = getIngredients(dCocktail);

            return cocktail;
        }
        private List<string> getIngredients(Dictionary<string, object> d)
        {
            List<string> ingredients = new List<string>();

            for (int i = 1; i <= 15; i++)
            {
                string ingredientKey = "strIngredient" + i;
                string measureKey = "strMeasure" + i;

                string? ingredient = Convert.ToString(d.ContainsKey(ingredientKey) ? d[ingredientKey] : null);
                string? measure = Convert.ToString(d.ContainsKey(measureKey) ? d[measureKey] : null);

                if (ingredient != null && measure != null && ingredient != "")
                {
                    ingredients.Add($"{measure} {ingredient}");
                }
                else
                {
                    i = 10000;//early exit
                }
            }
            return ingredients;
        }

        private async void loadCocktailPreview(Cocktail cocktail)
        {
            Uri cocktailUri = new Uri(cocktail.Image);
            img_cocktail.Source = new BitmapImage(cocktailUri);

            lbl_name.Content = cocktail.Name;
        }

        private async void Go_to_CocktailDetails(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new CocktailDetailsPage(currentCocktail));
        }
    }
}
