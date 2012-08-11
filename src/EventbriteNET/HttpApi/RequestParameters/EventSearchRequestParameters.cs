namespace EventbriteNET.HttpApi.RequestParameters
{
    using System.Collections.Generic;
    using Exceptions;
    using Resources;

    public class EventSearchRequestParameters : RequestParametersBase
    {
        public EventSearchRequestParameters()
        {
            InitMap();
        }

        public EventSearchRequestParameters(IEnumerable<KeyValuePair<string, object>> sourceDict) : base(sourceDict)
        {
            InitMap();
        }


        public string Keywords { get; set; }
        public string Organizer { get; set; }
        public long? Max { get; set; }
        public long? Page { get; set; }
        public string SortBy { get; set; }
        public string TrackingLink { get; set; }

        private void InitMap()
        {
            Map.Add("keywords", GetPair(() => Keywords,
                                        value => Keywords = value.ToString()));

            Map.Add("organizer", GetPair(() => Organizer,
                                         value => Organizer = value.ToString()));
            Map.Add("max", GetPair(() => Max,
                                   value => Max = (long) value));
            Map.Add("page", GetPair(() => Page,
                                    value => Page = (long) value));
            Map.Add("sort_by", GetPair(() => SortBy,
                                       value => SortBy = value.ToString()));
            Map.Add("tracking_link", GetPair(() => TrackingLink,
                                             value => TrackingLink = value.ToString()));
        }

        public override void Validate()
        {
            base.Validate();
            if (Max > 100 || Max <= 0)
            {
                throw new EventbriteInputValidationParameterException(string.Format(SR.event_search_max_validation, Max));
            }
        }
    }
}