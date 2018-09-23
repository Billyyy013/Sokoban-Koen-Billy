using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    abstract class Entity
    {
        public int XLoc { get; set; }
        public int YLoc { get; set; }
        public char Symbol { get; set; }
    }
}
