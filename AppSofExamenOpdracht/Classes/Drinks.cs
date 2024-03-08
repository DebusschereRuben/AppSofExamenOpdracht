using System.Text.Json.Serialization;

namespace AppSofExamenOpdracht.Classes
{
    internal class Drinks
    {
        [JsonPropertyName("drinks")]
        public IList<Cocktail> Cocktails { get; set; } = new List<Cocktail>();
    }
}
