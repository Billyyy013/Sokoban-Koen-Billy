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
        public override char Symbol
        {
            get
            {
                if (Awake == true)
                {
                    return '$';
                }
                else
                {
                    return 'z';
                }
            }
            set { }
        }
        public Worker()
        {
            Symbol = '$';
            SymbolOnDestination = '$';
            Movable = false;
            Awake = true;
            randomGen = new Random();
        }
        public override void ArrivedOnDestination(Maze maze, int value) { return; }

        public override void StepOnPitFall(Tile current) { return; }

        private bool CheckIfAwake()
        {
            int chance;
            if (Awake)
            {
                chance = randomGen.Next(1, 100);
                if(chance > 0 && chance < 26)
                {
                    Awake = false;
                    Symbol = 'z';
                    SymbolOnDestination = 'z';
                    return Awake;
                }
            }
            chance = randomGen.Next(1,100);
            if (chance > 0 && chance < 11)
            {
                Awake = true;
                Symbol = '$';
                SymbolOnDestination = '$';
                return Awake;
            }
            return Awake;
        }

        public override bool Move(Maze maze, Tile moveTo)
        {
            if (!CheckIfAwake())
            {
                return false;
            }
            Tile[] tiles = ReturnRandomDestination(maze);
            if (tiles[1] == null) { return false; }
            if (tiles[0].PutEntityOnThisField(maze, maze.CurrentWorker, tiles[1]))
            {
                maze.CurrentWorker = tiles[0];
            }
            return false;
        }

        public Tile[] ReturnRandomDestination(Maze maze)
        {
            int number = randomGen.Next(1, 100);
            Tile[] tiles = new Tile[2];
            if (number > 0 && number < 26)
            {
                tiles[0] = maze.CurrentWorker.Above;
                tiles[1] = maze.CurrentWorker.Above.Above;
                return tiles;
            }
            else if (number > 25 && number < 51)
            {
                tiles[0] = maze.CurrentWorker.Left;
                tiles[1] = maze.CurrentWorker.Left.Left;
                return tiles;
            }
            else if (number > 50 && number < 76)
            {
                tiles[0] = maze.CurrentWorker.Below;
                tiles[1] = maze.CurrentWorker.Below.Below;
                return tiles;
            }
            else
            {
                tiles[0] = maze.CurrentWorker.Right;
                tiles[1] = maze.CurrentWorker.Right.Right;
                return tiles;
            }
        }
    }
}
