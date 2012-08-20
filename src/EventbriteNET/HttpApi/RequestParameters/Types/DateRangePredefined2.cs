namespace EventbriteNET.HttpApi.RequestParameters.Types
{
    using System.Collections.Generic;

    public sealed class DateRangePredefined2 : PredefinedBase<DateRangePredefined2>
    {
        private DateRangePredefined2(string value)
            : base(value)
        {
        }
        public static readonly DateRangePredefined2 All = new DateRangePredefined2("All");
        public static readonly DateRangePredefined2 Future = new DateRangePredefined2("Future");
        public static readonly DateRangePredefined2 Past = new DateRangePredefined2("Past");
        public static readonly DateRangePredefined2 Today = new DateRangePredefined2("Today");
        public static readonly DateRangePredefined2 Yesterday = new DateRangePredefined2("Yesterday");
        public static readonly DateRangePredefined2 LastWeek = new DateRangePredefined2("Last Week");
        public static readonly DateRangePredefined2 ThisWeek = new DateRangePredefined2("This Week");
        public static readonly DateRangePredefined2 NextWeek = new DateRangePredefined2("Next Week");
        public static readonly DateRangePredefined2 ThisMonth = new DateRangePredefined2("This Month");
        public static readonly DateRangePredefined2 NextMonth = new DateRangePredefined2("Next Month");

        public static readonly DateRangePredefined2 January = new DateRangePredefined2("January");
        public static readonly DateRangePredefined2 February = new DateRangePredefined2("February");
        public static readonly DateRangePredefined2 March = new DateRangePredefined2("March");
        public static readonly DateRangePredefined2 April = new DateRangePredefined2("April");
        public static readonly DateRangePredefined2 May = new DateRangePredefined2("May");
        public static readonly DateRangePredefined2 June = new DateRangePredefined2("June");
        public static readonly DateRangePredefined2 July = new DateRangePredefined2("July");
        public static readonly DateRangePredefined2 August = new DateRangePredefined2("August");
        public static readonly DateRangePredefined2 September = new DateRangePredefined2("September");
        public static readonly DateRangePredefined2 October = new DateRangePredefined2("October");
        public static readonly DateRangePredefined2 November = new DateRangePredefined2("November");
        public static readonly DateRangePredefined2 December = new DateRangePredefined2("December");

        

        public override IEnumerable<DateRangePredefined2> GetValues()
        {
            yield return All;
            yield return Future;
            yield return Past;
            yield return Today;
            yield return Yesterday;
            yield return LastWeek;
            yield return ThisWeek;
            yield return NextWeek;
            yield return ThisMonth;
            yield return NextMonth;

            yield return January;
            yield return February;
            yield return March;
            yield return April;
            yield return May;
            yield return June;
            yield return July;
            yield return August;
            yield return September;
            yield return October;
            yield return November;
            yield return December;
        }

        public override DateRangePredefined2 Create(string value)
        {
            return new DateRangePredefined2(value);
        }

        public static bool TryParse(string s, out DateRangePredefined2 value)
        {
            return Today.TryParseImpl(s, out value);
        }
    }
}