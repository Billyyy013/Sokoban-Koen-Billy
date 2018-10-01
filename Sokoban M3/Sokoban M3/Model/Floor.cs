using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    class Floor : Tile
    {
        public override char Symbol
        {
            get
            {
                if (HasForklift == true)
                {
                    return Forklift.Symbol;
                }
                else if (HasChest == true)
                {
                    return Chest.Symbol;
                }
                else
                {
                    return _symbol;
                }
            }
            set { }
        }
        public Floor()
        {
            _symbol = '·';
            HasChest = false;
            HasForklift = false;
        }

        public override bool PutChestOnThisField(Chest chest)
        {
            if (!HasChest)
            {
                this.Chest = chest;
                HasChest = true;
                return true;
            }
            return false;
        }

        public override bool PutForkliftOnThisField(Tile current , Tile next)
        {
            if (!HasChest)
            {
                this.Forklift = current.Forklift;
                HasForklift = true;
                current.HasForklift = false;
                current.Forklift = null;
                return true;
            }
            else
            {
                if (next.PutChestOnThisField(this.Chest))
                {
                    this.Chest = null;
                    HasChest = false;
                    this.Forklift = current.Forklift;
                    HasForklift = true;
                    current.HasForklift = false;
                    current.Forklift = null;
                    return true;
                }
                return false;
            }
            
        }
    }
}
            
