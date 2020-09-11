using DAL.Common;
using Entitiens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Json 
{
    public class JsonRewardDAL : IRewardDAL
    {
        public const string LocalDataPath = "D:\\Backup\\Rewarded users\\";
        public const string fileBeginning = "Reward_";
        public const string fileExtension = ".json";

        public void SaveRaward(Users user, Awards award)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (award == null)
                throw new ArgumentNullException(nameof(award));

            DirectoryInfo dirInfo = new DirectoryInfo(LocalDataPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            string fileName = fileBeginning + user.ID + fileExtension;
            string fullFilePath = LocalDataPath + fileName;

            DirectoryInfo dirInfoFile = new DirectoryInfo(fullFilePath);
            var fileStrUser = JsonConvert.SerializeObject(user);
            var fileStrAward = JsonConvert.SerializeObject(award);

            if (!dirInfoFile.Exists)
            {
                
                using (var append = new StreamWriter(fullFilePath, true))
                    append.Write(fileStrAward);
            }
            else
            {
                using (var writer = new StreamWriter(File.Open(fullFilePath, FileMode.Append))) 
                writer.Write(fileStrAward);
               // writer.Write(fileStrAward);

            }
           
        }
    }
}
