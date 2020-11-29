using MinefieldTurtle.Directions.Entities.Directions;
using MinefieldTurtle.Entities;
using System;
using System.Collections.Generic;

namespace MinefieldTurtle.Configuration
{
	public class Settings
	{
		public int MinefieldWidth { get; set; }
		public int MinefieldHeight { get; set; }
		public string TurtleDirection { get; set; }
		public Point TurtlePosition { get; set; }
		public Point Exit { get; set; }
		public IList<Point> Mines { get; set; }

		public static Direction GetTurtleDirection(string direction) =>
			direction switch
			{
				"N" => new North(),
				"E" => new East(),
				"W" => new West(),
				"S" => new South(),
				_ => throw new NotImplementedException(),
			};

		#region Deconstructors
		public void Deconstruct(
			out int width,
			out int height,
			out Direction turtleDirection,
			out Point turtlePosition,
			out Point exit,
			out IList<Point> mines)
		{
			width = MinefieldWidth;
			height = MinefieldHeight;
			turtleDirection = GetTurtleDirection(TurtleDirection);
			turtlePosition = TurtlePosition;
			exit = Exit;
			mines = Mines;
		}

		public void Deconstruct(
			out Direction turtleDirection,
			out Point turtlePosition)
		{
			turtleDirection = GetTurtleDirection(TurtleDirection);
			turtlePosition = TurtlePosition;
		}

		#endregion
	}
}
