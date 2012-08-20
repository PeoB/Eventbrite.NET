#region (c)2009 Lokad - New BSD license

// Copyright (c) Lokad 2009 
// Company: http://www.lokad.com
// This code is released under the terms of the new BSD licence

#endregion

namespace EventbriteNET.Utils
{
    using System;
    using System.Collections.Generic;

    /// <summary>
	/// Enum helper class from xLim
	/// </summary>
	public static class EnumUtil
	{
		/// <summary>
		/// Parses the specified string into the <typeparamref name="TEnum"/>, ignoring the case
		/// </summary>
		/// <typeparam name="TEnum">The type of the enum.</typeparam>
		/// <param name="value">The value.</param>
		/// <returns>Parsed enum</returns>
		/// <exception cref="ArgumentNullException">If <paramref name="value"/> is null</exception>
		public static TEnum Parse<TEnum>( string value) where TEnum : struct, IComparable
		{
			if (value == null) throw new ArgumentNullException("value");
			return Parse<TEnum>(value, true);
		}

		/// <summary>
		/// Parses the specified string into the <typeparamref name="TEnum"/>, ignoring the case
		/// </summary>
		/// <typeparam name="TEnum">The type of the enum.</typeparam>
		/// <param name="value">The value.</param>
		/// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
		/// <returns>Parsed enum</returns>
		/// <exception cref="ArgumentNullException">If <paramref name="value"/> is null</exception>
		public static TEnum Parse<TEnum>( string value, bool ignoreCase) where TEnum : struct, IComparable
		{
			if (value == null) throw new ArgumentNullException("value");

			var dict = ignoreCase ? EnumUtil<TEnum>.IgnoreCaseDict : EnumUtil<TEnum>.CaseDict;

			TEnum @enum;
			if (!dict.TryGetValue(value, out @enum))
			{
				throw new ArgumentException(string.Format("Can't find enum for '{0}'", value));
			}
			return @enum;
		}

        public static List<TEnum> ParseList<TEnum>(string value, bool ignoreCase = true, string separator = ",") where TEnum : struct, IComparable
        {
            if (value == null) throw new ArgumentNullException("value");

            var stringEnums = value.Split(new [] {separator}, StringSplitOptions.RemoveEmptyEntries);
            var enums = new List<TEnum>(stringEnums.Length);

            foreach (var @enum in stringEnums)
            {
                enums.Add(Parse<TEnum>(@enum, ignoreCase));
            }
            return enums;
        }
	}
}