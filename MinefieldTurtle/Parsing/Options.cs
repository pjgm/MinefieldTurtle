using CommandLine;

namespace MinefieldTurtle.Parsing
{
	public class Options
	{
		[Option("settings", Default = "game-settings.json", Required = false, HelpText = "A settings file must be provided")]
		public string Settings { get; set; }

		[Option("moves", Default = "moves.json", Required = false, HelpText = "A moves file must be provided")]
		public string Moves { get; set; }
	}
}
