namespace EventbriteNET.HttpApi.RequestParameters
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class PredefinedBase<T> where T : PredefinedBase<T>
    {
        protected readonly string Value;
        protected readonly string UpperCaseValue;

        protected PredefinedBase(string value)
        {
            Value = value;
            UpperCaseValue = value.ToUpperInvariant();
        }

        public abstract IEnumerable<T> GetValues();

        public abstract T Create(string value);

        public override string ToString()
        {
            return Value;
        }

        public bool TryParseImpl(string s, out T value)
        {
            if (string.IsNullOrEmpty(s))
            {
                value = null;
                return false;
            }
            s = s.ToUpperInvariant();

            value = GetValues().FirstOrDefault(_ => _.UpperCaseValue == s);

            return value != null;
        }
    }
}