using System;

namespace ApplicationCore.Exceptions
{
	class InvalidInputValueException : Exception
	{
		public InvalidInputValueException(string message) : base(message)
		{
		}
	}
}
