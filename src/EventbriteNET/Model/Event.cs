namespace EventbriteNET.Model
{
    using System;
    using Newtonsoft.Json;

    public class Event : ModelWithId
    {
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDateTime { get; set; }

        public DateTime Modified { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDateTime { get; set; }

        public string Title { get; set; }
    }
}