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
                    if (tiles[i, j].ownSymbol.Equals('o') || tiles[i, j].ownSymbol.Equals('·')|| tiles[i,j].ownSymbol.Equals('x'))
                    {
                        tiles[i, j].above = tiles[i - 1, j];
                        tiles[i, j].below = tiles[i + 1, j];
                        tiles[i, j].left = tiles[i, j - 1];
                        tiles[i, j].right = tiles[i, j + 1];
                    }
                }
            }
        }

        public bool CheckIfPossible(Tile one, Tile two)
        {
            if (one.displaySymbol.Equals('█'))
            {
                return false;
            }
            if (one.hasChest && two.displaySymbol.Equals('█'))
            {
                return false;
            }
            if (one.hasChest && two.hasChest)
            {
                return false;
            }

            return true;
        }
    }
}
