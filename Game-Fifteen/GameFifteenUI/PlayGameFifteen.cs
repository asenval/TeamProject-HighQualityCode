namespace GameFifteenUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameFifteenLibrary;

    /// <summary>
    /// Class that generate the console UI
    /// </summary>
    public class PlayGameFifteen
    {
        /// <summary>
        /// Main method of the program.
        /// </summary>
        public static void Main()
        {
            List<Tile> tilesMatrix = new List<Tile>();
            int movesCount = 0;
            string currentCommand = "restart";
            bool isMatrixSolved = false;
            
            while (currentCommand != "exit")
            {
                if (!isMatrixSolved)
                {
                    switch (currentCommand)
                    {
                        case "restart":
                            {
                                string welcomeMessage = "Welcome to the game “15”. Please try to arrange the numbers sequentially." +
                                    "\nUse 'top' to view the top scoreboard, 'restart' to start a new game and 'exit'\nto quit the game.";
                                Console.WriteLine();
                                Console.WriteLine(welcomeMessage);
                                tilesMatrix = MatrixGenerator.GenerateMatrix();
                                tilesMatrix = MatrixGenerator.ShuffleMatrix(tilesMatrix);
                                isMatrixSolved = Gameplay.IsMatrixSolved(tilesMatrix);
                                Console.WriteLine(Gameplay.GetMatrixAsString(tilesMatrix));
                                break;
                            }

                        case "top":
                            {
                                Console.WriteLine(Scoreboard.PrintScoreboard());
                                break;
                            }
                    }

                    Console.Write("Enter a number to move: ");
                    currentCommand = Console.ReadLine();

                    int tileLabel;
                    bool isMovingCommand = int.TryParse(currentCommand, out tileLabel);

                    if (isMovingCommand)
                    {
                        try
                        {
                            Gameplay.MoveTiles(tilesMatrix, tileLabel);
                            movesCount++;
                            Console.WriteLine(Gameplay.GetMatrixAsString(tilesMatrix));
                            isMatrixSolved = Gameplay.IsMatrixSolved(tilesMatrix);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    }
                    else
                    {
                        currentCommand = currentCommand.ToLower();
                        if (!Enum.GetNames(typeof(Command)).Any(x => x.ToLower().Equals(currentCommand)))
                        {
                            Console.WriteLine("Invalid command");
                        }
                    }
                }
                else
                {
                    if (movesCount == 0)
                    {
                        Console.WriteLine("Your matrix was solved by default :) Come on - NEXT try");
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You won the game in {0} moves.", movesCount);
                        if (Scoreboard.CheckPlayerScores(movesCount))
                        {
                            Console.Write("Please enter your name for the top scoreboard: ");
                            string playerName = Console.ReadLine();
                            Player player = new Player(playerName, movesCount);
                            Scoreboard.AddPlayer(player);
                        }
                        else
                        {
                            Console.WriteLine("Your scores are not at top five.");
                        }

                        Console.WriteLine(Scoreboard.PrintScoreboard());
                    }

                    currentCommand = "restart";
                    isMatrixSolved = false;
                    movesCount = 0;
                }
            }
        }
    }
}
