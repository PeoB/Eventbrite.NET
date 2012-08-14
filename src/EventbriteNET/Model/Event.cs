namespace EventbriteNET.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        public List<Ticket2> AllTickets { get; set; }

        [JsonIgnore]
        public List<Ticket> Tickets
        {
            get
            {
                if (AllTickets == null)
                {
                    return new List<Ticket>();
                }
                return AllTickets.Where(_ => _.Ticket != null).Select(_ => _.Ticket).ToList();
            }
        }

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
    }
}