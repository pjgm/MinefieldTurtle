using CommandLine;
using MinefieldTurtle.Configuration;
using MinefieldTurtle.Engine;
using MinefieldTurtle.Exceptions;
using MinefieldTurtle.Interfaces;
using MinefieldTurtle.Parsing;
using MinefieldTurtle.UI;
using System;
using System.Collections.Generic;
using System.IO;

namespace MinefieldTurtle
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Parser.Default.ParseArguments<Options>(args)
				.WithParsed(options =>
				{
					var commandLine = new CommandLineUI();
					try {
						var settings = FileParser.Parse<Settings>(options.Settings);
						var moves = FileParser.Parse<List<string>>(options.Moves);
						StartEngine(settings, moves, commandLine);
					}
					catch (Exception ex) when (ex is FileNotFoundException || ex is InvalidConfigurationException)
					{
						commandLine.ShowErrorMessage($"Error: {ex.Message}");
					}
				});
		}

		public static void StartEngine(Settings settings, List<string> sequences, IGameUI ui)
		{
			var engine = new GameEngine(settings);

			for (var i = 0; i < sequences.Count; i++)
			{
				var result = engine.Run(sequences[i]);
				ui.ShowMessage(result, $"Sequence {i + 1}: ");

				engine.ResetGame();
			}
		}
	}
}
