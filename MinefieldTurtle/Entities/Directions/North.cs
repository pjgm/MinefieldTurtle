using MinefieldTurtle.Entities;

namespace MinefieldTurtle.Directions.Entities.Directions
{
	public class North : Direction
	{
		public override Point MoveForward(Point point) => new Point(point.X, point.Y - 1);
		public override Direction RotateRight() => new East();
	}
}
