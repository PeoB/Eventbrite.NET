﻿namespace EventbriteNET.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represent errors that occur while calling a Eventbrite API.
    /// </summary>
    [Serializable]
    public class EventbriteApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventbriteApiException"/> class.
        /// </summary>
        public EventbriteApiException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventbriteApiException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public EventbriteApiException(string message)
            : base(message)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="EventbriteApiException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public EventbriteApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventbriteApiException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected EventbriteApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}