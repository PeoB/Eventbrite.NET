namespace EventbriteNET.Utils
{
    using RestSharp;

    /// <summary>
    /// The OAuth 2 Eventbrite authenticator. 
    /// http://developer.eventbrite.com/doc/authentication/
    /// </summary>
    public class OAuth2EventbriteAuthenticator : IAuthenticator
    {
        private readonly string _accessToken;
        private readonly string _appKey;

        public OAuth2EventbriteAuthenticator(string appKey, string accessToken) : this(appKey)
        {
            _accessToken = accessToken;
        }

        public OAuth2EventbriteAuthenticator(string appKey)
        {
            Guard.NullOrEmpty("appKey", appKey);
            _appKey = appKey;
        }

        public string AppKey
        {
            get { return _appKey; }
        }

        public string AccessToken
        {
            get { return _accessToken; }
        }

        #region IAuthenticator Members

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            if (!string.IsNullOrEmpty(AccessToken))
            {
                request.AddHeader("Authorization", string.Format("Bearer {0}", AccessToken));
            }

            request.AddParameter("app_key", AppKey);
        }

        #endregion
    }
}