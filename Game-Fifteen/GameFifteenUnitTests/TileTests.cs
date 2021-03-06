﻿namespace GameFifteenProject
{
    using System;
    using GameFifteenLibrary;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TileTests
    {
        [TestMethod]
        public void TestCheckTileLabel()
        {
            Tile tile = new Tile("7", 5);
            Assert.AreEqual("7", tile.Label);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCheckTileNegativePosition()
        {
            Tile tile = new Tile("7", -5);
        }

        [TestMethod]
        public void TestCheckTilePosition()
        {
            Tile tile = new Tile("7", 5);
            Assert.AreEqual(5, tile.Position);
        }

        [TestMethod]
        public void Test1CompareTo()
        {
            Tile tile1 = new Tile("7", 5);
            Tile tile2 = new Tile("3", 8);
            Assert.AreEqual(-1, tile1.CompareTo(tile2));
        }

        [TestMethod]
        public void Test2CompareTo()
        {
            Tile tile1 = new Tile("7", 12);
            Tile tile2 = new Tile("3", 8);
            Assert.AreEqual(1, tile1.CompareTo(tile2));
        }
    }
}
