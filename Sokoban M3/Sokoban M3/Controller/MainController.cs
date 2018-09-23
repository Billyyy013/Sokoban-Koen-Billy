using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sokoban_M3.Controller
{
    class MainController
    {
        private View.OutputView outputView;
        private View.InputView inputView;
        private Parser parser;
        public Model.Maze maze { get; set; }
        public MainController()
        {
            outputView = new View.OutputView();
            inputView = new View.InputView();
            parser = new Parser();
            parser.buildMaze(inputView.RetrieveMazeNumber());
            maze = parser.maze;
            outputView.printMaze(maze.height, maze.width, maze.tiles);
            MoveArrows();
            Console.ReadLine();
        }

        public void MoveArrows()
        {
            inputView.askForArrowInput();

            while (maze.amountOfChests != maze.amountOfChestsOnDestination)
            {
                ConsoleKey key = Console.ReadKey().Key;
                int x = maze.forklift.xLoc;
                int y = maze.forklift.yLoc;
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
                {
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            if (maze.checkIfPossible(x - 1, x - 2, y, y))
                            {
                                move(x - 1, x - 2, y, y);
                            }
                            outputView.printMaze(maze.height, maze.width, maze.tiles);
                            break;
                        case ConsoleKey.DownArrow:
                            if (maze.checkIfPossible(x + 1, x + 2, y, y))
                            {
                                move(x + 1, x + 2, y, y);
                            }
                            outputView.printMaze(maze.height, maze.width, maze.tiles);
                            break;
                        case ConsoleKey.LeftArrow:
                            if (maze.checkIfPossible(x, x, y - 1, y - 2))
                            {
                                move(x, x, y - 1, y - 2);
                            }
                            outputView.printMaze(maze.height, maze.width, maze.tiles);
                            break;
                        case ConsoleKey.RightArrow:
                            if (maze.checkIfPossible(x, x, y + 1, y + 2))
                            {
                                move(x, x, y + 1, y + 2);
                            }
                            outputView.printMaze(maze.height, maze.width, maze.tiles);
                            break;
                    }
                }
                else
                {
                    inputView.invalidInputMessage();
                }
            }
            outputView.levelCompletedMessage();
        }

        public void move(int x1, int x2, int y1, int y2)
        {
            Model.Tile[,] tiles = maze.tiles;
            int x = maze.forklift.xLoc;
            int y = maze.forklift.yLoc;
            if (tiles[x1, y1].displaySymbol.Equals('O'))

            {
                tiles[x1, y1].loseBarrel();
                tiles[x2, y2].obtainBarrel();
                if (maze.tiles[x2, y2].displaySymbol.Equals('0'))
                {
                    maze.amountOfChestsOnDestination++;
                }
            }
            else if (tiles[x1, y1].displaySymbol.Equals('0'))
            {
                tiles[x1, y1].loseBarrel();
                maze.amountOfChestsOnDestination--;
                tiles[x2, y2].obtainBarrel();
                if (parser.maze.tiles[x2, y2].displaySymbol.Equals('0'))
                {
                    maze.amountOfChestsOnDestination++;
                }
            }
            tiles[x, y].loseTruck();
            tiles[x1, y1].obtainTruck();

            maze.forklift.xLoc = x1;
            maze.forklift.yLoc = y1;
        }

    }
}
