namespace EventbriteNET.HttpApi.RequestParameters.Types
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class PredefinedBase
    {
        protected readonly string Value;
        protected readonly string UpperCaseValue;

        internal PredefinedBase()
        {
        }

        protected PredefinedBase(string value)
        {
            Value = value;
            UpperCaseValue = value.ToUpperInvariant();
        }

        public override string ToString()
        {
            return Value;
        }
    }

    public abstract class PredefinedBase<T> : PredefinedBase where T : PredefinedBase<T>
    {
        internal PredefinedBase()
        {
        }

        protected PredefinedBase(string value) : base(value)
        {
        }

        public abstract IEnumerable<T> GetValues();

        public abstract T Create(string value);

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