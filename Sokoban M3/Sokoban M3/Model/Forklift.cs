﻿using System;
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
        }

        public override void ArrivedOnDestination(Maze maze, int value) { return; }
    }
}
