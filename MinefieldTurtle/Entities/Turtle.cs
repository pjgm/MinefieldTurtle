using MinefieldTurtle.Directions.Entities.Directions;
using MinefieldTurtle.Exceptions;

namespace MinefieldTurtle.Entities
{
	public class Turtle
	{
		private readonly MineField _mineField;
		public Point Position { get; set; }
		public Direction Direction { get; set; }
		
		public Turtle(Point position, Direction direction, MineField mineField)
		{
			_mineField = mineField;
			_mineField.ValidatePoint(position);

			Position = position;
			Direction = direction;
		}

		public Direction RotateRight()
		{
			Direction = Direction.RotateRight();
			return Direction;
		}

		public Point MoveForward()
		{
			var newPosition = Direction.MoveForward(Position);

			if (!_mineField.IsInBounds(newPosition))
			{
				throw new TurtleOutOfBoundsException(Position.ToString());
			}

			Position = newPosition;
			return Position;
		}

		public bool LandedOnMine()
		{
			return _mineField.IsMine(Position);
		}

		public bool CanExit()
		{
			return _mineField.IsExit(Position);
		}

	}
}
