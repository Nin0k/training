using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3._2.SUPER_STRING
{
    public static class StringExtensions
    {
        public static string CheckForLanguage(this string stringToCheck)
        {
            stringToCheck = stringToCheck.ToLower();

            int RuCodeBegin = char.ConvertToUtf32("а", 0) - 1;
            int RuCodeEnd = char.ConvertToUtf32("я", 0) + 1;
            int RuCodeE = char.ConvertToUtf32("ё", 0);

            int EnCodeBegin = char.ConvertToUtf32("a", 0) - 1;
            int EnCodeEnd = char.ConvertToUtf32("z", 0) + 1;

            int NumCodeBegin = char.ConvertToUtf32("0", 0) - 1;
            int NumCodeEnd = char.ConvertToUtf32("9", 0) + 1;

            if (stringToCheck.All(s => s > RuCodeBegin && s < RuCodeEnd || s == RuCodeE))
            {
                return "Russian";
            }
            else if (stringToCheck.All(s => s > EnCodeBegin && s < EnCodeEnd))
            {
                return "English";
            }
            else if (stringToCheck.All(s => s > NumCodeBegin && s < NumCodeEnd))
            {
                return "Number";
            }
            return "Mixed";

        }
    }
}
