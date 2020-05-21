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

            try
            {
                uint N = uint.Parse(Console.ReadLine());

                for (uint i = 0; i < N; i++)
                {
                    for (uint j = N; j > i; j--)
                    {
                        Console.Write(" ");
                    }

                    for (uint k = 0; k <= i * 2; k++)
                    {
                        Console.Write("*");
                    }

                    Console.WriteLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка. Неверный формат числа.");
            }
            Console.ReadLine();
        }
    }
}
