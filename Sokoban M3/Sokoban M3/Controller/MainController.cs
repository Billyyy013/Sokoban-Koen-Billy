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
        public Model.Maze Maze { get; set; }
        public MainController()
        {
            outputView = new View.OutputView();
            inputView = new View.InputView();
            parser = new Parser();
            parser.BuildMaze(inputView.RetrieveMazeNumber());
            Maze = parser.Maze;
            outputView.PrintMaze(Maze.Height, Maze.Width, Maze.Tiles);
            MoveArrows();
            Console.ReadLine();
        }

        public void MoveArrows()
        {
            inputView.AskForArrowInput();

            while (Maze.AmountOfChests != Maze.AmountOfChestsOnDestination)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Model.Tile currentTile = Maze.Tiles[Maze.Forklift.XLoc, Maze.Forklift.YLoc];
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
                {
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            if (currentTile.Above.Above == null) { break;}
                            if (Maze.CheckIfPossible(currentTile.Above, currentTile.Above.Above))
                            {
                                Move(currentTile.Above, currentTile.Above.Above);
                                Maze.Forklift.XLoc--;
                            }
                            outputView.PrintMaze(Maze.Height, Maze.Width, Maze.Tiles);
                            break;
                        case ConsoleKey.DownArrow:
                            if (currentTile.Below.Below == null) { break; }
                            if (Maze.CheckIfPossible(currentTile.Below, currentTile.Below.Below))
                            {
                                Move(currentTile.Below, currentTile.Below.Below);
                                Maze.Forklift.XLoc++;
                            }
                            outputView.PrintMaze(Maze.Height, Maze.Width, Maze.Tiles);
                            break;
                        case ConsoleKey.LeftArrow:
                            if (currentTile.Left.Left == null) { break; }
                            if (Maze.CheckIfPossible(currentTile.Left, currentTile.Left.Left))
                            {
                                Move(currentTile.Left, currentTile.Left.Left);
                                Maze.Forklift.YLoc--;
                            }
                            outputView.PrintMaze(Maze.Height, Maze.Width, Maze.Tiles);
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentTile.Right.Right == null) { break; }
                            if (Maze.CheckIfPossible(currentTile.Right, currentTile.Right.Right))
                            {
                                Move(currentTile.Right, currentTile.Right.Right);
                                Maze.Forklift.YLoc++;
                            }
                            outputView.PrintMaze(Maze.Height, Maze.Width, Maze.Tiles);
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
            Model.Tile[,] tiles = Maze.Tiles;
            int x = Maze.Forklift.XLoc;
            int y = Maze.Forklift.YLoc;
            if (one.DisplaySymbol.Equals('O'))

            {
                one.LoseChest();
                if (two.OwnSymbol.Equals('x'))
                {
                    Maze.AmountOfChestsOnDestination++;
                    two.ObtainChest(Maze.Chest.SymbolOnDestination);
                }
                else
                {
                    two.ObtainChest(Maze.Chest.Symbol);
                }
            }
            else if (one.DisplaySymbol.Equals('0'))
            {
                one.LoseChest();
                Maze.AmountOfChestsOnDestination--;
                two.ObtainChest(Maze.Chest.Symbol);
                if (two.DisplaySymbol.Equals('0'))
                {
                    Maze.AmountOfChestsOnDestination++;
                }
            }
            tiles[x, y].LoseForklift();
            one.ObtainForklift(Maze.Forklift.Symbol);
        }

    }
}
