using System;
using System.IO;

namespace _4._1._1_FILE_MANAGEMENT_SYSTEM
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите режим:");
                Console.WriteLine("\t 1. Режим наблюдения.");
                Console.WriteLine("\t 2. Режим отката изменений.");
                Console.WriteLine("\t 3. Выход.");
                if (int.TryParse(Console.ReadLine(), out int mode))
                {

                    switch (mode)
                    {
                        case 1:

                            Console.WriteLine("Задайте путь к папке, которую требуется отслеживать.");
                            Console.WriteLine(@"Формат ввода: D:\Storage.");
                            string path = Console.ReadLine();
                           
                            if (!Directory.Exists(path))
                            {
                                Console.WriteLine("Такой папки не существует или путь введен неверно.");
                            }
                            else
                            {
                                new Surveillance(path);
                            }

                            break;
                        case 2:

                            new Recovery();
                            break;

                        case 3:

                            Environment.Exit(0);
                            break;

                        default:

                            Console.WriteLine("К сожалению, такого режима нет");
                            break;
                    }
                }
                Console.ReadLine();
            }

        }
    }

}
