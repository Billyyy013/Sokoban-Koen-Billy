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
        public Model.Maze maze { get; set; }
        public Parser()
        {
        }

        public void buildMaze(int mazeNumber)
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
            maze = new Maze(list.Count,characters.Length);
            for (int i = 0; i < list.Count; i++) { 
                characters = list[i].ToArray();
                for (int j = 0; j < characters.Length; j++)
                {
                    switch (characters[j])
                    {
                        case ' ':
                            maze.tiles[i, j] = new EmptyTile();
                            break;
                        case '.':
                            maze.tiles[i, j] = new Floor();
                            break;
                        case '#':
                            maze.tiles[i, j] = new Wall();
                            break;
                        case '@':
                            maze.tiles[i, j] = new Floor();
                            maze.tiles[i, j].obtainTruck();
                            maze.forklift.xLoc = i;
                            maze.forklift.yLoc = j;
                            break;
                        case 'x':
                            maze.tiles[i, j] = new Destination();
                            break;
                        case 'o':
                            maze.tiles[i, j] = new Floor();
                            maze.tiles[i, j].obtainBarrel();
                            break;
                    }
                        
                }
         
            }
            maze.printMaze();
            maze.setRelativeTo();
        }
    }
}
