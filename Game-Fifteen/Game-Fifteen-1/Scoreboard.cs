namespace GameFifteenProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Contains a list of players
    /// </summary>
    public static class Scoreboard
    {
        private static readonly List<Player> players = new List<Player>();

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
            players.Sort();
        }

        /// <summary>
        /// Print a list of players to the console 
        /// </summary>
        public static void PrintScoreboard()
        {
            Console.WriteLine("Scoreboard:");
            foreach (Player player in players)
            {
                string scoreboardLine = string.Format("{0}. {1} --> {2} moves", players.IndexOf(player) + 1, player.Name, player.Moves);
                Console.WriteLine(scoreboardLine);
            }
        }

        /// <summary>
        /// Delete all players except top five from a list of players
        /// </summary>
        public static void DeleteAllExceptTopFivePlayers()
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
