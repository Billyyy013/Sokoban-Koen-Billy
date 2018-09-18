using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban_M3.View;

namespace Sokoban_M3
{
    class Program
    {

        static void Main(string[] args)
        {
            Controller.MainController mc = new Controller.MainController();
            MainView mv = new MainView();
            mv.printGame();
        }
    }
}
