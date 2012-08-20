namespace EventbriteNET.HttpApi.RequestParameters.Types
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class DateRange
    {
        protected readonly DateTime EndDate;

        protected readonly PredefinedBase Predefined;
        protected readonly DateTime StartDate;

        protected static readonly Dictionary<Type, Func<string, PredefinedBase>> Map = new Dictionary
            <Type, Func<string, PredefinedBase>>
            {
                {
                    typeof (DateRangePredefined),
                    s =>
                        {
                            DateRangePredefined dateRangePredefined;
                            return DateRangePredefined.TryParse(s, out dateRangePredefined)
                                       ? dateRangePredefined
                                       : null;
                        }
                },
                {
                    typeof (DateRangePredefined2),
                    s =>
                        {
                            DateRangePredefined2 dateRangePredefined;
                            return DateRangePredefined2.TryParse(s, out dateRangePredefined)
                                       ? dateRangePredefined
                                       : null;
                        }
                },
            };

        public DateRange(PredefinedBase predefined)
        {
            Predefined = predefined;
        }

        public DateRange(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public override string ToString()
        {
            return Predefined == null
                       ? string.Format(@"{0:yyyy-MM-dd} {1:yyyy-MM-dd}", StartDate, EndDate)
                       : Predefined.ToString();
        }


        protected bool Equals(DateRange other)
        {
            return StartDate.Equals(other.StartDate.Date) &&
                   EndDate.Equals(other.EndDate.Date) &&
                   Equals(Predefined, other.Predefined);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((DateRange) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = StartDate.Date.GetHashCode();
                hashCode = (hashCode*397) ^ EndDate.Date.GetHashCode();
                hashCode = (hashCode*397) ^ (Predefined != null ? Predefined.GetHashCode() : 0);
                return hashCode;
            }
        }
    }

    public class DateRange<T> : DateRange where T : PredefinedBase
    {
        public DateRange(T predefined) : base(predefined)
        {
        }

        public DateRange(DateTime startDate, DateTime endDate) : base(startDate, endDate)
        {
        }

        public static DateRange<T> Parse(string s)
        {
            var predefined = Map[typeof (T)](s);
            if (predefined != null)
            {
                return new DateRange<T>((T) predefined);
            }

            var parts = s.Split(' ');

            var startDate = DateTime.ParseExact(parts[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(parts[1], "yyyy-MM-dd", CultureInfo.InvariantCulture);

            return new DateRange<T>(startDate, endDate);
        }
    }
}