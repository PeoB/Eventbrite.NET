namespace EventbriteNET.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class EventbriteInputValidationParameterException : EventbriteApiException
    {
        public EventbriteInputValidationParameterException()
        {
        }

        
        public EventbriteInputValidationParameterException(string message)
            : base(message)
        {
        }

        public EventbriteInputValidationParameterException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        protected EventbriteInputValidationParameterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}