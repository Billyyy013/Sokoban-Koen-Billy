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
            parser.BuildMaze(inputView.RetrieveMazeNumber());
            maze = parser.maze;
            outputView.PrintMaze(maze.height, maze.width, maze.tiles);
            MoveArrows();
            Console.ReadLine();
        }

        public void MoveArrows()
        {
            inputView.AskForArrowInput();

            while (maze.amountOfChests != maze.amountOfChestsOnDestination)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Model.Tile currentTile = maze.tiles[maze.forklift.xLoc, maze.forklift.yLoc];
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
                {
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            if (currentTile.above.above == null) { break;}
                            if (maze.CheckIfPossible(currentTile.above, currentTile.above.above))
                            {
                                Move(currentTile.above, currentTile.above.above);
                                maze.forklift.xLoc--;
                            }
                            outputView.PrintMaze(maze.height, maze.width, maze.tiles);
                            break;
                        case ConsoleKey.DownArrow:
                            if (currentTile.below.below == null) { break; }
                            if (maze.CheckIfPossible(currentTile.below, currentTile.below.below))
                            {
                                Move(currentTile.below, currentTile.below.below);
                                maze.forklift.xLoc++;
                            }
                            outputView.PrintMaze(maze.height, maze.width, maze.tiles);
                            break;
                        case ConsoleKey.LeftArrow:
                            if (currentTile.left.left == null) { break; }
                            if (maze.CheckIfPossible(currentTile.left, currentTile.left.left))
                            {
                                Move(currentTile.left, currentTile.left.left);
                                maze.forklift.yLoc--;
                            }
                            outputView.PrintMaze(maze.height, maze.width, maze.tiles);
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentTile.right.right == null) { break; }
                            if (maze.CheckIfPossible(currentTile.right, currentTile.right.right))
                            {
                                Move(currentTile.right, currentTile.right.right);
                                maze.forklift.yLoc++;
                            }
                            outputView.PrintMaze(maze.height, maze.width, maze.tiles);
                            break;
                    }
                }
                else
                {
                    inputView.InvalidInputMessage();
                }
            }
            outputView.LevelCompletedMessage();
        }

        public void Move(Model.Tile one, Model.Tile two)
        {
            Model.Tile[,] tiles = maze.tiles;
            int x = maze.forklift.xLoc;
            int y = maze.forklift.yLoc;
            if (one.displaySymbol.Equals('O'))

            {
                one.LoseChest();
                if (two.ownSymbol.Equals('x'))
                {
                    maze.amountOfChestsOnDestination++;
                    two.ObtainChest(maze.chest.SymbolOnDestination);
                }
                else
                {
                    two.ObtainChest(maze.chest.Symbol);
                }
            }
            else if (one.displaySymbol.Equals('0'))
            {
                one.LoseChest();
                maze.amountOfChestsOnDestination--;
                two.ObtainChest(maze.chest.Symbol);
                if (two.displaySymbol.Equals('0'))
                {
                    maze.amountOfChestsOnDestination++;
                }
            }
            tiles[x, y].LoseForklift();
            one.ObtainForklift(maze.forklift.Symbol);
        }

    }
}
