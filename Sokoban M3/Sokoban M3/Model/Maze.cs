using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Model
{
    class Maze
    {
        public Forklift Forklift { get; set; }
        public Chest Chest { get; set; }
        public Tile[,] Tiles { get; set; }
        public int AmountOfChests { get; set; }
        public int AmountOfChestsOnDestination { get; set; }

        public int Height { get; }
        public int Width { get; }

        public Maze(int height, int width)
        {
            Forklift = new Forklift();
            Chest = new Chest();
            Tiles = new Tile[height, width];
            this.Height = height;
            this.Width = width;
        }

        public void SetRelativeTo()
        {
            for (int i = 1; i < Height; i++)
            {
                for (int j = 1; j < Width; j++)
                {
                    if (Tiles[i, j].OwnSymbol.Equals('o') || Tiles[i, j].OwnSymbol.Equals('·')|| Tiles[i,j].OwnSymbol.Equals('x'))
                    {
                        Tiles[i, j].Above = Tiles[i - 1, j];
                        Tiles[i, j].Below = Tiles[i + 1, j];
                        Tiles[i, j].Left = Tiles[i, j - 1];
                        Tiles[i, j].Right = Tiles[i, j + 1];
                    }
                }
            }
        }

        public bool CheckIfPossible(Tile one, Tile two)
        {
            if (one.DisplaySymbol.Equals('█'))
            {
                return false;
            }
            if (one.HasChest && two.DisplaySymbol.Equals('█'))
            {
                return false;
            }
            if (one.HasChest && two.HasChest)
            {
                return false;
            }

            return true;
        }
    }
}
