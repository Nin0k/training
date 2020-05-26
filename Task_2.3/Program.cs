using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2
{

    class Program
    {
       
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
           // string str = "Антон хорошо начал утро: послушал Стинга, выпил кофе и посмотрел Звёздные Войны";
           
            var count = str.Split(new string[] { " ", ",", ";", ":", "/", ".", "!", "?" }, StringSplitOptions.RemoveEmptyEntries);
            int result = count.Length;

            for (int i = 0; i < count.Length; i++)
            {
                if (Char.IsUpper(count[i][0]))
                { 
                    result -= 1;
                }
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
