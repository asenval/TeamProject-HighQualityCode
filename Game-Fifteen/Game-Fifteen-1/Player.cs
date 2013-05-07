using System;
using System.Linq;

namespace GameFifteenProject
{
    /// <summary>
    /// Class Player contains player data.
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
        /// Player constructor.
        /// </summary>
        /// <param name="name">Player name string</param>
        /// <param name="moves">Player number of moves integer</param>
        public Player(string name, int moves)
        {
            this.name = name;
            this.moves = moves;
        }

        /// <summary>
        /// Player constructor.
        /// </summary>
        /// <param name="player">Player object</param>
        /// <returns></returns>
        public int CompareTo(object player)
        {
            Player otherPlayer = (Player)player;
            int result = this.Moves.CompareTo(otherPlayer.Moves);
            
            return result;
        }
    }
}
