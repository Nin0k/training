using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Написать программу, которая определяет площадь прямоугольника со сторонами a и b. 
             * Если пользователь вводит некорректные значения (отрицательные или ноль), 
             * должно выдаваться сообщение об ошибке. Возможность ввода пользователем строки вида 
             * «абвгд» или нецелых чисел игнорировать.
             * 
             */
            Console.Write("Введите ширину прямоугольника:");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите высоту прямоугольника:");
            int b = int.Parse(Console.ReadLine());

            if ((a <= 0)||(b <= 0))
            {
                Console.WriteLine("Ошибка! Введите корректные значения.");
            }
            else
            {
                int S = a * b;
                Console.WriteLine("Площадь прямоугольника:" + S);
            }
           
            Console.ReadLine();

        }
    }
}
