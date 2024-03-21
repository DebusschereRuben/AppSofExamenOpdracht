using AppSofExamenOpdracht.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public partial class CocktailDetailsPage : Page
    {
        Cocktail cocktail;
        Frame _mainFrame;
        RandomPage _randomPage;
        CocktailsPage _cocktailsPage;
        public CocktailDetailsPage(Cocktail cocktail)//basic opstarten 1e keer
        {
            InitializeComponent();
            this.cocktail = cocktail;
            loadCocktailDetails();
        }
        public CocktailDetailsPage(Cocktail cocktail, Frame mainFrame, RandomPage rp)//om terug te kunnen keren naar randompage met behoud van data
        {
            InitializeComponent();
            this.cocktail = cocktail;
            _mainFrame = mainFrame;
            _randomPage = rp;
            loadCocktailDetails();
        }
        public CocktailDetailsPage(Cocktail cocktail, Frame mainFrame, CocktailsPage cp)//om terug te kunnen keren naar searchpage met behoud van data
        {
            InitializeComponent();
            this.cocktail = cocktail;
            _mainFrame = mainFrame;
            _cocktailsPage = cp;
            loadCocktailDetails();
        }

        public void loadCocktailDetails()
        {
            Uri cocktailUri = new Uri(cocktail.Image);
            img_cocktail.Source = new BitmapImage(cocktailUri);

            txt_name.Text = cocktail.Name;
            lbl_alcoholic.Content = cocktail.Alcoholic;
            lbl_categorie.Content += cocktail.Categorie;
            lbl_glass.Content += cocktail.Glass;

            txt_instructions.Text = cocktail.Instructions;

            lst_ingredients.Items.Clear();
            foreach (var ing in cocktail.ingredients)
            {
                lst_ingredients.Items.Add(ing);
            }
        }

        private async void btn_ReturnToRandom(object sender, RoutedEventArgs e)
        {
            if(_randomPage != null)
            {
                _mainFrame.Navigate(_randomPage);
            }else if(_cocktailsPage != null)
            {
                _mainFrame.Navigate(_cocktailsPage);
            }
        }
    }
}
