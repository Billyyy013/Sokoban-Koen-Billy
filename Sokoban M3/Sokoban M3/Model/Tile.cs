using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    abstract class Tile
    {
        public char OwnSymbol { get; set;}
        public char DisplaySymbol { get; set;}
        public bool HasChest { get; set; }

        public Tile Above { get; set;}
        public Tile Below { get; set;}
        public Tile Left { get; set;}
        public Tile Right { get; set;}

        public void ObtainChest(char symbol)
        {
            DisplaySymbol = symbol;
            HasChest = true;
        }

        public void LoseChest()
        {
            DisplaySymbol = OwnSymbol;
            HasChest = false;
        }

        public void ObtainForklift(char symbol)
        {
            DisplaySymbol = symbol;
        }

        public void LoseForklift()
        {
            DisplaySymbol = OwnSymbol;
        }
    }
}
