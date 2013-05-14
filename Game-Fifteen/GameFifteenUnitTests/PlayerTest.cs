using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameFifteenProject
{
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
        public void CreatePlayerEmptyName()
        {
            Player gamer = new Player("", 5);
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
    }
}
