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
        Cocktail _cocktail;
        Frame _mainFrame;
        Page _previousPage;
        
        public CocktailDetailsPage(Cocktail c, Frame mainFrame, Page p)//om terug te kunnen keren naar vorige pagina met behoud van data
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            _cocktail = c;
            _previousPage = p;
            loadCocktailDetails();
        }

        public void loadCocktailDetails()
        {
            Uri cocktailUri = new(_cocktail.Image);
            img_cocktail.Source = new BitmapImage(cocktailUri);

            txt_name.Text = _cocktail.Name;
            lbl_alcoholic.Content = _cocktail.Alcoholic;
            lbl_categorie.Content += _cocktail.Categorie;
            lbl_glass.Content += _cocktail.Glass;

            txt_instructions.Text = _cocktail.Instructions;

            lst_ingredients.Items.Clear();
            foreach (var ing in _cocktail.ingredients)
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
