using System.Text.Json.Serialization;

namespace AppSofExamenOpdracht.Classes
{
    internal class Meals
    {
        [JsonPropertyName("meals")]
        public IList<Meal> MealsList { get; set; } = new List<Meal>();
    }
}
