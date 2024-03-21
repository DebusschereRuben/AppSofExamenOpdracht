using AppSofExamenOpdracht.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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

namespace AppSofExamenOpdracht.Pages
{
    /// <summary>
    /// Interaction logic for MealsPage.xaml
    /// </summary>
    public partial class MealsPage : Page
    {
        private Frame _mainFrame;
        public MealsPage(Frame mainframe)
        {
            InitializeComponent();
            _mainFrame = mainframe;
        }

        private async void btn_search_Click(object sender, RoutedEventArgs e)
        {
            lst_mealList.Items.Clear();
            string search = txt_input.Text.Trim().ToLower();

            if (search != "")
            {
                var meals = await getMealsAsync(search);

                if (meals.MealsList != null)
                {
                    foreach (var meal in meals.MealsList)
                    {
                        lst_mealList.Items.Add(meal);
                    }
                }
                else
                {
                    MessageBox.Show("Geen meals gevonden die overeenkomen met de zoekopdracht: " + search + ", probeer iets anders");
                }
            }
        }

        private async Task<Meals> getMealsAsync(string search)
        {
            HttpClient client = new HttpClient();
            Meals? meals = new Meals();

            var JSON = await client.GetStringAsync($"https://www.themealdb.com/api/json/v1/1/search.php?s={search}");
            meals = JsonSerializer.Deserialize<Meals>(JSON);

            return meals;
        }

        private async void btn_details_Click(object sender, RoutedEventArgs e)
        {
            if(lst_mealList.SelectedItem != null)
            {
                HttpClient client = new();

                var listItem = lst_mealList.SelectedItem;
                Meal meal = (Meal)listItem;

                var JSON = await client.GetStringAsync($"https://www.themealdb.com/api/json/v1/1/search.php?s={meal.Name}");
                var dResponse = JsonSerializer.Deserialize<Dictionary<string, List<Dictionary<string, object>>>>(JSON);
                var dMeals = dResponse["meals"];
                var dMeal = dMeals[0];
                meal.ingredients = getIngredients(dMeal, 20);

                _mainFrame.Navigate(new MealDetailsPage(meal, _mainFrame, this));//mainframe voor navigatie, this is state vd pagina
            }
            else
            {
                MessageBox.Show("Geen maaltijd geselcteerd");
            }
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
    }
}
