using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_M3.View
{
    class InputView
    {
        public InputView()
        {

        }

        public int RetrieveMazeNumber()
        {
            int intTemp = Convert.ToInt32(Console.ReadLine());

            return intTemp;
        }

        public void askForArrowInput()
        {
            Console.WriteLine("Gebruik de pijltjes toetsen.");
        }

        public void invalidInputMessage()
        {
            Console.WriteLine("Geen valide input probeer opnieuw");
        }
    }
}
