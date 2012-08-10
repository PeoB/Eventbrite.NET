namespace EventbriteNET.HttpApi
{
    using System.Collections.Generic;
    using RestSharp;

    public class EventbriteRequest
    {
        private readonly EventbriteOptions _options;

        public EventbriteRequest(EventbriteOptions options)
        {
            _options = options;
        }

        public IRestRequest Get(string resource, params Parameter[] parameters)
        {
            var request = CreateRequest(resource, parameters);
            request.Method = Method.GET;

            return request;
        }

        public IRestRequest Post(string resource, params Parameter[] parameters)
        {
            var request = CreateRequest(resource, parameters);
            request.Method = Method.POST;

            return request;
        }

        public IRestRequest Delete(string resource, params Parameter[] parameters)
        {
            var request = CreateRequest(resource, parameters);
            request.Method = Method.DELETE;

            return request;
        }

        public IRestRequest Put(string resource, params Parameter[] parameters)
        {
            var request = CreateRequest(resource, parameters);
            request.Method = Method.PUT;

            return request;
        }

        private IRestRequest CreateRequest(string resource, IEnumerable<Parameter> parameters)
        {
            var request = new RestRequest();
            if (parameters != null)
            {
                request.Parameters.AddRange(parameters);
            }

            request.DateFormat = "yyyy-MM-dd";
            request.Resource = resource;
            request.RequestFormat = DataFormat.Json;

            return request;
        }
    }
}