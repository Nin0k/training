using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    class Program
    {
        [Flags]
        enum Font : byte
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }
        static void Main(string[] args)
        {
            var type_font = Font.None;
            
            while (true)
            {
                Console.WriteLine("Введите:");
                Console.WriteLine("     1: bold");
                Console.WriteLine("     2: italic");
                Console.WriteLine("     3: underline");
                int font_new = int.Parse(Console.ReadLine());

                switch (font_new)
                {
                    case 1:
                        type_font = type_font ^ Font.Bold;
                        break;
                    case 2:
                        type_font = type_font ^ Font.Italic;
                        break;
                    case 3:
                        type_font = type_font ^ Font.Underline;
                        break;
                    default:
                        Console.WriteLine("Вы ввели неизвестное число");
                        break;
                }
                Console.WriteLine("Параметры надписи: " + type_font);
            }
            
        }
    }
}
