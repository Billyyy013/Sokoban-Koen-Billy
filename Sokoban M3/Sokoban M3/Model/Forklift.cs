using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    class Forklift : Entity
    {
        public Forklift()
        {
            Symbol = '@';
            SymbolOnDestination = '@';
            Movable = false;
            Awake = true;
        }

        public override void ArrivedOnDestination(Maze maze, int value) { return; }

        public override bool Move(Maze maze, Tile moveTo)
        {
            moveTo.Entity = maze.CurrentForkLift.Entity;
            maze.CurrentForkLift.Entity = null;
            maze.CurrentForkLift = moveTo;
            return true;
        }

        public override void StepOnPitFall(Tile current) { return; }
    }
}
