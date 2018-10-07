using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.Presentation
{
    class InputView
    {
        public InputView()
        {

        }

        public int RetrieveMazeNumber()
        {
            int intTemp;
            while (true)
            {
                string s = Console.ReadLine();
                if (int.TryParse(s, out intTemp))
                {

                    intTemp = Convert.ToInt32(s);
                    if (intTemp > 0 && intTemp < 7)
                    {
                        Console.WriteLine("Succes");
                        break;
                    } 

                }
                if (s.Equals("s"))
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Ongeldige input");
                }
            }
            return intTemp;
        }

        public void AskForArrowInput()
        {
            Console.WriteLine("Gebruik de pijltjes toetsen.");
        }

        public ConsoleKey RetrieveConsoleKey()
        {
            ConsoleKey key = Console.ReadKey().Key;
            return key;
        }

        public void InvalidInputMessage()
        {
            Console.WriteLine("Geen valide input probeer opnieuw");
        }
    }
}
