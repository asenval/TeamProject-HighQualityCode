using System;
using System.Collections.Generic;
using System.Linq;

namespace GameFifteenProject
{
    public static class MatrixGenerator
    {
        private const int HorizontalNeighbourDistance = 1;
        private const int VerticalNeighbourDistance = 4;
        private const int MatrixSize = 4;
        private const int MinimumMoves = 20;
        private const int MaximumMoves = 50;
        private static Random random;

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

        private static List<Tile> MoveEmptyTile(List<Tile> tilesMatrix)
        {
            Tile emptyTile = DetermineEmptyTile(tilesMatrix);

            List<Tile> neighbourTiles = new List<Tile>();

            foreach (Tile tile in tilesMatrix)
            {
                neighbourTiles = GenerateNeighbourTilesList(emptyTile, tile, neighbourTiles);
            }

            int position = random.Next() % (neighbourTiles.Count());
            Tile neighbourTile = neighbourTiles[position];

            int neighbourTilePosition = neighbourTile.Position;
            tilesMatrix[neighbourTile.Position].Position = emptyTile.Position;
            tilesMatrix[emptyTile.Position].Position = neighbourTilePosition;
            tilesMatrix.Sort();

            return tilesMatrix;
        }

        private static Tile DetermineEmptyTile(List<Tile> tilesMatrix)
        {
            Tile emptyTile = new Tile();

            foreach (Tile tile in tilesMatrix)
            {
                if (tile.Label == string.Empty)
                {
                    emptyTile = tile;
                }
            }

            return emptyTile;
        }

        private static List<Tile> GenerateNeighbourTilesList(Tile emptyTile, Tile currentTile, List<Tile> neighbourTiles)
        {
            bool areValidNeighbours = AreValidNeighbours(emptyTile, currentTile);
            if (areValidNeighbours)
            {
                neighbourTiles.Add(currentTile);
            }

            return neighbourTiles;
        }

        private static bool AreValidNeighbours(Tile emptyTile, Tile currentTile)
        {
            int tilesDistance = emptyTile.Position - currentTile.Position;
            int tilesAbsoluteDistance = Math.Abs(tilesDistance);
            bool areValidHorizontalNeighbours =
                ((tilesAbsoluteDistance == HorizontalNeighbourDistance) && !(((currentTile.Position + 1) % MatrixSize == 1 && tilesDistance == -1) || ((currentTile.Position + 1) % MatrixSize == 0 && tilesDistance == 1)));
            bool areValidVerticalNeighbours = (tilesAbsoluteDistance == VerticalNeighbourDistance);
            bool areValidNeigbours = areValidHorizontalNeighbours || areValidVerticalNeighbours;

            return areValidNeigbours;
        }
    }
}
