using System;

namespace MP3Tagger.Extensions.Strings
{
	public static class StringExtensions
	{
		public static bool ContainsInsensitive(this string source, string toCheck)
		{
			return source.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
		}

		public static bool EqualsInsensitive(this string source, string toCheck)
		{
			return source.ToLower() == toCheck.ToLower();
		}
	}
}