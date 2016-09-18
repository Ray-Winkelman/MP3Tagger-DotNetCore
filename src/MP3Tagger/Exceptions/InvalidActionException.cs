using System;

namespace Exceptions
{
	public class InvalidActionException : Exception
	{
		public InvalidActionException()
		: base("None, or an invalid action was provided.")
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