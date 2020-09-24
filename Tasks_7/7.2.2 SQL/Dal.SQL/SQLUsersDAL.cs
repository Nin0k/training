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
   public class SQLUsersDAL : IUserDAL
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;

       // private SqlConnection _connection = new SqlConnection(_connectionString);
        public IEnumerable<Users> GetAllUsers()
        {
           
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Users_GetAllUsers";

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

                    yield return user;
                }
            }
        }
        public Users GetUserByID(Guid id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Users_GetById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Users user = new Users(reader["Name"] as string, (DateTime)reader["DateOfBirth"]);
                    user.ID = (Guid)reader["IDUser"];
                    user.Age = (int)reader["Age"];

                    return user;
                }

                throw new InvalidOperationException("Cannot find Student with ID = " + id);
            }
        }
        public void DeleteUser(Guid id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Users_DeleteUser";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();
                command.ExecuteReader();
            }
        }
        public void SaveUser(Users user)//TODO
        {
            IEnumerable<Users> allUsers = GetAllUsers();
            
            if (allUsers.Any(p => p.ID == user.ID))
            {
                using (SqlConnection _connection = new SqlConnection(_connectionString))
                {
                    var stProc = "Users_UpdateUsers";

                    var command = new SqlCommand(stProc, _connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("@ID", user.ID);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    command.Parameters.AddWithValue("@Age", user.Age);
                   
                    _connection.Open();
                    command.ExecuteReader();
                }

            }
            else
            {

            using (SqlConnection _connection = new SqlConnection(_connectionString))
                {
                    var stProc = "Users_SaveUser";

                    var command = new SqlCommand(stProc, _connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("@ID", user.ID);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    command.Parameters.AddWithValue("@Age", user.Age);

                    _connection.Open();
                    command.ExecuteReader();
                }
            }
           
        }

        public void RegistrationUser(string login, string password, bool admin)
        {
            
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "RegisteredUsers_RegistrationUser";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Name", login);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Admin", admin);

                _connection.Open();
                command.ExecuteReader();
            }
        }

        public bool CheckForExistence(string name)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "RegisteredUsers_GetByName";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Name", name);

                _connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    if ((reader["Name"] as string) == name)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        public string[] GetRolesForUser(string username)
        {
            string[] role = new string[] {"no role"};
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "RegisteredUsers_GetRolesForUser";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Name", username);

                _connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    bool isAdmin = (bool)reader["Admin"];
                    if (isAdmin == true)
                    {
                        role[0] = "Admin";
                    }
                    else if(isAdmin == false)
                    {
                        role[0] = "User";
                    }
                   
                }

                return role;
            }
        }
        public bool IsUserInRole(string username, string roleName)
        {
            string[] role = GetRolesForUser(username);

            foreach (var item in role)
            {
                if (item == roleName)
                {
                    return true;
                }
            }
            return false;
        }
       
        public string GetPassword(string name)
        {
            string password = "0";
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "RegisteredUsers_GetPassword";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Name", name);

                _connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                   password = reader["Password"] as string;
                }

                return password;
            }
        }
    }
}
