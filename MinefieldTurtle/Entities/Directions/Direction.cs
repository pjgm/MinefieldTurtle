using MinefieldTurtle.Entities;

namespace MinefieldTurtle.Directions.Entities.Directions
{
	public abstract class Direction
	{
		public abstract Point MoveForward(Point point);
		public abstract Direction RotateRight();
	}
}
 