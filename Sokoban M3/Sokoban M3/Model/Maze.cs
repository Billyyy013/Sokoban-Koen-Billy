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
        public Tile[,] tiles { get; set; }
        public int amountOfChests { get; set; }
        public int amountOfChestsOnDestination { get; set; }

        public int height { get; }
        public int width { get; }

        public Maze(int height, int width)
        {
            forklift = new Forklift();
            tiles = new Tile[height, width];
            this.height = height;
            this.width = width;
        }

        public void SetRelativeTo()
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

        public bool CheckIfPossible(int x1, int x2, int y1, int y2)
        {
            if (tiles[x1, y1].displaySymbol.Equals('█'))
            {
                return false;
            }
            if (tiles[x1, y1].displaySymbol.Equals('O') && tiles[x2, y2].displaySymbol.Equals('█'))
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
    }
}
