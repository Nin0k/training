using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1._1.WEAKEST_LINK
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите N:");
                if (int.TryParse(Console.ReadLine(), out int N) && N > 0)
                {
                    Console.Write("Введите, какой по счету человек будет вычеркнут каждый раунд:");
                    if (int.TryParse(Console.ReadLine(), out int exclude) && exclude < N)
                    {

                        List<int> people = new List<int>(N);

                        for (int i = 0; i < N; i++)
                        {
                            people.Add(i + 1);
                        }

                        Console.WriteLine($"Сгенерирован круг из {N} людей. Начинаем вычеркивать каждого {exclude}-го.");

                        int step = exclude - 1;
                        int index = 0;
                        int counter = 1;

                        while (step < people.Count)
                        {

                            index = (index + step) % people.Count;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Раунд {counter}. Вычеркнут { people[index]}-й человек. Людей осталось: {people.Count - 1}");

                            people.RemoveAt(index);
                            counter++;

                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше людей.");

                        foreach (int i in people)
                        {
                            Console.WriteLine($"Остался {i}-й человек");
                        }

                    }
                    else
                    {
                        Console.WriteLine(" Невозможно начать вычеркивать. Введите значение больше N. ");
                    }

                }
                else
                {
                    Console.WriteLine(" Введите значение больше 0. ");
                }


                Console.ReadLine();
            }
        }
    }
}
