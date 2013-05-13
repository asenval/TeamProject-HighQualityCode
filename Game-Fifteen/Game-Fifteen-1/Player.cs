using System;
using System.Linq;

namespace GameFifteenProject
{
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
        /// Player constructor
        /// </summary>
        /// <param name="name">Player name represented as a string</param>
        /// <param name="moves">Player number of moves represented as an integer</param>
        public Player(string name, int moves)
        {
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
