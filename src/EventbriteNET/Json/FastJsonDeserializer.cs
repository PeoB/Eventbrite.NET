using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventbriteNET.Json
{
    using System.Collections;
    using System.Globalization;
    using RestSharp;
    using RestSharp.Deserializers;
    using fastJSON;

    public class FastJsonDeserializer : IDeserializer
    {
        public string RootElement { get; set; }

        public string Namespace { get; set; }

        public string DateFormat { get; set; }

        public T Deserialize<T>(IRestResponse response)
        {
            var json = JSON.Instance;
            return json.ToObject<T>(response.Content);
        }
    }
}
