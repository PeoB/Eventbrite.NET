namespace EventbriteNET
{
    using HttpApi;
    using HttpApi.RequestParameters;
    using Model;

    public partial class EventbriteClient
    {
        public EveventEventbriteClient Event
        {
            get { return new EveventEventbriteClient(this); }
        }

        #region Nested type: EveventEventbriteClient

        public class EveventEventbriteClient : EventbriteClient
        {
            public EveventEventbriteClient(EventbriteClient client)
                : base(client.Client)
            {
            }

            public EventsModel EventSearch(EventSearchRequestParameters parameters)
            {
                var request = EventbriteRequest.Get("event_search", parameters);
                return ExecuteRequest<EventsModel>(request);
            }
            /*
            public User GetUser(UserId userId)
            {
                Guard.IsTrue("userId", () => userId.ToString().Length>0);

                var request = EventbriteRequest.Get(string.Format("users/{0}", userId));
                return ExecuteRequest<User>(request);
            }

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