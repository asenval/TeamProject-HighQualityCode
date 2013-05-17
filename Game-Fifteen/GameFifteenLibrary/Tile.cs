namespace GameFifteenLibrary
{
    using System;
    using System.Linq;

    /// <summary>
    /// Contains tile label and position
    /// </summary>
    public class Tile : IComparable
    {
        private readonly string label;
        private int position;

        /// <summary>
        /// Gets the label of the tile
        /// </summary>
        public string Label
        {
            get { return this.label; }
        }

        /// <summary>
        /// Gets or sets the position of the tile in the matrix
        /// </summary>
        public int Position
        {
            get
            {
                return this.position;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Tile position must be positive number."); 
                }
                else
                {
                    this.position = value;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance  of the <see cref="Tile"/> class.
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
