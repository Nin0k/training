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
    public class JsonAwardsDAL : IAwardDAL
    {
        public const string LocalDataPath = "D:\\Backup\\Awards\\";
        public const string fileBeginning = "Award_";
        public const string fileExtension = ".json";
        public IEnumerable<Awards> GetAllAwards()
        {
            DirectoryInfo directory = new DirectoryInfo(LocalDataPath + "\\");
            if (!directory.Exists)
            {
                directory.Create();
            }

            foreach (var file in directory.GetFiles())
                using (var reader = new StreamReader(file.FullName))
                    yield return JsonConvert.DeserializeObject<Awards>(reader.ReadToEnd());
        }

        public Awards GetAwardByID(Guid id)
        {
            return GetAllAwards().FirstOrDefault(n => n.ID == id);
        }

        public void RemoveAward(Awards award)
        {
            throw new NotImplementedException();
        }

        public void SaveAward(Awards award)
        {
            if (award == null)
                throw new ArgumentNullException(nameof(award));

            DirectoryInfo dirInfo = new DirectoryInfo(LocalDataPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            string userName = fileBeginning + award.ID + fileExtension;
            var userStr = JsonConvert.SerializeObject(award);

            using (var writer = new StreamWriter(LocalDataPath + userName))
                writer.Write(userStr);
        }
    }
}
