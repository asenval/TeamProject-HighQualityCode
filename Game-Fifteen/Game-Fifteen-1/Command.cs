using System;
using System.Linq;

namespace GameFifteenProject
{
    /// <summary>
    /// Contains and validate player console commands
    /// </summary>
    public static class Command
    {
        private enum Commands { Restart, Top, Exit };

        /// <summary>
        /// Validate player command
        /// </summary>
        /// <param name="command">Player command represented as a string</param>
        /// <returns>Valid player command represented as a string</returns>
        public static string IsCommandValid(string command)
        {
            string commandToLower = command.ToLower();

            switch (commandToLower)
            {
                case "restart":
                    return Commands.Restart.ToString().ToLower();
                case "top":
                    return Commands.Top.ToString().ToLower();
                case "exit":
                    return Commands.Exit.ToString().ToLower();
                default:
                    throw new ArgumentException("Invalid Command!");
            }
        }

    }
}
