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
        Cocktail currentCocktail;
        public CocktailDetailsPage(Cocktail cocktail)
        {
            InitializeComponent();
            currentCocktail = cocktail;
            loadDetails();
        }

        public void loadDetails()
        {
            lbl_name.Content = currentCocktail.Name;
        }
    }
}
