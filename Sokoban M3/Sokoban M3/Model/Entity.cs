using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    abstract class Entity
    {
        public char Symbol { get; set; }
        public char SymbolOnDestination { get; set; }

        public abstract void ArrivedOnDestination(Maze maze, int value);
    }
}
