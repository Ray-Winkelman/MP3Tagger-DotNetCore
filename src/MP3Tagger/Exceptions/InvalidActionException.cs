using System;
using Resources;

namespace Exceptions
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