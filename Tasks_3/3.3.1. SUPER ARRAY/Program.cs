using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3._1.SUPER_ARRAY
{
    
    
    class Program
    {
        static void Main(string[] args)
        {
            double[] mass = new double[] { 2, 6, 9, 15, 6, 3, 13 };
            double[] mass1;
            double[] mass2;
            double[] mass3;
            Console.WriteLine($"Исходный массив: ");
            foreach (var i in mass)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Сумма элементов: {mass.SumElements()}");

            Console.WriteLine($"Среднее значение: {mass.AverageArray()}");

             Console.WriteLine($"Самый часто повторяемый элемент: {mass.RepeatElements()}");
           
            mass1 = mass.Modification((a)=> a * a);


            Console.WriteLine($"Исходный массив возведенный в квадрат: ");
            foreach (var i in mass1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            mass2 = mass.Modification((a) => a * 3);

            Console.WriteLine($"Исходный массив умноженный на 3: ");
            foreach (var i in mass2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            mass3 = mass.Modification((a) => a / 2);

            Console.WriteLine($"Исходный массив деленный на 2: ");
            foreach (var i in mass3)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
   
}
