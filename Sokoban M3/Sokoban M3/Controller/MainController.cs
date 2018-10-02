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
                            if (Maze.Current.Above.PutEntityOnThisField(Maze, Maze.Current, Maze.Current.Above.Above))
                            {
                                Maze.Current = Maze.Current.Above;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (currentTile.Below.Below == null) { break; }
                            if (Maze.Current.Below.PutEntityOnThisField(Maze, Maze.Current, Maze.Current.Below.Below))
                            {
                                Maze.Current = Maze.Current.Below;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (currentTile.Left.Left == null) { break; }
                            if (Maze.Current.Left.PutEntityOnThisField(Maze, Maze.Current, Maze.Current.Left.Left))
                            {
                                Maze.Current = Maze.Current.Left;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentTile.Right.Right == null) { break; }
                            if (Maze.Current.Right.PutEntityOnThisField(Maze, Maze.Current, Maze.Current.Right.Right))
                            {
                                Maze.Current = Maze.Current.Right;
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
