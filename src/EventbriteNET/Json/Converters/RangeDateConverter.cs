namespace EventbriteNET.Json.Converters
{
    using System;
    using HttpApi.RequestParameters;
    using Newtonsoft.Json;

    public class RangeDateConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(RangeDate);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                                        JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                return RangeDate.Parse(reader.Value.ToString());
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

            var uri = value as RangeDate;
            if (uri != null)
            {
                writer.WriteValue(uri.ToString());
                return;
            }

            throw new InvalidOperationException("Unable to process JSON");
        }
    }
}