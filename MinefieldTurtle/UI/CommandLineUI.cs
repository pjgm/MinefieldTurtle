using MinefieldTurtle.Entities;
using MinefieldTurtle.Interfaces;
using System;

namespace MinefieldTurtle.UI
{
	public class CommandLineUI : IGameUI
	{
		public void ShowMessage(GameResult result, string prependText = "")
		{
			var message = $"{prependText}{result.Message}";

			if (result.GameWon)
			{
				ShowSuccessMessage(message);
			}
			else
			{
				ShowErrorMessage(message);
			}
		}

		public void ShowSuccessMessage(string message)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(message);
			Console.ResetColor();
		}

		public void ShowErrorMessage(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
}
