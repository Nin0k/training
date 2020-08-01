using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace _4._1._1_FILE_MANAGEMENT_SYSTEM
{
    class Recovery
    {
        string pathBackup = @"D:\Backup storage";
        private readonly Dictionary<int, List<Files>> list = new Dictionary<int, List<Files>>();
        private readonly List<String> listData = new List<String>();
        public Recovery()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(pathBackup);
            if (!dirInfo.Exists)
            {
                NoBackup();
            }
            else
            {
                StreamReader sr = new StreamReader(pathBackup + "\\backup.json");
                int number = 0;

                while (sr.Peek() >= 0)
                {
                    StructureJSON versionsRestore = JsonConvert.DeserializeObject<StructureJSON>(sr.ReadLine());
                    listData.Add(versionsRestore.DateTime);
                    list.Add(number, versionsRestore.Files);

                    ++number;
                }
                sr.Close();

                if (listData.Count == 0)
                {
                    NoBackup();
                }

                else
                {
                    Console.WriteLine("Выберите дату восстановления:");
                    number = 0;

                    foreach (var item in listData)
                    {
                        Console.WriteLine($"{number++} - {item}");
                    }

                    if (int.TryParse(Console.ReadLine(), out int selectedDate))
                    {

                        foreach (var item in list[selectedDate])
                        {
                            Console.WriteLine(item.Name);
                            ExtractionFile(item.Name, item.FileContents, selectedDate);
                        }
                    }
                }
            }
        }

        void ExtractionFile(string pathFale, string fileContents, int selectedDate)
        {
            string[] pathMass = pathFale.Split(new char[] { '\\' });
            string path1 = "";

            path1 = String.Concat(path1, pathMass[0]);

            for (int i = 1; i < pathMass.Length - 1; i++)
            {
                path1 = String.Concat(path1, "\\");
                path1 = String.Concat(path1, pathMass[i]);
            }

            DirectoryInfo dirInfo = new DirectoryInfo(path1);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            StreamWriter sw = new StreamWriter(pathFale, false);

            sw.Write(fileContents);
            Console.WriteLine($"Версия от {listData[selectedDate]} восстановлена.");
            Console.WriteLine();
            sw.Close();
        }

        void NoBackup ()
        {
            Console.WriteLine("Не найдено ни одной резервной копии.");
        }
    }
}
