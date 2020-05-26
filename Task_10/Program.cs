using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10
{
    class Program
    {
        static void Main(string[] args)
        {

            Random rand = new Random();

            int[,] array_2d = new int[5, 5];
            Console.WriteLine("Массив: ");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    array_2d[i, j] = rand.Next(-30, 30);
                    Console.Write(" " + array_2d[i, j]);
                }
                Console.WriteLine(" ");
            }
            int summ = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int parity = (i + j) % 2;
                    if (parity == 0)
                    {
                        summ += array_2d[i, j];
                    }
                }
            }
            Console.Write("Сумма элементов массива, стоящих на чётных позициях: " + summ);
            Console.ReadLine();
        }
    }
}
