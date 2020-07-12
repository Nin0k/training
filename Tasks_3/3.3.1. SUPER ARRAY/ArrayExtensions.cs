using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3._1.SUPER_ARRAY
{
    public static class ArrayExtensions
    {
        public static double[] Modification(this double[] mass, Func<double, double> function)
        {
            if (function == null)
            {
                throw new NullReferenceException("Cannot call an empty delegate");
            }

            double[] newAMass = new double[mass.Length];

            for (int i = 0; i < mass.Length; i++)
            {
                newAMass[i] = function(mass[i]);
            }

            return newAMass;
        }

        public static double SumElements(this double[] mass)
        {
            return mass.Sum();
        }

        public static double AverageArray(this double[] mass)
        {
            return mass.Average();
        }

        public static double RepeatElements(this double[] mass)
        {
            double element = mass[0];
            int repeat;
            int maxRepeat = 1;

            for (int i = 0; i < mass.Length; i++)
            {
                repeat = mass.Count(e => e == mass[i]);

                if (repeat > maxRepeat)
                {
                    maxRepeat = repeat;
                    element = mass[i];

                }
            }

            if (maxRepeat == 1)
            {
                Console.WriteLine("Все элементы повторяются только по одному разу");
            }
            return element;
        }

    }
}
