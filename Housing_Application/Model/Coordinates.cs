using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Housing_Application.Model
{
    public class Coordinates
    {
        [JsonProperty("lat")]
        public float Latitude { get; set; } = 0.00f;
        [JsonProperty("lon")]
        public float Longitude { get; set; } = 0.00f;
    }
}