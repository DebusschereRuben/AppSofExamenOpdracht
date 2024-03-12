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
        Meal currentMeal;
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
            var meal = await ProcessMealAsync(client);
            currentMeal = meal;

            LoadMealPreview(meal);
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

        private async Task<Meal> ProcessMealAsync(HttpClient client)
        {
            var JSON = await client.GetStringAsync("https://www.themealdb.com/api/json/v1/1/random.php");
            var meals = JsonSerializer.Deserialize<Meals>(JSON);
            var meal = meals.Meals[0];

            // Ingredients list
            meal.Ingredients = GetIngredients(meal);

            return meal;
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
        private List<string> GetIngredients(Meal meal)
        {
            List<string> ingredients = new List<string>();

            for (int i = 1; i <= 20; i++)
            {
                string ingredientKey = "strIngredient" + i;
                string measureKey = "strMeasure" + i;

                string? ingredient = Convert.ToString(meal.ContainsKey(ingredientKey) ? meal[ingredientKey] : null);
                string? measure = Convert.ToString(meal.ContainsKey(measureKey) ? meal[measureKey] : null);

                if (ingredient != null && measure != null && ingredient != "")
                {
                    ingredients.Add($"{measure} {ingredient}");
                }
                else
                {
                    break; // Early exit
                }
            }
            return ingredients;
        }

        private async void loadCocktailPreview(Cocktail cocktail)
        {
            Uri cocktailUri = new Uri(cocktail.Image);
            img_cocktail.Source = new BitmapImage(cocktailUri);

            lbl_nameCocktail.Content = cocktail.Name;
        }

        private async void LoadMealPreview(Meal meal)
        {
            Uri mealUri = new Uri(meal.Image);
            img_meal.Source = new BitmapImage(mealUri);

            lbl_nameMeal.Content = meal.Name;
        }

        private async void Go_to_CocktailDetails(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new CocktailDetailsPage(currentCocktail));
        }

        private async void Go_to_MealDetails(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new MealDetailsPage(currentMeal));
        }
    }
}
