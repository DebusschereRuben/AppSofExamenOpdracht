using AppSofExamenOpdracht.Classes;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace AppSofExamenOpdracht.Pages
{
    /// <summary>
    /// Interaction logic for CocktailsPage.xaml
    /// </summary>
    public partial class CocktailsPage : Page
    {
        private Frame _mainFrame;
        public CocktailsPage(Frame mainframe)
        {
            InitializeComponent();
            _mainFrame = mainframe;
        }

        private async void btn_search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lst_drinkList.Items.Clear();
                string search = txt_input.Text.Trim().ToLower();
                if (search != "")
                {
                    var drinks = await getDrinksAsync(search);

                    foreach (var drink in drinks.DrinksList)
                    {
                        lst_drinkList.Items.Add(drink);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Geen cocktails met deze naam gevonden, probeer iets anders");
            }
        }

        private async Task<Drinks> getDrinksAsync(string search)
        {
            HttpClient client = new HttpClient();
            Drinks? drinks = new Drinks();

            var JSON = await client.GetStringAsync($"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={search}");
            drinks = JsonSerializer.Deserialize<Drinks>(JSON);

            return drinks;
        }

        private List<string> getIngredients(Dictionary<string, object> d, int amount)
        {
            List<string> ingredients = new List<string>();

            for (int i = 1; i <= amount; i++)
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
        private async void btn_details_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient client = new();

                var listItem = lst_drinkList.SelectedItem;
                Cocktail cocktail = (Cocktail)listItem;

                var JSON = await client.GetStringAsync($"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={cocktail.Name}");
                var dResponse = JsonSerializer.Deserialize<Dictionary<string, List<Dictionary<string, object>>>>(JSON);
                var dDrinks = dResponse["drinks"];
                var dCocktail = dDrinks[0];
                cocktail.ingredients = getIngredients(dCocktail, 15);

                _mainFrame.Navigate(new CocktailDetailsPage(cocktail));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Geen cocktail geselcteerd");
            } 
        }
    }
}
