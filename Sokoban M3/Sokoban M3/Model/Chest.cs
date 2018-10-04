using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    class Chest : Entity
    {
        public Chest()
        {
            Symbol = 'O';
            SymbolOnDestination = '0';
        }

        public override void ArrivedOnDestination(Maze maze, int value)
        {
            if (value == 1)
            {
                maze.AmountOfChestsOnDestination++;
            }
            else
            { 
                maze.AmountOfChestsOnDestination--;
            }   
        }

        public override void Move(Maze maze) { return; }

        public override void StepOnPitFall(Tile current)
        {
            current.Entity = null;
        }
    }
}
