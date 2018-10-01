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
            outputView.PrintMaze(Maze.First);
            MoveArrows();
            Console.ReadLine();
        }

        public void MoveArrows()
        {
            inputView.AskForArrowInput();

            while (Maze.AmountOfChests != Maze.AmountOfChestsOnDestination)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Model.Tile currentTile = Maze.Current;
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
                {
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            if (currentTile.Above.Above == null) { break; }
                            if (Maze.Current.Above.PutForkliftOnThisField(Maze.Current, Maze.Current.Above.Above))
                            {
                                Maze.Current = Maze.Current.Above;
                                Maze.countChestsOnDestiation();
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (currentTile.Below.Below == null) { break; }
                            if (Maze.Current.Below.PutForkliftOnThisField(Maze.Current, Maze.Current.Below.Below))
                            {
                                Maze.Current = Maze.Current.Below;
                                Maze.countChestsOnDestiation();
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (currentTile.Left.Left == null) { break; }
                            if (Maze.Current.Left.PutForkliftOnThisField(Maze.Current, Maze.Current.Left.Left))
                            {
                                Maze.Current = Maze.Current.Left;
                                Maze.countChestsOnDestiation();
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentTile.Right.Right == null) { break; }
                            if (Maze.Current.Right.PutForkliftOnThisField(Maze.Current, Maze.Current.Right.Right))
                            {
                                Maze.Current = Maze.Current.Right;
                                Maze.countChestsOnDestiation();
                            }
                            break;
                    }
                    outputView.PrintMaze(Maze.First);
                }
                else
                {
                    inputView.InvalidInputMessage();
                }
            }
            outputView.LevelCompletedMessage();
        }
    }
}
