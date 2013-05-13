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
                else if (Int32.Parse(currentTile.Label) < 10)
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
        /// Move tile to an empty position if such exists next to it 
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
            int emptyTilePosition = GetEmptyTilePosition(newMatrix);
            Tile emptyTile = tilesMatrix[emptyTilePosition];
            int targerTilePosition = GetDestinationTilePosition(newMatrix, tileLabel);
            Tile targetTile = tilesMatrix[targerTilePosition];

            bool areValidNeighbours = AreValidNeighbours(emptyTile, targetTile);

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
        /// Gets the position of the tile that is going to be moved
        /// </summary>
        /// <param name="tilesMatrix">The matrix in which the tile is going to be moved</param>
        /// <param name="tileLabel">The tile that is going to be moved</param>
        /// <returns>Returns the position of the tile that is going to be moved</returns>
        private static int GetDestinationTilePosition(List<Tile> tilesMatrix, int tileLabel)
        {
            int tilePosition = 0;
            for (int index = 0; index < tilesMatrix.Count; index++)
            {
                int currentTileLabel = 0;
                bool successfulParsing = Int32.TryParse(tilesMatrix[index].Label, out currentTileLabel);
                if (successfulParsing && tileLabel == currentTileLabel)
                {
                    tilePosition = index;
                }
            }

            return tilePosition;
        }

        /// <summary>
        /// Checks if a tile can be moved to another position
        /// </summary>
        /// <param name="emptyTile">The empty tile in the matrix</param>
        /// <param name="currentTile">The tile that is going to be moved</param>
        /// <returns>Returns a boolean value</returns>
        private static bool AreValidNeighbours(Tile emptyTile, Tile currentTile)
        {
            int tilesDistance = emptyTile.Position - currentTile.Position;
            int tilesAbsoluteDistance = Math.Abs(tilesDistance);
            bool areValidHorizontalNeighbours =
                (tilesAbsoluteDistance == HorizontalNeighbourDistance && !(((currentTile.Position + 1) % MatrixSize == 1 && tilesDistance == -1) || ((currentTile.Position + 1) % MatrixSize == 0 && tilesDistance == 1)));
            bool areValidVerticalNeighbours = (tilesAbsoluteDistance == VerticalNeighbourDistance);
            bool areValidNeigbours = areValidHorizontalNeighbours || areValidVerticalNeighbours;

            return areValidNeigbours;
        }

        /// <summary>
        /// Gets the position of the empty tile in a matrix
        /// </summary>
        /// <param name="tilesMatrix">The matrix in which the empty tile position is searched</param>
        /// <returns>Returns the position of the empty tile</returns>
        private static int GetEmptyTilePosition(List<Tile> tilesMatrix)
        {
            int emptyTilePosition = 0;
            for (int index = 0; index < tilesMatrix.Count; index++)
            {
                if (tilesMatrix[index].Label == String.Empty)
                {
                    emptyTilePosition = index;
                    break;
                }
            }

            return emptyTilePosition;
        }
    }
}
