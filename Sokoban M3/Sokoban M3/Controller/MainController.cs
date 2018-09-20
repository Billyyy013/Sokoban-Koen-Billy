using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sokoban_M3.Controller
{
    class MainController
    {
        private View.OutputView outputView;
        private View.InputView inputView;
        private Parser parser;
        public MainController()
        {
            outputView = new View.OutputView();
            inputView = new View.InputView();
            parser = new Parser();
            parser.buildMaze(outputView.RetrieveMazeNumber());
            MoveArrows();
            Console.ReadLine();
        }

        public void MoveArrows()
        {
            Console.WriteLine("Gebruik de pijltjes toetsen.");
            
            while (parser.maze.amountOfChests != parser.maze.amountOfChestsOnDestination)
            {
                ConsoleKey key = Console.ReadKey().Key;
                int x = parser.maze.forklift.xLoc;
                int y = parser.maze.forklift.yLoc;
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
                {
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            Console.WriteLine("up");
                            if (parser.maze.checkIfPossible(x-1,x-2,y,y))
                            {
                                move(x-1,x-2,y,y);
                            }
                            parser.maze.printMaze();
                            break;
                        case ConsoleKey.DownArrow:
                            Console.WriteLine("down");
                            if (parser.maze.checkIfPossible(x+1,x+2,y,y))
                            {
                                move(x + 1, x + 2, y, y);
                            }
                            parser.maze.printMaze();
                            break;
                        case ConsoleKey.LeftArrow:
                            Console.WriteLine("left");
                            if (parser.maze.checkIfPossible(x,x,y-1,y-2))
                            {
                                move(x, x, y - 1, y - 2);
                            }
                            parser.maze.printMaze();
                            break;
                        case ConsoleKey.RightArrow:
                            Console.WriteLine("right");
                            if (parser.maze.checkIfPossible(x,x,y+1,y+2))
                            {
                                move(x, x, y + 1, y + 2);
                            }
                            parser.maze.printMaze();
                            break;
                    }
                } else
                {
                    Console.WriteLine("Geen valide input");
                }
            }
            Console.WriteLine("Level Completed");
        }

        public void move(int x1, int x2, int y1, int y2)
        {
            Model.Tile[,] tiles = parser.maze.tiles;
            int x = parser.maze.forklift.xLoc;
            int y = parser.maze.forklift.yLoc;
            if (tiles[x1, y1].displaySymbol.Equals('O'))
                
            {
                tiles[x1, y1].loseBarrel();
                tiles[x2, y2].obtainBarrel();
                if (parser.maze.tiles[x2, y2].displaySymbol.Equals('0'))
                {
                    parser.maze.amountOfChestsOnDestination++;
                }
            }
            else if(tiles[x1, y1].displaySymbol.Equals('0'))
            {
                tiles[x1, y1].loseBarrel();
                parser.maze.amountOfChestsOnDestination--;
                tiles[x2, y2].obtainBarrel();
                if (parser.maze.tiles[x2,y2].displaySymbol.Equals('0'))
                {
                    parser.maze.amountOfChestsOnDestination++;
                }
            }
            tiles[x, y].loseTruck();
            tiles[x1, y1].obtainTruck();

            parser.maze.forklift.xLoc = x1;
            parser.maze.forklift.yLoc = y1;
        }
 
    }
}
