using System.Text.Json.Serialization;

namespace AppSofExamenOpdracht.Classes
{
    public class Cocktail
    {
        [JsonPropertyName("strDrink")]
        public string? Name { get; set; }
        [JsonPropertyName("strAlcoholic")]
        public string? Alcoholic { get; set; }
        [JsonPropertyName("strCategory")]
        public string? Categorie { get; set; }
        [JsonPropertyName("strInstructions")]
        public string? Instructions { get; set; }
        [JsonPropertyName("strGlass")]
        public string? Glass { get; set; }

        public List<string>? ingredients;

        [JsonPropertyName("strDrinkThumb")]
        public string? Image {  get; set; }        
    }
}
