using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using GameFifteenLibrary;

namespace GameFifteenProject
{
    [TestClass]
    public class ScoreboardTests
    {
        [TestMethod]
        public void TestAddPlayerWithThreeAddedPlayers()
        {
            Scoreboard.ClearPlayer();
            Player player1 = new Player("Ivan", 21);
            Scoreboard.AddPlayer(player1);
            Player player2 = new Player("Petar", 12);
            Scoreboard.AddPlayer(player2);
            Player player3 = new Player("Petya", 24);
            Scoreboard.AddPlayer(player3);
            Assert.AreEqual(3, Scoreboard.Count);
        }

        [TestMethod]
        public void TestAddPlayerWithSevenMoreAddedPlayers()
        {
            Scoreboard.ClearPlayer();
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
            Assert.AreEqual(5, Scoreboard.Count);
        }

        [TestMethod]
        public void TestArePrintPlayersSorted()
        {
            Scoreboard.ClearPlayer();
            Player player1 = new Player("Ivan", 21);
            Scoreboard.AddPlayer(player1);
            Player player2 = new Player("Petar", 12);
            Scoreboard.AddPlayer(player2);
            Player player3 = new Player("Petya", 24);
            Scoreboard.AddPlayer(player3);
            Player player4 = new Player("Mimi", 14);
            Scoreboard.AddPlayer(player4);
            Player player5 = new Player("Yordan", 27);
            Scoreboard.AddPlayer(player5);
            StringBuilder expectetPrint = new StringBuilder();
            expectetPrint.AppendLine("Scoreboard:");
            expectetPrint.AppendLine(string.Format("1. {0} --> {1} moves", player2.Name, player2.Moves));
            expectetPrint.AppendLine(string.Format("2. {0} --> {1} moves", player4.Name, player4.Moves));
            expectetPrint.AppendLine(string.Format("3. {0} --> {1} moves", player1.Name, player1.Moves));
            expectetPrint.AppendLine(string.Format("4. {0} --> {1} moves", player3.Name, player3.Moves));
            expectetPrint.AppendLine(string.Format("5. {0} --> {1} moves", player5.Name, player5.Moves));
            string scoreBoardPring = Scoreboard.PrintScoreboard();

            Assert.AreEqual(expectetPrint.ToString(), scoreBoardPring);
        }

        [TestMethod]
        public void TestDeleteAllExceptTopFivePlayers()
        {
            Scoreboard.ClearPlayer();
            Player player1 = new Player("Ivan", 21);
            Scoreboard.AddPlayer(player1);
            Assert.IsTrue(Scoreboard.Count <= 5);
        }

        [TestMethod]
        public void TestDeleteAllExceptTopFivePlayersMorePlayers()
        {
            Scoreboard.ClearPlayer();
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
            Assert.IsTrue(Scoreboard.Count <= 5);
        }

        [TestMethod]
        public void TestCheckPlayersScoresBiggetThanOthers()
        {
            Scoreboard.ClearPlayer();
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
            bool isScoresBiggerThanOtherPlayersScores = Scoreboard.CheckPlayerScores(30);
            Assert.IsFalse(isScoresBiggerThanOtherPlayersScores);
        }

        [TestMethod]
        public void TestCheckPlayersScoresSmallerThanOthers()
        {
            Scoreboard.ClearPlayer();
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
            bool isScoresSmalerThanOtherPlayersScores = Scoreboard.CheckPlayerScores(10);
            Assert.IsTrue(isScoresSmalerThanOtherPlayersScores);
        }
    }
}
