namespace GameFifteenProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameFifteenLibrary;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for MatrixGenerator class
    /// </summary>
    [TestClass]
    public class MatrixGeneratorTest
    {
        [TestMethod]
        public void TestGenerateOrderedMatrix()
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

            List<Tile> generatedMatrix = MatrixGenerator.GenerateMatrix();

            Assert.IsTrue(this.CompareTileLists(templateMatrix, generatedMatrix));
        }

        [TestMethod]
        public void TestShuffeledMatrix()
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

            List<Tile> generatedMatrix = MatrixGenerator.GenerateMatrix();
            generatedMatrix = MatrixGenerator.ShuffleMatrix(generatedMatrix);

            Assert.IsFalse(this.CompareTileLists(templateMatrix, generatedMatrix), "Matrix is not shuffeled.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetEmptyTileException()
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

            Tile emptyTile = MatrixGenerator.GetEmptyTile(templateMatrix);
        }

        [TestMethod]
        public void TestGetEmptyTile()
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
            templateMatrix.Add(new Tile(string.Empty, 11));
            templateMatrix.Add(new Tile("12", 12));
            templateMatrix.Add(new Tile("13", 13));
            templateMatrix.Add(new Tile("14", 14));
            templateMatrix.Add(new Tile("15", 15));

            Tile emptyTile = MatrixGenerator.GetEmptyTile(templateMatrix);
            Assert.AreEqual(string.Empty, emptyTile.Label, "Empty tile is not empty");
        }

        [TestMethod]
        public void TestAreValidNeighboursTop()
        {
            Tile emptyTile = new Tile(string.Empty, 1);
            Tile currentTile = new Tile("12", 5);

            Assert.IsTrue(MatrixGenerator.AreValidNeighbours(emptyTile, currentTile), "Empty tile are not neighbours.");
        }

        [TestMethod]
        public void TestAreValidNeighboursBottom()
        {
            Tile emptyTile = new Tile(string.Empty, 9);
            Tile currentTile = new Tile("12", 5);

            Assert.IsTrue(MatrixGenerator.AreValidNeighbours(emptyTile, currentTile), "Empty tile are not neighbours.");
        }

        [TestMethod]
        public void TestAreValidNeighboursLeft()
        {
            Tile emptyTile = new Tile(string.Empty, 6);
            Tile currentTile = new Tile("12", 7);

            Assert.IsTrue(MatrixGenerator.AreValidNeighbours(emptyTile, currentTile), "Empty tile are not neighbours.");
        }

        [TestMethod]
        public void TestAreValidNeighboursRight()
        {
            Tile emptyTile = new Tile(string.Empty, 7);
            Tile currentTile = new Tile("12", 6);

            Assert.IsTrue(MatrixGenerator.AreValidNeighbours(emptyTile, currentTile), "Empty tile are not neighbours.");
        }
        
        [TestMethod]
        public void TestAreNotValidNeighbours()
        {
            Tile emptyTile = new Tile(string.Empty, 3);
            Tile currentTile = new Tile("12", 5);

            Assert.IsFalse(MatrixGenerator.AreValidNeighbours(emptyTile, currentTile), "Empty tile are not neighbours.");
        }

        private bool CompareTileLists(List<Tile> list1, List<Tile> list2)
        {
            bool areEqual = true;

            if (list1.Count != list2.Count)
            {
                return false;
            }

            foreach (Tile item in list1)
            {
                Tile tile1 = item;
                Tile tile2 = list2.ElementAt(list1.IndexOf(item));

                if (0 != tile1.CompareTo(tile2))
                {
                    areEqual = false;
                }

                if (!tile1.Label.Equals(tile2.Label))
                {
                    areEqual = false;
                }
            }

            return areEqual;
        }
    }
}
