using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _3._3._2.SUPER_STRING
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringToCheck = "Тысячадевятьсотвосьмидесятидевятимиллиметровый";
            
            Console.WriteLine($"Слово {stringToCheck} на {stringToCheck.CheckForLanguage()} языке");

            string stringToCheck2 = "Incomprehensibilities";
            Console.WriteLine($"Слово {stringToCheck2} на {stringToCheck2.CheckForLanguage()} языке");

            string stringToCheck3 = "0123456789";
            Console.WriteLine($"Слово {stringToCheck3} на {stringToCheck3.CheckForLanguage()} языке");


            string stringToCheck4 = "Комната13f";
            Console.WriteLine($"Слово {stringToCheck4} на {stringToCheck4.CheckForLanguage()} языке");



            Console.ReadLine();
        }
    }
    
}
