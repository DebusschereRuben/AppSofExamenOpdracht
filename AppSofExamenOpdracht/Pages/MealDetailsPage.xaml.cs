using AppSofExamenOpdracht.Classes;
using System.Windows;
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
        Frame _mainFrame;
        RandomPage _randomPage;
        MealsPage _mealsPage;
        public MealDetailsPage(Meal meal, Frame mainFrame, RandomPage rp)
        {
            InitializeComponent();
            this.meal = meal;
            _mainFrame = mainFrame;
            _randomPage = rp;
            loadMealDetails();
        }
        public MealDetailsPage(Meal meal, Frame mainFrame, MealsPage mp)
        {
            InitializeComponent();
            this.meal = meal;
            _mainFrame = mainFrame;
            _mealsPage = mp;
            loadMealDetails();
        }

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

            txt_name.Text = meal.Name;
            lbl_categorie.Content += meal.Categorie;
            lbl_country.Content += meal.Country;

            txt_instructions.Text = meal.Instructions;

            lst_ingredients.Items.Clear();
            foreach (var ing in meal.ingredients)
            {
                lst_ingredients.Items.Add(ing);
            }
        }

        private async void btn_ReturnToRandom(object sender, RoutedEventArgs e)
        {
            if (_randomPage != null)
            {
                _mainFrame.Navigate(_randomPage);
            }
            else if (_mealsPage != null)
            {
                _mainFrame.Navigate(_mealsPage);
            }
        }
    }
}
