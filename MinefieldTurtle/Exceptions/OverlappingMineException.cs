using System;

namespace MinefieldTurtle.Exceptions
{
	public class OverlappingMineException : Exception
	{
		public OverlappingMineException(string message) : base(message) {  }
	}
}
