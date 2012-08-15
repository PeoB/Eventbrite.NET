namespace EventbriteNET.Json
{
    using System;
    using Newtonsoft.Json.Converters;

    internal class ConstructorCreationConverter<TInterface, T> : CustomCreationConverter<TInterface>
        where T : TInterface, new()
    {
        public override TInterface Create(Type objectType)
        {
            return new T();
        }
    }
}