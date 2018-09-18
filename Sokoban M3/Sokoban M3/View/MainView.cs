using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.View
{
    class MainView
    {
        public MainView()
        {
            PrintGame();
            PrintField(RetrieveMazeNumber());
        }
        public void PrintGame()
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

        public void PrintField(int maze)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Billy\Desktop\School\Doolhof\doolhof" + maze + ".txt");


            System.Console.WriteLine(text);
            Console.ReadLine();
        }

        public int RetrieveMazeNumber()
        {
            int intTemp = Convert.ToInt32(Console.ReadLine());

            return intTemp;
        }


    }
}
