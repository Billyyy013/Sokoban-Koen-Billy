using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    class EmptyTile : Tile
    {
        public EmptyTile()
        {
            ownSymbol = ' ';
            displaySymbol = ownSymbol;
        }
    }
}
