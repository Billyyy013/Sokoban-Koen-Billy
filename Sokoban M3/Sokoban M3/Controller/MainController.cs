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
        public MainController()
        {
            outputView = new View.OutputView();
            inputView = new View.InputView();
            parser = new Parser();
            parser.buildMaze(outputView.RetrieveMazeNumber());
            MoveArrows();
            Console.ReadLine();
        }

        public void MoveArrows()
        {
            Console.WriteLine("Gebruik de pijltjes toetsen.");
            
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
                {
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            Console.WriteLine("up");
                            if (parser.maze.checkIfUpPossible())
                            {
                                moveUp();
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            Console.WriteLine("down");
                            if (parser.maze.checkIfDownPossible())
                            {
                                moveDown();
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            Console.WriteLine("left");
                            if (parser.maze.checkIfLeftPossible())
                            {
                                moveLeft();
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            Console.WriteLine("right");
                            if (parser.maze.checkIfRightPossible())
                            {
                                moveRight();
                            }
                            break;
                    }
                } else
                {
                    Console.WriteLine("Geen valide input");
                }
            }
        }

        public void moveUp()
        {
        }
        public void moveDown()
        {
        }
        public void moveLeft()
        {
        }
        public void moveRight()
        {
        }
    }
}
