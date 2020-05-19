using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
             
            int[,,] array_3d = new int[5, 5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        array_3d[i,j,k] = rand.Next(-30, 30);
                        Console.Write(" " + array_3d[i, j, k]);
                    }
                    Console.WriteLine(" ");
                }
                Console.WriteLine(" ");
            }
            Console.ReadLine();
        }
    }
}
