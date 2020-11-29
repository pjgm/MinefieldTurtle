namespace MinefieldTurtle.Entities
{
	public class Point
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Point() { } // Needed for deserialization
		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public override bool Equals(object obj)
		{
			if ((obj == null) || !GetType().Equals(obj.GetType()))
			{
				return false;
			}
			else
			{
				Point point = (Point)obj;
				return (X == point.X) && (Y == point.Y);
			}
		}

		public override int GetHashCode()
		{
			return X ^ Y;
		}

		public override string ToString() => $"X: {X}; Y: {Y}";
	}
}
