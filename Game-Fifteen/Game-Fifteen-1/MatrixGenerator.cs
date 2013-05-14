using System;
using System.Collections.Generic;
using System.Linq;

namespace GameFifteenProject
{
    public static class MatrixGenerator
    {
        private const int MatrixSize = 4;
        private const int HorizontalNeighbourDistance = 1;
        private const int VerticalNeighbourDistance = MatrixSize;
        private const int MinimumMoves = 20;
        private const int MaximumMoves = 50;
        private static Random random;

        /// <summary>
        /// Generate a new Matrix
        /// </summary>
        /// <returns>Returns the matrix</returns>
        public static List<Tile> GenerateMatrix()
        {
            List<Tile> tilesMatrix = new List<Tile>();

            for (int tilePosition = 0; tilePosition < 15; tilePosition++)
            {
                String tileLabel = (tilePosition + 1).ToString();

                Tile currentTile = new Tile(tileLabel, tilePosition);
                tilesMatrix.Add(currentTile);
            }

            Tile emptyTile = new Tile(string.Empty, 15);
            tilesMatrix.Add(emptyTile);

            return tilesMatrix;
        }

        /// <summary>
        /// Shuffles the tiles in a matrix
        /// </summary>
        /// <param name="tilesMatrix">The matrix that is going to be shuffeled</param>
        /// <returns>Returns the matrix with shuffled tiles</returns>
        public static List<Tile> ShuffleMatrix(List<Tile> tilesMatrix)
        {
            random = new Random();
            int movesNumber = random.Next(MinimumMoves, MaximumMoves);
            List<Tile> shuffledMatrix = tilesMatrix;

            for (int move = 0; move < movesNumber; move++)
            {
                shuffledMatrix = MoveEmptyTile(shuffledMatrix);
            }

            return shuffledMatrix;
        }

        /// <summary>
        /// Moves the empty tile of a matrix
        /// </summary>
        /// <param name="tilesMatrix">The matrix in which the empty tile is going to be moved</param>
        /// <returns>Returns the matrix with moved empty tile</returns>
        private static List<Tile> MoveEmptyTile(List<Tile> tilesMatrix)
        {
            Tile emptyTile = GetEmptyTile(tilesMatrix);

            List<Tile> neighbourTiles = new List<Tile>();

            foreach (Tile tile in tilesMatrix)
            {
                bool areValidNeighbours = AreValidNeighbours(emptyTile, tile);
                if (areValidNeighbours)
                {
                    neighbourTiles.Add(tile);
                }
            }

            int position = random.Next() % (neighbourTiles.Count());
            Tile neighbourTile = neighbourTiles[position];

            int neighbourTilePosition = neighbourTile.Position;
            tilesMatrix[neighbourTile.Position].Position = emptyTile.Position;
            tilesMatrix[emptyTile.Position].Position = neighbourTilePosition;
            tilesMatrix.Sort();

            return tilesMatrix;
        }
        
        /// <summary>
        /// Gets the empty tile in a matrix
        /// </summary>
        /// <param name="tilesMatrix">The matrix in which the empty tile is searched</param>
        /// <returns>Returns the empty tile of the matrix</returns>
        public static Tile GetEmptyTile(List<Tile> tilesMatrix)
        {
            foreach (Tile tile in tilesMatrix)
            {
                if (tile.Label == string.Empty)
                {
                    return tile;
                }
            }

            throw new ArgumentNullException("EmptyTile is missing.");
        }
        
        /// <summary>
        /// Check if two tiles are valid neighbours
        /// </summary>
        /// <param name="emptyTile">The empty tile in the matrix</param>
        /// <param name="currentTile">The tile that is checked if it is valid naighbour</param>
        /// <returns>Returns boolean value</returns>
        public static bool AreValidNeighbours(Tile emptyTile, Tile currentTile)
        {
            int tilesDistance = emptyTile.Position - currentTile.Position;
            int tilesAbsoluteDistance = Math.Abs(tilesDistance);
            bool areValidHorizontalNeighbours = false;
            if (tilesAbsoluteDistance == HorizontalNeighbourDistance)
            {
                areValidHorizontalNeighbours = true;
                if (((currentTile.Position + 1) % MatrixSize == 1 && tilesDistance == -1) || ((currentTile.Position + 1) % MatrixSize == 0 && tilesDistance == 1))
                {
                    areValidHorizontalNeighbours = false;
                }
            }
            bool areValidVerticalNeighbours = (tilesAbsoluteDistance == VerticalNeighbourDistance);
            bool areValidNeigbours = areValidHorizontalNeighbours || areValidVerticalNeighbours;

            return areValidNeigbours;
        }
    }
}
