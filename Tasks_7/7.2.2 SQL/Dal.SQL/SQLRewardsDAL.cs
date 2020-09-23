using DAL.Common;
using Entitiens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.SQL
{
    public class SQLRewardsDAL : IRewardDAL
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
        public IEnumerable<Rewards> GetAllRewards()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Rewards_AllRewards";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Users user = new Users(reader["Name"] as string, (DateTime)reader["DateOfBirth"]);

                    user.ID = (Guid)reader["IDUser"];
                    user.Age = (int)reader["Age"];

                    List<Awards> listAwards = new List<Awards>();
                    Awards award = new Awards(reader["Title"] as string);
                    award.IDAward = (Guid)reader["IDAward"];
                    listAwards.Add(award);

                    Rewards reward = new Rewards(user, listAwards);

                    yield return reward;
                }
            }
        }

        public List<Users> GetUsersWithCurrentReward(Guid idAward)
        {
            List<Users> listUsers = new List<Users>();
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Rewards_UsersWithAward";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", idAward);
                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Users user = new Users(reader["Name"] as string, (DateTime)reader["DateOfBirth"]);

                    user.ID = (Guid)reader["IDUser"];
                    user.Age = (int)reader["Age"];

                    listUsers.Add(user);

                }
                return listUsers;
            }
        }

        public void SaveRaward(Rewards reward)
        {
            foreach (var item in reward.Award)
            {

                using (SqlConnection _connection = new SqlConnection(_connectionString))
                {
                    var stProc = "Rewards_SaveReward";

                    var command = new SqlCommand(stProc, _connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("@IDUser", reward.User.ID);
                    command.Parameters.AddWithValue("@IDAward", item.IDAward);


                    _connection.Open();
                    command.ExecuteReader();
                }
            }
        }
        public void DeleteAwardReward(Guid IDAward)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Rewards_DeleteAward";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@IDAward", IDAward);

                _connection.Open();
                command.ExecuteReader();
            }
        }
        public void EditAward(Awards newAward)
        {
            //This method is not necessary when working with a database
        }
        public void DeleteReward(Guid idUser, Guid idAward)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Rewards_DeleteReward";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@IDUser", idUser);
                command.Parameters.AddWithValue("@IDAward", idAward);

                _connection.Open();
                command.ExecuteReader();
            }
        }
        public void DeleteUserReward(Guid IDUser)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Rewards_DeleteUser";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@IDUser", IDUser);

                _connection.Open();
                command.ExecuteReader();
            }
        }
    }
}
