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

        public static List<Tile> MoveTiles(List<Tile> tilesMatrix, int tileLabel)
        {
            if (tileLabel < 0 || tileLabel > 15)
            {
                throw new ArgumentException("Invalid move!");
            }

            List<Tile> newMatrix = tilesMatrix;
            Tile emptyTile = tilesMatrix[GetEmptyTilePosition(tilesMatrix)];
            Tile targetTile = tilesMatrix[GetDestinationTilePosition(tilesMatrix, tileLabel)];

            bool areValidNeighbours = TilePositionValidation(tilesMatrix, emptyTile, targetTile);

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

        public static bool IsMatrixSolved(List<Tile> tilesMatrix)
        {
            int count = 0;
            foreach (Tile tile in tilesMatrix)
            {
                int currentTileLabel = 0;
                Int32.TryParse(tile.Label, out currentTileLabel);
                if (currentTileLabel == (tile.Position + 1))
                {
                    count++;
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

        private static bool TilePositionValidation(List<Tile> tiles, Tile emptyTile, Tile currentTile)
        {
            bool areValidNeighbours = AreValidNeighbours(emptyTile, currentTile);

            return areValidNeighbours;
        }

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
