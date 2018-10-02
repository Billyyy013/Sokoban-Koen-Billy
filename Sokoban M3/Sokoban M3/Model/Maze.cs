using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    class Maze
    {
        public int AmountOfChests { get; set; }
        public int AmountOfChestsOnDestination { get; set; }

        public Tile Current { get; set; }
        public Tile First { get; set; }

        public Maze()
        {
        }
    }
}
