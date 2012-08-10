namespace EventbriteNET.Model
{
    using System.Collections.Generic;
    using HttpApi;

    public class Organizer
    {
        private readonly long id;

        private Dictionary<long, Event> events;


        public long Id
        {
            get { return id; }
        }
/*
        public Dictionary<long, Event> Events
        {
            get
            {
                if (events == null)
                {
                    events = new Dictionary<long, Event>();
                    var eventArray = new OrganizerEventsRequest(Id, Context).GetResponse();
                    foreach (var eventEntity in eventArray)
                    {
                        events.Add(eventEntity.Id, eventEntity);
                    }
                }
                return events;
            }
        }*/
    }
}