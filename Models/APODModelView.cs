using System.Text.Json.Serialization;

namespace Planets.Models
{
    public class APODModelView
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("explanation")]
        public string Explanation { get; set; }

        public override string ToString()
        {
            return $"URL {Url} Title {Title} Explanation {Explanation}";
        }
    }
}