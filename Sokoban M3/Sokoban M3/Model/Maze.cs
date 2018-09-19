using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    class Maze
    {
        public Forklift forklift { get; set;}
        
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

        public void setRelativeTo()
        {
            for (int i = 1; i < height; i++)
            {
                for (int j = 1; j < width;j++)
                {
                    if (tiles[i, j].ownSymbol.Equals('o')|| tiles[i, j].ownSymbol.Equals('·'))
                    {
                        tiles[i, j].above = tiles[i-1, j];
                        tiles[i, j].below = tiles[i + 1, j];
                        tiles[i, j].left = tiles[i, j-1];
                        tiles[i, j].right = tiles[i, j+1];
                    }
                }
            }
        }

        public bool checkIfUpPossible()
        {
            return true;
        }

        public bool checkIfDownPossible()
        {
            return true;
        }

        public bool checkIfLeftPossible()
        {
            return true;
        }

        public bool checkIfRightPossible()
        {
            return true;
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
