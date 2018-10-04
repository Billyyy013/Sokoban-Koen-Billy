using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    class Worker : Entity
    {
        private Random randomGen;
        private bool Awake { get; set; }
        public Worker()
        {
            Symbol = '$';
            SymbolOnDestination = '$';

            randomGen = new Random();
        }
        public override void ArrivedOnDestination(Maze maze, int value) { return; }

        public override void StepOnPitFall(Tile current) { return; }

        public bool CheckIfAwake()
        {
            int chance = randomGen.Next(1, 100);
            if (Awake)
            {
                chance = randomGen.Next(1, 100);
                if(chance > 0 && chance < 26)
                {
                    Awake = false;
                }
            }
            if (chance > 0 && chance < 11)
            {
                Awake = true;
            }
            return Awake;
        }
    }
}
