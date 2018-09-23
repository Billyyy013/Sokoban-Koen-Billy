using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.View
{
    class OutputView
    {
        public OutputView()
        {
            PrintWelcomeMessage();
        }
        public void PrintWelcomeMessage()
        {
            Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
            Console.WriteLine("| Welkom bij Sokoban                                      |");
            Console.WriteLine("|                                                         |");
            Console.WriteLine("| Betekenis van de symbolen    |    Doel van het spel     |");
            Console.WriteLine("|                              |                          |");
            Console.WriteLine("| spatie : outerspace          |    Duw met de truck      |");
            Console.WriteLine("|      █ : muur                |    De krat(ten)          |");
            Console.WriteLine("|      · : vloer               |    naar de bestemming    |");
            Console.WriteLine("|      O : krat                |                          |");
            Console.WriteLine("|      0 : krat op bestemming  |                          |");
            Console.WriteLine("|      x : bestemming          |                          |");
            Console.WriteLine("|      @ : truck               |                          |");
            Console.WriteLine("└─────────────────────────────────────────────────────────┘");
            Console.WriteLine();
            Console.WriteLine("> Kies een doolhof (1 - 4), s = stop");

        }

        public void PrintMaze(int height, int width, Model.Tile[,] tiles)
        {
            Console.WriteLine();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(tiles[i, j].displaySymbol);
                }
                Console.WriteLine();
            }
        }

        public void LevelCompletedMessage()
        {
            Console.WriteLine("Level Completed!!!");
        }
    }
}
