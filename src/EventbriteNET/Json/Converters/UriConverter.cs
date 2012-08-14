namespace EventbriteNET.Json.Converters
{
    using System;
    using Newtonsoft.Json;

    public class UriConverter : JsonConverter
    {
        private bool _isObject;

        public override bool CanConvert(Type objectType)
        {
            _isObject = objectType == typeof (object);
            return typeof (Uri).IsAssignableFrom(objectType) || _isObject;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                                        JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                //try to create uri out of the string
                Uri uri;
                if (Uri.TryCreate(reader.Value.ToString(), UriKind.Absolute, out uri))
                {
                    return uri;
                }
                //just a string -> return string value
                return _isObject ? reader.Value : null;
            }

            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            throw new InvalidOperationException("Unable to process JSON");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (null == value)
            {
                writer.WriteNull();
                return;
            }

            var uri = value as Uri;
            if (uri != null)
            {
                writer.WriteValue(uri.OriginalString);
                return;
            }

            throw new InvalidOperationException("Unable to process JSON");
        }
    }
}