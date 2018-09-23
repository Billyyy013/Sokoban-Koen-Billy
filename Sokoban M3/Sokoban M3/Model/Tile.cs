using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    abstract class Tile
    {
        public char ownSymbol { get; set;}
        public char displaySymbol { get; set;}
        public bool hasChest { get; set; }

        public Tile above { get; set;}
        public Tile below { get; set;}
        public Tile left { get; set;}
        public Tile right { get; set;}

        public virtual void ObtainChest(char Symbol)
        {
            displaySymbol = Symbol;
            hasChest = true;
        }

        public virtual void LoseChest()
        {
            displaySymbol = ownSymbol;
            hasChest = false;
        }

        public void ObtainForklift(char Symbol)
        {
            displaySymbol = Symbol;
        }

        public void LoseForklift()
        {
            displaySymbol = ownSymbol;
        }
    }
}
