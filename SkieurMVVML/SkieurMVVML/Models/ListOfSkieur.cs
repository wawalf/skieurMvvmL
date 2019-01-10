using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkieurMVVML.Models
{
    public class ListOfSkieur
    {
        [JsonProperty("Skieurs")]
        public List<Skieur> Skieurs { get; set; }
        public ListOfSkieur()
        {
            Skieurs = new List<Skieur>();
        }
    }
}
