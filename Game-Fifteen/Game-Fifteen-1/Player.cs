namespace GameFifteenProject
{
    using System;
    using System.Linq;

    /// <summary>
    /// Contains player name and moves
    /// </summary>
    public class Player : IComparable
    {
        private readonly string name;
        private readonly int moves;

        public string Name
        {
            get { return this.name; }
        }

        public int Moves
        {
            get { return this.moves; }
        }

        /// <summary>
        /// Initializes a new instance  of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="name">Player name represented as a string</param>
        /// <param name="moves">Player number of moves represented as an integer</param>
        public Player(string name, int moves)
        {
            if (name == string.Empty || name == null)
            {
                throw new ArgumentException("Player name is required!");
            }

            if (moves < 0)
            {
                throw new ArgumentException("Player moves can't be negative number!");
            }

            this.name = name;
            this.moves = moves;
        }

        /// <summary>
        /// Compares two players by number of their moves
        /// </summary>
        /// <param name="player">Player object</param>
        /// <returns>The result of comparing the players</returns>
        public int CompareTo(object player)
        {
            Player otherPlayer = (Player)player;
            int result = this.Moves.CompareTo(otherPlayer.Moves);
            
            return result;
        }
    }
}
