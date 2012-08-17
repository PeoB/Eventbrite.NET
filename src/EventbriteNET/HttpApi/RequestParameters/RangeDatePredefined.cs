namespace EventbriteNET.HttpApi.RequestParameters
{
    using System.Collections.Generic;

    public sealed class RangeDatePredefined : PredefinedBase<RangeDatePredefined>
    {
        public RangeDatePredefined(string value)
            : base(value)
        {
        }

        public static readonly RangeDatePredefined Today = new RangeDatePredefined("Today");
        public static readonly RangeDatePredefined Yesterday = new RangeDatePredefined("Yesterday");
        public static readonly RangeDatePredefined LastWeek = new RangeDatePredefined("Last Week");
        public static readonly RangeDatePredefined ThisWeek = new RangeDatePredefined("This Week");
        public static readonly RangeDatePredefined ThisMonth = new RangeDatePredefined("This Month");

        public override IEnumerable<RangeDatePredefined> GetValues()
        {
            yield return Today;
            yield return Yesterday;
            yield return LastWeek;
            yield return ThisWeek;
            yield return ThisMonth;
        }

        public override RangeDatePredefined Create(string value)
        {
            return new RangeDatePredefined(value);
        }

        public static bool TryParse(string s, out RangeDatePredefined value)
        {
            return Today.TryParseImpl(s, out value);
        }
    }
}