using System;
using System.IO;
using System.Security.Permissions;
using Newtonsoft.Json;

namespace _4._1._1_FILE_MANAGEMENT_SYSTEM
{
    public class Surveillance
    {
        static StructureLog fileLog = new StructureLog();
        static string path;
        static string pathLog = @"D:\Backup storage";
        static string filter = "*.txt";

        public Surveillance(string newPath)
        {
            path = newPath;

            FileStream fs = File.Open(pathLog+"\\log.json", FileMode.Open, FileAccess.ReadWrite);
            fs.SetLength(0);
            fs.Close();

            Run();
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void Run()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher(path, filter))
            {
                watcher.IncludeSubdirectories = true;
               
                watcher.NotifyFilter = NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                watcher.Changed += OnChanged;
                watcher.Created += OnCreated;
                watcher.Deleted += OnDeleted;
                watcher.Renamed += OnRenamed;

                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Для выхода введите 'q'.");
                while (Console.Read() != 'q') ;
            }
        }
       
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
            
            fileLog.DateTime = DateTime.UtcNow.ToString();
            fileLog.File = e.FullPath;
            fileLog.Action = "changed";

            Logging();
        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

            fileLog.DateTime = DateTime.UtcNow.ToString();
            fileLog.File = e.FullPath;
            fileLog.Action = "created";

            Logging();
        }

        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

            fileLog.DateTime = DateTime.UtcNow.ToString();
            fileLog.File = e.FullPath;
            fileLog.Action = "deleted";

            Logging();
        }


        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");

            fileLog.DateTime = DateTime.UtcNow.ToString();
            fileLog.File = e.OldFullPath;
            fileLog.Action = $"renamed to {e.FullPath}";

            Logging();
        }

        public static void Logging()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(pathLog);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            StreamWriter sw = new StreamWriter(File.Open(pathLog+"\\log.json", FileMode.Append));

            sw.WriteLine(JsonConvert.SerializeObject(fileLog));
            sw.Close();

            new Backup(path);
        }
    }
}
