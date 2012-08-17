namespace EventbriteNET.HttpApi.RequestParameters
{
    using System;
    using System.Globalization;

    public class RangeDate
    {
        protected readonly DateTime StartDate;
        protected readonly DateTime EndDate;

        protected readonly RangeDatePredefined Predefined;

        public RangeDate(RangeDatePredefined predefined)
        {
            Predefined = predefined;
        }

        public RangeDate(DateTime startDate, DateTime endDate)
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

        public static RangeDate Parse(string s)
        {
            RangeDatePredefined rangeDatePredefined;
            if(RangeDatePredefined.TryParse(s, out rangeDatePredefined))
            {
                return new RangeDate(rangeDatePredefined);
            }

            var parts = s.Split(' ');

            var startDate = DateTime.ParseExact(parts[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(parts[1], "yyyy-MM-dd", CultureInfo.InvariantCulture);

            return new RangeDate(startDate, endDate);
        }

        protected bool Equals(RangeDate other)
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
            return Equals((RangeDate) obj);
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
}