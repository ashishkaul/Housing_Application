using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Housing_Application.Model
{
    public class House
    {
        [JsonProperty(PropertyName = "coords")]
        public Coordinates Coordinates { get; set; } = null;

        [JsonProperty("params")]
        public Parameters Parameters { get; set; } = null;

        [JsonProperty("street")]
        public string StreetName { get; set; } = string.Empty;
        public double Distance { get; set; } = 0.00;
    }
}