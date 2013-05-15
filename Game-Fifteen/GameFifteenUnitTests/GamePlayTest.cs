using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
