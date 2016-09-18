using System;

namespace Exceptions
{
	public class InvalidAttributeException : Exception
	{
		public InvalidAttributeException()
		: base("None, or an invalid attribute was provided.")
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