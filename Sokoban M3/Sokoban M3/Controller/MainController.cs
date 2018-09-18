using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Controller
{
    class MainController
    {
        Model.Maze maze;
        View.MainView mainView;
        public MainController()
        {
            maze = new Model.Maze();
            mainView = new View.MainView();
        }
    }
}
