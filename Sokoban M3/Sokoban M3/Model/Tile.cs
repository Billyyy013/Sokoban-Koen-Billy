using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    class Tile
    {
        protected char ownSymbol { get; set;}
        public char displaySymbol { get; set;}

        public void getBarrel()
        {
            displaySymbol = 'o';
        }

        public void loseBarrel()
        {
            displaySymbol = ownSymbol;
        }

        public void getTruck()
        {
            displaySymbol = '@';
        }

        public void loseTruck()
        {
            displaySymbol = ownSymbol;
        }
    }
}
