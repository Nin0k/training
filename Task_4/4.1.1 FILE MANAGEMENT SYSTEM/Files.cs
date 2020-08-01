using System;
using System.IO;


namespace _4._1._1_FILE_MANAGEMENT_SYSTEM
{
    public class Files
    {
        public string Name { get; set; }
        public string FileContents { get; set; }

        public Files(string name, string fileContents)
        {
            Name = name;
            FileContents = fileContents;
        }
    }
}
