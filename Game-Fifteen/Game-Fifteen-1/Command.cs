using System;
using System.Linq;

namespace GameFifteenProject
{
    public static class Command
    {
        private enum Commands { restart, top, exit };

        public static string CommandType(string command)
        {
            string commandToLower = command.ToLower();

            if (commandToLower == Commands.exit.ToString() || commandToLower == Commands.restart.ToString() || commandToLower == Commands.top.ToString())
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
