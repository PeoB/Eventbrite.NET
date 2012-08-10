namespace EventbriteNET.HttpApi
{
    using System.Collections.Generic;

    public class EventbriteOptions
    {
        public List<string> Fields { get; set; }

        public List<string> Expand { get; set; }

        public bool Pretty { get; set; }
    }
}