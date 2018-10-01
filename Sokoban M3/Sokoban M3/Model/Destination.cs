using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    class Destination : Tile
    {
        public override char Symbol
        {
            get
            {
                if (Forklift != null)
                {
                    return Forklift.Symbol;
                }
                else if (Chest != null)
                {
                    return Chest.SymbolOnDestination;
                }
                else
                {
                    return _symbol;
                }
            }
            set { }
        }
        public Destination()
        {
            _symbol = 'x';
        }

        public override bool PutChestOnThisField(Chest chest)
        {
            if (Chest == null)
            {
                this.Chest = chest;
                return true;
            }
            return false;
        }

        public override bool PutForkliftOnThisField(Tile current, Tile next)
        {
            if (Chest == null)
            {
                this.Forklift = current.Forklift;
                current.Forklift = null;
                return true;
            }
            else
            {
                if (next.PutChestOnThisField(this.Chest))
                {
                    this.Chest = null;
                    this.Forklift = current.Forklift;
                    current.Forklift = null;
                    return true;
                }
                return false;
            }
        }
    }
}
