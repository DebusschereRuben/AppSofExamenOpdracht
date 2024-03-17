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
        public CocktailDetailsPage(Cocktail cocktail)
        {
            InitializeComponent();
            this.cocktail = cocktail;
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
    }
}
