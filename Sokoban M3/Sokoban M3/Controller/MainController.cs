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
            Console.WriteLine("Gebruik een pijltjes toets.");
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Console.WriteLine("up");
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("down");
                    break;
                case ConsoleKey.LeftArrow:
                    Console.WriteLine("left");
                    break;
                case ConsoleKey.RightArrow:
                    Console.WriteLine("right");
                    break;
            }
        }

    }
}
