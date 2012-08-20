namespace EventbriteNET.Json.Converters
{
    using System;
    using Newtonsoft.Json;

    public abstract class SimpleConverter<T> : JsonConverter where T : class
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (T);
        }

        public abstract T Parse(string value);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                                        JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                return Parse(reader.Value.ToString());
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

            var dateRange = value as T;
            if (dateRange != null)
            {
                writer.WriteValue(dateRange.ToString());
                return;
            }

            throw new InvalidOperationException("Unable to process JSON");
        }
    }
}