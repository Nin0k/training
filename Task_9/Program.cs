using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Массив:");

            int[] array = new int[20];
            Random rand = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-99, 99);
                Console.Write(" " + array[i]);
            }
            Console.WriteLine();
            int summ = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    summ += array[i];
                }
            }
            Console.Write("Cумма неотрицательных элементов: " + summ);
            Console.ReadLine();
        }
    }
}
