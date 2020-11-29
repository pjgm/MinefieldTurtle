using System.IO;
using System.Text.Json;

namespace MinefieldTurtle.Parsing
{
	public static class FileParser
	{
		public static T Parse<T>(string filename)
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), filename);
			var fileString = File.ReadAllText(filePath);
			return JsonSerializer.Deserialize<T>(fileString);
		}
	}
}
