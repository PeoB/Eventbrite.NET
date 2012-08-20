namespace EventbriteNET.HttpApi.RequestParameters
{
    using System.Collections.Generic;
    using Utils;

    public class GetEventFilter : FilterBase
    {
        private List<GetEventDisplayFields> _eventDisplayFields = new List<GetEventDisplayFields>();

        public GetEventFilter()
        {
            InitMap();
        }

        public GetEventFilter(IEnumerable<KeyValuePair<string, object>> sourceDict) : base(sourceDict)
        {
            InitMap();
        }

        public long Id { get; set; }
        public List<GetEventDisplayFields> EventDisplayFields
        {
            get { return _eventDisplayFields; }
            set
            {
                if (value != null)
                {
                    _eventDisplayFields = value;
                }
            }
        }

        private void InitMap()
        {
            Map.Add("id", GetPair(() => Id,
                                  value => Id = long.Parse(value.ToString())));
            Map.Add("display", GetPair(() => string.Join(",", EventDisplayFields),
                                       value =>
                                       EventDisplayFields = EnumUtil.ParseList<GetEventDisplayFields>(value.ToString())));
        }
    }

    public enum GetEventDisplayFields
    {
        custom_header,
        custom_footer,
        confirmation_page,
        confirmation_email,
    }
}