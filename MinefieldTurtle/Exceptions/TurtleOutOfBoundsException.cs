using System;

namespace MinefieldTurtle.Exceptions
{
	public class TurtleOutOfBoundsException : Exception
	{
		public TurtleOutOfBoundsException(string message) : base(message) { }
	}
}
