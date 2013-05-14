using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameFifteenProject
{
    [TestClass]
    public class ScoreboardTests
    {
        [TestMethod]
        public void TestAddPlayerWithThreeAddedPlayers()
        {
            Player player1 = new Player("Ivan", 21);
            Scoreboard.AddPlayer(player1);
            Player player2 = new Player("Petar", 12);
            Scoreboard.AddPlayer(player2);
            Player player3 = new Player("Petya", 24);
            Scoreboard.AddPlayer(player3);
            Assert.AreEqual(3, Scoreboard.Count);
        }

        [TestMethod]
        public void Test1DeleteAllExceptTopFivePlayers()
        {
            Scoreboard.DeleteAllExceptTopFivePlayers();
            Assert.AreEqual(3, Scoreboard.Count);
        }

        [TestMethod]
        public void TestAddPlayerWithSevenMoreAddedPlayers()
        {
            Player player1 = new Player("Ivan", 21);
            Scoreboard.AddPlayer(player1);
            Player player2 = new Player("Petar", 12);
            Scoreboard.AddPlayer(player2);
            Player player3 = new Player("Petya", 24);
            Scoreboard.AddPlayer(player3);
            Player player4 = new Player("Mimi", 12);
            Scoreboard.AddPlayer(player4);
            Player player5 = new Player("Gosho", 17);
            Scoreboard.AddPlayer(player5);
            Player player6 = new Player("Yordan", 27);
            Scoreboard.AddPlayer(player6);
            Player player7 = new Player("Lily", 11);
            Scoreboard.AddPlayer(player7);
            Assert.AreEqual(10, Scoreboard.Count);
        }

        [TestMethod]
        public void Test2DeleteAllExceptTopFivePlayers()
        {
            Scoreboard.DeleteAllExceptTopFivePlayers();
            Assert.AreEqual(5, Scoreboard.Count);
        }

        [TestMethod]
        public void TestDeleteAllExceptTopFivePlayersWithSevenMorePlayersAdded()
        {
            Player player1 = new Player("Ivan", 21);
            Scoreboard.AddPlayer(player1);
            Player player2 = new Player("Petar", 12);
            Scoreboard.AddPlayer(player2);
            Player player3 = new Player("Petya", 24);
            Scoreboard.AddPlayer(player3);
            Player player4 = new Player("Mimi", 12);
            Scoreboard.AddPlayer(player4);
            Player player5 = new Player("Gosho", 17);
            Scoreboard.AddPlayer(player5);
            Player player6 = new Player("Yordan", 27);
            Scoreboard.AddPlayer(player6);
            Player player7 = new Player("Lily", 11);
            Scoreboard.AddPlayer(player7);
            Scoreboard.DeleteAllExceptTopFivePlayers();
            Assert.AreEqual(5, Scoreboard.Count);
        }
    }
}
