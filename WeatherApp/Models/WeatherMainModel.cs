﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class WeatherMainModel
    {
        [JsonProperty("name")]
        public string name { get; set; }
        public WeatherTempDetails main { get; set; }
        public List<WeatherSubDetails> weather { get; set; }
        public WeatherWindDetails wind { get; set; }
        public WeatherSysDetails sys { get; set; }

        public class WeatherSubDetails
        {
            [JsonProperty("main")]
            public string main { get; set; }
            [JsonProperty("description")]
            public string description { get; set; }
            [JsonProperty("icon")]
            public string icon { get; set; }
        }

        public class WeatherSysDetails
        {
            [JsonProperty("country")]
            public string country { get; set; }
        }

        public class WeatherTempDetails
        {
            [JsonProperty("temp")]
            public string temp { get; set; }
            [JsonProperty("humidity")]
            public string humidity { get; set; }
            [JsonProperty("temp_min")]
            public string temp_min { get; set; }
            [JsonProperty("temp_max")]
            public string temp_max { get; set; }
        }

        public class WeatherWindDetails
        {
            [JsonProperty("speed")]
            public string speed { get; set; }
        }
       
    }

}
