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
            
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
                {
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            Console.WriteLine("up");
                            if (parser.maze.checkIfUpPossible())
                            {
                                moveUp();
                            }
                            parser.maze.printMaze();
                            break;
                        case ConsoleKey.DownArrow:
                            Console.WriteLine("down");
                            if (parser.maze.checkIfDownPossible())
                            {
                                moveDown();
                            }
                            parser.maze.printMaze();
                            break;
                        case ConsoleKey.LeftArrow:
                            Console.WriteLine("left");
                            if (parser.maze.checkIfLeftPossible())
                            {
                                moveLeft();
                            }
                            parser.maze.printMaze();
                            break;
                        case ConsoleKey.RightArrow:
                            Console.WriteLine("right");
                            if (parser.maze.checkIfRightPossible())
                            {
                                moveRight();
                            }
                            parser.maze.printMaze();
                            break;
                    }
                } else
                {
                    Console.WriteLine("Geen valide input");
                }
            }
        }

        public void moveUp()
        {
            Model.Tile[,] tiles = parser.maze.tiles;
            int x = parser.maze.forklift.xLoc;
            int y = parser.maze.forklift.yLoc;
            if (tiles[x - 1, y].displaySymbol.Equals('0')|| tiles[x - 1, y].displaySymbol.Equals('O'))
            {
                tiles[x - 1, y].loseBarrel();
                tiles[x - 2, y].obtainBarrel();
            }
            tiles[x, y].loseTruck();
            tiles[x-1, y].obtainTruck();

            parser.maze.forklift.xLoc = x - 1;
        }
        public void moveDown()
        {
            Model.Tile[,] tiles = parser.maze.tiles;
            int x = parser.maze.forklift.xLoc;
            int y = parser.maze.forklift.yLoc;
            if (tiles[x + 1, y].displaySymbol.Equals('0') || tiles[x + 1, y].displaySymbol.Equals('O'))
            {
                tiles[x + 1, y].loseBarrel();
                tiles[x + 2, y].obtainBarrel();
            }
            tiles[x, y].loseTruck();
            tiles[x + 1, y].obtainTruck();

            parser.maze.forklift.xLoc = x + 1;
        }
        public void moveLeft()
        {
            Model.Tile[,] tiles = parser.maze.tiles;
            int x = parser.maze.forklift.xLoc;
            int y = parser.maze.forklift.yLoc;
            if (tiles[x, y - 1].displaySymbol.Equals('0') || tiles[x, y - 1].displaySymbol.Equals('O'))
            {
                tiles[x, y - 1].loseBarrel();
                tiles[x, y - 2].obtainBarrel();
            }
            tiles[x, y].loseTruck();
            tiles[x, y - 1].obtainTruck();

            parser.maze.forklift.yLoc = y - 1;
        }
        public void moveRight()
        {
            Model.Tile[,] tiles = parser.maze.tiles;
            int x = parser.maze.forklift.xLoc;
            int y = parser.maze.forklift.yLoc;
            if (tiles[x, y + 1].displaySymbol.Equals('0') || tiles[x, y + 1].displaySymbol.Equals('O'))
            {
                tiles[x, y + 1].loseBarrel();
                tiles[x, y + 2].obtainBarrel();
            }
            tiles[x, y].loseTruck();
            tiles[x, y + 1].obtainTruck();

            parser.maze.forklift.yLoc = y + 1;
        }
    }
}
