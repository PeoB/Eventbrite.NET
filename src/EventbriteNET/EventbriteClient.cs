namespace EventbriteNET
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using Exceptions;
    using HttpApi;
    using Model;
    using RestSharp;
    using RestSharp.Deserializers;
    using RestSharp.Extensions;
    using Utils;

    public abstract partial class EventbriteClient
    {
        private const string BaseUrl = "https://www.eventbrite.com/json/";

        protected readonly IRestClient Client;

        protected EventbriteClient(EventbriteConfig config)
            : this(new RestClient(BaseUrl)
                {
                    Authenticator =
                        new OAuth2EventbriteAuthenticator(config.ApiKey),
                })
        {
        }

        protected internal EventbriteClient(IRestClient restClient)
        {
            Guard.NotNull("restClient", restClient);
            Client = restClient;
            ErrorHandler =
                (ex, actionName) =>
                    {
                        if (Debugger.IsAttached && Debugger.IsLogging())
                        {
                            Debugger.Log(1, Debugger.DefaultCategory,
                                         string.Format("Error occured in a {0} method with message: {1}", actionName,
                                                       ex.Message));
                        }
                    };
        }

        public Action<Exception, string> ErrorHandler { get; set; }

        protected EventbriteRequest EventbriteRequest
        {
            get { return new EventbriteRequest(RequestOptions); }
        }

        protected abstract EventbriteOptions RequestOptions { get; }

        protected TModel ExecuteRequest<TModel>(IRestRequest request,
                                                HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
            where TModel : new()
        {
            // validate request
            Guard.NotNull("request", request);

            // execute the request
            var responseRaw = Client.Execute(request);

            if (responseRaw.ResponseStatus == ResponseStatus.Error)
            {
                TryThrowErrorException(request, responseRaw);
                throw new EventbriteApiException(GetErrorMessage(responseRaw), responseRaw.ErrorException);
            }

            IRestResponse<TModel> typedResponse;
            bool isDeserialized = TryDeserialize(request, responseRaw, out typedResponse);

            //error convert to typed class
            if (!isDeserialized && typedResponse.ResponseStatus == ResponseStatus.Error)
            {
                if (typedResponse.ErrorException is InvalidCastException)
                {
                    TryThrowErrorException(request, typedResponse);
                }

                throw new EventbriteApiException(GetErrorMessage(typedResponse), typedResponse.ErrorException);
            }

            // make sure the exected status code is returned
            VerifyResponse(typedResponse, expectedStatusCode);

            // return the response
            return typedResponse.Data;
        }

        private void TryThrowErrorException(IRestRequest request, IRestResponse responseRaw)
        {
            var rootElement = request.RootElement;
            request.RootElement = "error";
            //try to deserialize into error response
            IRestResponse<Error> errorResponse;
            bool isDeserialized = TryDeserialize(request, responseRaw, out errorResponse);
            request.RootElement = rootElement;

            if (isDeserialized)
            {
                var errorModel = errorResponse.Data;
                throw new EventbriteApiException(GetErrorMessage(errorModel.ErrorType) + " " +
                                                 errorModel.ErrorMessage,
                                                 responseRaw.ErrorException);
            }
        }

        private static string GetErrorMessage(string response)
        {
            return /*errorMessage + " " + */ response;
        }

        private static string GetErrorMessage(IRestResponse response)
        {
            string errorMessage;
            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    errorMessage = "Invalid request.";
                    break;
                case HttpStatusCode.Unauthorized:
                    errorMessage = "No authorization.";
                    break;
                case HttpStatusCode.Forbidden:
                    errorMessage = "Access denied.";
                    break;
                case HttpStatusCode.NotFound:
                    errorMessage = "Not found.";
                    break;
                default:
                    errorMessage = "Server error.";
                    break;
            }

            return errorMessage + " " + response;
        }

        /// <summary>
        /// Verifies whether given <paramref name="response"/> is as expected.
        /// </summary>
        /// <param name="response">The <see cref="IRestResponse"/> which to verify.</param>
        /// <param name="expectedStatusCode">The exepected status code of the request, default is <seealso cref="HttpStatusCode.OK"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="response"/> is null.</exception>
        protected static void VerifyResponse(IRestResponse response,
                                             HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            // validate arguments
            Guard.NotNull("response", response);

            // check if the user was not authorized to make the request
            /*if (response.StatusCode == HttpStatusCode.Unauthorized && expectedStatusCode != HttpStatusCode.Unauthorized)
                throw new LinkedINUnauthorizedException();

            // check if the actuel status code is not the expected status code
            if (response.StatusCode != expectedStatusCode)
                throw new LinkedINHttpResponseException(expectedStatusCode, response.StatusCode, response.ErrorMessage, response.ErrorException);*/
        }

        private bool TryDeserialize<T>(IRestRequest request, IRestResponse raw, out IRestResponse<T> restResponse)
        {
            request.OnBeforeDeserialization(raw);
            IDeserializer handler = new JsonDeserializer();
            handler.RootElement = request.RootElement;
            handler.DateFormat = request.DateFormat;
            handler.Namespace = request.XmlNamespace;
            restResponse = new RestResponse<T>();
            try
            {
                restResponse = raw.toAsyncResponse<T>();
                restResponse.Data = handler.Deserialize<T>(raw);
            }
            catch (Exception ex)
            {
                restResponse.ResponseStatus = ResponseStatus.Error;
                restResponse.ErrorMessage = ex.Message;
                restResponse.ErrorException = ex;
                return false;
            }
            return true;
        }
    }

    public abstract class EventbriteClient<TClient> : EventbriteClient where TClient : EventbriteClient
    {
        protected EventbriteClient(EventbriteConfig config)
            : base(config)
        {
        }

        protected internal EventbriteClient(IRestClient restClient)
            : base(restClient)
        {
        }
    }
}