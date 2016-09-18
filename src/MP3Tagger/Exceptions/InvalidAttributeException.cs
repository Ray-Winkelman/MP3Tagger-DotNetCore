using System;
using Resources;

namespace Exceptions
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