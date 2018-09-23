using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    abstract class Tile
    {
        public char ownSymbol { get; set;}
        public char displaySymbol { get; set;}
        public bool hasBarrel { get; set; }

        public Tile above { get; set;}
        public Tile below { get; set;}
        public Tile left { get; set;}
        public Tile right { get; set;}

        public virtual void ObtainBarrel()
        {
            displaySymbol = 'O';
            hasBarrel = true;
        }

        public virtual void LoseBarrel()
        {
            displaySymbol = ownSymbol;
            hasBarrel = false;
        }

        public void ObtainTruck()
        {
            displaySymbol = '@';
        }

        public void LoseTruck()
        {
            displaySymbol = ownSymbol;
        }
    }
}
