using MinefieldTurtle.Configuration;
using MinefieldTurtle.Constants;
using MinefieldTurtle.Engine;
using MinefieldTurtle.Entities;
using MinefieldTurtle.Exceptions;
using System.Collections.Generic;
using Xunit;

namespace MinefieldTurtle.UnitTests.Engine
{
	public class GameEngineTests
	{
		private readonly Settings _gameSettings;
		public GameEngineTests()
		{
			_gameSettings = new Settings
			{
				MinefieldWidth = 10,
				MinefieldHeight = 5,
				TurtleDirection = "E",
				TurtlePosition = new Point(0, 0),
				Exit = new Point(9, 4),
				Mines = new List<Point>
				{
					new Point(1, 1),
					new Point(1, 2),
					new Point(2, 2)
				}
			};
		}


		[Fact]
		public void Run_EmptySequence_ReturnsExitNotReached()
		{
			// Arrange
			var gameEngine = new GameEngine(_gameSettings);
			var actionSequence = "";

			// Act
			var result = gameEngine.Run(actionSequence);

			// Assert
			Assert.False(result.GameWon);
			Assert.Equal(result.Message, GameMessages.ExitNotReached);
		}

		[Fact]
		public void Run_ValidSequence_ReturnsSuccess()
		{
			// Arrange
			var gameEngine = new GameEngine(_gameSettings);
			var actionSequence = "mmmmmmmmmrmmmm";

			// Act
			var result = gameEngine.Run(actionSequence);

			// Assert
			Assert.True(result.GameWon);
			Assert.Equal(result.Message, GameMessages.Success);
		}

		[Fact]
		public void Run_HitMineSequence_ReturnsHitMine()
		{
			// Arrange
			var gameEngine = new GameEngine(_gameSettings);
			var actionSequence = "mrrrrrmm";

			// Act
			var result = gameEngine.Run(actionSequence);

			// Assert
			Assert.False(result.GameWon);
			Assert.Equal(result.Message, GameMessages.MineHit);
		}

		[Fact]
		public void Run_OutOfBoundsSequence_ReturnsOutOfBounds()
		{
			// Arrange
			var gameEngine = new GameEngine(_gameSettings);
			var actionSequence = "rrmmm";

			// Act
			var result = gameEngine.Run(actionSequence);

			// Assert
			Assert.False(result.GameWon);
			Assert.Equal(result.Message, GameMessages.OutOfBounds);
		}
		[Fact]
		public void Run_OverlappingMine_ThrowsOverlappingMineException()
		{
			// Arrange
			_gameSettings.Mines.Add(new Point(3, 3));
			_gameSettings.Mines.Add(new Point(3, 3));

			// Act & Assert
			Assert.Throws<InvalidConfigurationException>(() => new GameEngine(_gameSettings));
		}

		[Fact]
		public void Run_GameOver_ReturnsGameOver()
		{
			// Arrange
			var gameEngine = new GameEngine(_gameSettings);
			var actionSequence = "rmrrm";

			// Act
			gameEngine.Run(actionSequence);
			var gameOverResult = gameEngine.Run(actionSequence);

			// Assert
			Assert.False(gameOverResult.GameWon);
			Assert.Equal(gameOverResult.Message, GameMessages.GameOver);
		}

		[Fact]
		public void RunResetGame_TwoSuccessSequences_ReturnsSuccess()
		{
			var gameEngine = new GameEngine(_gameSettings);
			var actionSequence = "mmmmmmmmmrmmmm";

			// Act
			var result = gameEngine.Run(actionSequence);
			gameEngine.ResetGame();
			var result2 = gameEngine.Run(actionSequence);

			// Assert
			Assert.True(result.GameWon);
			Assert.Equal(result2, result);
		}
	}
}
