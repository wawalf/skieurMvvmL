using Newtonsoft.Json;

namespace SkieurMVVML.Models
{
    public class Categorie
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("libelle")]
        public string Libelle { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}