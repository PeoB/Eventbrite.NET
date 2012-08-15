namespace EventbriteNET.Model
{
    using System;
    using System.Collections.Generic;
    using Json.Converters;
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

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("organizer")]
        public Organizer Organizer { get; set; }

        [JsonProperty("url")]
        [JsonConverter(typeof (UriConverter))]
        public Uri Url { get; set; }
        
        [JsonProperty("tickets")]
        [JsonConverter(typeof(InnerListConverter<Ticket2, Ticket>))]
        public List<Ticket> Tickets { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("privacy")]
        public string Privacy { get; set; }
        
        [JsonProperty("logo")]
        [JsonConverter(typeof(UriConverter))]
        public Uri Logo { get; set; }

        [JsonProperty("venue")]
        public Venue Venue { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}