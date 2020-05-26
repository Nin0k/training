using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите N:");

            try
            {
                uint N = uint.Parse(Console.ReadLine());

                for (uint i = 0; i <= N; i++)
                {

                    for (uint l = 0; l < i; l++)
                    {

                        for (uint j = N; j > l; j--)
                        {
                            Console.Write(" ");
                        }
                        for (uint k = 0; k <= l * 2; k++)
                        {
                            Console.Write("*");
                        }

                        Console.WriteLine();
                    }
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
