using DAL.Common;
using Entitiens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DAL.Json 
{
    public class JsonRewardDAL : IRewardDAL
    {
        public const string LocalDataPath = "D:\\Backup\\Rewarded users\\";
        public const string fileBeginning = "Reward_";
        public const string fileExtension = ".json";
      
        string addRewardsStr;
        Users rewriteUser;
        public IEnumerable<Rewards> GetAllRewards()
        {
            DirectoryInfo directory = new DirectoryInfo(LocalDataPath + "\\");
            if (!directory.Exists)
            {
                directory.Create();
            }

            foreach (var file in directory.GetFiles())
                using (var reader = new StreamReader(file.FullName))
                {
                    
                   List<Awards> listAwards = new List<Awards>();
                    var allRead = JsonConvert.DeserializeObject<Rewards>(reader.ReadToEnd());
                    foreach (var item in allRead.Award)
                    {
                        listAwards.Add(item);
                    }
                    yield return new Rewards(allRead.User, listAwards);
                }
            
        }
        
        public void SaveRaward(Rewards reward)
        {
            if (reward == null)
                throw new ArgumentNullException(nameof(reward));

            DirectoryInfo dirInfo = new DirectoryInfo(LocalDataPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            string fileName = fileBeginning + reward.User.ID + fileExtension;
            string fullFilePath = LocalDataPath + fileName;

            var userStr = JsonConvert.SerializeObject(reward);
            var rewardStr = JsonConvert.SerializeObject(reward.Award);
            

            if (!File.Exists(fullFilePath))
            {
                using (StreamWriter writer = new StreamWriter(fullFilePath, false))
                {
                    writer.Write(userStr);
                }
            }
            else
            {
                addRewardsStr = Union(fullFilePath, reward.Award);
                using (StreamWriter writer = new StreamWriter(fullFilePath, false))
                {
                    writer.Write(addRewardsStr);
                }
            }
        }

        public string Union(string fullFilePath, List<Awards> awards)
        {
            List<Awards> listAwards = new List<Awards>();
            using (var reader = new StreamReader(fullFilePath))
            {
                var allRead = JsonConvert.DeserializeObject<Rewards>(reader.ReadToEnd());
                foreach (var item in allRead.Award)
                {
                    listAwards.Add(item);
                }
                rewriteUser = allRead.User;
            }
            var unificationList = listAwards.Concat(awards);
            return(JsonConvert.SerializeObject(new Rewards(rewriteUser, unificationList.ToList())));

        }
    }
}
