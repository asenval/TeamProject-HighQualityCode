using System;
using System.Linq;

namespace GameFifteenProject
{
    public class Tile : IComparable
    {
        private readonly string label;
        private int position;

        public string Label
        {
            get { return this.label; }
        }

        public int Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public Tile(string label, int position)
        {
            this.label = label;
            this.position = position;
        }

        public Tile()
        {
        }

        public int CompareTo(object tile)
        {
            Tile otherTile = (Tile)tile;
            int result = this.Position.CompareTo(otherTile.Position);

            return result;
        }
    }
}
