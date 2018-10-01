using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    class Wall : Tile
    {
        public override char Symbol { get; set; }
        public Wall()
        {
            Symbol = '█';
        }

        //You can't put a chest on a wall as such this methode will return false when used
        public override bool PutChestOnThisField(Chest chest) { return false; }

        //You can't put a forklift on a wall as such this methode will return false when used
        public override bool PutForkliftOnThisField(Tile current, Tile next) { return false; }
    }
}
