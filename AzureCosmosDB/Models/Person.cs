using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AzureCosmosDB.Models
{
    public class Person
    {
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }

        [Required ]
        [JsonProperty(PropertyName ="firstName")]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [Required]
        [JsonProperty("birthdate")]
        public DateTime Birthdate { get; set; }
        
        [Required]
        [JsonProperty("sex")]
        public Sex Sex { get; set; }
    }

    public enum Sex
    {
        Male,
        Female
    }
}
