using System;
using MP3Tagger.Resources;

namespace MP3Tagger.Exceptions
{
	public class InvalidActionException : Exception
	{
		public InvalidActionException()
			: base(Strings.InvalidAction)
		{
		}

		public InvalidActionException(string message)
		: base(message)
		{
		}

		public InvalidActionException(string message, Exception inner)
		: base(message, inner)
		{
		}
	}
}