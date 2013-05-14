using System;
using System.Collections.Generic;
using System.Linq;

namespace GameFifteenProject
{
    public static class Gameplay
    {
        private const int HorizontalNeighbourDistance = 1;
        private const int VerticalNeighbourDistance = 4;
        private const int MatrixSize = 4;

        /// <summary>
        /// Print a matrix to the console 
        /// </summary>
        /// <param name="tilesMatrix">The matrix that is going to be printed</param>
        public static void PrintMatrix(List<Tile> tilesMatrix)
        {
            Console.WriteLine("  ------------");
            Console.Write("| ");
            int currentColumn = 0;
            for (int index = 0; index < 16; index++)
            {
                Tile currentTile = tilesMatrix.ElementAt(index);

                if (currentTile.Label == String.Empty)
                {
                    Console.Write("   ");
                }
                else if (int.Parse(currentTile.Label) < 10)
                {
                    Console.Write(' ' + currentTile.Label + ' ');
                }
                else
                {
                    Console.Write(currentTile.Label + ' ');
                }

                currentColumn++;
                if (currentColumn == 4)
                {
                    Console.Write(" |");
                    Console.WriteLine();
                    if (index < 12)
                    {
                        Console.Write("| ");
                    }
                    currentColumn = 0;
                }
            }

            Console.WriteLine("  ------------");
        }

        /// <summary>
        /// Moves a tile to an empty position if such exists next to it 
        /// </summary>
        /// <param name="tilesMatrix">The matrix in which the tile is moved</param>
        /// <param name="tileLabel">The tile that is going to be moved</param>
        /// <returns>Returns the new matrix</returns>
        public static List<Tile> MoveTiles(List<Tile> tilesMatrix, int tileLabel)
        {
            if (tileLabel < 0 || tileLabel > 15)
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
                throw new Exception("Invalid move!");
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

            if (count == 15)
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
                int currentTileLabel = 0;
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
