namespace EventbriteNET.Tests
{
    using System;
    using NAsana.API.Tests.Mocks;
    using Utils;

    public class EventbriteClientTests
    {
        public TClient GetAsanaClient<TClient>(string responseContent = null) where TClient : EventbriteClient
        {
            var asanaClient = responseContent == null
                                  ? Activator.CreateInstance(typeof (TClient),
                                                             new EventbriteClient(
                                                                 new EventbriteConfigManager().GetConfig()))
                                  : Activator.CreateInstance(typeof (TClient),
                                                             new EventbriteClient(new TestRestClient(responseContent)));
            return (TClient) asanaClient;
        }
    }
}