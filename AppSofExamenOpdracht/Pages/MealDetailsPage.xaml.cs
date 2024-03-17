using AppSofExamenOpdracht.Classes;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AppSofExamenOpdracht.Pages
{
    /// <summary>
    /// Interaction logic for MealDetailsPage.xaml
    /// </summary>
    public partial class MealDetailsPage : Page
    {
        Meal meal;
        public MealDetailsPage(Meal meal)
        {
            InitializeComponent();
            this.meal = meal;
            loadMealDetails();
        }

        private void loadMealDetails()
        {
            Uri mealUri = new Uri(meal.Image);
            img_meal.Source = new BitmapImage(mealUri);

            lbl_name.Content = meal.Name;
            lbl_categorie.Content += meal.Categorie;
            lbl_country.Content += meal.Country;

            txt_instructions.Text = meal.Instructions;

            lst_ingredients.Items.Clear();
            foreach (var ing in meal.ingredients)
            {
                lst_ingredients.Items.Add(ing);
            }
        }
    }
}
