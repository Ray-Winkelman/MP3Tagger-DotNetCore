using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions.Enumerations
{
	public static class EnumExtensions
	{
		public static IEnumerable<T> ToList<T>()
		{
			return Enum.GetValues(typeof(T)).Cast<T>();
		}

		public static string ToLowercaseString(this Enum value)
		{
			return value.ToString().ToLower();
		}
	}
}