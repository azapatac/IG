namespace IG.Common
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Country
    {

        [JsonProperty("capital")]
        public string Capital { get; set; }

        [JsonProperty("latlng")]
        public IList<double> Latlng { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }
    }
}