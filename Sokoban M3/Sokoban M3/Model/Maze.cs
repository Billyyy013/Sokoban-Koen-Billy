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

        public void countChestsOnDestiation()
        {
            int count = 0;
            Model.Tile horizontal = First;
            Model.Tile vertical = First;
            while (vertical != null)
            {
                while (horizontal != null)
                {
                    if (horizontal.Symbol.Equals('0')) { count++; }
                    horizontal = horizontal.Right;
                }
                vertical = vertical.Below;
                horizontal = vertical;
            }
            AmountOfChestsOnDestination = count;
        }
    }
}
