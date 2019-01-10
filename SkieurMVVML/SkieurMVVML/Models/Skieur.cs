using Newtonsoft.Json;
using System.Collections.Generic;

namespace SkieurMVVML.Models
{
    public class Skieur
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("lastName")]
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName == value)
                {
                    return;
                }
                lastName = value;
                //OnPropertyChanged("LastName");
            }
        }
        [JsonProperty("firstName")]
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName == value)
                {
                    return;
                }
                firstName = value;
                //OnPropertyChanged("FirstName");
            }
        }

        [JsonProperty("niveau")]
        private string niveau;

        public string Niveau
        {
            get { return niveau; }
            set
            {
                if (niveau == value)
                {
                    return;
                }
                niveau = value;
                //OnPropertyChanged("niveau");
            }
        }

        [JsonProperty("competences")]
        public List<Competence> Competences { get; set; }

    }
}