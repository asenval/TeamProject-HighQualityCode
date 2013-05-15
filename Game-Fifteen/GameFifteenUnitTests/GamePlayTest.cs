using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteenProject
{
    [TestClass]
    public class GamePlayTest
    {
        [TestMethod]
        public void TestIsMatrixSolved()
        {
            List<Tile> templateMatrix = new List<Tile>();
            templateMatrix.Add(new Tile("1", 0));
            templateMatrix.Add(new Tile("2", 1));
            templateMatrix.Add(new Tile("3", 2));
            templateMatrix.Add(new Tile("4", 3));
            templateMatrix.Add(new Tile("5", 4));
            templateMatrix.Add(new Tile("6", 5));
            templateMatrix.Add(new Tile("7", 6));
            templateMatrix.Add(new Tile("8", 7));
            templateMatrix.Add(new Tile("9", 8));
            templateMatrix.Add(new Tile("10", 9));
            templateMatrix.Add(new Tile("11", 10));
            templateMatrix.Add(new Tile("12", 11));
            templateMatrix.Add(new Tile("13", 12));
            templateMatrix.Add(new Tile("14", 13));
            templateMatrix.Add(new Tile("15", 14));
            templateMatrix.Add(new Tile(string.Empty, 15));

            Assert.IsTrue(Gameplay.IsMatrixSolved(templateMatrix));
        }

        [TestMethod]
        public void TestIsMatrixNotSolved()
        {
            List<Tile> templateMatrix = new List<Tile>();
            templateMatrix.Add(new Tile("1", 0));
            templateMatrix.Add(new Tile("2", 1));
            templateMatrix.Add(new Tile("3", 2));
            templateMatrix.Add(new Tile("4", 3));
            templateMatrix.Add(new Tile("5", 4));
            templateMatrix.Add(new Tile("6", 5));
            templateMatrix.Add(new Tile("7", 6));
            templateMatrix.Add(new Tile("8", 7));
            templateMatrix.Add(new Tile("9", 8));
            templateMatrix.Add(new Tile("10", 9));
            templateMatrix.Add(new Tile("11", 10));
            templateMatrix.Add(new Tile("12", 11));
            templateMatrix.Add(new Tile("13", 12));
            templateMatrix.Add(new Tile("14", 13));
            templateMatrix.Add(new Tile(string.Empty, 14));
            templateMatrix.Add(new Tile("15", 15));

            Assert.IsFalse(Gameplay.IsMatrixSolved(templateMatrix));
        }

        [TestMethod]
        public void TestMatriAsStringEmpryMatrix()
        {
            List<Tile> templateMatrix = new List<Tile>();
            templateMatrix.Add(new Tile("9", 0));
            templateMatrix.Add(new Tile("1", 1));
            templateMatrix.Add(new Tile("8", 2));
            templateMatrix.Add(new Tile("7", 3));
            templateMatrix.Add(new Tile("10", 4));
            templateMatrix.Add(new Tile("6", 5));
            templateMatrix.Add(new Tile("2", 6));
            templateMatrix.Add(new Tile("5", 7));
            templateMatrix.Add(new Tile("12", 8));
            templateMatrix.Add(new Tile("3", 9));
            templateMatrix.Add(new Tile("14", 10));
            templateMatrix.Add(new Tile("4", 11));
            templateMatrix.Add(new Tile("15", 12));
            templateMatrix.Add(new Tile("13", 13));
            templateMatrix.Add(new Tile(string.Empty, 14));
            templateMatrix.Add(new Tile("11", 15));
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" -------------");
            sb.Append("| ");
            int currentColumn = 0;
            for (int index = 0; index < 16; index++)
            {
                Tile currentTile = templateMatrix.ElementAt(index);

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
                if (currentColumn == 4)
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

            string matrixAsString = Gameplay.GetMatrixAsString(templateMatrix);

            Assert.AreEqual(sb.ToString(),  matrixAsString);
        }

        [TestMethod]
        public void TestMoveTile()
        {
            List<Tile> templateMatrix = new List<Tile>();
            templateMatrix.Add(new Tile("1", 0));
            templateMatrix.Add(new Tile("2", 1));
            templateMatrix.Add(new Tile("3", 2));
            templateMatrix.Add(new Tile("4", 3));
            templateMatrix.Add(new Tile("5", 4));
            templateMatrix.Add(new Tile("6", 5));
            templateMatrix.Add(new Tile("7", 6));
            templateMatrix.Add(new Tile("8", 7));
            templateMatrix.Add(new Tile("9", 8));
            templateMatrix.Add(new Tile("10", 9));
            templateMatrix.Add(new Tile("11", 10));
            templateMatrix.Add(new Tile("12", 11));
            templateMatrix.Add(new Tile("13", 12));
            templateMatrix.Add(new Tile("14", 13));
            templateMatrix.Add(new Tile(string.Empty, 14));
            templateMatrix.Add(new Tile("15", 15));
            int tileLabel = 14;
            List<Tile> newMatrix = Gameplay.MoveTiles(templateMatrix, tileLabel);

            Assert.AreEqual(string.Empty, newMatrix[13].Label, "EmptyTile is not at correct place.");
            Assert.AreEqual("14", newMatrix[14].Label, "Moved Tile is not at correct place.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMoveTileNegativeDestination()
        {
            List<Tile> templateMatrix = new List<Tile>();
            templateMatrix.Add(new Tile("1", 0));
            templateMatrix.Add(new Tile("2", 1));
            templateMatrix.Add(new Tile("3", 2));
            templateMatrix.Add(new Tile("4", 3));
            templateMatrix.Add(new Tile("5", 4));
            templateMatrix.Add(new Tile("6", 5));
            templateMatrix.Add(new Tile("7", 6));
            templateMatrix.Add(new Tile("8", 7));
            templateMatrix.Add(new Tile("9", 8));
            templateMatrix.Add(new Tile("10", 9));
            templateMatrix.Add(new Tile("11", 10));
            templateMatrix.Add(new Tile("12", 11));
            templateMatrix.Add(new Tile("13", 12));
            templateMatrix.Add(new Tile("14", 13));
            templateMatrix.Add(new Tile(string.Empty, 14));
            templateMatrix.Add(new Tile("15", 15));
            int tileLabel = -1;
            List<Tile> newMatrix = Gameplay.MoveTiles(templateMatrix, tileLabel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMoveTileWrongDestination()
        {
            List<Tile> templateMatrix = new List<Tile>();
            templateMatrix.Add(new Tile("1", 0));
            templateMatrix.Add(new Tile("2", 1));
            templateMatrix.Add(new Tile("3", 2));
            templateMatrix.Add(new Tile("4", 3));
            templateMatrix.Add(new Tile("5", 4));
            templateMatrix.Add(new Tile("6", 5));
            templateMatrix.Add(new Tile("7", 6));
            templateMatrix.Add(new Tile("8", 7));
            templateMatrix.Add(new Tile("9", 8));
            templateMatrix.Add(new Tile("10", 9));
            templateMatrix.Add(new Tile("11", 10));
            templateMatrix.Add(new Tile("12", 11));
            templateMatrix.Add(new Tile("13", 12));
            templateMatrix.Add(new Tile("14", 13));
            templateMatrix.Add(new Tile(string.Empty, 14));
            templateMatrix.Add(new Tile("15", 15));
            int tileLabel = 50;
            List<Tile> newMatrix = Gameplay.MoveTiles(templateMatrix, tileLabel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDeniedMoveTile()
        {
            List<Tile> templateMatrix = new List<Tile>();
            templateMatrix.Add(new Tile("1", 0));
            templateMatrix.Add(new Tile("2", 1));
            templateMatrix.Add(new Tile("3", 2));
            templateMatrix.Add(new Tile("4", 3));
            templateMatrix.Add(new Tile("5", 4));
            templateMatrix.Add(new Tile("6", 5));
            templateMatrix.Add(new Tile("7", 6));
            templateMatrix.Add(new Tile("8", 7));
            templateMatrix.Add(new Tile("9", 8));
            templateMatrix.Add(new Tile("10", 9));
            templateMatrix.Add(new Tile("11", 10));
            templateMatrix.Add(new Tile("12", 11));
            templateMatrix.Add(new Tile("13", 12));
            templateMatrix.Add(new Tile("14", 13));
            templateMatrix.Add(new Tile(string.Empty, 14));
            templateMatrix.Add(new Tile("15", 15));
            int tileLabel = 10;
            List<Tile> newMatrix = Gameplay.MoveTiles(templateMatrix, tileLabel);
        }
    }
}
