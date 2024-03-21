using AppSofExamenOpdracht.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AppSofExamenOpdracht.Pages
{
    public partial class MealDetailsPage : Page
    {
        Meal meal;
        Frame _mainFrame;
        Page _previousPage;
        public MealDetailsPage(Meal meal, Frame mainFrame, Page p)
        {
            InitializeComponent();
            this.meal = meal;
            _mainFrame = mainFrame;
            _previousPage = p;
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

        private void btn_Return(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(_previousPage);
        }
    }
}
