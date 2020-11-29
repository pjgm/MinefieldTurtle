using MinefieldTurtle.Configuration;
using MinefieldTurtle.Directions.Entities.Directions;
using Xunit;

namespace MinefieldTurtle.UnitTests.Configuration
{
	public class SettingsTests
	{
		[Fact]
		public void GetTurtleDirection_North_ReturnNorth()
		{
			// Arrange
			var north = new North();

			// Act
			var result = Settings.GetTurtleDirection("N");

			// Assert
			Assert.Equal(result.GetType(), north.GetType());
		}

		[Fact]
		public void GetTurtleDirection_South_ReturnSouth()
		{
			// Arrange
			var south = new South();

			// Act
			var result = Settings.GetTurtleDirection("S");

			// Assert
			Assert.Equal(result.GetType(), south.GetType());
		}

		[Fact]
		public void GetTurtleDirection_West_ReturnWest()
		{
			// Arrange
			var west = new West();

			// Act
			var result = Settings.GetTurtleDirection("W");

			// Assert
			Assert.Equal(result.GetType(), west.GetType());
		}

		[Fact]
		public void GetTurtleDirection_East_ReturnEast()
		{
			// Arrange
			var east = new East();

			// Act
			var result = Settings.GetTurtleDirection("E");

			// Assert
			Assert.Equal(result.GetType(), east.GetType());
		}
	}
}
