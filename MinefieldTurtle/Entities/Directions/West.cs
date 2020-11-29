using MinefieldTurtle.Entities;

namespace MinefieldTurtle.Directions.Entities.Directions
{
	public class West : Direction
	{
		public override Point MoveForward(Point point) => new Point(point.X - 1, point.Y);
		public override Direction RotateRight() => new North();
	}
}
