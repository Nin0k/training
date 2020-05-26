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
            // string str1 = "написать программу, которая";
            //string str2 = "описание";

            Console.Write("Строка 1: ");
            string str1 = Console.ReadLine();

            Console.Write("Строка 2: ");
            string str2 = Console.ReadLine();

            StringBuilder str_new = new StringBuilder("");

            for (int i = 0; i < str1.Length; i++)
            {

                if (str2.Contains(str1[i]))
                {

                    str_new.Append(str1[i]);
                    str_new.Append(str1[i]);
                }
                else
                {
                    str_new.Append(str1[i]);
                }
            }
            Console.WriteLine(str_new);
            Console.ReadLine();
        }
    }
}
