﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GameFifteenProject
{
    public static class Scoreboard
    {
        private static List<Player> players = new List<Player>();

        public static void AddPlayer(Player player)
        {
            players.Add(player);
            players.Sort();
            DeleteAllExceptTopPlayers();
        }

        public static void PrintScoreboard()
        {
            Console.WriteLine("Scoreboard:");
            foreach (Player player in players)
            {
                string scoreboardLine = (players.IndexOf(player) + 1).ToString() + ". " + player.Name + " --> " + player.Moves.ToString() + " moves";
                Console.WriteLine(scoreboardLine);
            }
        }

        private static void DeleteAllExceptTopPlayers()
        {
            for (int index = 0; index < players.Count(); index++)
            {
                if (index > 4)
                {
                    players.Remove(players[index]);
                }
            }
        }
    }
}
