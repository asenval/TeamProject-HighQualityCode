namespace GameFifteenProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Gameplay class contains gameplay logic
    /// </summary>
    public static class Gameplay
    {
        private const int MatrixSize = 4;
        private static readonly int maxTiles = MatrixSize * MatrixSize - 1;

        /// <summary>
        /// Print a matrix to the console 
        /// </summary>
        /// <param name="tilesMatrix">The matrix that is going to be printed</param>
        public static string GetMatrixAsString(List<Tile> tilesMatrix)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" -------------");
            sb.Append("| ");
            int currentColumn = 0;
            for (int index = 0; index < 16; index++)
            {
                Tile currentTile = tilesMatrix.ElementAt(index);

                if (currentTile.Label == string.Empty)
                {
                    sb.Append("   ");
                }
                else if (int.Parse(currentTile.Label) < 10)
                {
                    sb.Append(' ' + currentTile.Label + ' ');
                }
                else
                {
                    sb.Append(currentTile.Label + ' ');
                }

                currentColumn++;
                if (currentColumn == MatrixSize)
                {
                    sb.Append("|");
                    sb.AppendLine();
                    if (index < 12)
                    {
                        sb.Append("| ");
                    }

                    currentColumn = 0;
                }
            }

            sb.AppendLine(" -------------");
            return sb.ToString();
        }

        /// <summary>
        /// Moves a tile to an empty position if such exists next to it 
        /// </summary>
        /// <param name="tilesMatrix">The matrix in which the tile is moved</param>
        /// <param name="tileLabel">The tile that is going to be moved</param>
        /// <returns>Returns the new matrix</returns>
        public static List<Tile> MoveTiles(List<Tile> tilesMatrix, int tileLabel)
        {
            if (tileLabel < 0 || tileLabel > maxTiles)
            {
                throw new ArgumentException("Invalid move!");
            }

            List<Tile> newMatrix = tilesMatrix;
            Tile emptyTile = MatrixGenerator.GetEmptyTile(newMatrix);
            Tile targetTile = GetDestinationTile(newMatrix, tileLabel);

            bool areValidNeighbours = MatrixGenerator.AreValidNeighbours(emptyTile, targetTile);

            if (areValidNeighbours)
            {
                int targetTilePosition = targetTile.Position;
                newMatrix[targetTilePosition].Position = emptyTile.Position;
                newMatrix[emptyTile.Position].Position = targetTilePosition;
                newMatrix.Sort();
            }
            else
            {
                throw new InvalidOperationException("Invalid move!");
            }

            return newMatrix;
        }

        /// <summary>
        /// Checks if the matrix is solved
        /// </summary>
        /// <param name="tilesMatrix">The matrix that is checked</param>
        /// <returns>Returns a boolean value</returns>
        public static bool IsMatrixSolved(List<Tile> tilesMatrix)
        {
            int count = 0;
            foreach (Tile tile in tilesMatrix)
            {
                int currentTileLabel = 0;

                if (int.TryParse(tile.Label, out currentTileLabel))
                {
                    if (currentTileLabel == (tile.Position + 1))
                    {
                        count++;
                    }
                }
            }

            if (count == maxTiles)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the tile that is going to be moved
        /// </summary>
        /// <param name="tilesMatrix">The matrix in which the tile is going to be moved</param>
        /// <param name="tileLabel">The tile that is going to be moved</param>
        /// <returns>Returns the tile that is going to be moved</returns>
        private static Tile GetDestinationTile(List<Tile> tilesMatrix, int tileLabel)
        {
            for (int index = 0; index < tilesMatrix.Count; index++)
            {
                int currentTileLabel;
                bool successfulParsing = int.TryParse(tilesMatrix[index].Label, out currentTileLabel);
                if (successfulParsing && tileLabel == currentTileLabel)
                {
                    return tilesMatrix[index];
                }
            }

            throw new ArgumentException("There is no tile with this tileLabel.");
        }
    }
}
