using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1
{
    class Program
    {
      
        static void Main(string[] args)
        {
          //  string str = "Викентий хорошо отметил день рождения: покушал пиццу, посмотрел кино, пообщался со студентами в чате.";
            Console.Write("Введите строку:");
            string str = Console.ReadLine();
            string[] words = str.Split(new[] { ' ', '!', '?', ':', ';', ',', '.', '-' }, StringSplitOptions.RemoveEmptyEntries);
            int average = 0;

            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
                average += words[i].Length;
            }
            average /= words.Length;
            Console.WriteLine("Средняя длина слова: " + average);
            
            Console.ReadLine();
        }
    }
}
