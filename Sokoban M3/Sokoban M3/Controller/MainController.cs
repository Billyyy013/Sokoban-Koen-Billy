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
            Console.ReadLine();
        }


    }
}
