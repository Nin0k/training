using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите N:");
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                for (int j = N; j > i; j--)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k <= i*2; k++)
                {
                    Console.Write("*");
                }
                
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
