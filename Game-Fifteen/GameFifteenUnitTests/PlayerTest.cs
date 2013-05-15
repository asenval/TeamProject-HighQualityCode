namespace GameFifteenProject
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteenLibrary;

    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatePlayerNegativMoves()
        {
            Player gamer = new Player("Ivan", -5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatePlayerNullName()
        {
            Player gamer = new Player(null, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatePlayerEmptyName()
        {
            Player gamer = new Player(string.Empty, 5);
        }

        [TestMethod]
        public void CreatePlayerCheckNmae()
        {
            Player gamer = new Player("Ivan", 5);
            Assert.AreEqual(gamer.Name, "Ivan");
        }

        [TestMethod]
        public void CreatePlayerCheckMoves()
        {
            Player gamer = new Player("Ivan", 5);
            Assert.AreEqual(gamer.Moves, 5);
        }

        [TestMethod]
        public void ComparePlayerEqual()
        {
            Player gamer = new Player("Ivan", 5);
            Player gamer2 = new Player("Dancho", 5);
            Assert.AreEqual(0, gamer.CompareTo(gamer2));
        }

        [TestMethod]
        public void ComparePlayerDiferentSmaller()
        {
            Player gamer = new Player("Ivan", 5);
            Player gamer2 = new Player("Dancho", 6);
            Assert.AreEqual(-1, gamer.CompareTo(gamer2));
        }

        [TestMethod]
        public void ComparePlayerDiferentBiger()
        {
            Player gamer = new Player("Ivan", 6);
            Player gamer2 = new Player("Dancho", 5);
            Assert.AreEqual(1, gamer.CompareTo(gamer2));
        }
    }
}
