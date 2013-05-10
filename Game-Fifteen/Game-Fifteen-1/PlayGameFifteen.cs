using System;
using System.Collections.Generic;
using System.Linq;

namespace GameFifteenProject
{
    public class PlayGameFifteen
    {
        static void Main()
        {
            List<Tile> tilesMatrix = new List<Tile>();
            int movesCount = 0;
            string command = "restart";
            bool isMatrixSolved = false;

            while (command != "exit")
            {
                if (!isMatrixSolved)
                {
                    switch (command)
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
                                Gameplay.PrintMatrix(tilesMatrix);
                                break;
                            }
                        case "top":
                            {
                                Scoreboard.PrintScoreboard();
                                break;
                            }
                    }
                    Console.Write("Enter a number to move: ");
                    command = Console.ReadLine();

                    int tileLabel;
                    bool isMovingCommand = Int32.TryParse(command, out tileLabel);

                    if (isMovingCommand)
                    {
                        try
                        {
                            Gameplay.MoveTiles(tilesMatrix, tileLabel);
                            movesCount++;
                            Gameplay.PrintMatrix(tilesMatrix);
                            isMatrixSolved = Gameplay.IsMatrixSolved(tilesMatrix);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            command = Command.IsCommandValid(command);
                        }
                        catch (ArgumentException exception)
                        {
                            Console.WriteLine(exception.Message);
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
                        Console.Write("Please enter your name for the top scoreboard: ");
                        string playerName = Console.ReadLine();
                        Player player = new Player(playerName, movesCount);
                        Scoreboard.AddPlayer(player);
                        Scoreboard.PrintScoreboard();
                    }
                    command = "restart";
                    isMatrixSolved = false;
                    movesCount = 0;
                }
            }
        }
    }
}
