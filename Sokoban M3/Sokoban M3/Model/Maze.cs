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

        private Random randomGen;

        public Maze()
        {
            randomGen = new Random();
        }

        public Tile ReturnRandomDestination()
        {
            int number = randomGen.Next(1, 100);
            if(number > 0 && number < 26)
            {
                return this.Current.Above;
            } else if(number > 25 && number < 51)
            {
                return this.Current.Left;
            } else if(number > 50 && number < 76)
            {
                return this.Current.Below;
            } else
            {
                return this.Current.Right;
            }
        }
    }
}
