﻿using System;

namespace MinefieldTurtle.Exceptions
{
	public class InvalidConfigurationException : Exception
	{
		public InvalidConfigurationException(string message) : base(message) { }
	}
}
