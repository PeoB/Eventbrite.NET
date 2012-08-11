namespace EventbriteNET.HttpApi.RequestParameters
{
    using System;
    using System.Collections.Generic;

    public abstract class RequestParametersBase
    {
        protected IDictionary<string, KeyValuePair<Func<object>, Action<object>>> Map = new Dictionary<string, KeyValuePair<Func<object>, Action<object>>>();

        protected RequestParametersBase()
        {
        }

        protected RequestParametersBase(IEnumerable<KeyValuePair<string, object>> sourceDict) : this()
        {
            //init object from dictionary
            foreach (var source in sourceDict)
            {
                //skip null or empty property names
                if (String.IsNullOrEmpty(source.Key))
                {
                    continue;
                }
                KeyValuePair<Func<object>, Action<object>> action;
                if(Map.TryGetValue(source.Key.ToLowerInvariant(), out action))
                {
                    action.Value(source.Value);
                }
            }
        }

        protected static KeyValuePair<Func<object>, Action<object>> GetPair(Func<object> getter, Action<object> setter)
        {
            return new KeyValuePair<Func<object>, Action<object>>(getter, setter);
        }

        /// <summary>
        /// Validate input parameter, throw exception in case of inconsistency
        /// </summary>
        public virtual void Validate()
        {
        }
        
        public virtual IEnumerable<KeyValuePair<string, object>> ToDictionary()
        {
            foreach (var pair in Map)
            {
                var value = pair.Value.Key();
                if (value == null)
                {
                    continue;
                }
                if (value is string && string.IsNullOrEmpty(value as string))
                {
                    continue;
                }
                yield return new KeyValuePair<string, object>(pair.Key, value);
            }
        }


    }
}