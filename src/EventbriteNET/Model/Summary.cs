namespace EventbriteNET.Model
{
    using HttpApi.RequestParameters;
    using Newtonsoft.Json;

    public class Summary
    {
        [JsonProperty("first_event")]
        public long FirstEvent { get; set; }

        [JsonProperty("last_event")]
        public long LastEvent { get; set; }

        [JsonProperty("total_items")]
        public long TotalItems { get; set; }

        [JsonProperty("num_showing")]
        public long NumShowing { get; set; }

        [JsonProperty("filters")]
        public EventSearchFilter Filter { get; set; }
    }
}