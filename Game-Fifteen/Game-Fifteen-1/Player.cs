using System;
using System.Linq;

namespace GameFifteenProject
{
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

        public Player(string name, int moves)
        {
            this.name = name;
            this.moves = moves;
        }

        public int CompareTo(object player)
        {
            Player otherPlayer = (Player)player;
            int result = this.Moves.CompareTo(otherPlayer.Moves);
            
            return result;
        }
    }
}
