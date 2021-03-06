﻿namespace GameFifteenLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Contains a list of players
    /// </summary>
    public static class Scoreboard
    {
        private static readonly List<Player> players = new List<Player>();

        /// <summary>
        /// Gets the number of players in the list
        /// </summary>
        public static int Count
        {
            get
            {
                return players.Count;
            }
        }

        /// <summary>
        /// Add player to a list of players and sort the list
        /// by the number of moves of each player
        /// </summary>
        /// <param name="player">Player object</param>
        public static void AddPlayer(Player player)
        {
            players.Add(player);
            players.Sort((x, y) => x.Moves.CompareTo(y.Moves));
            DeleteAllExceptTopFivePlayers();
        }

        /// <summary>
        /// Print a list of players to the console 
        /// </summary>
        /// <returns>Returns scoreboard as a string.</returns>
        public static string PrintScoreboard()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Scoreboard:");
            foreach (Player player in players)
            {
                sb.AppendLine(string.Format("{0}. {1} --> {2} moves", players.IndexOf(player) + 1, player.Name, player.Moves));                
            }

            return sb.ToString();
        }

        /// <summary>
        /// Compares the score of the last player of the list with an integer and 
        /// returns true if it is bigger
        /// </summary>
        /// <param name="scores">An integer that is compared with the score of the player</param>
        /// <returns>Returns boolean value</returns>
        public static bool CheckPlayerScores(int scores)
        {
            if (players.Count == 0)
            {
                return true;
            }

            if (scores < players[players.Count - 1].Moves)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Clears the player list
        /// </summary>
        internal static void ClearPlayer()
        {
            players.Clear();
        }

        /// <summary>
        /// Delete all players except top five from a list of players
        /// </summary>
        private static void DeleteAllExceptTopFivePlayers()
        {
            for (int index = 0; index < players.Count(); index++)
            {
                if (index > 4)
                {
                    players.Remove(players[index]);
                    index--;
                }
            }
        }
    }
}
