using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    class Maze
    {
        private Forklift forklift;
        private Destination[] destinations;
        private Floor[] floors;
        private Wall[] walls;
        private Chest[] chests;
        private EmptyTile[] emptyTiles;
        public Tile[,] tiles { get; set; }

        private int height;
        private int width;
        
        public Maze(int height, int width)
        {
            tiles = new Tile[height,width];
            this.height = height;
            this.width = width;
        }

        public void printMaze()
        {
            for (int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    Console.Write(tiles[i, j].displaySymbol);
                }
                Console.WriteLine();
            }
        }
    }
}
