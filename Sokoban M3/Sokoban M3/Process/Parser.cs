using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban_M3.Model;

namespace Sokoban_M3.Process
{
    class Parser
    {
        public Model.Maze Maze { get; set; }
        public Parser()
        {
        }

        public void BuildMaze(int mazeNumber)
        {

            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            _filePath = Directory.GetParent(_filePath).FullName;
            _filePath = Directory.GetParent(Directory.GetParent(_filePath).FullName).FullName;
            _filePath += @"\Sokoban M3\Mazes\doolhof" + mazeNumber + ".txt";
            TextReader tr = new StreamReader(_filePath);

            string line;
            List<string> list = new List<string>();

            while ((line = tr.ReadLine()) != null)
            {
                list.Add(line);

            }

            char[] characters = list[0].ToArray();
            Maze = new Maze();
            Model.Tile[,] tiles = new Model.Tile[list.Count, characters.Length];
            for (int i = 0; i < list.Count; i++)
            {
                characters = list[i].ToArray();
                for (int j = 0; j < characters.Length; j++)
                {
                    switch (characters[j])
                    {
                        case ' ':
                            tiles[i, j] = new EmptyTile();
                            break;
                        case '.':
                            tiles[i, j] = new Floor();
                            break;
                        case '#':
                            tiles[i, j] = new Wall();
                            break;
                        case '@':
                            tiles[i, j] = new Floor();
                            tiles[i, j].Entity = new Model.Forklift();
                            Maze.CurrentForkLift = tiles[i, j];
                            break;
                        case 'x':
                            tiles[i, j] = new Destination();
                            break;
                        case 'o':
                            tiles[i, j] = new Floor();
                            tiles[i, j].Entity = new Chest();
                            Maze.AmountOfChests++;
                            break;
                        case '~':
                            tiles[i, j] = new Pitfall();
                            break;
                        case '$':
                            tiles[i, j] = new Floor();
                            tiles[i, j].Entity = new Worker();
                            Maze.CurrentWorker = tiles[i, j];
                            break;
                    }
                    if (Maze.First == null)
                    {
                        Maze.First = tiles[i, j];
                    }

                }

            }
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < characters.Length; j++)
                {
                    if (i - 1 > -1) { tiles[i, j].Above = tiles[i - 1, j]; }
                    if(i+1 < list.Count){tiles[i, j].Below = tiles[i + 1, j];
                    }
                    if (j-1>-1) {  tiles[i, j].Left = tiles[i, j - 1];
                    }
                    if(j+1 < characters.Length){  tiles[i, j].Right = tiles[i, j + 1];
                    }
                }
            }
        }
    }
}
