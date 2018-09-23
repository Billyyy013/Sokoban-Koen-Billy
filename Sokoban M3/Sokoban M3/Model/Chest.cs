using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    class Chest : Entity
    {
        public char SymbolOnDestination { get; set; }
        public Chest()
        {
            Symbol = 'O';
            SymbolOnDestination = '0';
        }
    }
}
