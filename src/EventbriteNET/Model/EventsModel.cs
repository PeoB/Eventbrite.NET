namespace EventbriteNET.Model
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class EventsModel
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [JsonProperty("events")]
        public List<GenericEvent> AllEvents { get; set; }

        [JsonIgnore]
        public List<Event> Events
        {
            get
            {
                if (AllEvents == null)
                {
                    return new List<Event>();
                }
                return AllEvents.Where(_ => _.Event != null).Select(_ => _.Event).ToList();
            }
        }
        
        [JsonIgnore]
        public Summary Summary
        {
            get
            {
                if (AllEvents == null)
                {
                    return null;
                }
                var summaryEvent = AllEvents.FirstOrDefault(_ => _.Summary != null);
                return summaryEvent != null ? summaryEvent.Summary : null;
            }
        }
    }
}