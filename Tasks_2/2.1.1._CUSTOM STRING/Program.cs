using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangedString;


namespace Task_2._1._1_CUSTOM_STRING
{
   
    class Program
    {
        static void Main(string[] args)
        {
           
            СhangedString example = new СhangedString("hello");
            СhangedString example2 = new СhangedString("goodbye");

            example.GetInfo();
            Console.WriteLine();

            Console.WriteLine($"Строки равны? {example.СompareStrings(example2)}");
           
            СhangedString ex = example + example2;
            Console.WriteLine($"Конкатенация строк: {ex.NoArray()}");
           

            Console.WriteLine($"Индекс первого вхождения символа: {example.SearchChar('l', 1)}");
            Console.WriteLine($"Индекс последнего вхождения символа: {example.LastSearchChar('l')}");

            Console.WriteLine($"Идут ли два одинаковых символа подряд? {example.RepeatSymbol('l')}");
          
            example2.GetInfo();
            Console.ReadKey();
        }
    }
}
