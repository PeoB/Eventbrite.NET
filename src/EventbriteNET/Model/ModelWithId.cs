namespace EventbriteNET.Model
{
    using Newtonsoft.Json;

    public class ModelWithId
    {
        [JsonProperty("id")]
        public long Id;
    }
}