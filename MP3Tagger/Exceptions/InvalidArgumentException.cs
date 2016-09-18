using System;
using MP3Tagger.Resources;

namespace MP3Tagger.Exceptions
{
	public class InvalidArgumentException : Exception
	{
		public InvalidArgumentException(string arg)
			: base(string.Format(Strings.InvalidArgument, arg))
		{
		}

		public InvalidArgumentException(string message, Exception inner)
		: base(message, inner)
		{
		}
	}
}