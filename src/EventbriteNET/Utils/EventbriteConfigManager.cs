namespace EventbriteNET.Utils
{
    using System.Configuration;

    public class EventbriteConfigManager
    {
        public EventbriteConfig GetConfig()
        {
            var appSettings = ConfigurationManager.AppSettings;
            return new EventbriteConfig
                {
                    ApiKey = appSettings["eventbrite.api_key"],
                };
        }
    }
}