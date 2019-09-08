using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Web;

namespace Housing_Application.Model
{
    public class Houses
    {
        [JsonProperty("houses")]
        public IList<House> houses { get; set; }
    }
}