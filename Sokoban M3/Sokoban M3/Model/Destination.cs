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
                if (Entity != null)
                {
                    return Entity.SymbolOnDestination;
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

        public override bool PutEntityOnThisField(Maze maze, Tile previous, Tile next)
        {
            if (Entity == null)
            {
                Entity = previous.Entity;
                previous.Entity = null;
                Entity.ArrivedOnDestination(maze, 1);
                return true;
            }
            else
            {
                if (next.Entity != null) { return false; }
                if (next.PutEntityOnThisField(maze, this, next))
                {
                    Entity = previous.Entity;
                    previous.Entity = null;
                    maze.AmountOfChestsOnDestination--;
                    return true;
                }
                return false;
            }
        }
    }
}
