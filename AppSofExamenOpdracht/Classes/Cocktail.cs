using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppSofExamenOpdracht.Classes
{
    public class Cocktail
    {
        [JsonPropertyName("strDrink")]
        public string? Name { get; set; }
        [JsonPropertyName("strCategorie")]
        public string? Categorie { get; set; }
        [JsonPropertyName("strInstructions")]
        public string? Instructions { get; set; }

        public string? Ingredients;
        public string? Measures;

        [JsonPropertyName("strDrinkThumb")]
        public string? Image {  get; set; }

        public void SetIngredients()
        {

        }

        public void SetMeasures()
        {

        }
    }
}
