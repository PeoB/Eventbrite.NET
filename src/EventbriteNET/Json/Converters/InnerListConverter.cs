namespace EventbriteNET.Json.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    public class InnerListConverter<TOuter, T> : JsonConverter where TOuter : IOuterConverter<TOuter, T>, new()
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                                        JsonSerializer serializer)
        {
            var converter = new TOuter();
            var list = serializer.Deserialize<List<TOuter>>(reader);
            return list.Select(converter.Convert).ToList();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof (List<T>).IsAssignableFrom(objectType);
        }
    }
}