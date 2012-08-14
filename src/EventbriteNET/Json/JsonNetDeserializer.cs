namespace EventbriteNET.Json
{
    using Newtonsoft.Json;
    using RestSharp;
    using RestSharp.Deserializers;

    public class JsonNetDeserializer : IDeserializer
    {
        #region IDeserializer Members

        public string RootElement { get; set; }

        public string Namespace { get; set; }

        public string DateFormat { get; set; }

        public T Deserialize<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        #endregion
    }
}