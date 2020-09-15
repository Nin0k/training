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
    public class JsonUsersDAL : IUserDAL
    {
        public const string LocalDataPath = "D:\\Backup\\Users\\";
        public const string fileBeginning = "User_";
        public const string fileExtension = ".json";

        public IEnumerable<Users> GetAllUsers()
        {
            //TODO
            DirectoryInfo directory = new DirectoryInfo(LocalDataPath + "\\");
            if (!directory.Exists)
            {
                directory.Create();
            }
           
            foreach (var file in directory.GetFiles())
                using (var reader = new StreamReader(file.FullName))
                    yield return JsonConvert.DeserializeObject<Users>(reader.ReadToEnd());
        }

        public Users GetUserByID(Guid id)
        {
            return GetAllUsers().FirstOrDefault(n => n.ID == id);
        }

        public void DeleteUser(Guid id)
        {
            string userName = LocalDataPath + fileBeginning + id + fileExtension;
            File.Delete(userName);
        }



        public void SaveUser(Users user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            DirectoryInfo dirInfo = new DirectoryInfo(LocalDataPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            string userName = fileBeginning + user.ID + fileExtension;
            var userStr = JsonConvert.SerializeObject(user);

            using (var writer = new StreamWriter(LocalDataPath + userName))
                writer.Write(userStr);
        }
    }
}
