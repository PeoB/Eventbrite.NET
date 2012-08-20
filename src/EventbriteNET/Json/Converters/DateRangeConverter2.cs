namespace EventbriteNET.Json.Converters
{
    using HttpApi.RequestParameters.Types;

    public class DateRangeConverter2 : SimpleConverter<DateRange>
    {
        public override DateRange Parse(string value)
        {
            return DateRange<DateRangePredefined2>.Parse(value);
        }
    }
}