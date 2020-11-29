using System.Collections.Generic;
using System.Linq;

namespace MinefieldTurtle.Entities
{
	public class GameResult
	{
		public GameResult(string message, bool gameWon)
		{
			Message = message;
			GameWon = gameWon;
		}

		public string Message { get; private set; }
		public bool GameWon { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (GameResult)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        protected IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Message;
            yield return GameWon;
        }
    }
}
