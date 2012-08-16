#region (c)2009-2010 Lokad - New BSD license

// Copyright (c) Lokad 2009-2010 
// Company: http://www.lokad.com
// This code is released under the terms of the new BSD licence

#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace Lokad
{
	/// <summary>
	/// Strongly-typed enumeration util
	/// </summary>
	/// <typeparam name="TEnum">The type of the enum.</typeparam>
	public static class EnumUtil<TEnum> where TEnum : struct, IComparable
	{
		/// <summary>
		/// Values of the <typeparamref name="TEnum"/>
		/// </summary>
		public static readonly TEnum[] Values;

		/// <summary>
		/// Values of the <typeparamref name="TEnum"/> without the default value.
		/// </summary>
		public static readonly TEnum[] ValuesWithoutDefault;

		// enum parsing performance is horrible!
		internal static readonly IDictionary<string, TEnum> CaseDict;
		internal static readonly IDictionary<string, TEnum> IgnoreCaseDict;
        
		static EnumUtil()
		{
			Values = GetValues();
			var def = default(TEnum);
			ValuesWithoutDefault = Values.Where(x => !def.Equals(x)).ToArray();

			IgnoreCaseDict = new Dictionary<string, TEnum>(StringComparer.InvariantCultureIgnoreCase);
			CaseDict = new Dictionary<string, TEnum>(StringComparer.InvariantCulture);

			foreach (var value in Values)
			{
				var item = value.ToString();
				IgnoreCaseDict[item] = value;
				CaseDict[item] = value;
			}
		}
        
		static TEnum[] GetValues()
		{
			Type enumType = typeof (TEnum);

			if (!enumType.IsEnum)
			{
				throw new ArgumentException("Type is not an enum: '" + enumType.Name);
			}

#if !SILVERLIGHT2

			return Enum
				.GetValues(enumType)
				.Cast<TEnum>()
				.ToArray();
#else
			return enumType
				.GetFields()
				.Where(field => field.IsLiteral)
				.ToArray(f => (TEnum) f.GetValue(enumType));
#endif
		}
	}
}