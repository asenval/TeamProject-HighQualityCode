using System;
using System.Linq;

namespace GameFifteenProject
{
    /// <summary>
    /// Contains tile label and position
    /// </summary>
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

        /// <summary>
        /// Tile constructor
        /// </summary>
        /// <param name="label">Tile label represented as a string</param>
        /// <param name="position">Tile position represented as an integer</param>
        public Tile(string label, int position)
        {
            this.label = label;
            this.Position = position;
        }

        /// <summary>
        /// Compares two tiles by their position
        /// </summary>
        /// <param name="tile">Tile object</param>
        /// <returns>The result of comparing the tiles</returns>
        public int CompareTo(object tile)
        {
            Tile otherTile = (Tile)tile;
            int result = this.Position.CompareTo(otherTile.Position);

            return result;
        }
    }
}
