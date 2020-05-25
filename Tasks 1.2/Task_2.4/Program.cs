using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._4
{
    class Program
    {
      
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            // string str = "я плохо учил русский язык. забываю начинать предложения с заглавной. хорошо, что можно написать программу!";

            StringBuilder str_new = new StringBuilder(str);
            str_new[0] = char.ToUpper(str_new[0]);
            for (int i = 0; i < str_new.Length-1; i++)
            {
                if (str_new[i]== '.' || str_new[i] == '!' || str_new[i] == '?')
                {
                    if (str_new[i+1] == ' ')
                    {
                        str_new[i + 2] = char.ToUpper(str_new[i + 2]);
                    }
                    else
                    {
                        str_new[i + 1] = char.ToUpper(str_new[i + 1]);
                    }
                }
            }

            Console.WriteLine(str_new);
            Console.ReadLine();
        }
    }
}
