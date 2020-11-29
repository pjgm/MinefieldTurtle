using MinefieldTurtle.Entities;

namespace MinefieldTurtle.Interfaces
{
	public interface IGameUI
	{
		public void ShowMessage(GameResult result, string prepend = "");
		public void ShowSuccessMessage(string message);
		public void ShowErrorMessage(string message);
	}
}
