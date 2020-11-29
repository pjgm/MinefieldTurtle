using System;
using System.Collections.Generic;
using System.Linq;

namespace MinefieldTurtle.Engine
{
	public static class SequenceParser
	{
		public static IEnumerable<Action> Parse(GameEngine engine, string sequence)
		{
			return sequence.Select(action =>
				action switch
				{
					'm' => (Action)engine.MoveTurtleForward,
					'r' => (Action)engine.RotateTurtle,
					_ => throw new NotImplementedException()
				}
			);
		}
	}
}
