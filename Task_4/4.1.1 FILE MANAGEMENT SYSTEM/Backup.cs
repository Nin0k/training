using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace _4._1._1_FILE_MANAGEMENT_SYSTEM
{
    public class Backup
    {
        public Backup(string path)
        {
            // сохранение данных
            //string path = @"D:\Storage\";
            string pathBackup = @"D:\Backup storage\backup.json";
            string filter = "*.txt";
            string[] files = Directory.GetFiles(path, filter, SearchOption.AllDirectories);

            StructureJSON fileJSON = new StructureJSON();

            fileJSON.DateTime = DateTime.UtcNow.ToString();

            List<Files> listFiles = new List<Files>();

            foreach (string filename in files)
            {
                
                FileStream file1 = new FileStream(filename, FileMode.Open); 
                StreamReader reader = new StreamReader(file1); 

                Files file = new Files(filename, reader.ReadToEnd());
                listFiles.Add(file);

                reader.Close();
            }

            fileJSON.Files = listFiles;
            StreamWriter sw = new StreamWriter(File.Open(pathBackup, FileMode.Append));
           
            sw.WriteLine(JsonConvert.SerializeObject(fileJSON));
            
            sw.Close();
        }
    }
}
