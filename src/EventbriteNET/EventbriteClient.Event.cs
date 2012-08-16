namespace EventbriteNET
{
    using HttpApi;
    using HttpApi.RequestParameters;
    using Model;

    public partial class EventbriteClient
    {
        public EventEventbriteClient Event
        {
            get { return new EventEventbriteClient(this); }
        }

        #region Nested type: EventEventbriteClient

        public class EventEventbriteClient : EventbriteClient
        {
            public EventEventbriteClient(EventbriteClient client)
                : base(client.Client)
            {
            }

            public EventsModel EventSearch(EventSearchFilter filter = null)
            {
                var request = EventbriteRequest.Get("event_search", filter);
                return ExecuteRequest<EventsModel>(request);
            }

            public Event GetEvent(GetEventFilter filter)
            {
                var request = EventbriteRequest.Get("event_get", filter);
                return ExecuteRequest<Event2>(request).@event;
            }
            /*
            public List<User> GetUsers()
            {
                var request = EventbriteRequest.Get("users");
                return ExecuteRequest<List<User>>(request);
            }*/

            protected override EventbriteOptions RequestOptions
            {
                get { return new EventbriteOptions(); }
            }
        }

        #endregion
    }
}