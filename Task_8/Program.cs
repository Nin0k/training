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
             
            int[,,] array_3d = new int[2, 5, 5];
            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < 2; i++)
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

            Console.WriteLine("Новый массив: ");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        if(array_3d[i, j, k] > 0)
                        {
                            array_3d[i, j, k] = 0;
                        }
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
