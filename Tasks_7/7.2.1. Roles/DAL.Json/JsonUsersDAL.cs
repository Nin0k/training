using DAL.Common;
using Entitiens;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DAL.Json
{
    public class JsonUsersDAL : IUserDAL
    {
        public const string LocalDataPath = "D:\\Backup\\Users\\";
        public const string fileBeginning = "User_";
        public const string fileExtension = ".json";

        public const string RoleDataPath = "D:\\Backup\\Role\\";
        public const string catalogUser = "User\\";
        public const string catalogAdmin = "Admin\\";
        public IEnumerable<Users> GetAllUsers()
        {
            DirectoryInfo directory = new DirectoryInfo(LocalDataPath);
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

            using (var writer = new StreamWriter(LocalDataPath + userName, false))
                writer.Write(userStr);
        }

        //RegisteredUser
        public void RegistrationUser(string login, string password, bool admin)
        {
            
            string fileName;

            DirectoryInfo dirInfo = new DirectoryInfo(RoleDataPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            if (admin)
            {
                fileName = RoleDataPath + catalogAdmin + login + fileExtension;
                DirectoryInfo dirictore= new DirectoryInfo(RoleDataPath + catalogAdmin);
                if (!dirictore.Exists)
                {
                    dirictore.Create();
                }
            }
            else
            {
                fileName = RoleDataPath + catalogUser + login + fileExtension;
                DirectoryInfo dirictore = new DirectoryInfo(RoleDataPath + catalogUser);
                if (!dirictore.Exists)
                {
                    dirictore.Create();
                }
            }

           if(!File.Exists(fileName))
            {
                using (var writer = new StreamWriter(fileName))
                    writer.Write(password);
            }
        }

        public bool CheckForExistence(string name)
        {
           // string nameDirectory = false;
            DirectoryInfo dirInfo = new DirectoryInfo(RoleDataPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            FileInfo[] allFiles = dirInfo.GetFiles("*", SearchOption.AllDirectories);
            foreach (var file in allFiles)
            {
                int position = file.Name.IndexOf(".");
                string nameUser = file.Name.Substring(0, position);
                if (nameUser == name)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetPassword(string name)
        {
            string password = "0";
            DirectoryInfo dirInfo = new DirectoryInfo(RoleDataPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            FileInfo[] allFiles = dirInfo.GetFiles("*", SearchOption.AllDirectories);
            foreach (var file in allFiles)
            {
                int position = file.Name.IndexOf(".");
                string nameUser = file.Name.Substring(0, position);
                if (nameUser == name)
                {
                    using (var reader = new StreamReader(file.FullName))
                    {
                        password = reader.ReadToEnd();
                        return password;
                    }
                }
            }
            return password;
                    
        }
        public string[] GetRolesForUser(string username)
        {
            string[] nameRole = new string[] { "no role" };
            DirectoryInfo dirInfo = new DirectoryInfo(RoleDataPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            FileInfo[] allFiles = dirInfo.GetFiles("*", SearchOption.AllDirectories);
            foreach (var file in allFiles)
            {
                int position = file.Name.IndexOf(".");
                string nameUser = file.Name.Substring(0, position);
                if (nameUser == username)
                {
                    int positionSymbol = file.DirectoryName.LastIndexOf('\\') + 1;
                    nameRole[0] = file.DirectoryName.Substring(positionSymbol, file.DirectoryName.Length- positionSymbol);
                    
                    return nameRole;
                }
            }
            return nameRole;
        }
        public bool IsUserInRole(string username, string roleName)
        {
            string[] allRole = GetRolesForUser(username);
            foreach (var item in allRole)
            {
                if(item == roleName)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
