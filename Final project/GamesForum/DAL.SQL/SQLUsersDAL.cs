﻿using DAL.Common;
using Entitiens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SQL
{
    public class SQLUsersDAL : IUsersDAL
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
        public User GetUserByID(Guid idUser)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Users_GetById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id", idUser);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    User user = new User(reader["nickname"] as string, (bool)reader["admin"], reader["password"] as string);
                    user.IDUser = idUser;
                    user.DateRegistration = (DateTime)reader["date_registration"];
                    user.Reputation = (int)reader["reputation"];
                    
                    return user;
                }

                throw new InvalidOperationException("Cannot find user with ID = " + idUser);
            }
        }
        public User GetUserByName(string nickname)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Users_GetUserByName";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@nickname", nickname);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    User user = new User(nickname, (bool)reader["admin"], reader["password"] as string);
                    user.IDUser = (Guid)reader["id_user"];
                    user.DateRegistration = (DateTime)reader["date_registration"];
                    user.Reputation = (int)reader["reputation"];

                    return user;
                }

                throw new InvalidOperationException("Cannot find user with nickname = " + nickname);
            }
        }

        public IEnumerable<User> GetAllUsers() 
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
                    
                    User users = new User(reader["nickname"] as string, (bool)reader["admin"], reader["password"] as string);

                    users.IDUser = (Guid)reader["id_user"];
                    users.Reputation = (int)reader["reputation"];
                    users.DateRegistration = (DateTime)reader["date_registration"];

                    yield return users;
                }
            }
        }
        public void RegistrationUser(User user)
        {

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Users_RegistrationUser";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id_user", user.IDUser);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@admin", user.Admin);
                command.Parameters.AddWithValue("@nickname", user.Nickname);
                command.Parameters.AddWithValue("@data", user.DateRegistration);
                command.Parameters.AddWithValue("@reputation", user.Reputation);
                
                _connection.Open();
                command.ExecuteReader();
                
            }
        }

        public bool CheckForExistence(string nickname)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Users_GetByName";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@nickname", nickname);

                _connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    if ((reader["nickname"] as string) == nickname)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        public string[] GetRolesForUser(string username)
        {
            string[] role = new string[] { "no role" };
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Users_GetRolesForUser";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@nickname", username);

                _connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    bool isAdmin = (bool)reader["Admin"];
                    if (isAdmin == true)
                    {
                        role[0] = "Admin";
                    }
                    else if (isAdmin == false)
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
                var stProc = "Users_GetPassword";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@nickname", name);

                _connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    password = reader["password"] as string;
                }

                return password;
            }
        }
        public void EditUser(User user)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "User_UpdateUser";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id_user", user.IDUser);
                command.Parameters.AddWithValue("@reputation", user.Reputation);
                command.Parameters.AddWithValue("@admin", user.Admin);

                _connection.Open();
                command.ExecuteReader();
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

    }
}
