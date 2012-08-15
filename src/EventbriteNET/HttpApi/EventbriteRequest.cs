namespace EventbriteNET.HttpApi
{
    using RequestParameters;
    using RestSharp;

    public class EventbriteRequest
    {
        private readonly EventbriteOptions _options;

        public EventbriteRequest(EventbriteOptions options)
        {
            _options = options;
        }

        public IRestRequest Get(string resource, FilterBase filters = null)
        {
            var request = CreateRequest(resource, filters);
            request.Method = Method.GET;

            return request;
        }

        public IRestRequest Post(string resource, FilterBase filters = null)
        {
            var request = CreateRequest(resource, filters);
            request.Method = Method.POST;

            return request;
        }

        public IRestRequest Delete(string resource, FilterBase filters = null)
        {
            var request = CreateRequest(resource, filters);
            request.Method = Method.DELETE;

            return request;
        }

        public IRestRequest Put(string resource, FilterBase filters = null)
        {
            var request = CreateRequest(resource, filters);
            request.Method = Method.PUT;

            return request;
        }

        private IRestRequest CreateRequest(string resource, FilterBase filters)
        {
            var request = new RestRequest();
            if (filters != null)
            {
                filters.Validate();

                foreach (var param in filters.ToDictionary())
                {
                    request.AddParameter(param.Key, param.Value);
                }
            }

            request.DateFormat = _options.DateFormat ?? "yyyy-MM-dd HH:mm:ss";
            request.Resource = resource;
            request.RootElement = _options.RootElement ?? string.Empty;
            request.RequestFormat = DataFormat.Json;

            return request;
        }
    }
}