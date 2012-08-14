namespace EventbriteNET.Model
{
    using System;
    using Json.Converters;
    using Newtonsoft.Json;

    public class Organizer : ModelWithId
    {
        [JsonProperty("url")]
        [JsonConverter(typeof (UriConverter))]
        public Uri Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("long_description")]
        public string LongDescription { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}