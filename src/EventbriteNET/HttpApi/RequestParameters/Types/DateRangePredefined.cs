namespace EventbriteNET.HttpApi.RequestParameters.Types
{
    using System.Collections.Generic;

    public sealed class DateRangePredefined : PredefinedBase<DateRangePredefined>
    {
        internal DateRangePredefined()
        {
        }

        private DateRangePredefined(string value)
            : base(value)
        {
        }

        public static readonly DateRangePredefined Today = new DateRangePredefined("Today");
        public static readonly DateRangePredefined Yesterday = new DateRangePredefined("Yesterday");
        public static readonly DateRangePredefined LastWeek = new DateRangePredefined("Last Week");
        public static readonly DateRangePredefined ThisWeek = new DateRangePredefined("This Week");
        public static readonly DateRangePredefined ThisMonth = new DateRangePredefined("This Month");

        public override IEnumerable<DateRangePredefined> GetValues()
        {
            yield return Today;
            yield return Yesterday;
            yield return LastWeek;
            yield return ThisWeek;
            yield return ThisMonth;
        }

        public override DateRangePredefined Create(string value)
        {
            return new DateRangePredefined(value);
        }

        public static bool TryParse(string s, out DateRangePredefined value)
        {
            return Today.TryParseImpl(s, out value);
        }
    }
}