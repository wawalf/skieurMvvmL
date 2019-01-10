using Newtonsoft.Json;

namespace SkieurMVVML.Models
{
    public class Competence
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("libelle")]
        public string Libelle { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("moniteur")]
        public string Moniteur { get; set; }
        [JsonProperty("Categorie")]
        public Categorie Categorie { get; set; }
    }
}