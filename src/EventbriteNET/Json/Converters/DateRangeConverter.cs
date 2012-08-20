namespace EventbriteNET.Json.Converters
{
    using HttpApi.RequestParameters.Types;

    public class DateRangeConverter : SimpleConverter<DateRange>
    {
        public override DateRange Parse(string value)
        {
            return DateRange<DateRangePredefined>.Parse(value);
        }
    }
}