namespace EventbriteNET.Tests
{
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
    }
}