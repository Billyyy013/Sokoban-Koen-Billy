﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    class Destination : Tile
    {
        public Destination()
        {
            ownSymbol = 'x';
            displaySymbol = ownSymbol;
            hasBarrel = false;
        }

        public override void ObtainBarrel()
        {
            displaySymbol = '0';
        }
    }
}
