namespace EventbriteNET.Model
{
    using System;
    using System.Collections.Generic;
    using HttpApi;

    public class Event
    {
        public DateTime Created;
        public string Description;
        public DateTime EndDateTime;
        public long Id;
        public DateTime Modified;
        public DateTime StartDateTime;

        public Dictionary<long, Ticket> Tickets = new Dictionary<long, Ticket>();
        public string Title;

        private List<Attendee> attendees;

/*
        public List<Attendee> Attendees
        {
            get
            {
                if (attendees == null)
                {
                    attendees = new List<Attendee>();
                    attendees.AddRange(new EventAttendeesRequest(Id, Context).GetResponse());
                }
                return attendees;
            }
        }*/
    }
}