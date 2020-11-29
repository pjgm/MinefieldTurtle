using MinefieldTurtle.Configuration;
using MinefieldTurtle.Constants;
using MinefieldTurtle.Entities;
using MinefieldTurtle.Exceptions;

namespace MinefieldTurtle.Engine
{
	public class GameEngine
	{
		private readonly Settings _settings;
		private readonly Turtle _turtle;
		
		private bool GameOver = false;

		public GameEngine(Settings settings)
		{
			_settings = settings;
			var (width, height, turtleDirection, turtlePosition, exit, mines) = _settings;

			var mineField = new MineField(width, height, mines, exit);
			_turtle = new Turtle(turtlePosition, turtleDirection, mineField);			
		}

		public void RotateTurtle() => _turtle.RotateRight();
		public void MoveTurtleForward() => _turtle.MoveForward();

		public GameResult Run(string sequence)
		{
			if (GameOver)
			{
				return new GameResult(GameMessages.GameOver, false);
			}

			var result = ExecuteActionSequence(sequence);

			GameOver = true;

			return result;
		}

		public void ResetGame()
		{
			var (initialDirection, initialPosition) = _settings;

			_turtle.Direction = initialDirection;
			_turtle.Position = initialPosition;

			GameOver = false;
		}

		private GameResult ExecuteActionSequence(string sequence)
		{
			var actions = SequenceParser.Parse(this, sequence);

			foreach (var turtleAction in actions)
			{
				try
				{
					turtleAction();
				}
				catch (TurtleOutOfBoundsException)
				{
					return new GameResult(GameMessages.OutOfBounds, false);
				}

				if (_turtle.LandedOnMine())
				{
					return new GameResult(GameMessages.MineHit, false);
				}
			}

			if (_turtle.CanExit())
			{
				return new GameResult(GameMessages.Success, true);
			}

			return new GameResult(GameMessages.ExitNotReached, false);
		}
	}
}
