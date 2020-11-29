using MinefieldTurtle.Enums;
using MinefieldTurtle.Exceptions;
using System.Collections.Generic;

namespace MinefieldTurtle.Entities
{
	public class MineField
	{
		private readonly FieldType[,] _grid;

		public MineField(int width, int height, IList<Point> mines, Point exit)
		{
			ValidateDimensions(width, height);

			_grid = new FieldType[width, height];
			var set = new HashSet<Point>();

			foreach (var mine in mines)
			{
				ValidatePoint(mine);

				if (!set.Add(mine))
				{
					throw new OverlappingMineException(mine.ToString());
				}

				SetMine(mine);
			}

			ValidatePoint(exit);
			SetExit(exit);
		}

		public bool IsMine(Point position) =>
			_grid[position.X, position.Y] == FieldType.Mine;

		public bool IsExit(Point position) =>
			_grid[position.X, position.Y] == FieldType.Exit;

		public bool IsInBounds(Point point) =>
			point.X >= 0 &&
			point.Y >= 0 &&
			point.X < _grid.GetLength(0) &&
			point.Y < _grid.GetLength(1);

		private void SetMine(Point mine) =>
			_grid[mine.X, mine.Y] = FieldType.Mine;

		private void SetExit(Point exit) =>
			_grid[exit.X, exit.Y] = FieldType.Exit;

		private void ValidateDimensions(int width, int height)
		{
			var validDimensions = 
				width > 0 && 
				height > 0 && 
				(long)width * height > 1;

			if (!validDimensions)
			{
				throw new InvalidConfigurationException($"{width}x{height} are not valid dimensions for the minefield");
			}
		}

		public void ValidatePoint(Point point)
		{
			if (!IsInBounds(point))
			{
				throw new InvalidConfigurationException($"Point {point} is out of bounds");
			}
			if (_grid[point.X, point.Y] != FieldType.Empty)
			{
				throw new InvalidConfigurationException($"There is already a {_grid[point.X, point.Y]} on {point}");
			}
		}
	}
}
