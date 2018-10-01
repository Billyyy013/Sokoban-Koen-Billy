using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    abstract class Tile
    {
        protected char _symbol;
        abstract public char Symbol { get; set; }
        public bool HasChest { get; set; }
        public bool HasForklift { get; set; }

        public Tile Above { get; set;}
        public Tile Below { get; set;}
        public Tile Left { get; set;}
        public Tile Right { get; set;}

        public Forklift Forklift { get; set; }
        public Chest Chest { get; set; }

        public abstract bool PutForkliftOnThisField(Tile current ,Tile next);
        public abstract bool PutChestOnThisField(Chest chest);
    }
}
