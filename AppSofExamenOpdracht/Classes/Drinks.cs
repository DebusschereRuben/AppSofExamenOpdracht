using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppSofExamenOpdracht.Classes
{
    internal class Drinks
    {
        [JsonPropertyName("drinks")]
        public IList<Cocktail> Cocktails { get; set; } = new List<Cocktail>();
    }
}
