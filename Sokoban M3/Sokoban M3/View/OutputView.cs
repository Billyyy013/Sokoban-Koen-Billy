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
            //string text = System.IO.File.ReadAllText("C:\\doolhof" + maze + ".txt");
            //string text = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Mazes\doolhof" + maze + ".txt");
            //string[] files = File.ReadAllLines(text);

            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            _filePath = Directory.GetParent(_filePath).FullName;
            _filePath = Directory.GetParent(Directory.GetParent(_filePath).FullName).FullName;
            _filePath += @"\Sokoban M3\Mazes\doolhof" + maze + ".txt";
            TextReader tr = new StreamReader(_filePath);

            string line;
            List<string> list = new List<string>();

            
            while ((line = tr.ReadLine()) != null)
            {
                list.Add(line);
                System.Console.WriteLine(line);

            }

            Console.ReadLine();
            
        }

        public int RetrieveMazeNumber()
        {
            int intTemp = Convert.ToInt32(Console.ReadLine());

            return intTemp;
        }


    }
}
