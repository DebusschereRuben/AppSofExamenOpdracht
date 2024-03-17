using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppSofExamenOpdracht.Classes
{
    public class Meal
    {
        [JsonPropertyName("strMeal")]
        public string? Name { get; set; }
        [JsonPropertyName("strArea")]
        public string? Country { get; set; }
        [JsonPropertyName("strCategory")]
        public string? Categorie { get; set; }
        [JsonPropertyName("strInstructions")]
        public string? Instructions { get; set; }
        [JsonPropertyName("strMealThumb")]
        public string? Image { get; set; }
        public List<string>? ingredients;
    }
}
