using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    class Tile
    {
        public char ownSymbol { get; set;}
        public char displaySymbol { get; set;}

        public Tile above { get; set;}
        public Tile below { get; set;}
        public Tile left { get; set;}
        public Tile right { get; set;}

        public void obtainBarrel()
        {
            displaySymbol = 'O';
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
