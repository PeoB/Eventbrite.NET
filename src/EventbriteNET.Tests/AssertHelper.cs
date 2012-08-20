namespace EventbriteNET.Tests
{
    using HttpApi.RequestParameters;
    using HttpApi.RequestParameters.Types;
    using Model;
    using PowerAssert;

    internal static class AssertHelper
    {
        public static void AssertEventsSearchResultValid(EventsModel events)
        {
            PAssert.IsTrue(() => events != null);
            PAssert.IsTrue(() => events.Events != null && events.Events.Count > 0);
            PAssert.IsTrue(() => events.Summary != null);
            PAssert.IsTrue(() => events.Summary.TotalItems > 0);
        }
        
        public static void AssertEventsSearchResultFilteredByDateValid(EventsModel events, DateRange created)
        {
            PAssert.IsTrue(() => events.Summary.Filter != null);
            PAssert.IsTrue(() => events.Summary.Filter.Created != null);
            PAssert.IsTrue(() => events.Summary.Filter.Created.Equals(created));
        }
    }
}