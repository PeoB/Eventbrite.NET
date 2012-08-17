namespace EventbriteNET.Utils
{
    using System;

    public static class FluentExtensions
    {
        public static TResult With<TInput, TResult>(this TInput o, Func<TInput, TResult> evaluator)
            where TResult : class
            where TInput : class
        {
            return o == null ? null : evaluator(o);
        }

        public static TResult? With<TInput, TResult>(this TInput o, Func<TInput, TResult?> evaluator)
            where TInput : class
            where TResult : struct
        {
            return o == null ? null : evaluator(o);
        }
    }
}