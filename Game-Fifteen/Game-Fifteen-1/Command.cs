using System;
using System.Linq;

namespace GameFifteenProject
{
    /// <summary>
    /// Class Command contains and validate player console commands.
    /// </summary>
    public static class Command
    {
        private enum Commands { restart, top, exit };

        /// <summary>
        /// Validate player command.
        /// </summary>
        /// <param name="command">Player command string</param>
        /// <returns>Valid player command string</returns>
        public static string CommandType(string command)
        {
            string commandToLower = command.ToLower();

            if (commandToLower == Commands.exit.ToString() ||
                commandToLower == Commands.restart.ToString() || 
                commandToLower == Commands.top.ToString())
            {
                return commandToLower;
            }
            else
            {
                throw new ArgumentException("Invalid Command!");
            }
        }

    }
}
