namespace EventbriteNET.Model
{
    using Newtonsoft.Json;

    public class GenericEvent : ModelWithId
    {
        [JsonProperty("event")]
        public Event Event { get; set; }

        [JsonProperty("summary")]
        public Summary Summary { get; set; }
    }
}