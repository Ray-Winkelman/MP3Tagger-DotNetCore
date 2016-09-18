using System;
using MP3Tagger.Resources;

namespace MP3Tagger.Exceptions
{
	public class InvalidAttributeException : Exception
	{
		public InvalidAttributeException()
			: base(Strings.InvalidAttribute)
		{
		}

		public InvalidAttributeException(string message)
		: base(message)
		{
		}

		public InvalidAttributeException(string message, Exception inner)
		: base(message, inner)
		{
		}
	}
}