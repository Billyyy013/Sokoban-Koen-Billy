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
            Console.WriteLine("|      ~ : valkuil             |                          |");
            Console.WriteLine("└─────────────────────────────────────────────────────────┘");
            Console.WriteLine();
            Console.WriteLine("> Kies een doolhof (1 - 6), s = stop");

        }

        public void PrintMaze(Model.Tile first)
        {
            Console.WriteLine();
            Model.Tile horizontal = first;
            Model.Tile vertical = first;
            while (vertical != null)
            {
                while (horizontal !=null)
                {
                    Console.Write(horizontal.Symbol);
                    horizontal = horizontal.Right;
                }
                Console.WriteLine();
                vertical = vertical.Below;
                horizontal = vertical;
            }
        }

        public void LevelCompletedMessage()
        {
            Console.WriteLine("Level Completed!!!");
        }
    }
}
