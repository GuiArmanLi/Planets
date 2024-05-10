using Newtonsoft.Json;

namespace Planets.Application.DTO
{
    public class APODResponseDTO
    {
        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("explanation")]
        public string? Explanation { get; set; }
        [JsonProperty("media_type")]
        public string? MediaType { get; set; }
        public override string ToString()
        {
            return $"URL {Url} Title {Title} Explanation {Explanation}";
        }
    }
}