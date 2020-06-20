using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _2._2._1.GAME
{
    class Program
    {
       
        static void Main(string[] args)
        {
                new Game();
        }
    }
   
    class GameOver
    {
        public GameOver(int code)
        {
            Console.Clear();
            if (code == 1)
            {
                Console.Write("Вы выиграли!");
            }
            else
            {
                Console.Write("Вы проиграли!");
            }
            
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }
   
}
