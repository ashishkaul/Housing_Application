using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Housing_Application.Model
{
    public class Parameters
    {
        [JsonProperty("rooms")]
        public int Rooms { get; set; } = 0;
        [JsonProperty("value")]
        public int Value { get; set; } = 0;
    }
}