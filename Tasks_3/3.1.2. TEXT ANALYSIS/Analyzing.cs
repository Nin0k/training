using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _3._1._2.TEXT_ANALYSIS
{
    class Analyzing
    {
        internal Analyzing(string originalString)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();

            string lowercaseString = originalString.ToLower();
            var arrayWords = lowercaseString.Split(new string[] { " ", ",", ";", ":", "/", ".", "!", "?" }, StringSplitOptions.RemoveEmptyEntries);

            int value = 0;
            for (int i = 0; i < arrayWords.Length; i++)
            {
                
                if (!words.ContainsKey(arrayWords[i]))
                {
                    words.Add(arrayWords[i], 1);
                }
                else
                {
                    value = words[arrayWords[i]] + 1;

                    words[arrayWords[i]] = value;
                }
            }
            Console.WriteLine("{0, -10}  {1,-4} {2}", "Слово" , "-", "Количество");

            Console.WriteLine(new string('_', 25));

            foreach (KeyValuePair<string, int> keyValue in words)
            {
                Console.WriteLine("{0, -10}  {1,-7} {2}", keyValue.Key, "-" , keyValue.Value);
            }

            int max = 0;
            int min = 0;

            maxWords();
            minWords();
            percentWords();

            void maxWords()
            {
                max = words.Max(s => s.Value);
                var rezultMax = words.Where(s => s.Value.Equals(max)).Select(s => s.Key).ToList();

                Console.WriteLine(new string('_', 25));
                Console.WriteLine($"Самые частые слова (встретились по {max} раза):");

                for (int i = 0; i < rezultMax.Count; i++)
                {

                    Console.Write($"{rezultMax[i]}; ");
                }
                Console.WriteLine();
            }

            void minWords()
            {
                min = words.Min(s => s.Value);
                var rezultMin = words.Where(s => s.Value.Equals(min)).Select(s => s.Key).Count();
                Console.WriteLine($"Количество уникальных слов  {rezultMin}.");
            }

            void percentWords()
            {
                int percentMeeting = (max * 100) / arrayWords.Length;

                if (percentMeeting < 20)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Это хороший текст! Процент максимального повтора слова: {percentMeeting}%.");
                }
                else if (percentMeeting > 20 && percentMeeting < 50)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Это нормальный текст. Процент максимального повтора слова: {percentMeeting}%.");
                }
                else if (percentMeeting > 50)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Это плохой текст! Процент максимального повтора слова: {percentMeeting}%.");
                }
            }
        }
    }
}
