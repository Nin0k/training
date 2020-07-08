using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _3._1._2.TEXT_ANALYSIS
{
    class Program
    {
        static void Main(string[] args)
        {
            //string originalString = "It took Her two weeks to write her last letter with revisions and corrected spelling. A journalist looked thoughtful, started to write";

            Console.WriteLine("Введите текст:");
            string originalString = Console.ReadLine();

            Console.Write("Идет анализ текста");

            for (int i = 0; i< 20; i++)
            {
                Console.Write(".");
                Thread.Sleep(10);
            }

            Console.WriteLine(".");
            new Analyzing(originalString);
            

            Console.ReadLine();
        }

        
    }
 
}
