using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Controller
{
    class Parser
    {
        public Model.Maze maze {get;}
        public Parser()
        {
            maze = new Model.Maze();
        }
    }
}
