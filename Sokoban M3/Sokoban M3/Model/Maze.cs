using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    class Maze
    {
        public Forklift forklift { get; set; }

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
            forklift = new Forklift();
            tiles = new Tile[height, width];
            this.height = height;
            this.width = width;
        }

        public void setRelativeTo()
        {
            for (int i = 1; i < height; i++)
            {
                for (int j = 1; j < width; j++)
                {
                    if (tiles[i, j].ownSymbol.Equals('o') || tiles[i, j].ownSymbol.Equals('·'))
                    {
                        tiles[i, j].above = tiles[i - 1, j];
                        tiles[i, j].below = tiles[i + 1, j];
                        tiles[i, j].left = tiles[i, j - 1];
                        tiles[i, j].right = tiles[i, j + 1];
                    }
                }
            }
        }
         //█ · O 0 x @
        public bool checkIfPossible(int x1, int x2, int y1, int y2)
        {
            //int x = forklift.xLoc;
            //int y = forklift.yLoc;
            if (tiles[x1, y1].displaySymbol.Equals('█'))
            {
                return false;
            }
            if (tiles[x1, y1].displaySymbol.Equals('O')&& tiles[x2, y2].displaySymbol.Equals('█'))
            {
                return false;
            }

            if (tiles[x1, y1].displaySymbol.Equals('0') && tiles[x2, y2].displaySymbol.Equals('█'))
            {
                return false;
            }

            if (tiles[x1, y1].displaySymbol.Equals('O') && tiles[x2, y2].displaySymbol.Equals('0'))
            {
                return false;
            }

            if (tiles[x1, y1].displaySymbol.Equals('0') && tiles[x2, y2].displaySymbol.Equals('O'))
            {
                return false;
            }

            if (tiles[x1, y1].displaySymbol.Equals('O') && tiles[x2, y2].displaySymbol.Equals('O'))
            {
                return false;
            }

            if (tiles[x1, y1].displaySymbol.Equals('0') && tiles[x2, y2].displaySymbol.Equals('0'))
            {
                return false;
            }
            return true;
        }

        public void printMaze()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(tiles[i, j].displaySymbol);
                }
                Console.WriteLine();
            }
        }
    }
}
