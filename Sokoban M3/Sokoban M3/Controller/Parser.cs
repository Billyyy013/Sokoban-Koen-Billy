using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban_M3.Model;

namespace Sokoban_M3.Controller
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
                //System.Console.WriteLine(line);

            }

            char[] characters = list[0].ToArray();
            Maze = new Maze(list.Count,characters.Length);
            for (int i = 0; i < list.Count; i++) { 
                characters = list[i].ToArray();
                for (int j = 0; j < characters.Length; j++)
                {
                    switch (characters[j])
                    {
                        case ' ':
                            Maze.Tiles[i, j] = new EmptyTile();
                            break;
                        case '.':
                            Maze.Tiles[i, j] = new Floor();
                            break;
                        case '#':
                            Maze.Tiles[i, j] = new Wall();
                            break;
                        case '@':
                            Maze.Tiles[i, j] = new Floor();
                            Maze.Tiles[i, j].ObtainForklift(Maze.Forklift.Symbol);
                            Maze.Forklift.XLoc = i;
                            Maze.Forklift.YLoc = j;
                            break;
                        case 'x':
                            Maze.Tiles[i, j] = new Destination();
                            break;
                        case 'o':
                            Maze.Tiles[i, j] = new Floor();
                            Maze.Tiles[i, j].ObtainChest(Maze.Chest.Symbol);
                            Maze.AmountOfChests++;
                            break;
                    }
                        
                }
         
            }
            Maze.SetRelativeTo();
        }
    }
}
