namespace EventbriteNET.Json.Converters
{
    using System;

    public interface IOuterConverter<in T, out TResult> where T : new()
    {
        Func<T, TResult> Convert { get; }
    }
}