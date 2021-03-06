﻿using System;

namespace Sokoban_M3.Process
{
    class MainController
    {
        private Presentation.OutputView outputView;
        private Presentation.InputView inputView;
        private Parser parser;
        public Model.Maze Maze { get; set; }
        public MainController()
        {
            outputView = new Presentation.OutputView();
            inputView = new Presentation.InputView();
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
                ConsoleKey key = inputView.RetrieveConsoleKey();
                Model.Tile currentTile = Maze.CurrentForkLift;
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
                {
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            if (currentTile.Above.Above == null) { break; }
                            if (Maze.CurrentForkLift.Above.PutEntityOnThisField(Maze, Maze.CurrentForkLift, Maze.CurrentForkLift.Above.Above))
                            {
                                Maze.CurrentForkLift = Maze.CurrentForkLift.Above;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (currentTile.Below.Below == null) { break; }
                            if (Maze.CurrentForkLift.Below.PutEntityOnThisField(Maze, Maze.CurrentForkLift, Maze.CurrentForkLift.Below.Below))
                            {
                                Maze.CurrentForkLift = Maze.CurrentForkLift.Below;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (currentTile.Left.Left == null) { break; }
                            if (Maze.CurrentForkLift.Left.PutEntityOnThisField(Maze, Maze.CurrentForkLift, Maze.CurrentForkLift.Left.Left))
                            {
                                Maze.CurrentForkLift = Maze.CurrentForkLift.Left;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentTile.Right.Right == null) { break; }
                            if (Maze.CurrentForkLift.Right.PutEntityOnThisField(Maze, Maze.CurrentForkLift, Maze.CurrentForkLift.Right.Right))
                            {
                                Maze.CurrentForkLift = Maze.CurrentForkLift.Right;
                            }
                            break;
                    }
                    if (Maze.CurrentWorker!= null) { Maze.CurrentWorker.Entity.Move(Maze); }
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
